using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexASPNET.Models
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PrimaryType { get; set; }
        public string SecondaryType { get; set; }
        public bool Caught { get; set; }
        public int EvolvesTo { get; set; }
        public int Pid { get; set; }

    }
}
