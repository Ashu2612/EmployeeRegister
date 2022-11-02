using System.ComponentModel.DataAnnotations;

namespace EmployeeRegister.Models
{
    public class ITaskManager
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Task { get; set; }
        public int TimePeriod { get; set; }
    }
}
