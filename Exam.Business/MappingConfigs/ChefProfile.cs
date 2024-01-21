using AutoMapper;
using Exam.Business.Models.Chef;
using Exam.Business.Models.SocialMedia;
using Exam.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.MappingConfigs
{
    public class ChefProfile : Profile
    {
        public ChefProfile(IWebHostEnvironment env)
        {
            CreateMap<ChefCreateVM, Chef>()
                .ForMember(c => c.ProfileImageUrl, opt => opt.Ignore())
                .AfterMap(async (src, dest) =>
                {
                    if(src.ProfileImage != null)
                       dest.ProfileImageUrl = await src.ProfileImage.SaveAndProvideUrlAsync(env,FileExtensions.ChefImagesPath);
                });

            CreateMap<ChefUpdateVM, Chef>()
                .ForMember(c => c.ProfileImageUrl, opt => opt.Ignore())
                .AfterMap(async (src, dest) =>
                {
                    if (src.ProfileImage != null)
                        dest.ProfileImageUrl = await src.ProfileImage.SaveAndProvideUrlAsync(env, FileExtensions.ChefImagesPath);
                });

            CreateMap<ChefVM, ChefUpdateVM>();

            CreateMap<Chef, ChefVM>();


            CreateMap<AddChefSocialMediaVM, ChefSocialMedia>();


            CreateMap<SocialMedia, SocialMediaVM>();

        }
    }
}
