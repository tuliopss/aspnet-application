using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services {
    public class SellerService {
        private readonly WebApplication1Context _context;

        public SellerService(WebApplication1Context context) {
            _context = context;
        }

        public List<Seller> FindAll() {
            return _context.Seller.ToList();

        }

        public void Insert (Seller obj) {
            obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
