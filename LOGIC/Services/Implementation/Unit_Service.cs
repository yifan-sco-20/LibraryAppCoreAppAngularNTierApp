using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Unit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Unit unit Data
    /// </summary>
    public class Unit_Service : IUnit_Service
    {
        //Reference to our crud functions
        private IUnit_Operations _unit_operations = new Unit_Operations();

        /// <summary>
        /// Obtains all the Unit unites that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Unit_ResultSet>>> GetAllUnits()
        {
            Generic_ResultSet<List<Unit_ResultSet>> result = new Generic_ResultSet<List<Unit_ResultSet>>();
            try
            {
                //GET ALL Unit unitES
                List<Unit> Unites = await _unit_operations.ReadAll();
                //MAP DB Unit RESULTS
                result.result_set = new List<Unit_ResultSet>();
                Unites.ForEach(s =>
                {
                    result.result_set.Add(new Unit_ResultSet
                    {
                        unit_id = s.UnitID,
                        name = s.Unit_Name,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Unit unites obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Unit_Service: GetAllUnits() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Unit unites from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Unit_Service: GetAllUnits(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Unit_ResultSet>> GetUnitById(long id)
        {
            Generic_ResultSet<Unit_ResultSet> result = new Generic_ResultSet<Unit_ResultSet>();
            try
            {
                //GET by ID Unit 
                var Unit = await _unit_operations.Read(id);

                //MAP DB Unit RESULTS
                result.result_set = new Unit_ResultSet
                {
                    name = Unit.Unit_Name,
                    unit_id = Unit.UnitID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Unit  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Unit_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Unit  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Unit_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new unit to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Unit_ResultSet>> AddUnit(string name)
        {
            Generic_ResultSet<Unit_ResultSet> result = new Generic_ResultSet<Unit_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Unit
                Unit Unit = new Unit
                {
                    Unit_Name = name
                };

                //ADD Unit TO DB
                Unit = await _unit_operations.Create(Unit);

                //MANUAL MAPPING OF RETURNED Unit VALUES TO OUR Unit_ResultSet
                Unit_ResultSet unitAdded = new Unit_ResultSet
                {
                    name = Unit.Unit_Name,
                    unit_id = Unit.UnitID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Unit unit {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Unit_Service: AddUnit() method executed successfully.";
                result.result_set = unitAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Unit unit supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Unit_Service: AddUnit(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Unit units name.
        /// </summary>
        /// <param name="unit_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Unit_ResultSet>> UpdateUnit(Int64 unit_id, string name)
        {
            Generic_ResultSet<Unit_ResultSet> result = new Generic_ResultSet<Unit_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Unit
                Unit Unit = new Unit
                {
                    UnitID = unit_id,
                    Unit_Name = name,
                    //Unit_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Unit IN DB
                Unit = await _unit_operations.Update(Unit, unit_id);

                //MANUAL MAPPING OF RETURNED Unit VALUES TO OUR Unit_ResultSet
                Unit_ResultSet unitUpdated = new Unit_ResultSet
                {
                    name = Unit.Unit_Name,
                    unit_id = Unit.UnitID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Unit unit {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Unit_Service: UpdateUnit() method executed successfully.";
                result.result_set = unitUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Unit unit supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Unit_Service: UpdateUnit(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteUnit(long unit_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Unit IN DB
                var unitDeleted = await _unit_operations.Delete(unit_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Unit unit {0} was deleted successfully", unit_id);
                result.internalMessage = "LOGIC.Services.Implementation.Unit_Service: DeleteUnit() method executed successfully.";
                result.result_set = unitDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Unit unit supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Unit_Service: DeleteUnit(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
