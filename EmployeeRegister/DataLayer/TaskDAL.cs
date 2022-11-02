using EmployeeRegister.Models;
using System.Data;
using System.Data.SqlClient;




namespace EmployeeRegister.View
{
    public class TaskDAL
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Database=EmployeeDB;Integrated Security=true");
        private SqlCommand? cmd;




        public bool InsertTask(ITaskManager task)
        {
            String query = "INSERT INTO [dbo].[TaskManager] (ID,Name,Task,TimePeriod) VALUES (@ID,@Name,@Task, @TimePeriod)";

            {
                cmd = new SqlCommand("sp_insert_Value", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", task.ID);
                cmd.Parameters.AddWithValue("@Name", task.Name);
                cmd.Parameters.AddWithValue("@Task", task.Task);
                cmd.Parameters.AddWithValue("@TimePeriod", task.TimePeriod);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                con.Close();
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
