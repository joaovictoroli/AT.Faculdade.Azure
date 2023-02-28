using AT_Joao.BLL.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Joao.BLL.Models.Entities
{
    public class Country : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public IEnumerable<State> CountryStates { get; set; }

    }
}
