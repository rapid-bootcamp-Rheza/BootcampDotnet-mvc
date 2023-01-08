using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<EmployeeViewModel> _employeeViewModel = new List<EmployeeViewModel>() 
        { 
            new EmployeeViewModel (1,"Agus","Laki", "Address1", "Medan", "Sumatra Utara", "Karyawan"),
            new EmployeeViewModel (2,"Ari","Perempuan", "Address2", "Cibubur", "Jakarta Timur", "Karyawan"),
            new EmployeeViewModel (3,"Arum","Perempuan", "Address3", "Padang", "Sumatra Barat", "Karyawan"),
            new EmployeeViewModel (4,"Beni","Laki", "Address4", "Kulon Progo", "DI Yogyakarta", "Sales"),
        };
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult ListEmployee()
        {
            return View(_employeeViewModel);
        }
        [HttpPost]
        public IActionResult Save([Bind("EmployeeId, EmployeeName, Gender, Address, City, Province, Jabatan")] EmployeeViewModel employee)
        {
            _employeeViewModel.Add(employee);
            return Redirect("ListEmployee");


        }

        public IActionResult Edit(int? employeeId)
        {
            //Find with lamda
            EmployeeViewModel employee = _employeeViewModel.Find(x => x.EmployeeId.Equals(employeeId));
            return View(employee);
        }
        public IActionResult Update(int employeeId, [Bind("EmployeeId, EmployeeName, Gender, Address, City, Province, Jabatan")] EmployeeViewModel employee)
        {
            //hapus
            EmployeeViewModel employeeOld = _employeeViewModel.Find(x => x.EmployeeId.Equals(employeeId);
            _employeeViewModel.Remove(employeeOld);

            //input
            _employeeViewModel.Add(employee);
            return Redirect("ListEmployee");

        }
        public IActionResult Details(int employeeId)
        {
            // ProductViewModel product = new ProductViewModel(1, "jus mangga", "minuman", 10000);
            //return View(product);

            //find with linq
            EmployeeViewModel employee = (
                from p in _employeeViewModel
                where p.EmployeeId.Equals(employeeId)
                select p).SingleOrDefault(new EmployeeViewModel());
            return View(employee);
        }

        public IActionResult Delete(int? employeeId)
        {
            //find data
            EmployeeViewModel employee = _employeeViewModel.Find(x => x.EmployeeId.Equals(employeeId));
            //remove data
            _employeeViewModel.Remove(employee);

            return Redirect("ListEmployee");
        }



    }
}
