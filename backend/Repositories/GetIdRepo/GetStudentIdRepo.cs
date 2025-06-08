using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.GetIdRepo
{
    public class GetStudentIdRepo:IGetStudentIdRepo
    {
        private readonly AppDbContext _context;

        public GetStudentIdRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string?> GetStudentIdByUsernameAsync(string username)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Username == username);
            return student?.StudentId;
        }
    }
}
