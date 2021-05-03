using System.Collections.Generic;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public interface IKindOfProjectRepository
    {
        IEnumerable<KindOfProject> GetAllKinds();
        IEnumerable<KindOfProject> GetAllKindsForRole(int roleId);
        bool CreateRelationship(int roleId, int kindId);
        KindOfProject GetKindById(int kindId);
    }
}