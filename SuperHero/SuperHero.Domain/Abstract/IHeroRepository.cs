using SuperHero.Domain.Concrete;
using System.Threading.Tasks;

namespace SuperHero.Domain.Abstract
{
    public interface IHeroRepository
    {
        Task<ResponseHero> HeroByStringSearch(string searchString);
        Task<ResponseHero> HeroById(int id);
    }
}
