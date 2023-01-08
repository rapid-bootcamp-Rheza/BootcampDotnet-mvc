namespace WebMvc.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public String EmployeeName { get; set; }
        public String Gender { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String Province { get; set; }
        public String Jabatan { get; set; }

        public EmployeeViewModel(int employeeId, string employeeName, string gender,string address,string city, string province, string jabatan)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            Gender = gender;
            Address = address;
            City = city;
            Province = province; 
            Jabatan = jabatan;
        }
        public EmployeeViewModel()
        {

        }

    }
}
