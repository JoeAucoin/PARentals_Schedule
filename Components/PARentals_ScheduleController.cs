using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace GIBS.PARentals_Schedule.Components
{
    public class PARentals_ScheduleController : IPortable
    {

        #region public method


        public List<PARentals_ScheduleInfo> Rentals_Schedule_GetAvailability(int propertyID)
        {
            return CBO.FillCollection<PARentals_ScheduleInfo>(DataProvider.Instance().Rentals_Schedule_GetAvailability(propertyID));
        }


        /// <summary>
        /// Gets all the PARentals_ScheduleInfo objects for items matching the this moduleId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<PARentals_ScheduleInfo> GetPARentals_Schedules(int moduleId)
        {
            return CBO.FillCollection<PARentals_ScheduleInfo>(DataProvider.Instance().GetPARentals_Schedules(moduleId));
        }

        /// <summary>
        /// Get an info object from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public PARentals_ScheduleInfo GetPARentals_Schedule(int moduleId, int itemId)
        {
            return (PARentals_ScheduleInfo)CBO.FillObject(DataProvider.Instance().GetPARentals_Schedule(moduleId, itemId), typeof(PARentals_ScheduleInfo));
        }


        /// <summary>
        /// Adds a new PARentals_ScheduleInfo object into the database
        /// </summary>
        /// <param name="info"></param>
        public void AddPARentals_Schedule(PARentals_ScheduleInfo info)
        {
            //check we have some content to store
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().AddPARentals_Schedule(info.ModuleId, info.Content, info.CreatedByUserID);
            }
        }

        /// <summary>
        /// update a info object already stored in the database
        /// </summary>
        /// <param name="info"></param>
        public void UpdatePARentals_Schedule(PARentals_ScheduleInfo info)
        {
            //check we have some content to update
            if (info.Content != string.Empty)
            {
                DataProvider.Instance().UpdatePARentals_Schedule(info.ModuleId, info.ItemId, info.Content, info.CreatedByUserID);
            }
        }


        /// <summary>
        /// Delete a given item from the database
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="itemId"></param>
        public void DeletePARentals_Schedule(int moduleId, int itemId)
        {
            DataProvider.Instance().DeletePARentals_Schedule(moduleId, itemId);
        }


        #endregion

        //#region ISearchable Members

        ///// <summary>
        ///// Implements the search interface required to allow DNN to index/search the content of your
        ///// module
        ///// </summary>
        ///// <param name="modInfo"></param>
        ///// <returns></returns>
        //public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(ModuleInfo modInfo)
        //{
        //    SearchItemInfoCollection searchItems = new SearchItemInfoCollection();

        //    List<PARentals_ScheduleInfo> infos = GetPARentals_Schedules(modInfo.ModuleID);

        //    foreach (PARentals_ScheduleInfo info in infos)
        //    {
        //        SearchItemInfo searchInfo = new SearchItemInfo(modInfo.ModuleTitle, info.Content, info.CreatedByUserID, info.CreatedDate,
        //                                            modInfo.ModuleID, info.ItemId.ToString(), info.Content, "Item=" + info.ItemId.ToString());
        //        searchItems.Add(searchInfo);
        //    }

        //    return searchItems;
        //}

        //#endregion

        #region IPortable Members

        /// <summary>
        /// Exports a module to xml
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        public string ExportModule(int moduleID)
        {
            StringBuilder sb = new StringBuilder();

            List<PARentals_ScheduleInfo> infos = GetPARentals_Schedules(moduleID);

            if (infos.Count > 0)
            {
                sb.Append("<PARentals_Schedules>");
                foreach (PARentals_ScheduleInfo info in infos)
                {
                    sb.Append("<PARentals_Schedule>");
                    sb.Append("<content>");
                    sb.Append(XmlUtils.XMLEncode(info.Content));
                    sb.Append("</content>");
                    sb.Append("</PARentals_Schedule>");
                }
                sb.Append("</PARentals_Schedules>");
            }

            return sb.ToString();
        }

        /// <summary>
        /// imports a module from an xml file
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <param name="Content"></param>
        /// <param name="Version"></param>
        /// <param name="UserID"></param>
        public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        {
            XmlNode infos = DotNetNuke.Common.Globals.GetContent(Content, "PARentals_Schedules");

            foreach (XmlNode info in infos.SelectNodes("PARentals_Schedule"))
            {
                PARentals_ScheduleInfo PARentals_ScheduleInfo = new PARentals_ScheduleInfo();
                PARentals_ScheduleInfo.ModuleId = ModuleID;
                PARentals_ScheduleInfo.Content = info.SelectSingleNode("content").InnerText;
                PARentals_ScheduleInfo.CreatedByUserID = UserID;

                AddPARentals_Schedule(PARentals_ScheduleInfo);
            }
        }

        #endregion
    }
}
