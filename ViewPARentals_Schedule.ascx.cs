using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;

using GIBS.PARentals_Schedule.Components;

namespace GIBS.Modules.PARentals_Schedule
{
    public partial class ViewPARentals_Schedule : PortalModuleBase, IActionable
    {
        public int _propertyID = 0;
        static int _PAModuleID = 0;
        static int _PATabID = 0;

        protected void Page_Init(object sender, EventArgs e)
        {

            ReadQueryString();

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                SetModuleTitle();

                
                if (!IsPostBack)
                {
                    
                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        public void GetAvailability(int _propID)
        {

            try
            {
                
                PARentals_ScheduleController objController = new PARentals_ScheduleController();
                List<PARentals_ScheduleInfo> objList = objController.Rentals_Schedule_GetAvailability(_propID);

                Repeater1.DataSource = objList;
                Repeater1.DataBind();



            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void Repeater1_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            //            <td><asp:Label ID="lblStartDate" runat="server" Text="" /></td>
            //<td><asp:Label ID="lblEndDate" runat="server" Text="Label" /></td>
            //<td><asp:Label ID="lblRent" runat="server" Text="Label" /></td>

            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    
                   

                    Label _Start = (Label)e.Item.FindControl("lblStartDate");
                    Label _End = (Label)e.Item.FindControl("lblEndDate");
                    Label _Rent = (Label)e.Item.FindControl("lblRent");

                    DateTime _start = DateTime.Parse(DataBinder.Eval(e.Item.DataItem, "DateStart").ToString());
                    DateTime _end = DateTime.Parse(DataBinder.Eval(e.Item.DataItem, "DateEnd").ToString());	
                    decimal _RentAmt =  decimal.Parse(DataBinder.Eval(e.Item.DataItem, "RentalAmount").ToString());

                    _Start.Text = _start.ToShortDateString();
                    _End.Text = _end.ToShortDateString();
                    _Rent.Text = _RentAmt.ToString("C0");

                    




                }


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void SetModuleTitle()
        {

            try
            {
                if (_propertyID > 0)
                {
                    this.ModuleConfiguration.ModuleTitle = "Availibility";
                    GetAvailability(_propertyID);

                }
                else
                {
                    this.ModuleConfiguration.ModuleTitle = "";
                 //   lblDebug.Text = "ERROR - No PID";
                }

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void ReadQueryString()
        {

            try
            {




                if (Request.QueryString["PropertyID"] != null)
                {
                    _propertyID = Int32.Parse(Request.QueryString["PropertyID"].ToString());
               //     lblDebug.Text = _propertyID.ToString();

                }




            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void GetSettings()
        {

            try
            {


                PARentals_ScheduleSettings settingsData = new PARentals_ScheduleSettings(this.TabModuleId);




                if (settingsData.PA_ModuleID != null)
                {

                    string s = settingsData.PA_ModuleID.ToString();
                    string[] parts = s.Split('-');
                    string i1 = parts[0];
                    string i2 = parts[1];

                    _PAModuleID = Convert.ToInt32(i2);
                    _PATabID = Convert.ToInt32(i1);
                }

 






            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }



        #region IActionable Members

        public DotNetNuke.Entities.Modules.Actions.ModuleActionCollection ModuleActions
        {
            get
            {
                //create a new action to add an item, this will be added to the controls
                //dropdown menu
                ModuleActionCollection actions = new ModuleActionCollection();
                //actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.AddContent, this.LocalResourceFile),
                //    ModuleActionType.AddContent, "", "", EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit,
                //     true, false);

                return actions;
            }
        }

        #endregion


        /// <summary>
        /// Handles the items being bound to the datalist control. In this method we merge the data with the
        /// template defined for this control to produce the result to display to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       

    }
}