using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_finances_system
{
    public static class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            return "Data Source=BARYAR\\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True";
        }
    }
}
