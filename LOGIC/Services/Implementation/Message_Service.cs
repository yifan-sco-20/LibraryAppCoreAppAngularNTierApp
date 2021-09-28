using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Message;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    public class Message_Service : IMessage_Service
    {
        //Reference to our crud functions
        private IMessage_Operations _message_operations = new Message_Operations();

        /// <summary>
        /// Obtains all the Message messagees that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Message_ResultSet>>> GetAllMessages()
        {
            Generic_ResultSet<List<Message_ResultSet>> result = new Generic_ResultSet<List<Message_ResultSet>>();
            try
            {
                //GET ALL Message messageES
                List<Message> Messagees = await _message_operations.ReadAll();
                //MAP DB Message RESULTS
                result.result_set = new List<Message_ResultSet>();
                Messagees.ForEach(s =>
                {
                    result.result_set.Add(new Message_ResultSet
                    {
                        messageid = s.MessageID,
                        message_content = s.Message_Content,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Message messagees obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Message_Service: GetAllMessages() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Message messagees from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Message_Service: GetAllMessages(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Message_ResultSet>> GetMessageById(long id)
        {
            Generic_ResultSet<Message_ResultSet> result = new Generic_ResultSet<Message_ResultSet>();
            try
            {
                //GET by ID Message 
                var Message = await _message_operations.Read(id);

                //MAP DB Message RESULTS
                result.result_set = new Message_ResultSet
                {
                    message_content = Message.Message_Content,
                    messageid = Message.MessageID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Message  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Message_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Message  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Message_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new message to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Message_ResultSet>> AddMessage(string content)
        {
            Generic_ResultSet<Message_ResultSet> result = new Generic_ResultSet<Message_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Message
                Message Message = new Message
                {
                    Message_Content = content
                };

                //ADD Message TO DB
                Message = await _message_operations.Create(Message);

                //MANUAL MAPPING OF RETURNED Message VALUES TO OUR Message_ResultSet
                Message_ResultSet messageAdded = new Message_ResultSet
                {
                    message_content = Message.Message_Content,
                    messageid = Message.MessageID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Message message {0} was added successfully", content);
                result.internalMessage = "LOGIC.Services.Implementation.Message_Service: AddMessage() method executed successfully.";
                result.result_set = messageAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Message message supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Message_Service: AddMessage(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Message messages name.
        /// </summary>
        /// <param name="message_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Message_ResultSet>> UpdateMessage(Int64 message_id, string content)
        {
            Generic_ResultSet<Message_ResultSet> result = new Generic_ResultSet<Message_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Message
                Message Message = new Message
                {
                    MessageID = message_id,
                    Message_Content = content,
                    //Message_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Message IN DB
                Message = await _message_operations.Update(Message, message_id);

                //MANUAL MAPPING OF RETURNED Message VALUES TO OUR Message_ResultSet
                Message_ResultSet messageUpdated = new Message_ResultSet
                {
                    message_content = Message.Message_Content,
                    messageid = Message.MessageID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Message message {0} was updated successfully", content);
                result.internalMessage = "LOGIC.Services.Implementation.Message_Service: UpdateMessage() method executed successfully.";
                result.result_set = messageUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Message message supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Message_Service: UpdateMessage(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteMessage(long message_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Message IN DB
                var messageDeleted = await _message_operations.Delete(message_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Message message {0} was deleted successfully", message_id);
                result.internalMessage = "LOGIC.Services.Implementation.Message_Service: DeleteMessage() method executed successfully.";
                result.result_set = messageDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Message message supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Message_Service: DeleteMessage(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}
