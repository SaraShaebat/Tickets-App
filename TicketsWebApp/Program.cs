using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayerSchool.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("TicketsWebAppPresentationLayer")));


// Register Services
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IPriorityService, PriorityService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ITicketTypeService, TicketTypeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserTicketService, UserTicketService>();

// Register Managers
builder.Services.AddScoped<ICommentManager, CommentManager>();
builder.Services.AddScoped<ICompanyManager, CompanyManager>();
builder.Services.AddScoped<IPriorityManager, PriorityManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IStatusManager, StatusManager>();
builder.Services.AddScoped<ITicketManager, TicketManager>();
builder.Services.AddScoped<ITicketTypeManager, TicketTypeManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserTicketManager, UserTicketManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();