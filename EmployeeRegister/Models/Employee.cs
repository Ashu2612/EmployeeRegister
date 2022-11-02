using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;


namespace EmployeeRegister.Models
{

    public class Employee
    {
       
       /*
        [required( ErrorMessage = "Please enter your unique ID")]
       */
        public int UserID { get; set; }

        /*
        [required]
        [DataType(DataType.Text, ErrorMessage = "Please enter your Name")]
    */
        public string? Name { get; set; }


        /*
        [required( ErrorMessage = "Please enter your Employee ID")]
        */
        public int ID { get; set; }
        /*
        [required]
        [DataType(DataType.Text, ErrorMessage = "Please enter the Task Name")]
        
        [required(ErrorMessage = "Please enter time in hours")]
        */

        

    }
}
