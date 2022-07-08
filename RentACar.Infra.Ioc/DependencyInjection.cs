using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Application.Interfaces;
using RentACar.Application.Mappings;
using RentACar.Application.Services;
using RentACar.Domain.Account;
using RentACar.Domain.Interfaces;
using RentACar.Infra.Data.Context;
using RentACar.Infra.Data.Identity;
using RentACar.Infra.Data.Repositories;
using System;

namespace RentACar.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(option =>
                option.AccessDeniedPath = "/Account/Login");


            #region Repositories
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
            #endregion

            #region EntityServices
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IProprietarioService, ProprietarioService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            #endregion

            #region AuthenticationServices
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            #endregion

            var myhandlers = AppDomain.CurrentDomain.Load("RentACar.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}
