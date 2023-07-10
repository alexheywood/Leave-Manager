using System.ComponentModel.DataAnnotations;

namespace LeaveManager.web.ViewModels
{
    public class LeaveTypeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }


        [Display(Name = "Standard Number of Days")]
        public int DefaultDays { get; set; }
    }
}
