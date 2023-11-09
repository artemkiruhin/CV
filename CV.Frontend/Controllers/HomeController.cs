using CV.Frontend.Models;
using CV.Models;
using CV.API;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CV.API.Controllers;
using CV.Frontend.ViewModels;
using System.Net.WebSockets;

namespace CV.Frontend.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly FeedbackController _feedbackController = new FeedbackController();
        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            // Вызов метода API для получения отзывов
            var feedbacks = _feedbackController.GetAll();
            return View(feedbacks);
        }

        public IActionResult Skills() {
            return View();
        }

        public IActionResult Contacts() {
            return View();
        }

        [HttpGet]
        public IActionResult Connect(FeedbackViewModel feedback) {
            return View(feedback);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}