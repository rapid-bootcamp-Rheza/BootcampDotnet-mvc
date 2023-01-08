namespace WebMvc.Models
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public String CustomerName { get; set; }
        public String Gender { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String Province { get; set; }
        //public String JenisCustomer { get; set; }

        public CustomerViewModel(int customerId, string customerName, string gender, string address, string city, string province)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            Gender = gender;
            Address = address;
            City = city;
            Province = province;
            //JenisCustomer = jenisCustomer;
        }

        public CustomerViewModel()
        {
        }
    }
}
