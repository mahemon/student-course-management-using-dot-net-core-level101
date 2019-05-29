using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CST.Models
{
    public class TeachersAccount
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string accountType { get; set; }
        public decimal amount { get; set; }

        public Teacher Teacher { get; set; }
    }
}
