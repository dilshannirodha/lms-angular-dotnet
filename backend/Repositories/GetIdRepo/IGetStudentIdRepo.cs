namespace backend.Repositories.GetIdRepo
{
    public interface IGetStudentIdRepo
    {
        Task<string?> GetStudentIdByUsernameAsync(string username);

    }
}
