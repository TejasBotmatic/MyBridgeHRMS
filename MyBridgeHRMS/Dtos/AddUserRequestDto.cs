namespace MyBridgeHRMS.Dtos
{
    public class EmployeeInsertRequestDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int? AccountType { get; set; }
        public string Address { get; set; }
        public string AnnualCtc { get; set; }
        public int? BiometricEmpId { get; set; }
        public int BranchId { get; set; }
        public string Children { get; set; }
        public string CompanyDoj { get; set; }
        public int CreatedBy { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public DateTime? Dob { get; set; }
        public string Documents { get; set; }
        public string Email { get; set; }
        public string EmployeeId { get; set; }
        public string Gender { get; set; }
        public int IsActive { get; set; }
        public int? ManagerId { get; set; }
        public string MaritalStatus { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpire { get; set; }
        public int? RoleId { get; set; }
        public string SalaryBand { get; set; }
        public int? SalaryType { get; set; }
    }
}
