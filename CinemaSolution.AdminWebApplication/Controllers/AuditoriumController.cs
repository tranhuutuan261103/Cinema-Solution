﻿using Azure.Core;
using CinemaSolution.AdminWebApplication.Filters;
using CinemaSolution.Application.Auditorium;
using CinemaSolution.ViewModels.Auditorium;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSolution.AdminWebApplication.Controllers
{
    [Route("cinemas/{cinemaId}/auditoriums")]
    [Authorize(Roles = "Administrator")]
    [SetBarActive("cinemas")]
    public class AuditoriumController : Controller
    {
        private readonly IAuditoriumService _auditoriumService;

        public AuditoriumController(IAuditoriumService auditoriumService)
        {
            _auditoriumService = auditoriumService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(int cinemaId)
        {
            var auditoriums = await _auditoriumService.GetByCinemaId(cinemaId);
            ViewBag.CinemaId = cinemaId;
            return View(auditoriums);
        }

        [HttpGet("create")]
        public IActionResult Create(int cinemaId)
        {
            ViewBag.CinemaId = cinemaId;
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
            return View("Create", request);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(int cinemaId, AuditoriumCreateRequest request)
        {
            await _auditoriumService.Create(request);
            ViewBag.CinemaId = cinemaId;
            return RedirectToAction("Index", new { cinemaId });
        }

        [HttpPost("{auditoriumId}/delete")]
        public async Task<IActionResult> Delete(int cinemaId, int auditoriumId)
        {
            await _auditoriumService.Delete(auditoriumId);
            return RedirectToAction("Index", new { cinemaId });
        }
    }
}
