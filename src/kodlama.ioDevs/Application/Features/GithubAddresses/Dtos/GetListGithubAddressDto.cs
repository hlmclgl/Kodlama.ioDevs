using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Dtos
{
    public class GetListGithubAddressDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string GithubUrl { get; set; }
        
    }
}
