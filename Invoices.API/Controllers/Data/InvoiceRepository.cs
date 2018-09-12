

using Microsoft.EntityFrameworkCore;

namespace Invoices.API.Data {

    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
}