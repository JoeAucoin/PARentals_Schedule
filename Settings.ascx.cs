using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

using GIBS.PARentals_Schedule.Components;
using DotNetNuke.Entities.Tabs;
using System.Collections;
using System.Collections.Generic;
using DotNetNuke.Security;
using System.Web.UI.WebControls;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Localization;

namespace GIBS.Modules.PARentals_Schedule
{
    public partial class Settings : ModuleSettingsBase
    {

        /// <summary>
        /// handles the loading of the module setting for this
        /// control
        /// </summary>
        public override void LoadSettings()
        {
            try
            {
                if (!IsPostBack)
                {
                    BindModules();
                    
                    PARentals_ScheduleSettings settingsData = new PARentals_ScheduleSettings(this.TabModuleId);
                    if (settingsData.PA_ModuleID != null)
                    {
                        ddlPAModuleID.SelectedValue = settingsData.PA_ModuleID.ToString();
                        
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        /// <summary>
        /// handles updating the module settings for this control
        /// </summary>
        public override void UpdateSettings()
        {
            try
            {
                PARentals_ScheduleSettings settingsData = new PARentals_ScheduleSettings(this.TabModuleId);
                settingsData.PA_ModuleID = ddlPAModuleID.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        private void BindModules()
        {
            DotNetNuke.Entities.Modules.ModuleController mc = new ModuleController();
            ArrayList existMods = mc.GetModulesByDefinition(this.PortalId, "Property Agent");

            foreach (DotNetNuke.Entities.Modules.ModuleInfo mi in existMods)
            {
                if (!mi.IsDeleted)
                {
                    DotNetNuke.Entities.Tabs.TabController tabController = new DotNetNuke.Entities.Tabs.TabController();
                    DotNetNuke.Entities.Tabs.TabInfo tabInfo = tabController.GetTab(mi.TabID, this.PortalId);
                    string strPath = tabInfo.TabName.ToString();
                    ListItem objListItem = new ListItem();
                    objListItem.Value = mi.TabID.ToString() + "-" + mi.ModuleID.ToString();     // TabID & ModuleID   
                    objListItem.Text = strPath + " -> " + mi.ModuleTitle.ToString();

                    ddlPAModuleID.Items.Add(objListItem);

                }
            }

            ddlPAModuleID.Items.Insert(0, new ListItem(Localization.GetString("SelectModule", this.LocalResourceFile), "-1"));
        }

        


    }
}