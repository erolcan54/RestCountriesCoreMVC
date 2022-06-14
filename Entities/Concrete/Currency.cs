using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Currency:IEntity
    {
        public string code { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
    }

    

    

    

    

    


}
