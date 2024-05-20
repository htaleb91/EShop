using AutoMapper;
using EShop.Areas.Admin.Factories;
using EShop.Areas.Admin.Models.UserModels;
using EShop.Entities.Domain;
using EShop.Framework.Extensions;
using EShop.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Linq.Expressions;
using System.Net;

namespace EShop.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserModelFactory _userModelFactory;
        private readonly IPictureService _pictureService;
        private readonly IMapper _mapper;
        private readonly IUserRoleService _userRoleService;
        private readonly IRoleService _roleService;
        public UserController(IUserService userService, IUserModelFactory userModelFactory, IPictureService pictureService, IMapper mapper, IUserRoleService userRoleService, IRoleService roleService)
        {
            _userService = userService;
            _userModelFactory = userModelFactory;
            _pictureService = pictureService;
            _mapper = mapper;
            _userRoleService = userRoleService;
            _roleService = roleService;
        }
        // GET: UserController
        public async Task<ActionResult> Index()
        {
            var model =await _userModelFactory.PrepareSearchModelAsync(new UserSearchModel() );

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> ListAsync(UserSearchModel searchModel)
        {
            
            var model =await _userModelFactory.PrepareListModelAsync(searchModel);
            return Json(model);
        }


        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: UserController/Create
        public async Task<ActionResult> Create()
        {
            var model =await _userModelFactory.PrepareUserModelAsync(null, null);
            return View(model);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserModel model)
        {
            try
            {
            if (model is null)
                throw new ArgumentNullException(nameof(UserModel));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
           User user = new User();
           
                user = _mapper.Map<User>(model);
                var pictureID = await ProcessPictureUpload(model.PictureFile);
                user.PictureId = pictureID;

                _userService.InsertUser(user);


            return RedirectToAction(nameof(Edit), new { id = user.Id });

        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
                return RedirectToAction(nameof(Index));
            var model = await _userModelFactory.PrepareUserModelAsync(null,user);

            return View(model);
        }

        // POST: UserController/Edit/5
        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [ValidateAntiForgeryToken]
        
        public async Task<ActionResult> Edit(UserModel model,bool continueEditing)
        {

            try
            {
                if (model is null)
                    throw new ArgumentNullException(nameof(UserModel));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }

            var user = await _userService.GetUser(model.UserId);
            if (user is null)
                return RedirectToAction(nameof(Index));

            //update User
            var _user = new User();
             _user = _mapper.Map<User>(model);
            _user.PasswordHash = user.PasswordHash;
            await _userService.UpdateUser(_user);


            //update profile picture
            if(model.PictureFile is not null)
            {
                var pic = await _pictureService.GetPicture(user.PictureId);
                await _pictureService.DeletePicture(pic);
                var pictureID = await ProcessPictureUpload(model.PictureFile);
                _user.PictureId = pictureID;
                await _userService.UpdateUser(_user);

            }

            // update roles
            // var oldRoles = (await _userModelFactory.GetUserRoles(user.Id)).Select(a => int.Parse(a.Value)).ToList();
            //var newRoles = model.RoleIds;
            model.RoleIds.Remove(model.RoleIds.Where(a => a==0).FirstOrDefault());
                var oldRolesMapps = await _userRoleService.GetUserRole(user.Id);
                foreach(var map in oldRolesMapps)
                {
                    await _userRoleService.DeleteUserRole(map);
                }
                foreach(var newRoleId in model.RoleIds)
                {
                    await _userRoleService.InsertUserRole(new IdentityUserRole<string>()
                    {
                        UserId = user.Id,
                        RoleId = (await _roleService.GetUserRoleByRoleId(newRoleId)).Id
                    });
                }
            

            return RedirectToAction(nameof(Edit), new { id = model.Id });
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
                var user = await _userService.GetUser(id);
            if (user is not null)
            {
                var roles = await _userRoleService.GetUserRole(user.Id);
                
                foreach (var role in roles)
                {
                    await _userRoleService.DeleteUserRole(role);
                }
                
                await _userService.DeleteUser(id);
            }
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteSelected(IList<int> selectedIds)
        {
            if (selectedIds == null || selectedIds.Count == 0)
                return NoContent();
           
                foreach(var id in selectedIds)
                {
                    await Delete(id);
                }
               
            

            return Json(new { Result = true });
        }

        public async Task<int> ProcessPictureUpload(IFormFile file)
        {
            string fileName = file.FileName;
            string fileExtenstion = Path.GetExtension(fileName);
            string newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtenstion);
            var fileSize = file.Length;
            if (fileSize < 2097152)
            {

                var picture = new Picture
                {
                    FileExtension = fileExtenstion,
                    Size = fileSize,
                    Description = newFileName

                };
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    picture.Bytes = stream.ToArray();
                }

                await _pictureService.InsertPicture(picture);
                return picture.Id;
            }
            return 0;
        }

        [HttpGet]
        public async Task<string> GetUserImageFile(int pictureId)
        {
           
            var picture = await _pictureService.GetPicture(pictureId);
            string base64String = Convert.ToBase64String(picture.Bytes, 0,(int) picture.Size);
            return "data:Image/png;base64," + base64String;
            
        }
        public async Task<IActionResult> ChangePassword(int userId,string password)
        {
            if(userId <= 0 || string.IsNullOrEmpty(password))
            {
                new JsonResult(new { error = "Something went wrong" })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
            var pwHasher = new PasswordHasher<User>();
            var user = await _userService.GetUser(userId);
            user.PasswordHash = pwHasher.HashPassword(user, password);
            
            await _userService.UpdateUser(user);
            return Ok();
        }
        

        
    }
}
