using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Models
{
    public class ProgrammingLanguageTechnologyListModel : BasePageableModel
    {
        public IList<GetListProgrammingLanguageTechnologyDto> Items { get; set; }
    }
}
