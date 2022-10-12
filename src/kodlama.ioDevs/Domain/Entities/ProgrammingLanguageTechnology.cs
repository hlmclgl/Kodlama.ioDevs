using Core.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgrammingLanguageTechnology:Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public ProgrammingLanguageTechnology()
        {
        }

        public ProgrammingLanguageTechnology(int id, int programmingLanguageId, string name) : this()
        {
            Id = id;   
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
        }



    }
}
