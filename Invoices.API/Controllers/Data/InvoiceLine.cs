namespace Invoices.API.Data
{
    public class InvoiceLine : IEntity 
    {
        public string Id { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}