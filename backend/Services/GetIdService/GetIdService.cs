using backend.Repositories.GetIdRepo;


namespace backend.Services.GetIdService
{
    public class GetIdService:IGetIdService
    {
        private readonly IGetStudentIdRepo _studentRepo;
        private readonly IGetTeacherIdRepo _teacherRepo;

        public GetIdService(IGetStudentIdRepo studentRepo, IGetTeacherIdRepo teacherRepo)
        {
            _studentRepo = studentRepo;
            _teacherRepo = teacherRepo;
        }

        public async Task<string?> GetStudentIdByUsernameAsync(string username)
        {
            return await _studentRepo.GetStudentIdByUsernameAsync(username);
        }

        public async Task<string?> GetTeacherIdByUsernameAsync(string username)
        {
            return await _teacherRepo.GetTeacherIdByUsernameAsync(username);
        }

    }
}
