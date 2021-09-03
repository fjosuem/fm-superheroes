using SuperHero.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHero.Domain.Concrete
{
    public class ResponseHero
    {
        public Hero currentHero { get; set; }
        public List<Hero> currentHeroes { get; set; }
        public string MessageError { get; set; }
    }
}
