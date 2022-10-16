using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Constants
{
    public class AuthMessages
    {
        public const string EmailCanNotBeDuplicatedWhenRegistered = "Email address already exist.";
        public const string UserIsNotFound = "User is not found.";
        public const string CheckIfPasswordIsCorrect = "Wrong password.";
        public const string UserEmailIsRequired = "User email is required.";
        public const string UserPasswordIsRequired = "User password is required.";
        public const string UserFirstNameIsRequired = "User firstname is required.";
        public const string UserLastNameIsRequired = "User lastname is required.";
    }
}
