
using System;

namespace Core.Entities
{
    
    public class Product : BaseEntity
    {  
         // Property
         // GET method - returns the value of the variable name.
         // SET method - assigns a value to the name variable. 
           public string Name { get; set; }
           
           // GET - returneaza valoarea variabilei description
           // SET - atribuie o valoare variabilei Description
           public string Description { get; set; }

           // GET - returneaza valoarea variabilei price
           // SET - atribuie o valoare variabilei price
           public decimal Price { get; set; }

           public string PictureUrl { get; set; }
           public ProductType ProductType { get; set; }
           public int ProductTypeId { get; set; }
           public ProductBrand ProductBrand { get; set; }
           public int ProductBrandId { get; set; }
           
    }
}