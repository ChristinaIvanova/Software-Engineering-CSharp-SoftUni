using System.Linq;
using System.Text;

namespace VaporStore.DataProcessor
{
    using System;
    using Data;

    public static class Bonus
    {
        public static string UpdateEmail(VaporStoreDbContext context, string username, string newEmail)
        {
            var message = string.Empty;

            var user = context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                message = $"User {username} not found";
            }
            else
            {
                var existingEmail = context.Users.Any(u => u.Email == newEmail);
                if (existingEmail)
                {
                    message = $"Email {newEmail} is already taken";
                }
                else
                {
                    user.Email = newEmail;

                    message = $"Changed {username}'s email successfully";
                }
            }

            return message;
        }
    }
}
