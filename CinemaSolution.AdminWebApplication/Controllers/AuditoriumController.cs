using Azure.Core;
using CinemaSolution.AdminWebApplication.Filters;
using CinemaSolution.Application.Auditorium;
using CinemaSolution.Application.Cinema;
using CinemaSolution.Application.Province;
using CinemaSolution.Data.Entities;
using CinemaSolution.ViewModels.Auditorium;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.AdminWebApplication.Controllers
{
    [Route("auditoriums")]
    [Authorize(Roles = "Administrator")]
    [SetBarActive("auditorium")]
    public class AuditoriumController : Controller
    {
        private readonly IAuditoriumService _auditoriumService;
        private readonly ICinemaService _cinemaService;
        private readonly IProvinceService _provinceService;

        public AuditoriumController(IAuditoriumService auditoriumService, ICinemaService cinemaService, IProvinceService provinceService)
        {
            _auditoriumService = auditoriumService;
            _cinemaService = cinemaService;
            _provinceService = provinceService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(int? cinemaId, int? provinceId, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetAuditoriumPagingRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                CinemaId = cinemaId,
                ProvinceId = provinceId
            };
            var auditoriums = await _auditoriumService.GetPagedResult(request);
            ViewBag.CinemaId = cinemaId;
            return View(auditoriums);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create(int cinemaId)
        {
            List<SeatDefaultViewModel> seats = new List<SeatDefaultViewModel>();
            for (int i = 1; i <= 12; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    seats.Add(new SeatDefaultViewModel
                    {
                        Row = i,
                        Column = j,
                        TypeId = 1
                    });
                }
            }

            var provinces = await _provinceService.GetAll();
            ViewBag.Provinces = provinces;

            var cinemas = await _cinemaService.GetAll();
            ViewBag.Cinemas = cinemas;

            return View(new AuditoriumCreateRequest { 
                CinemaId = cinemaId,
                SeatsPerColumn = 12,
                SeatsPerRow = 12,
                Seats = seats,
            });
        }

        [HttpPost("createMap")]
        public IActionResult CreateMap(int cinemaId, AuditoriumCreateRequest request)
        {
            ViewBag.CinemaId = cinemaId;
            List<SeatDefaultViewModel> seats = new List<SeatDefaultViewModel>();
            for (int i = 1; i <= request.SeatsPerRow; i++)
            {
                for (int j = 1; j <= request.SeatsPerColumn; j++)
                {
                    seats.Add(new SeatDefaultViewModel
                    {
                        Row = i,
                        Column = j,
                        TypeId = 1
                    });
                }
            }
            request.CinemaId = cinemaId;
            return View("Create", request);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(AuditoriumCreateRequest request)
        {
            await _auditoriumService.Create(request);
            return RedirectToAction("Index");
        }

        [HttpGet("{id}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var auditorium = await _auditoriumService.GetById(id);

            var seats = new List<SeatDefaultViewModel>();
            int[] seatMapVector = auditorium.SeatMapVector.Select(c => int.Parse(c.ToString())).ToArray();
            for (int i = 0; i < auditorium.SeatsPerRow; i++)
            {
                for (int j = 0; j < auditorium.SeatsPerColumn; j++)
                {
                    seats.Add(new SeatDefaultViewModel
                    {
                        Row = i + 1,
                        Column = j + 1,
                        TypeId = seatMapVector[i * auditorium.SeatsPerColumn + j]
                    });
                }
            }

            var provinces = await _provinceService.GetAll();
            ViewBag.Provinces = provinces;

            var cinemas = await _cinemaService.GetAll();
            ViewBag.Cinemas = cinemas;

            return View(new AuditoriumUpdateRequest()
            {
                Id = id,
                Name = auditorium.Name,
                SeatsPerColumn = auditorium.SeatsPerColumn,
                SeatsPerRow = auditorium.SeatsPerRow,
                Seats = seats,
            });
        }

        [HttpPost("{id}/update")]
        public async Task<IActionResult> Update(AuditoriumUpdateRequest request)
        {
            await _auditoriumService.Update(request);
            return RedirectToAction("Index");
        }

        [HttpPost("{auditoriumId}/delete")]
        public async Task<IActionResult> Delete(int cinemaId, int auditoriumId)
        {
            await _auditoriumService.Delete(auditoriumId);
            return RedirectToAction("Index", new { cinemaId });
        }
    }
}
