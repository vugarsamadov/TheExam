using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Exam.Business.Models.Chef;
using Exam.Business.Services.Abstract;
using Exam.Infrastructure.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace Exam.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class ChefsController : Controller
    {
        private const string BasePaginationUrl = "/Admin/Chefs/PaginatedChefs?page={0}&perpage={1}";

        private IChefService _chefService { get; }
        public ISocialMediaService _socialMediaService { get; }
        private IMapper _mapper { get; }

        public ChefsController(IChefService chefService,ISocialMediaService socialMediaService,IMapper mapper)
        {
            _chefService = chefService;
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var page = 1;
            var perPage = 3;

            var model = await _chefService.GetPaginatedChefsAsync(page,perPage,BasePaginationUrl);


            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> PaginatedChefs(int page, int perPage)
        {
            var model = await _chefService.GetPaginatedChefsAsync(page,perPage,BasePaginationUrl);

            return PartialView("_PartialChefsPaginatedModel",model);        
        }
        
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.SocialMedias = await _socialMediaService.GetAllAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChefCreateVM model)
        {
            if (!ModelState.IsValid)
            { 
                ViewBag.SocialMedias = await _socialMediaService.GetAllAsync();
                return View(model);
            }

            await _chefService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.SocialMedias = await _socialMediaService.GetAllAsync();
            var model = await _chefService.GetByIdAsync(id);
            var umodel = _mapper.Map<ChefUpdateVM>(model);
            return View(umodel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id,ChefUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.SocialMedias = await _socialMediaService.GetAllAsync();
                return View(model);
            }
            
            await _chefService.UpdateAsync(id, model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _chefService.SoftDelete(id);
            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public async Task<IActionResult> RevokeDelete(int id)
        {
            await _chefService.RevokeSoftDelete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
