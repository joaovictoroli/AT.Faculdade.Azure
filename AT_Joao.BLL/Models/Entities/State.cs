using AT_Joao.BLL.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Joao.BLL.Models.Entities
{
    public class State : BaseEntity
    {
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }     
        
        public Country Country { get; set; }
    }
}
