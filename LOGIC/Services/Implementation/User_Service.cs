using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    public class User_Service : IUser_Service
    {
        //Reference to our crud functions
        private IUser_Operations _user_operations = new User_Operations();

        /// <summary>
        /// Obtains all the User useres that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<User_ResultSet>>> GetAllUsers()
        {
            Generic_ResultSet<List<User_ResultSet>> result = new Generic_ResultSet<List<User_ResultSet>>();
            try
            {
                //GET ALL User userES
                List<User> Useres = await _user_operations.ReadAll();
                //MAP DB User RESULTS
                result.result_set = new List<User_ResultSet>();
                Useres.ForEach(s =>
                {
                    result.result_set.Add(new User_ResultSet
                    {
                        userid = s.UserID,
                        user_email=s.User_Email,
                        username = s.Username,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All User useres obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: GetAllUsers() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required User useres from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: GetAllUsers(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<User_ResultSet>> GetUserById(long id)
        {
            Generic_ResultSet<User_ResultSet> result = new Generic_ResultSet<User_ResultSet>();
            try
            {
                //GET by ID User 
                var User = await _user_operations.Read(id);

                //MAP DB User RESULTS
                result.result_set = new User_ResultSet
                {
                    username = User.Username,
                    userid = User.UserID,
                    user_email = User.User_Email
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - User  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required User  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new user to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<User_ResultSet>> AddUser(string name)
        {
            Generic_ResultSet<User_ResultSet> result = new Generic_ResultSet<User_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF User
                User User = new User
                {
                    Username = name
                };

                //ADD User TO DB
                User = await _user_operations.Create(User);

                //MANUAL MAPPING OF RETURNED User VALUES TO OUR User_ResultSet
                User_ResultSet userAdded = new User_ResultSet
                {
                    username = User.User_Email,
                    userid = User.UserID,
                    user_email = User.User_Email
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied User user {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: AddUser() method executed successfully.";
                result.result_set = userAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the User user supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: AddUser(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an User users name.
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<User_ResultSet>> UpdateUser(Int64 user_id, string name, string email)
        {
            Generic_ResultSet<User_ResultSet> result = new Generic_ResultSet<User_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF User
                User User = new User
                {
                    UserID = user_id,
                    Username = name,
                    User_Email = email
                    //User_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE User IN DB
                User = await _user_operations.Update(User, user_id);

                //MANUAL MAPPING OF RETURNED User VALUES TO OUR User_ResultSet
                User_ResultSet userUpdated = new User_ResultSet
                {
                    username = User.Username,
                    userid = User.UserID,
                    user_email = User.User_Email
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied User user {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: UpdateUser() method executed successfully.";
                result.result_set = userUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the User user supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: UpdateUser(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteUser(long user_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete User IN DB
                var userDeleted = await _user_operations.Delete(user_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied User user {0} was deleted successfully", user_id);
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: DeleteUser() method executed successfully.";
                result.result_set = userDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the User user supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: DeleteUser(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}
