using System.ComponentModel.DataAnnotations;

namespace CV.DatabaseModels {
    public class Contact {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
    }
}
