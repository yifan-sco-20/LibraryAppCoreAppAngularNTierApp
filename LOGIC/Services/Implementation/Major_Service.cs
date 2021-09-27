using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Major;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Major major Data
    /// </summary>
    public class Major_Service : IMajor_Service
    {
        //Reference to our crud functions
        private IMajor_Operations _major_operations = new Major_Operations();

        /// <summary>
        /// Obtains all the Major majores that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Major_ResultSet>>> GetAllMajors()
        {
            Generic_ResultSet<List<Major_ResultSet>> result = new Generic_ResultSet<List<Major_ResultSet>>();
            try
            {
                //GET ALL Major majorES
                List<Major> Majores = await _major_operations.ReadAll();
                //MAP DB Major RESULTS
                result.result_set = new List<Major_ResultSet>();
                Majores.ForEach(s =>
                {
                    result.result_set.Add(new Major_ResultSet
                    {
                        major_id = s.MajorID,
                        name = s.Major_Name,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Major majores obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Major_Service: GetAllMajors() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Major majores from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Major_Service: GetAllMajors(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Major_ResultSet>> GetMajorById(long id)
        {
            Generic_ResultSet<Major_ResultSet> result = new Generic_ResultSet<Major_ResultSet>();
            try
            {
                //GET by ID Major 
                var Major = await _major_operations.Read(id);

                //MAP DB Major RESULTS
                result.result_set = new Major_ResultSet
                {
                    name = Major.Major_Name,
                    major_id = Major.MajorID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Major  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Major_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Major  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Major_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new major to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Major_ResultSet>> AddMajor(string name)
        {
            Generic_ResultSet<Major_ResultSet> result = new Generic_ResultSet<Major_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Major
                Major Major = new Major
                {
                    Major_Name = name
                };

                //ADD Major TO DB
                Major = await _major_operations.Create(Major);

                //MANUAL MAPPING OF RETURNED Major VALUES TO OUR Major_ResultSet
                Major_ResultSet majorAdded = new Major_ResultSet
                {
                    name = Major.Major_Name,
                    major_id = Major.MajorID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Major major {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Major_Service: AddMajor() method executed successfully.";
                result.result_set = majorAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Major major supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Major_Service: AddMajor(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Major majors name.
        /// </summary>
        /// <param name="major_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Major_ResultSet>> UpdateMajor(Int64 major_id, string name)
        {
            Generic_ResultSet<Major_ResultSet> result = new Generic_ResultSet<Major_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Major
                Major Major = new Major
                {
                    MajorID = major_id,
                    Major_Name = name,
                    //Major_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Major IN DB
                Major = await _major_operations.Update(Major, major_id);

                //MANUAL MAPPING OF RETURNED Major VALUES TO OUR Major_ResultSet
                Major_ResultSet majorUpdated = new Major_ResultSet
                {
                    name = Major.Major_Name,
                    major_id = Major.MajorID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Major major {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Major_Service: UpdateMajor() method executed successfully.";
                result.result_set = majorUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Major major supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Major_Service: UpdateMajor(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteMajor(long major_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Major IN DB
                var majorDeleted = await _major_operations.Delete(major_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Major major {0} was deleted successfully", major_id);
                result.internalMessage = "LOGIC.Services.Implementation.Major_Service: DeleteMajor() method executed successfully.";
                result.result_set = majorDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Major major supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Major_Service: DeleteMajor(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
