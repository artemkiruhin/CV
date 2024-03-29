﻿using CV.DatabaseModels;
using CV.Models;
using Microsoft.EntityFrameworkCore;

namespace Database {
    public class FeedbackDbContext : DbContext {

        public FeedbackDbContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(
                DatabaseInformation.CONNECTION_STRING,
                MySqlServerVersion.AutoDetect(DatabaseInformation.CONNECTION_STRING)
                );
        }

        public DbSet<CV.DatabaseModels.Feedback> Feedbacks { get; set; }

        public IEnumerable<CV.Models.Feedback> GetAll () {
            var dbFeedbacks = Feedbacks.ToList();
            var modelFeedbacks = new List<CV.Models.Feedback>();

            foreach ( var feedback in dbFeedbacks )
            {
                var tmpModelFeedback = new CV.Models.Feedback() { 
                    Id = feedback.Id,
                    Sender = feedback.Sender,
                    Message = feedback.Message,
                    Title = feedback.Title,
                    Created = feedback.Created
                };

                modelFeedbacks.Add(tmpModelFeedback);
            }

            return (IEnumerable<CV.Models.Feedback>)modelFeedbacks;

        }

        public CV.Models.Feedback? GetFeedbackById(int id) {
            var dbFeedback = _GetFeedbackById(id);

            if (dbFeedback == null) return null;

            var modelFeedback = new CV.Models.Feedback()
            {
                Id = dbFeedback.Id,
                Sender = dbFeedback.Sender,
                Title = dbFeedback.Title,
                Message = dbFeedback.Message,
                Created = dbFeedback.Created
            };

            return modelFeedback;

        }

        public void DeleteFeedbackById(int id) {
            var dbFeedback = _GetFeedbackById(id);

            if (dbFeedback != null)
            {
                Feedbacks.Remove(dbFeedback);
                SaveChanges();
            }
        }

        public void AddFeedback(CV.Models.Feedback feedback) {
            var feedbackToDb = new CV.DatabaseModels.Feedback()
            {
                Sender = feedback.Sender,
                Title = feedback.Title,
                Message = feedback.Message,
                Created = feedback.Created
            };

            using (var db = new FeedbackDbContext()) // Assuming FeedbackDbContext is your database context
            {
                db.Feedbacks.Add(feedbackToDb); // Assuming Feedbacks is your DbSet<Feedback> property in the context
                db.SaveChanges();
            }
        }


        private CV.DatabaseModels.Feedback? _GetFeedbackById(int id) {
            var dbFeedback = Feedbacks.FirstOrDefault(x => x.Id == id);

            if (dbFeedback == null) return null;
            return dbFeedback;
        }
    }
}
