
using System;

namespace Core.Entities
{
    /*
        avem 2 coloane in tabela 'Products' : Id si name 
    */
    public class Product
    {
        // int Id -> prin conventie: primary key, autogenereaza un nou id de fiecare data cand apare o noua inregistrare in tabel 
           public int Id { get; set; } 
           public String Name { get; set; }
           
    }
}