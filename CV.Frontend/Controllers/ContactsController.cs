using CV.Frontend.ViewModels;
using CV.Models;
using Microsoft.AspNetCore.Mvc;

namespace CV.Frontend.Controllers {
    public class ContactsController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Success() {
            return View();
        }

        [HttpPost]
        public IActionResult OnFeedback(FeedbackViewModel feedbackVM) {
            if (ModelState.IsValid)
            {
                var feedbackModel = new CV.Models.Feedback()
                {
                    Title = feedbackVM.Title,
                    Message = feedbackVM.Message,
                    Sender = feedbackVM.Mail,
                    Created = DateTime.Now
                };

                var controller = new CV.API.Controllers.FeedbackController();
                controller.AddFeedback(feedbackModel);

                return View("Success");
            }
            return View("Index", feedbackVM);
        }
    }
}
