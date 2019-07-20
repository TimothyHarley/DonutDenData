using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutDenData.Models
{
    public class CookType
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
