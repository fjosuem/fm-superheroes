using Newtonsoft.Json;
using SuperHero.Domain.Abstract;
using SuperHero.Domain.Entities;
using SuperHero.Domain.Util;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SuperHero.Domain.Concrete
{
    public class HeroRepository : IHeroRepository
    {
        public async Task<ResponseHero> HeroById(int id)
        {
            ResponseHero response = new ResponseHero();
            using (var client = new HttpClient())
            {
                Hero heroFound = new Hero();
                client.BaseAddress = new Uri(Constants.BASE_URL);
                HttpResponseMessage Res = await client.GetAsync(Constants.URL_SEARCH_BY_ID + id);
                if (Res.IsSuccessStatusCode)
                {
                    var data = Res.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer jsDeserializer = new JavaScriptSerializer();
                    dynamic currentHero = JsonConvert.DeserializeObject<dynamic>(data);

                    if (currentHero?.response == "error")
                    {
                        response.MessageError = currentHero.error;
                        return response;
                    }

                    if (currentHero != null)
                    {
                        heroFound.id = currentHero?.id;
                        heroFound.name = currentHero?.name;
                        heroFound.gender = currentHero.appearance?.gender;
                        heroFound.image = currentHero?.image?.url;
                        heroFound.intelligence = currentHero?.powerstats?.intelligence;
                        heroFound.strength = currentHero?.powerstats?.strength;
                        heroFound.speed = currentHero?.powerstats?.speed;
                        heroFound.durability = currentHero?.powerstats?.durability;
                        heroFound.power = currentHero?.powerstats?.power;
                        heroFound.combat = currentHero?.powerstats?.combat;
                        heroFound.occupation = currentHero?.work?.occupation;
                        heroFound.@base = currentHero?.work?.@base;
                    }
                }
                response.currentHero = heroFound;
                return response;
            }
        }

        public async Task<ResponseHero> HeroByStringSearch(string searchString)
        {
            ResponseHero response = new ResponseHero();
            using (var client = new HttpClient())
            {
                List<Hero> herosFound = new List<Hero>();
                client.BaseAddress = new Uri(Constants.BASE_URL);
                HttpResponseMessage Res = await client.GetAsync(Constants.URL_SEARCH_BY_STRING + searchString);
                if (Res.IsSuccessStatusCode)
                {
                    var data = Res.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer jsDeserializer = new JavaScriptSerializer();
                    dynamic currentHeroes = JsonConvert.DeserializeObject<dynamic>(data);

                    if (currentHeroes?.response == "error")
                    {
                        response.MessageError = currentHeroes.error;
                        return response;
                    }

                    Hero heroFound = new Hero();
                    foreach (var item in currentHeroes.results)
                    {
                        if (currentHeroes != null)
                        {
                            heroFound = new Hero
                            {
                                id = item?.id,
                                name = item?.name,
                                gender = item.appearance?.gender,
                                image = item?.image?.url
                            };
                        }
                        herosFound.Add(heroFound);
                    }
                }
                response.currentHeroes = herosFound;
                return response;
            }
        }
    }
}
