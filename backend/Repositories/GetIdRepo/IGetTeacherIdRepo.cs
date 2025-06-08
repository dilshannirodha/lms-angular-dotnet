namespace backend.Repositories.GetIdRepo
{
    public interface IGetTeacherIdRepo
    {
        Task<string?> GetTeacherIdByUsernameAsync(string username);

    }
}
