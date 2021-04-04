using System;
using System.Collections.Generic;

namespace DelVeggieConsoleApp.BusinessLayer
{
    public interface IVeggieService
    {
        List<Veggie> GetVeggieList();
        
        Veggie GetVeggie(string id);
    } 
    
}