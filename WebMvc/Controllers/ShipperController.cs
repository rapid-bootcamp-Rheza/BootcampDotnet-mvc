using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class ShipperController : Controller
    {
        private static List<ShipperViewModel> _shipperViewModels = new List<ShipperViewModel>()
        {
            new ShipperViewModel (1, "PaketGo", "Makanan", "Jawa", 10000, 5),
            new ShipperViewModel (2, "Boxin", "Pakaian", "Kalimantan", 16000, 10),
            new ShipperViewModel (3, "Pixcel", "Umum", "Jawa", 10000, 25),
            new ShipperViewModel (4, "J&T", "Umum", "Indonesia", 18000, 100),
            new ShipperViewModel (5,"JJJ", "Elektronik", "Jawa", 16000, 15)
        };
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult ListShipper()
        {

            return View(_shipperViewModels);
        }

        [HttpPost]
        public IActionResult Save([Bind("Id, NameShipper, Production, Region, PriceShipper, Branch")] ShipperViewModel shipper)
        {
            _shipperViewModels.Add(shipper);
            return Redirect("ListShipper");
        }

        public IActionResult Edit(int? id)
        {
            //Find with Lamda
            ShipperViewModel shipper = _shipperViewModels.Find(x => x.Id.Equals(id));
            return View(shipper);
        }
        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, NameShipper, Production, Region, PriceShipper, Branch")] ShipperViewModel shipper)
        {
            //hapus data lama
            ShipperViewModel shipperOld = _shipperViewModels.Find(x => x.Id.Equals(id));
            _shipperViewModels.Remove(shipperOld);

            //Input Data Baru
            _shipperViewModels.Add(shipper);
            return Redirect("ListShipper");
        }


        public IActionResult Details(int id)
        {
            // ProductViewModel product = new ProductViewModel(1, "jus mangga", "minuman", 10000);
            //return View(product);

            //find with linq
            ShipperViewModel shipper = (
                from p in _shipperViewModels
                where p.Id.Equals(id)
                select p).SingleOrDefault(new ShipperViewModel());
            return View(shipper);
        }

        public IActionResult Delete(int? id)
        {
            //find data
            ShipperViewModel shipper = _shipperViewModels.Find(x => x.Id.Equals(id));
            //remove data
            _shipperViewModels.Remove(shipper);

            return Redirect("ListShipper");
        }
    }
}
