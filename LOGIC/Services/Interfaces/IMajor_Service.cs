using LOGIC.Services.Models;
using LOGIC.Services.Models.Major;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IMajor_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Major_ResultSet>>> GetAllMajors();
        Task<Generic_ResultSet<Major_ResultSet>> GetMajorById(Int64 id);

        //Task<Generic_ResultSet<Major_ResultSet>> GetMajorByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Major_ResultSet>> AddMajor(string name);
        Task<Generic_ResultSet<Major_ResultSet>> UpdateMajor(Int64 id, string name);
        Task<Generic_ResultSet<bool>> DeleteMajor(Int64 id);

    }
}

