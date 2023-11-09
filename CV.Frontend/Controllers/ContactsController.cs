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

            
            if (!ModelState.IsValid)
            {
                return RedirectToAction(actionName: "Connect", controllerName: "Home", routeValues: feedbackVM);
            }
            else
            {
                var feedbackModel = new CV.Models.Feedback()
                {
                    Title = feedbackVM.Title,
                    Message = feedbackVM.Message,
                    Sender = feedbackVM.Mail,
                    Created = DateTime.Now
                };

                var feedbackDbModel = new CV.DatabaseModels.Feedback()
                {
                    Title = feedbackModel.Title,
                    Message = feedbackModel.Message,
                    Sender = feedbackModel.Sender,
                    Created = DateTime.Now
                };


                var controller = new CV.API.Controllers.FeedbackController();

                controller.AddFeedback(feedbackModel);

                Console.WriteLine(feedbackDbModel.Id);

                return RedirectToAction(controllerName: "Contacts", actionName: "Success");
            }

            return RedirectToAction(controllerName: "Home", actionName: "Index");
        }
    }
}
