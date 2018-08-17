using DatingApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.Interfaces.Repository
{
    public interface IValueRepo
    {
       Task<IEnumerable<Value>> GetValues();

        Task<Value> GetValue(int id);
    } 
}
