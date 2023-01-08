namespace WebMvc.Models
{
    public class ShipperViewModel
    {
        public int Id { get; set; }
        public String NameShipper { get; set; }
        public String Production { get; set; }
        public String Region { get; set; }

        public int PriceShipper { get; set; }

        public int Branch { get; set; }

        public ShipperViewModel(int id, string nameShipper, string production, string region,int priceShipper, int branch)
        {
            Id = id;
            NameShipper = nameShipper;
            Production = production;
            Region = region;
            PriceShipper = priceShipper;
            Branch = branch;
        }

        public ShipperViewModel()
        {
        }
    }
}
