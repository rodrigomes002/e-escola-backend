namespace eEscola.Application.Interfaces
{
    public interface ICryptographyProvider
    {
        string HashPassword(string password, out byte[] salt);
        bool VerifyPassword(string password, string hash, byte[] salt);
    }
}
