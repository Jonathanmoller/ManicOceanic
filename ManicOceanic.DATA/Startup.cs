﻿using ManicOceanic.DATA.Data;
using ManicOceanic.DATA.Data.Repositories;
using ManicOceanic.DOMAIN.Entities;
using ManicOceanic.DOMAIN.Repositories.Interfaces;
using ManicOceanic.DOMAIN.Services;
using ManicOceanic.DOMAIN.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManicOceanic.DATA
{
  public class Startup
  {
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<MOContext>(options =>
      options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddDefaultIdentity<Customer>()
        .AddDefaultUI(UIFramework.Bootstrap4)
        .AddEntityFrameworkStores<MOContext>();

      services.AddScoped<IOrderService, OrderService>();
      services.AddScoped<IProductService, ProductService>();
      services.AddScoped<ICustomerService, CustomerService>();
      services.AddScoped<ICategoryService, CategoryService>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped<ICategoryRepository, CategoryRepository>();
      services.AddScoped<IProductRepository, ProductRepository>();
      services.AddScoped<ICustomerRepository, CustomerRepository>();
      services.AddScoped<IOrderRepository, OrderRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Hello World!");
      });
    }
  }
}