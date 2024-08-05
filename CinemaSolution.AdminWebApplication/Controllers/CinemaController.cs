using CinemaSolution.AdminWebApplication.Filters;
using CinemaSolution.Application.Cinema;
using CinemaSolution.Application.Province;
using CinemaSolution.ViewModels.Cinema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.AdminWebApplication.Controllers
{
    [Route("cinemas")]
    [Authorize(Roles = "Administrator")]
    [SetBarActive("cinema")]
    public class CinemaController : Controller
    {
        private readonly ICinemaService _cinemaService;
        private readonly IProvinceService _provinceService;
        public CinemaController(ICinemaService cinemaService, IProvinceService provinceService)
        {
            _cinemaService = cinemaService;
            _provinceService = provinceService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(int PageIndex = 1, int PageSize = 5, string Keyword = "", int? ProvinceId = null)
        {
            var request = new GetCinemaPagingRequest()
            {
                Keyword = Keyword,
                PageIndex = PageIndex,
                PageSize = PageSize,
                ProvinceId = ProvinceId
            };
            var cinema = await _cinemaService.GetPagedResult(request);
            var provinces = await _provinceService.GetAll();
            ViewBag.Provinces = provinces;
            if (ProvinceId != null)
            {
                var province = provinces.FirstOrDefault(x => x.Id == ProvinceId);
                if (province != null)
                {
                    ViewBag.ProvinceId = province.Id;
                    ViewBag.ProvinceName = province.Name;
                }
            } else
            {
                ViewBag.ProvinceId = null;
                ViewBag.ProvinceName = "All";
            }
            if (!string.IsNullOrEmpty(Keyword))
            {
                ViewBag.Keyword = Keyword;
            }
            return View(cinema);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            var provinces = await _provinceService.GetAll();
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CinemaCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                var provinces = await _provinceService.GetAll();
                ViewBag.Provinces = provinces;
                return View(request);
            }
            try
            {
                var result = await _cinemaService.Create(request);
                return RedirectToAction("Index");
            } catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(request);
            }
        }

        [HttpGet("{id}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var cinema = await _cinemaService.GetById(id);
            return View(new CinemaUpdateRequest()
            {
                Id = id,
                Name = cinema.Name,
                LogoUrl = cinema.LogoUrl,
            });
        }

        [HttpPost("{id}/update")]
        public async Task<IActionResult> Update(CinemaUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                var provinces = await _provinceService.GetAll();
                ViewBag.Provinces = provinces;
                return View(request);
            }
            try
            {
                var result = await _cinemaService.Update(request);
                return RedirectToAction("Index");
            } catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(request);
            }
        }

        [HttpPost("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cinemaService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
