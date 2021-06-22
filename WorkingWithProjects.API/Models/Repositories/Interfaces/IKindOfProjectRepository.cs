using System.Collections.Generic;
using System.Threading.Tasks;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public interface IKindOfProjectRepository
    {
        IEnumerable<KindOfProject> GetAllKinds();
        IEnumerable<KindOfProject> GetAllKindsForRole(int roleId);
        bool CreateRelationship(int roleId, int kindId);
        Task<KindOfProject> GetKindById(int kindId);
        KindOfProject UpdateKind(KindOfProject kind);
        KindOfProject AddKind(KindOfProject kind);
        KindOfProject DeleteKind(int id);
    }
}