using System.ComponentModel.DataAnnotations;

namespace LeaveManager.web.ViewModels
{
    public class LeaveTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Leave Type")]
        [Required]
        public string Name { get; set; }


        [Display(Name = "Standard Number of Days")]
        [Required]
        public int DefaultDays { get; set; }
    }
}
