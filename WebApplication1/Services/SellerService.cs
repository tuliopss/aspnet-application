using Microsoft.EntityFrameworkCore;
using System.Runtime.Remoting;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services.Exceptions;

namespace WebApplication1.Services {
    public class SellerService {
        private readonly WebApplication1Context _context;

        public SellerService(WebApplication1Context context) {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync() {
            return await _context.Seller.ToListAsync();

        }

        public async Task InsertAsync (Seller obj) {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id) {
           return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id); 
        }

        public async Task RemoveAsync(int id) {
            try {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException e) {
                throw new IntegrityException("This seller has sales");
            }
        }

        public async Task UpdateAsync(Seller obj) {

            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny) {
                throw new NotFoundExcepetion("id not found");
            }
            try {
                _context.Update(obj);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException e) {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }


    }
}
