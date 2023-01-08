using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class CustomerController : Controller
    {


        private static List<CustomerViewModel> _customerViewModel = new List<CustomerViewModel>()
        {
            new CustomerViewModel (1,"Joko", "laki", "Address1","Cikarang","Jawa Barat"),
            new CustomerViewModel (2,"Joki", "laki", "Address2","Bantul","DI Yogyakarta"),
            new CustomerViewModel (3,"Joka", "perempuan", "Address3","Tanggerang","Banten"),
            new CustomerViewModel (4,"Joku", "laki", "Address4","Sidoarjo","Jawa Timur"),
        };

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult ListCustomer()
        {
            return View(_customerViewModel);
        }
        [HttpPost]
        public IActionResult Save([Bind("CustomerId, CustomerName, Gender, Address, City, Province")] CustomerViewModel customer)
        {
            _customerViewModel.Add(customer);
            return Redirect("ListCustomer");
        }
        public IActionResult Edit(int? customerId)
        {
            CustomerViewModel customer = _customerViewModel.Find(x => x.CustomerId.Equals(customerId));
            return View(customer);
        }

        [HttpPost]
        public IActionResult Update (int customerId, [Bind("CustomerId, CustomerName, Gender, Address, City, Province")] CustomerViewModel customer)
        {
            //hapus
            CustomerViewModel customerOld = _customerViewModel.Find(x => x.CustomerId.Equals(customerId));
            _customerViewModel.Remove(customerOld);
            //input
            _customerViewModel.Add(customer);
            return Redirect("ListCustomer");

        }

        public IActionResult Details(int customerId)
        {
            CustomerViewModel customer = (
                from p in _customerViewModel
                where p.CustomerId.Equals(customerId)
                select p).SingleOrDefault(new CustomerViewModel());
            return View(customer);
        }

        public IActionResult Delete(int? customerId)
        {
            CustomerViewModel customer = _customerViewModel.Find(x => x.CustomerId.Equals(customerId));
            _customerViewModel.Remove(customer);

            return Redirect("ListCustomer");
        }
            

            
    }
}
