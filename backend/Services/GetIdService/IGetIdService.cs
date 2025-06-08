namespace backend.Services.GetIdService
{
    public interface IGetIdService
    {
        Task<string?> GetStudentIdByUsernameAsync(string username);
        Task<string?> GetTeacherIdByUsernameAsync(string username);
    }
}
