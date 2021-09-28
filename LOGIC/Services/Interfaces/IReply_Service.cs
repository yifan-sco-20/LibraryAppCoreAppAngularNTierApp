using LOGIC.Services.Models;
using LOGIC.Services.Models.Reply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IReply_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Reply_ResultSet>>> GetAllReplys();
        Task<Generic_ResultSet<Reply_ResultSet>> GetReplyById(Int64 id);

        //Task<Generic_ResultSet<Reply_ResultSet>> GetReplyByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Reply_ResultSet>> AddReply(string content);
        Task<Generic_ResultSet<Reply_ResultSet>> UpdateReply(Int64 id, string content);
        Task<Generic_ResultSet<bool>> DeleteReply(Int64 id);
    }
}
