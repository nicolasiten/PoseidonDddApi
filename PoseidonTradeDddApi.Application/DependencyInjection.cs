using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PoseidonTradeDddApi.Application.Common.Behaviours;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PoseidonTradeDddApi.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
