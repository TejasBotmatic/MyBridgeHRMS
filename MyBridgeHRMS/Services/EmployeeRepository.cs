//using MyBridgeHRMS.Data;
//using MyBridgeHRMS.AuthModels;
//using System.Data;
//using MyBridgeHRMS.JwtContext;

//namespace MyBridgeHRMS.Services
//{
//    public class EmployeeRepository
//    {
//        private readonly DbHelper _dbHelper;

//        private readonly JwtDbContext _context;

//        public EmployeeRepository(DbHelper dbHelper, JwtDbContext Context)
//        {
//            _dbHelper = dbHelper;
//            _context = Context;
//        }

//        public async Task<bool> UpdateUser(User user)
//        {
//            this._context.Users.Attach(user);
//            return await this._context.SaveChangesAsync() > 0 ? true : false;
//        }

//        // 🔹 GET ALL EMPLOYEES
//        public List<Employee> GetAllEmployees()
//        {
//            var list = new List<Employee>();
//            foreach (var row in _dbHelper.ExecuteQuery("sp_GetAllEmployees"))
//                list.Add(new Employee { 
//                    Id = Convert.ToInt32(row["id"]),
//                    Name = row["name"].ToString(),
//                    Salary = Convert.ToDecimal(row["salary"])
//                });
//            return list;
//        }

//        // 🔹 GET EMPLOYEE BY ID
//        public Employee GetEmployeeById(int id)
//        {
//            var parameters = new Dictionary<string, object> { { "@Id", id } };
//            var data = _dbHelper.ExecuteQuery("sp_GetEmployeeById", parameters);

//            if (data.Count > 0)
//            {
//                var row = data[0]; // Get the first row from the result
//                return new Employee
//                {
//                    Id = Convert.ToInt32(row["Id"]),
//                    Name = row["Name"].ToString(),
//                    Salary = Convert.ToDecimal(row["Salary"])
//                };
//            }
//            return null;
//        }

//        // 🔹 ADD NEW EMPLOYEE
//        public void AddEmployee(Employee employee)
//        {
//            var parameters = new Dictionary<string, object>
//        {
//            { "@Name", employee.Name },
//            { "@Salary", employee.Salary }
//        };
//            _dbHelper.ExecuteNonQuery("sp_AddEmployee", parameters);
//        }

//        // 🔹 UPDATE EMPLOYEE
//        public void UpdateEmployee(Employee employee)
//        {
//            var parameters = new Dictionary<string, object>
//        {
//            { "@Id", employee.Id },
//            { "@Name", employee.Name },
//            { "@Salary", employee.Salary }
//        };
//            _dbHelper.ExecuteNonQuery("sp_UpdateEmployee", parameters);
//        }

//        // 🔹 DELETE EMPLOYEE
//        public void DeleteEmployee(int id)
//        {
//            var parameters = new Dictionary<string, object> { { "@Id", id } };
//            _dbHelper.ExecuteNonQuery("sp_DeleteEmployee", parameters);
//        }
//    }
//}
