using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Data.Entities;

namespace TimedAssignment.Services.HateServices
{

    public class IHateService
    {
        

   public interface IHateService
    {
        Task<List<Hate>> GetAllHates();

    }
}
}