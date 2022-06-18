
namespace Bayegan.Services.Abstractions
{
    public interface ICryptoService
    {
        string Encrypt(string textEncrypt);
        string Decrypt(string textToDecrypt);
    }
}

