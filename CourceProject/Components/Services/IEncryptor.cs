namespace CourceProject.Components.Services
{
    public interface IEncryptor
    {
        public string Encrypt(string plainText);
        public string Decrypt(string plainText);
    }
}
