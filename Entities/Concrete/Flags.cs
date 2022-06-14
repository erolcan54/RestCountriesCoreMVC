using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Flags:IEntity
    {
        public string svg { get; set; }
        public string png { get; set; }
    }
}
