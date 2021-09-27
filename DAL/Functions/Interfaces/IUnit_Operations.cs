using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IUnit_Operations
    {
        Task<Unit> Create(Unit objectToAdd);
        Task<Unit> Read(Int64 entityId);
        Task<List<Unit>> ReadAll();
        Task<Unit> Update(Unit objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
