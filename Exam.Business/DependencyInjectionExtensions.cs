using Exam.Business.MappingConfigs;
using Exam.Business.Services;
using Exam.Business.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business
{
    public static class DependencyInjectionExtensions
    {

        public static IServiceCollection AddBusiness(this IServiceCollection services,IWebHostEnvironment env)
        {

            services.AddAutoMapper(opt=>
            opt.AddProfile(new ChefProfile(env)));

            services.AddScoped<IChefService, ChefService>();
            services.AddScoped<ISocialMediaService, SocialMediaService>();

            return services;
        }

    }
}
