using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IUser_Operations
    {
        Task<User> Create(User objectToAdd);
        Task<User> Read(Int64 entityId);
        Task<List<User>> ReadAll();
        Task<User> Update(User objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
