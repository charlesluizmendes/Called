using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Extensions
{
    public class HasherExtension
    {
        public static string HashPassword(string password)
        {
            var hasher = new PasswordHasher<User>();
            var hashPassword = hasher.HashPassword(null, password);

            return hashPassword;
        }

        public static bool VerifyHashedPassword(string passwordHash, string providedPassword)
        {
            var hasher = new PasswordHasher<User>();

            var verify = hasher.VerifyHashedPassword(null, passwordHash, providedPassword);

            if (verify == PasswordVerificationResult.Success)
            {
                return true;
            }

            return false;
        }
    }
}
