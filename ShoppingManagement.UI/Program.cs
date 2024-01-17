using Microsoft.EntityFrameworkCore;
using ShoppingManagement.Application;
using ShoppingManagement.Infrastructure;
using ShoppingManagement.UI.Automapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region "DB Configuration"
builder.Services.AddInfrastructureServices(builder.Configuration);
//builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"),
//    b => b.MigrationsAssembly("ShoppingManagement.UI")));  //Must add this MigrationAssembly, otherwise add-migration will throw error
#endregion

#region "Dependent Services"
builder.Services.AddApplicationServices();
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
////builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();           
//builder.Services.AddScoped<ICustomerService, CustomerService>();

//builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
//builder.Services.AddScoped<IInventoryService, InventoryService>();

//builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//builder.Services.AddScoped<IOrderService, OrderService>();
#endregion

#region "Automapper Configuration"
builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());  //this also works
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
