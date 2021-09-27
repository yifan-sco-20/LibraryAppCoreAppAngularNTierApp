using LOGIC.Services.Models;
using LOGIC.Services.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface ITeacher_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Teacher_ResultSet>>> GetAllTeachers();
        Task<Generic_ResultSet<Teacher_ResultSet>> GetTeacherById(Int64 id);

        //Task<Generic_ResultSet<Teacher_ResultSet>> GetTeacherByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Teacher_ResultSet>> AddTeacher(string name);
        Task<Generic_ResultSet<Teacher_ResultSet>> UpdateTeacher(Int64 id, string name);
        Task<Generic_ResultSet<bool>> DeleteTeacher(Int64 id);
    }
}
