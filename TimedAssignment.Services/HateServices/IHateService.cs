using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Data.Entities;
using TimedAssignment.Models.Hates;

namespace TimedAssignment.Services.HateServices
{
    public interface IHateService
    {
        Task<List<Hate>> GetAllHates();

        Hate CreateHate(HateCreate hateCreate);

        List<Hate> GetHatesByPostId(int postId);
        List<Hate> GetHatesByOwnerId(Guid ownerId);


        Hate UpdateHate(int hateId, HateEdit hateEdit);

        void DeleteHate(int hateId);
        object GetHatesByOwnerId(string ownerId);
    }
}