using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Server.Core.Domain
{
    public class User
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");

        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string UserName { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected User()
        {
        }

        public User(Guid id, string email, string userName, string password, string salt)
        {
            Id = id;
            SetEmail(email);
            SetPassword(password, salt);
            SetUserName(userName);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetUserName(string username)
        {
            if (!NameRegex.IsMatch(username))
            {
                throw new ArgumentException(ErrorCodes.InvalidUserName,
                    "Username is invalid.");
            }

            if (String.IsNullOrEmpty(username))
            {
                throw new ArgumentException(ErrorCodes.InvalidUserName,
                    "Username is invalid.");
            }

            UserName = username.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException(ErrorCodes.InvalidEmail,
                    "Email can not be empty.");
            }
            if (Email == email)
            {
                return;
            }

            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, string salt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException(ErrorCodes.InvalidPassword,
                    "Password can not be empty.");
            }
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new ArgumentException(ErrorCodes.InvalidPassword,
                    "Salt can not be empty.");
            }
            if (password.Length < 4)
            {
                throw new ArgumentException(ErrorCodes.InvalidPassword,
                    "Password must contain at least 4 characters.");
            }
            if (password.Length > 100)
            {
                throw new ArgumentException(ErrorCodes.InvalidPassword,
                    "Password can not contain more than 100 characters.");
            }
            if (Password == password)
            {
                return;
            }
            Password = password;
            Salt = salt;
            UpdatedAt = DateTime.UtcNow;
        }
    }
  
}
