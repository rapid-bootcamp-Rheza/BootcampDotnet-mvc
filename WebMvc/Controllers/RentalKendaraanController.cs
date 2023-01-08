using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class RentalKendaraanController : Controller
    {
        private static List<RentalViewModel> _rentalViewModel = new List<RentalViewModel>() { 
            new RentalViewModel (1,"Saka","Mobil","Toyota",2450000, 4),
            new RentalViewModel (2,"Saku","Mobil","Toyota",6000000, 7),
            new RentalViewModel (3,"Saki","Motor","Honda",500000, 2),
            new RentalViewModel (4,"Sake","Mobil","Dauhatsu",5400000, 10),
            new RentalViewModel (5,"Sako","Motor","Yamaha",900000, 3)
        
        };
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult ListRental()
        {

            return View(_rentalViewModel);
        }

        [HttpPost]
        public IActionResult Save([Bind("Id, NamaPenyewa, Jenis, Merk, Sewa, HariSewa")] RentalViewModel rental)
        {
            _rentalViewModel.Add(rental);
            return Redirect("ListRental");
        }

        public IActionResult Edit(int? id)
        {
            //Find with Lamda
            RentalViewModel rental = _rentalViewModel.Find(x => x.Id.Equals(id));
            return View(rental);
        }
        [HttpPost]
        public IActionResult Update(int id,[Bind("Id, NamaPenyewa, Jenis, Merk, Sewa, HariSewa")] RentalViewModel rental)
        {
            //hapus data lama
            RentalViewModel rentalOld = _rentalViewModel.Find(x => x.Id.Equals(id));
           _rentalViewModel.Remove(rentalOld);

            //Input Data Baru
            _rentalViewModel.Add(rental);
            return Redirect("ListRental");
        }


        public IActionResult Details(int id)
        {
            // ProductViewModel product = new ProductViewModel(1, "jus mangga", "minuman", 10000);
            //return View(product);

            //find with linq
            RentalViewModel rental = (
                from p in _rentalViewModel
                where p.Id.Equals(id)
                select p).SingleOrDefault(new RentalViewModel());
            return View(rental);
        }

        public IActionResult Delete(int? id)
        {
            //find data
            RentalViewModel rental = _rentalViewModel.Find(x => x.Id.Equals(id));
            //remove data
            _rentalViewModel.Remove(rental);

            return Redirect("ListRental");
        }


    }

}

