using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;


namespace LabTask.Models.Database
{
    public class Departments
    {
        private SqlConnection conn;

        public Departments(SqlConnection conn)
        {
            this.conn = conn;
        }

        public List<Department> GetAll()
        {
            List<Department> departments = new List<Department>();

            string query = "select * from Department";

            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Department s = new Department()
                {
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Id = reader.GetInt16(reader.GetOrdinal("Id")),
                  
                    
                };
                departments.Add(s);
            }
            conn.Close();
            return departments;
        }
    }
}