using Microsoft.EntityFrameworkCore;
using System.Runtime.Remoting;
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
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id) {
           return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id); 
        }

        public void Remove(int id) {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges(); 
        }

        public void Update(Seller obj) {
            if (!_context.Seller.Any(x => x.Id == obj.Id)) {
                throw new NotFoundExcepetion("id not found");
            }
            try {
                _context.Update(obj);
                _context.SaveChanges();

            }
            catch (DbUpdateConcurrencyException e) {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }


    }
}
