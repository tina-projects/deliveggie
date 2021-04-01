using System;
using System.Collections.Generic;

namespace DelVeggieAPI.DAL
{
    public interface IVeggieDal
    {
        List<Veggie> GetVeggieList();
    } 
    
}