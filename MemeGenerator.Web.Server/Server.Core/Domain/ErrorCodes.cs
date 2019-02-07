using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Core.Domain
{
    public static class ErrorCodes
    {
        public static string InvalidEmail => "invalid_email";
        public static string InvalidPassword => "invalid_password";
        public static string InvalidPath => "invalid_path";
        public static string InvalidUserName => "invalid_username";
        public static string InvalidTitle => "invalid_title";

    }
}
