using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class RegionalBloc:IEntity
    {
        public string acronym { get; set; }
        public string name { get; set; }
        public List<string> otherNames { get; set; }
        public List<string> otherAcronyms { get; set; }
    }
}
