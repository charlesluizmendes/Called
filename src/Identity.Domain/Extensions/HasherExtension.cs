using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Extensions
{
    public static class HasherExtension
    {
        public static string HashPassword(User user, string password)
        {
            var hasher = new PasswordHasher<User>();

            var hashPassword = hasher.HashPassword(user, password);

            return hashPassword;
        }

        public static bool VerifyHashedPassword(User user, string passwordHash, string providedPassword)
        {
            var hasher = new PasswordHasher<User>();

            if (passwordHash != null && providedPassword != null)
            {
                var verify = hasher.VerifyHashedPassword(user, passwordHash, providedPassword);

                if (verify == PasswordVerificationResult.Success)
                {
                    return true;
                }
            }            

            return false;
        }
    }
}
