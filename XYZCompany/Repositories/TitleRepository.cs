using Microsoft.EntityFrameworkCore;
using XYZCompany.Entities;

namespace XYZCompany.Repositories
{
    public class TitleRepository
    {
        private readonly XYZCompanyContext _context; ///private field
        public TitleRepository(XYZCompanyContext context) ///instance of the XYZCompanyContext named context
        {
            _context = context;
        }
        public async Task<List<Title>> GetAll()
        {
            return await _context.Titles.ToListAsync();
        }

        public async Task<Title> Get(Guid id)
        {
            return await _context.Titles.FindAsync(id);
        }
        public async Task<Title> Create(Title title)
        {
            title.id = Guid.NewGuid();
            _context.Add(title);
            await _context.SaveChangesAsync();
            return title;
        }
        public async Task<Title> Update(Title title)
        {
            _context.Update(title);
            await _context.SaveChangesAsync();
            return title;
        }
        public async Task Delete(Guid id)
        {
            var title = await _context.Titles.FindAsync(id);
            _context.Remove(title);
            await _context.SaveChangesAsync();
        }
    }
}
