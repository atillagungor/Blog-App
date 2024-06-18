﻿using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;
public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {

#if _WINDOWS
        services.AddDbContext<TobetoPlatformContext>(options => options.UseSqlServer(configuration.GetConnectionString("TobetoPlatform")));
#else
        services.AddDbContext<BlogContext>(options => options.UseSqlServer(configuration.GetConnectionString("BlogDb")));
#endif

        services.AddScoped<IUserDal, EfUserDal>();
        services.AddScoped<IPostDal, EfPostDal>();
        services.AddScoped<ILikeDal, EfLikeDal>();
        services.AddScoped<ICategoryDal, EfCategoryDal>();
        services.AddScoped<IOperationClaimDal, EfOperationClaimDal>();
        services.AddScoped<IUserOperationClaimDal, EfUserOperationClaimDal>();

        return services;
    }
}