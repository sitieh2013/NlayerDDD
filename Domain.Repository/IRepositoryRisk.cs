using Domain.Core.Paged;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repository
{
    public interface IRepositoryRisk
    {
        IEnumerable<Risks> GetListAll();

        IPage<Risks> GetRiskPages(IPageable paged);

        Risks GetRisks(int id);

        void CreateRisks(Risks risksNew);

        void UpdateRisks(Risks risks);

        void DeleteRisks(Risks risks);
    }
}
