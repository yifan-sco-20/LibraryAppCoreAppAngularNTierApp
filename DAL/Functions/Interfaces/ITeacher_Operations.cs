using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface ITeacher_Operations
    {
        Task<Teacher> Create(Teacher objectToAdd);
        Task<Teacher> Read(Int64 entityId);
        Task<List<Teacher>> ReadAll();
        Task<Teacher> Update(Teacher objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
