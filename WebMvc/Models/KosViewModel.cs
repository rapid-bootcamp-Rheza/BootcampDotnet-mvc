namespace WebMvc.Models
{
    public class KosViewModel
    {
        public int Id { get; set; }
        public String NamaPenyewa { get; set; }

        public String Gender { get; set; }

        public String Status { get; set; }
        public int HargaSewa { get; set; }
        public String JenisKamar { get; set;}

        public int Waktu { get; set; }

        public KosViewModel(int id, string namaPenyewa, string gender, string status, int hargaSewa,string jenisKamar, int waktu)
        {
            Id = id;
            NamaPenyewa = namaPenyewa;
            Gender = gender;
            Status = status;
            HargaSewa = hargaSewa;
            JenisKamar = jenisKamar;
            Waktu = waktu;

        }

        public KosViewModel()
        {
        }
    }
}
