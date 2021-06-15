using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace LabTask.Models.Database
{
    public class Database
    {
        public Students Students { get; set; }
        public Departments Departments { get; set; }

        public Database()
        {
            string connString = @"server=DESKTOP-0M9KU8T; Database = Student;Integrated security = true;";
            SqlConnection conn = new SqlConnection(connString);

            Students = new Students(conn);
            Departments = new Departments(conn);

        }
    }
}


