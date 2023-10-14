using System.ComponentModel.DataAnnotations;

namespace CV.DatabaseModels {
    public class Feedback {
        [Key]
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }

    }
}
