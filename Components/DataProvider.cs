using System;
using System.Data;
using DotNetNuke;
using DotNetNuke.Framework;

namespace GIBS.PARentals_Schedule.Components
{
    public abstract class DataProvider
    {

        #region common methods

        /// <summary>
        /// var that is returned in the this singleton
        /// pattern
        /// </summary>
        private static DataProvider instance = null;

        /// <summary>
        /// private static cstor that is used to init an
        /// instance of this class as a singleton
        /// </summary>
        static DataProvider()
        {
            instance = (DataProvider)Reflection.CreateObject("data", "GIBS.PARentals_Schedule.Components", "");
        }

        /// <summary>
        /// Exposes the singleton object used to access the database with
        /// the conrete dataprovider
        /// </summary>
        /// <returns></returns>
        public static DataProvider Instance()
        {
            return instance;
        }

        #endregion


        #region Abstract methods

        public abstract IDataReader Rentals_Schedule_GetAvailability(int propertyID);



        /* implement the methods that the dataprovider should */

        public abstract IDataReader GetPARentals_Schedules(int moduleId);
        public abstract IDataReader GetPARentals_Schedule(int moduleId, int itemId);
        public abstract void AddPARentals_Schedule(int moduleId, string content, int userId);
        public abstract void UpdatePARentals_Schedule(int moduleId, int itemId, string content, int userId);
        public abstract void DeletePARentals_Schedule(int moduleId, int itemId);

        #endregion

    }



}
