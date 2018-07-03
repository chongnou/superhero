using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Superhero.Models
{
    public class Superheroes
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string AlterEgo { get; set; }

        public string PrimarySuperheroAbility { get; set; }

        public string SecondarySuperheroAbility { get; set; }

        public string Catchphrase { get; set; }

    }
}