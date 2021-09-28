using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IMessage_Operations
    {
        Task<Message> Create(Message objectToAdd);
        Task<Message> Read(Int64 entityId);
        Task<List<Message>> ReadAll();
        Task<Message> Update(Message objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
