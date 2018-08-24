using DatingApp.Data;
using DatingApp.Data.Models;
using DatingApp.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.Repositories
{
    public class ValuesRepository : IValueRepo
    {
        private readonly DataContext _context;

        public ValuesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Value>> GetValues()
        {
            var values = await _context.Values.ToListAsync();

            return values;
        }

        public async Task<Value> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return value;
        }


    }
}
