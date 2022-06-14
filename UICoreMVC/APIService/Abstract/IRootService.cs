using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UICoreMVC.APIService.Abstract
{
    public interface IRootService
    {
        public Task<List<Root>> Listele();
        public Task<List<Root>> CapitalAra(string key);
        public Task<List<Root>> GenelArama(string key);
    }
}
