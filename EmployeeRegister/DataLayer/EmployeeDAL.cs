using EmployeeRegister.Models;
using System.Data;
using System.Data.SqlClient;


namespace EmployeeRegister.View
{
    public class EmployeeDAL
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Database=EmployeeDB;Integrated Security=true");
        private SqlCommand? cmd;

       
        public bool InsertEmployee(Employee employee)
        {
            String query = "INSERT INTO [dbo].[Users] (UID,Name,ID) VALUES (@UID,@Name,@ID)";

            {
                cmd = new SqlCommand("sp_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UID", employee.UserID);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@ID", employee.ID);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        public bool UpdateTask(ITaskManager itaskmanager)
        {

            String query = "update into [dbo].[TaskManager]  (ID,Name,Task,TimePeriod) VALUES (@ID,@Name,@Task,@TimePeriod)";

            {
                cmd = new SqlCommand("UpdateTask", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", itaskmanager.ID);
                cmd.Parameters.AddWithValue("@Name", itaskmanager.Name);
                cmd.Parameters.AddWithValue("@Task", itaskmanager.Task);
                cmd.Parameters.AddWithValue("@TimePeriod", itaskmanager.TimePeriod);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }    
}
