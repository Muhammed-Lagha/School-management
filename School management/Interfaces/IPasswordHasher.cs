namespace School_management.Interfaces
{
    public interface IPasswordHasher
    {
        string Generate(string password);

        bool Verify(string password ,string clientPassword);
    }
}
