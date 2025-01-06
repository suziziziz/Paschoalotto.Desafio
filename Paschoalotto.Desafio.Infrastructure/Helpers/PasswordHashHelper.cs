using dotenv.net.Utilities;

using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Paschoalotto.Desafio.Infrastructure.Helpers;

public static class PasswordHashHelper
{
    public static string Hash(string password, byte[] salt)
    {
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: EnvReader.GetIntValue("PASSWORD_HASH_ITERATION_COUNT"),
            numBytesRequested: 256 / 8));

        return hashed;
    }
}
