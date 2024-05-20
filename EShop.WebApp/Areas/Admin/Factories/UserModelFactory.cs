using AutoMapper;
using Azure.Core;
using EShop.Areas.Admin.Models.UserModels;
using EShop.Entities.Domain;
using EShop.Entities.Enums;
using EShop.Framework.Models.Extensions;
using EShop.Services;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace EShop.Areas.Admin.Factories
{
    public class UserModelFactory : IUserModelFactory
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IPictureService _pictureService;
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _roleUserMappingService;

        public UserModelFactory(IUserService userService, IMapper mapper, IPictureService pictureService, IRoleService roleService, IUserRoleService roleUserMappingService)
        {
            _userService = userService;
            _mapper = mapper;
            _pictureService = pictureService;
            _roleService = roleService;
            _roleUserMappingService = roleUserMappingService;
        }

        public async Task<IList<SelectListItem>>  GetUserRoles(string userId)
        {
            var userRoles = await _roleUserMappingService.GetUserRole(userId);
            var result = new List<SelectListItem>();
            //result.Add(new SelectListItem
            //{
            //    Text = "Select",
            //    Value = 0.ToString(),
            //    Selected = true
            //});
            foreach(var item in userRoles)
            {
                result.Add(new SelectListItem
                {
                    Value = item.RoleId,
                    Text = (await _roleService.GetRole(item.RoleId)).Name
                });

            }
            return result;
        }
        #region Utilities
        public async Task<IList<SelectListItem>> GetAvailableRoles()
        {
            var userRoles = await _roleService.GetAllUserRoles();
            var result = new List<SelectListItem>();
            result.Add(new SelectListItem
            {
                Text = "Select",
                Value = 0.ToString(),
                Selected = true
            });
            foreach (var item in userRoles)
            {
                result.Add(new SelectListItem
                {
                    Value = item.RoleId.ToString(),
                    Text = (await _roleService.GetUserRoleByRoleId(item.RoleId)).Name
                });

            }
            return result;
        }
        #region Factories
        public virtual async Task<UserListModel> PrepareListModelAsync(UserSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            var users = (await _userService.GetAllUsers()).ToPagedList(searchModel);
            //prepare list model to the grid
            var model = await new UserListModel().PrepareToGridAsync(searchModel, users, () =>
            {

                return users.SelectAwait(async user =>
                {

                    //fill in model values from the entity
                    var userModel = _mapper.Map<UserModel>(user);
                    userModel.Roles = await GetUserRoles(user.Id);
                    userModel.AvailableRoles = await GetAvailableRoles();


                    return userModel;
                });
            });
            return model;
        }


        #endregion


        public virtual async Task<UserModel> PrepareUserModelAsync(UserModel? model, User? user)
        {
            if(user is not null)
            {
                if(model is null)
                {
                    var _model = new UserModel();
                    _model = _mapper.Map<UserModel>(user);
                    if(user.Gender is not null)
                    {
                    _model.GenderId = user.Gender.Equals(Gender.Male.ToString())?1: user.Gender.Equals(Gender.Female.ToString())?2: 0;
                    }
                    else
                    {
                        _model.GenderId = 0;
                    }
                    if (user.PictureId > 0)
                    {
                        var picture = await _pictureService.GetPicture(_model.PictureId);
                        string base64String = Convert.ToBase64String(picture.Bytes, 0, (int)picture.Size);
                        _model.PictureUrl= "data:Image/png;base64," + base64String;
                    }

                    _model.Roles = await GetUserRoles(user.Id);
                    _model.RoleIds = new List<int>();
                    _model.RoleIds.AddRange(_model.Roles.Select(a => int.Parse(a.Value)));
                    _model.AvailableRoles = await GetAvailableRoles();
                    return _model;
                }
                model = _mapper.Map<UserModel>(user);
                return model;
            }
            if(model is null)
            {
                var _model = new UserModel();
                _model.RoleIds = new List<int>();
                _model.AvailableRoles = await GetAvailableRoles();
                return _model;
            }
            model.RoleIds = new List<int>();
            model.AvailableRoles = await GetAvailableRoles();
            return model;
        }

        public virtual async Task<UserSearchModel> PrepareSearchModelAsync(UserSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));


            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;

        }
        #endregion
    }
}
