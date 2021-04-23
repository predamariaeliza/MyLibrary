
using System;

namespace Core.Entities
{
    /*
        avem 2 coloane in tabela 'Products' : Id si name 
    */
    public class Product : BaseEntity
    {  
           public string Name { get; set; }
           public string Description { get; set; }
           public decimal Price { get; set; }
           public string PictureUrl { get; set; }
           public ProductType ProductType { get; set; }
           public int ProductTypeId { get; set; }
           public ProductBrand ProductBrand { get; set; }
           public int ProductBrandId { get; set; }
           
    }
}