namespace WebMvc.Models
{
    public class RentalViewModel
    {
        public int Id { get; set; }
        public String NamaPenyewa { get; set; }
        public String Jenis { get; set; }
        public String Merk { get; set; }

        public int Sewa { get; set; }
        public int HariSewa { get; set; }

        public RentalViewModel(int id, string namaPenyewa, string jenis, string merk, int sewa, int hariSewa)
        {
            Id = id;
            NamaPenyewa = namaPenyewa;
            Jenis = jenis;
            Merk = merk;
            Sewa = sewa;
            HariSewa = hariSewa;
        }

        public RentalViewModel()
        {
        }
    }
}
