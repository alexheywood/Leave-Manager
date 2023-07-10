using System.Diagnostics;

namespace LeaveManager.web.Models
{
    public class LeaveType : BaseEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}