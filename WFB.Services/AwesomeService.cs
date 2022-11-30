using System.Security.Cryptography;
using System.Text;

namespace WFB.Services;

public static class AwesomeService
{
    public static int GetRandomNumber()
    {
        return new Random().Next(0, 1000);
    }

    public static string HashWithSecret(string plainText, string secret)
    {
        var shaProvider = SHA256.Create();

        var secretHash = shaProvider.ComputeHash(Encoding.UTF8.GetBytes(plainText + secret));

        return Convert.ToHexString(secretHash);
    }
}