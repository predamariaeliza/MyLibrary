using System;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Data
{
    //implementam interfata IBasketRepository
    public class BasketRepository : IBasketRepository
    {
        //conexiune DataBase
        private readonly IDatabase _database;

        //generam un constructor pentru a injecta ce avem nevoie
        public BasketRepository(IConnectionMultiplexer redis)
        {
            //creem conexiunea catre DB pentru a adauga/update/sterge un cos de cumparaturi
            _database = redis.GetDatabase();
        }

        // DELETE Basket
        // async Task - intrucat returnam un task
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
                                    // basketId va fi stocat ca si valoare string in DB redis
            var data = await _database.StringGetAsync(basketId);

            //daca avem 'data', vom deserializa acea informatie in CustomerBasket, altfel returnam null
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        //UPDATE Basket / CREATE Basket
        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            //inlocuim basket-ul existent in Db redis cu orice update vine din partea utilizatorului ca nou basket
            var created = await _database.StringSetAsync(basket.Id, 
                JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
                // StringSetAsync = vechiul string, pe care il inlocuim cu noua versiune a basket-ului
                // TimeSpan.FromDays(30) = cate zile pastram in memorie lista cosului de cumparaturi
            
            //verificam daca basket-ul a fost creat
            if (!created) return null;
            
            return await GetBasketAsync(basket.Id);
        }
    }
}