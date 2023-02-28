using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Joao.BLL.Models.DTO
{
    public class StateDTO
    {
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public CountryDTO Country { get; set; }        
    }
}
