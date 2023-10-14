using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase {

        [HttpGet(Name = "All")]
        public IEnumerable<CV.Models.Feedback> GetAll() {
            using var db = new FeedbackDbContext();
            return db.GetAll();
        }

        [HttpGet("{id}")] // Add a route parameter for the 'id'
        public IActionResult GetById(int id) {
            using var db = new FeedbackDbContext();
            var feedback = db.GetFeedbackById(id);
            if (feedback == null)
            {
                return NotFound(); // Return 404 Not Found if feedback with the specified ID is not found
            }
            return Ok(feedback);
        }

        [HttpPost(Name = "Add")]
        public IActionResult AddFeedback(CV.Models.Feedback feedback) {
            if (feedback == null)
            {
                return BadRequest("Invalid feedback data"); // Return a 400 Bad Request if feedback data is invalid
            }

            using (var db = new FeedbackDbContext())
            {
                db.Feedbacks.Add(new CV.DatabaseModels.Feedback
                {
                    Sender = feedback.Sender,
                    Title = feedback.Title,
                    Message = feedback.Message,
                    Created = feedback.Created
                });

                db.SaveChanges();
            }

            return Ok("Feedback added successfully"); // Return a 200 OK response after successfully adding feedback
        }

    }
}
