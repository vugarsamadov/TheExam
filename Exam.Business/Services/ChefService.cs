using AutoMapper;
using Exam.Business.Models;
using Exam.Business.Models.Chef;
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
    public class ChefService : IChefService
    {
        private IChefRepository _chefRepository { get; }
        private IMapper _mapper { get; }

        public ChefService(IChefRepository chefRepository,IMapper mapper)
        {
            _chefRepository = chefRepository;
            _mapper = mapper;
        }

        public async Task<ChefVM> GetByIdAsync(int id)
        {
            var entity = await _chefRepository.GetByIdAsync(id,false);
            var model = _mapper.Map<ChefVM>(entity);
            return model;
        }

        public async Task CreateAsync(ChefCreateVM model)
        {
            var entity = _mapper.Map<Chef>(model);
            await _chefRepository.CreateAsync(entity);
            await _chefRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, ChefUpdateVM model)
        {
            var entity = await _chefRepository.GetByIdAsync(id, true);
            if (entity != null)
                _mapper.Map(model,entity);
            await _chefRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ChefVM>> GetTalantedChefs()
        {
            var entities = await _chefRepository.GetLastNAsync(3);
            var models = _mapper.Map<IEnumerable<ChefVM>>(entities);
            return models;
        }

        public async Task SoftDelete(int id)
        {
            var entity = await _chefRepository.GetByIdAsync(id, true);
            if (entity != null)
                entity.Delete();
            await _chefRepository.SaveChangesAsync();
        }

        public async Task RevokeSoftDelete(int id)
        {
            var entity = await _chefRepository.GetByIdAsync(id, true);
            if (entity != null)
                entity.RevokeDelete();
            await _chefRepository.SaveChangesAsync();
        }

        public async Task<GenericPaginatedModel<IEnumerable<ChefVM>>> GetPaginatedChefsAsync(int currentPage, int perPage,string baseUrl)
        {
            var entities = await _chefRepository.GetPaginatedEntities(currentPage,perPage,true);
            var count = await _chefRepository.GetCountAsync();
            var models = _mapper.Map<IEnumerable<ChefVM>>(entities);
            var pmodel = new GenericPaginatedModel<IEnumerable<ChefVM>>(models,currentPage,count,perPage,baseUrl);
            return pmodel;
        }
    }
}
