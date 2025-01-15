namespace PaymentProject.Models
{
    public class OrderInfo
    {
        public long OrderId { get; set; }
        public decimal Amount { get; set; }
        public string OrderDesc { get; set; }
        public string OrderType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string BillMobile { get; set; }
        public string BillEmail { get; set; }
        public string BillFirstName { get; set; }
        public string BillLastName { get; set; }
        public string BillAddress { get; set; }
        public string BillCity { get; set; }
        public string BillCountry { get; set; }
        public string Status { get; internal set; }
    }

}
