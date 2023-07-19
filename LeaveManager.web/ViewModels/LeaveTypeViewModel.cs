using System.ComponentModel.DataAnnotations;

namespace LeaveManager.web.ViewModels
{
    public class LeaveTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Leave Type")]
        [Required]
        public string Name { get; set; }


        [Display(Name = "Standard Days")]
        [Required]
        [Range(0, 365, ErrorMessage = "Please provide a valid number between 0 - 365.")]
        public int DefaultDays { get; set; }
    }
}
