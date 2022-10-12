using Application.Features.GithubAddresses.Dtos;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Models
{
    public class GithubAddressListModel : BasePageableModel
    {
        public IList<GetListGithubAddressDto> Items { get; set; }
    }
}
