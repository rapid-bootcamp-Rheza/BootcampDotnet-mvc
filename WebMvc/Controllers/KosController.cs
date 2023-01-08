using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class KosController : Controller
    {
        private static List<KosViewModel> _kosViewModel = new List<KosViewModel>()
        {
            new KosViewModel(1, "Eka", "laki", "Single", 1500000, "Exclusive", 24),
            new KosViewModel(2, "Eko", "laki", "Pasutri", 2500000, "Exclusive-Keluarga", 12),
            new KosViewModel(3, "Eki", "Laki", "Single", 1000000, "Biasa", 36),
            new KosViewModel(4, "Endang", "Perempuan", "Single", 2000000, "Exclusive", 12)
        };
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult ListKos()
        {

            return View(_kosViewModel);
        }
        [HttpPost]
        public IActionResult Save([Bind("Id, NamaPenyewa, Gender, Status, HargaSewa, JenisKamar, Waktu")] KosViewModel kos)
        {
            _kosViewModel.Add(kos);
            return Redirect("ListKos");
        }
        public IActionResult Edit(int? id)
        {
            //Find With Lamda
            KosViewModel kos = _kosViewModel.Find(x => x.Id.Equals(id));
            return View(kos);
        }
        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, NamaPenyewa, Gender, Status, HargaSewa, JenisKamar, Waktu")] KosViewModel kos)
        {
            //Hapus data lama
            KosViewModel kosOld = _kosViewModel.Find(x => x.Id.Equals(id));
            _kosViewModel.Remove(kosOld);

            //inpur
            _kosViewModel.Add(kos);
            return Redirect("ListKos");
        }

        public IActionResult Details(int id)
        {
            KosViewModel kos = (
                from p in _kosViewModel
                where p.Id.Equals(id)
                select p).SingleOrDefault(new KosViewModel());
            return View(kos);
        }

        public IActionResult Delete(int? id)
        {
            //find data
            KosViewModel kos = _kosViewModel.Find(x => x.Id.Equals(id));

            //remove data
            _kosViewModel.Remove(kos);
            return Redirect("ListKos");
        }


    }
}
