using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelephoneDir.Interface;
using TelephoneDir.Models;

namespace TelephoneDir.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _context;

        public ReportController(IReportService context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.GetAllReport());
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(ReportDetail reportDetail) // try catchin içine de alınacak
        {

            Report report = new Report();
            report.time = DateTime.Now;
            report.status = false;
            report.detail.location = reportDetail.location;
            _context.CreateReport(report);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(string id )
        {
            var reportDetail = _context.GetReportDetails(id);
            return View(reportDetail);
        }

    }
}
