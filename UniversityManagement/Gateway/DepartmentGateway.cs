using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagement.Models;

namespace UniversityManagement.Gateway
{
    public class DepartmentGateway : Gateway
    {
        public int Save(Department department)
        {
            Query = "INSERT INTO Department_tb (DepartmentCode, DepartmentName) VALUES (@code,@name)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("code", department.DepartmentCode);
            Command.Parameters.AddWithValue("name", department.DepartmentName);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
        public bool IsExitCode(Department department)
        {
            Query = "SELECT * FROM Department_tb WHERE DepartmentCode=@code";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("code", department.DepartmentCode);
            
            Connection.Open();
            Reader  = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                return true;
            }
            Connection.Close();
            return false;
        }
        public bool IsExitDepartmentName(Department department)
        {
            Query = "SELECT * FROM Department_tb WHERE DepartmentName=@name";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("name", department.DepartmentName);

            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                return true;
            }
            Connection.Close();
            return false;
        } 
        public List<Department> GetAllDepartments()
        {
            Query = "SELECT * FROM Department_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> departments=new List<Department>();
            while (Reader.Read())
            {
                Department department=new Department();
                department.DepartmentCode = Reader["DepartmentCode"].ToString();
                department.DepartmentName = Reader["DepartmentName"].ToString();
                departments.Add(department);
            }
            Connection.Close();
            return departments;
        }
    }
}