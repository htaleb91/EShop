using EShop.Areas.Admin.Factories;
using EShop.Areas.Admin.Models.UserModels;
using EShop.Data;
using EShop.Entities.Domain;
using EShop.Infrastructure.AutoMapper;
using EShop.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);

// define resources folder for localization 
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddRazorPages()
     .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
                new CultureInfo("en"),
                new CultureInfo("tr"),
                new CultureInfo("ar")
            };

    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders.Insert(0, new RouteDataRequestCultureProvider());
});
    
//var supportedCultures = new[]
//          {
//                new CultureInfo("en"),
//                new CultureInfo("tr"),
//                new CultureInfo("ar-sy"),
//            };


//var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
//    .AddSupportedCultures(supportedCultures)
//    .AddSupportedUICultures(supportedCultures);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    //options.Password.RequireDigit = true;
    //options.Password.RequireLowercase = true;
    //options.Password.RequireNonAlphanumeric = true;
    //options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    //options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});
builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();



#region Services Dependecy Injection


builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<IDiscountsAppliedToBrandService, DiscountsAppliedToBrandService>();
builder.Services.AddScoped<IDiscountsAppliedToCategoryService, DiscountsAppliedToCategoryService>();
builder.Services.AddScoped<IDiscountsAppliedToProductService, DiscountsAppliedToProductService>();
builder.Services.AddScoped<IDiscountUsageHistoryService, DiscountUsageHistoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IOrderNoteService, OrderNoteService>();
builder.Services.AddScoped<IPermissionRecordService, PermissionRecordService>();
builder.Services.AddScoped<IPermissionRecordRoleMappingService, PermissionRecordRoleMappingService>();
builder.Services.AddScoped<IPictureService, PictureService>();
builder.Services.AddScoped<IProductCategoryMappingService, ProductCategoryMappingService>();
builder.Services.AddScoped<IProductPictureMappingService, ProductPictureMappingService>();
builder.Services.AddScoped<IProductProductTagMappingService, ProductProductTagMappingService>();
builder.Services.AddScoped<IProductReviewService, ProductReviewService>();
builder.Services.AddScoped<IProductTagService, ProductTagService>();
builder.Services.AddScoped<IShipmentService, ShipmentService>();
builder.Services.AddScoped<IShipmentItemService, ShipmentItemService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();


// inject factories
builder.Services.AddScoped<IUserModelFactory, UserModelFactory>();

//Inject Mappers to dependency contatiner
//AppMapperConfigrations.AddMappers(builder.Services);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//builder.Services.AddAutoMapper(
//        GetType().Assembly,
//        typeof(EShop.Infrastructure.AutoMapper.AppMapperConfigrations)
//);
#endregion
//localization



var app = builder.Build();
var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(localizationOptions);


// Find a suitable location for seeding, such as Program.cs or a custom service.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var dbContext = services.GetRequiredService<ApplicationDbContext>();
        var userManager = services.GetRequiredService<UserManager<User>>();
        //var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        // Seed data here
        //await SeedData.InitializeAsync(services);
    }
    catch (Exception ex)
    {
        // Handle exceptions
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapRazorPages();

app.Run();
