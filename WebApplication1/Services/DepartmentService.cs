using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services {
    public class DepartmentService {
        private readonly WebApplication1Context _context;

        public DepartmentService(WebApplication1Context context) {
            _context = context;
        }

        public List<Department> FindAll() {
            return _context.Department.OrderBy(d => d.Name).ToList();
        }
    }
}
