﻿using System.ComponentModel.DataAnnotations;

namespace CV.Models {
    public class Feedback {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
    }
}
