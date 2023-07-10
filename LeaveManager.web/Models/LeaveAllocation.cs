using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManager.web.Models
{
    public class LeaveAllocation : BaseEntity
    {
        public int NumberOfDays { get; set; }

        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }

        public string EmployeeId { get; set; }

    }
}
