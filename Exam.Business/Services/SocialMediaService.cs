using AutoMapper;
using Exam.Business.Models.SocialMedia;
using Exam.Business.Services.Abstract;
using Exam.Core.Entities;
using Exam.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Services
{
    public class SocialMediaService : ISocialMediaService
    {
        public SocialMediaService(IGenericRepository<SocialMedia> socialMediaRepository,IMapper mapper)
        {
            _socialMediaRepository = socialMediaRepository;
            _mapper = mapper;
        }

        private IGenericRepository<SocialMedia> _socialMediaRepository { get; }
        private IMapper _mapper { get; }

        public async Task<IEnumerable<SocialMediaVM>> GetAllAsync()
        {
            var entities = await _socialMediaRepository.GetAllAsync();
            var models = _mapper.Map<IEnumerable<SocialMediaVM>>(entities);
            return models;
        }
    }
}
