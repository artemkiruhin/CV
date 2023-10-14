using CV.Frontend.Models;
using CV.Models;
using CV.API;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CV.API.Controllers;

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

        public IActionResult AboutThisProject() {
            return View();
        }

        public IActionResult AboutMe() {
            return View();
        }

        public IActionResult Skills() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}