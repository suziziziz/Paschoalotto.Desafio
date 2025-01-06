using System.Text.RegularExpressions;

using Paschoalotto.Desafio.Domain.Entities;
using Paschoalotto.Desafio.Domain.Exceptions;

namespace Paschoalotto.Desafio.Domain.Validations;

public partial class DomainUserValidation
{
    public static void When(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FullName))
            throw new DomainEntityException("É obrigatório preencher o nome completo.");

        if (string.IsNullOrWhiteSpace(user.Username))
            throw new DomainEntityException("É obrigatório preencher o nome de usuário.");

        if (UsernameRegex().Replace(user.Username, "").Length > 0)
            throw new DomainEntityException(
                """Nome de usuário deve conter apenas letras, números e/ou "_".""");

        if (string.IsNullOrWhiteSpace(user.Email))
            throw new DomainEntityException("É obrigatório preencher o email.");

        if (EmailRegex().Replace(user.Email, "").Length > 0)
            throw new DomainEntityException("Email inválido!");

        if (!PasswordRegex().Match(user.Password).Success
            || PasswordRegex().Replace(user.Password, "").Length > 0)
            throw new DomainEntityException(
                "Senha inválida\n"
                + "- mínimo 8 caracteres\n"
                + "- precisa conter ao menos 1 letra maiuscula, 1 letra minuscula, e 1 número\n"
                + "- pode conter caracteres especiais");

        if (!string.IsNullOrWhiteSpace(user.Picture))
            if (!UrlRegex().Match(user.Picture).Success
                || UrlRegex().Replace(user.Picture, "").Length > 0)
                throw new DomainEntityException("Url da foto do perfil inválida.");
    }

    [GeneratedRegex(@"[A-z0-9_]+")]
    private static partial Regex UsernameRegex();

    /// <summary>
    /// Credits: regexr.com/2rhq7
    /// </summary>
    [GeneratedRegex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
    private static partial Regex EmailRegex();

    /// <summary>
    /// Credits: regexr.com/3bfsi
    /// </summary>
    [GeneratedRegex(@"^.{8,}$", RegexOptions.Multiline)]
    private static partial Regex PasswordRegex();

    /// <summary>
    /// Credits: regexr.com/2rj36
    /// </summary>
    [GeneratedRegex(@"[-a-zA-Z0-9@:%_\+.~#?&//=]{2,256}\.[a-z]{2,4}\b(\/[-a-zA-Z0-9@:%_\+.~#?&//=]*)?", RegexOptions.IgnoreCase)]
    private static partial Regex UrlRegex();
}
