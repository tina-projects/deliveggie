using System;
using System.Collections.Generic;

namespace DelVeggieAPI.BusinessLayer
{
    public interface IVeggieService
    {
        List<Veggie> GetVeggieList();
        
        Veggie GetVeggie(string id);
    } 
    
}