using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services {
    public class DepartmentService {
        private readonly WebApplication1Context _context;

        public DepartmentService(WebApplication1Context context) {
            _context = context;
        }

       async public Task <List<Department>> FindAllAsync() {
           return await _context.Department.OrderBy(d => d.Name).ToListAsync();
        }
    }
}
