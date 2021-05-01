using System.Collections.Generic;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public interface IKindOfProjectRepository
    {
        IEnumerable<KindOfProject> GetAllKinds();
        KindOfProject GetKindById(int kindId);
    }
}