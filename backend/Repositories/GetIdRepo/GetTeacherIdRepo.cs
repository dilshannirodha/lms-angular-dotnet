using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.GetIdRepo
{
    public class GetTeacherIdRepo:IGetTeacherIdRepo
    {
        private readonly AppDbContext _context;

        public GetTeacherIdRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string?> GetTeacherIdByUsernameAsync(string username)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Username == username);
            return teacher?.TeacherId;
        }
    }
}
