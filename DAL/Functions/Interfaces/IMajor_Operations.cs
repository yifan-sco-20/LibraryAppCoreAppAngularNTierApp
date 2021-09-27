using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IMajor_Operations
    {
        Task<Major> Create(Major objectToAdd);
        Task<Major> Read(Int64 entityId);
        Task<List<Major>> ReadAll();
        Task<Major> Update(Major objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
