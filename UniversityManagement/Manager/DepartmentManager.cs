using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagement.Gateway;
using UniversityManagement.Models;

namespace UniversityManagement.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway=new DepartmentGateway();

        public string Save(Department department)
        {
            if (departmentGateway.IsExitCode(department))
            {
                return "Department Code is already Exits";
            }
            if (departmentGateway.IsExitDepartmentName(department))
            {
                return "Department name is already Exits";
            }
           
            if (departmentGateway.Save(department) > 0)
            {
                return "Department is save Successfully";
            }
            return "Department save Failed";
        }

        public List<Department> GetAllDepartments()
        {
            return departmentGateway.GetAllDepartments();
        }
    }
}