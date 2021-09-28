using LOGIC.Services.Models;
using LOGIC.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IUser_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<User_ResultSet>>> GetAllUsers();
        Task<Generic_ResultSet<User_ResultSet>> GetUserById(Int64 id);

        //Task<Generic_ResultSet<User_ResultSet>> GetUserByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<User_ResultSet>> AddUser(string name);
        Task<Generic_ResultSet<User_ResultSet>> UpdateUser(Int64 id, string name, string email);
        Task<Generic_ResultSet<bool>> DeleteUser(Int64 id);
    }
}
