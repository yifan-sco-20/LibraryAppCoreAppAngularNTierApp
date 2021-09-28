using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IReply_Operations
    {
        Task<Reply> Create(Reply objectToAdd);
        Task<Reply> Read(Int64 entityId);
        Task<List<Reply>> ReadAll();
        Task<Reply> Update(Reply objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
