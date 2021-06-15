using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace LabTask.Models.Database
{
    public class Students
    {
        private SqlConnection conn;

        public Students(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void Insert(Student p)
        {
           

            string query = "INSERT INTO Student VALUES(@name,@dob,@credit,@cgpa,@dept_id)";


            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@name", p.Name);
            cmd.Parameters.AddWithValue("@dob", p.Dob);
            cmd.Parameters.AddWithValue("@credit", p.Credit);
            cmd.Parameters.AddWithValue("@cgpa", p.Cgpa);
            cmd.Parameters.AddWithValue("@dept_id", p.Dept_id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();

            string query = "select * from Student";

            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Student s = new Student()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Dob = reader.GetDateTime(reader.GetOrdinal("Dob")),
                    Credit = reader.GetDouble(reader.GetOrdinal("Credit")),
                    Cgpa = reader.GetDouble(reader.GetOrdinal("Cgpa")),
                    Dept_id = reader.GetString(reader.GetOrdinal("Dept_id")),
                };
                students.Add(s);
            }
            conn.Close();
            return students;
        }

        public Student Get(int id)
        {
            Student p = null;
            string query = $"select * from Student Where Id={id}";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                p = new Student()
                {

                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Dob = reader.GetDateTime(reader.GetOrdinal("Dob")),
                    Credit = reader.GetDouble(reader.GetOrdinal("Credit")),
                    Cgpa = reader.GetDouble(reader.GetOrdinal("Cgpa")),
                    Dept_id = reader.GetString(reader.GetOrdinal("Dept_id")),
                };
            }
            conn.Close();
            return p;
        }
        public void Update(Student p)
        {
            string query = $"Update Student Set Name='{p.Name}', Dob='{p.Dob}' ,Credit={p.Credit}, Cgpa={p.Cgpa}, Dept_id='{p.Dept_id}' Where Id = {p.Id}";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}