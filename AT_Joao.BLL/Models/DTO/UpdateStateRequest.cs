using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Joao.BLL.Models.DTO
{
    public class UpdateStateRequest
    {
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }
    }
}
