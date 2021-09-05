using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperHero.Domain.Abstract;
using SuperHero.Domain.Concrete;
using System;
using System.Threading.Tasks;

namespace SuperHero.Tests
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public async Task SearchByIdTest()
        {
            // Looking for wolverine super hero
            // Id 717 = wolverine
            IHeroRepository repository = new HeroRepository();
            var heroe = await repository.HeroById(717);

            Assert.AreEqual("wolverine", heroe.currentHero.name.ToLower());
        }

        [TestMethod]
        public async Task ErrorSearchByIdTest()
        {
            // Looking for super heroe that doesnot exists by given id
            // Message error must have value
            IHeroRepository repository = new HeroRepository();
            var heroe = await repository.HeroById(71088757);

            Assert.AreNotEqual(heroe.MessageError.Length, 0);

        }

        [TestMethod]
        public async Task SearchByStringTest()
        {
            // Looking for super heroes that starts with "spider" word
            // Length must be more than zero 0
            IHeroRepository repository = new HeroRepository();
            var heroe = await repository.HeroByStringSearch("spider");

            Assert.AreNotEqual(heroe.currentHeroes.Count, 0);

        }

        [TestMethod]
        public async Task ErrorSearchByStringTest()
        {
            // Looking for super heroes that doesnot exist
            // Message error must have value
            IHeroRepository repository = new HeroRepository();
            var heroe = await repository.HeroByStringSearch("thisisnotanheroname");

            Assert.AreNotEqual(heroe.MessageError.Length, 0);

        }
    }
}
