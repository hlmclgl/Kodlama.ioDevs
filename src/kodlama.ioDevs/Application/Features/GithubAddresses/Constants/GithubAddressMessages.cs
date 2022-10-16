using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Constants
{
    public static class GithubAddressMessages
    {
        public const string GithubAddressShouldExistWhenRequested = "Requested Github account does not exist.";
        public const string GithubAddressCanNotBeDuplicatedWhenInserted = "Github account already exist.";
    }
}
