using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repository
{
    public interface IRepositoryRisk
    {
        List<Risks> GetListAll();

        Risks GetRisks(int id);

        void CreateRisks(Risks risksNew);

        void UpdateRisks(Risks risks);

        void DeleteRisks(Risks risks);
    }
}
