using System.ComponentModel.DataAnnotations;

namespace CV.Frontend.ViewModels {
    public class FeedbackViewModel {
        [Required(ErrorMessage = "Пожалуйста, введите тему сообщения")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Пожалуйста, введите сообщение")]
        public string Message { get; set; }


        [Required(ErrorMessage = "Пожалуйста, введите ваши контакты")]
        public string Mail { get; set; }
    }
}
