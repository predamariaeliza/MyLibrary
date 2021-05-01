using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBasketRepository
    {
         //get a Basket
         Task<CustomerBasket> GetBasketAsync(string basketId);
         
         //update or create a new Basket
         Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

         //delete the Basket
         Task<bool> DeleteBasketAsync(string basketId);
    }
}