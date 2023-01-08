using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;
using System.Linq;

namespace WebMvc.Controllers
{
    public class ProductController : Controller
    {
        /*
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }*/

        private static List<ProductViewModel> _productViewModel = new List<ProductViewModel>()
            {
                new ProductViewModel(1,"jus mangga", "minuman", 10000),
                new ProductViewModel(2,"jus jeruk", "minuman", 10000),
                new ProductViewModel(3,"Mie Goreng Tante", "makanan", 7000),
                new ProductViewModel(4,"Mie Goreng Telor", "makanan", 8000)
            };

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult List()
        {

            return View(_productViewModel);
        }

        [HttpPost]
        public IActionResult Save([Bind("Id, Name, Category, Price")] ProductViewModel product)
        {
            _productViewModel.Add(product);
            return Redirect("List");
        }

        public IActionResult Edit(int? id)
        {
            //Find with Lamda
            ProductViewModel product = _productViewModel.Find(x => x.Id.Equals(id));
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, Name, Category, Price")] ProductViewModel product)
        {
            //hapus data lama
            ProductViewModel productOld = _productViewModel.Find(x => x.Id.Equals(id));
            _productViewModel.Remove(productOld);

            //Input Data Baru
            _productViewModel.Add(product);
            return Redirect("List");
        }


        public IActionResult Details(int id)
        {
            // ProductViewModel product = new ProductViewModel(1, "jus mangga", "minuman", 10000);
            //return View(product);

            //find with linq
            ProductViewModel product = (
                from p in _productViewModel
                where p.Id.Equals(id)
                select p).SingleOrDefault(new ProductViewModel());
            return View(product);
        }

        public IActionResult Delete (int? id)
        {
            //find data
            ProductViewModel product = _productViewModel.Find(x => x.Id.Equals(id));
            //remove data
            _productViewModel.Remove(product);

            return Redirect("List");
        }


    }
}
