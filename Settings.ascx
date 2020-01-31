<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="GIBS.Modules.PARentals_Schedule.Settings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>



<div class="dnnForm" id="form-settings">


    <fieldset>

<dnn:sectionhead id="sectGeneralSettings" cssclass="Head" runat="server" text="General Settings" section="GeneralSection"
	includerule="False" isexpanded="True"></dnn:sectionhead>

<div id="GeneralSection" runat="server">   


                    		
    <div class="dnnFormItem">					
        <dnn:label id="lblPAModuleID" runat="server" suffix=":" controlname="drpModuleID" ResourceKey="lblPAModuleID" />
	    <asp:dropdownlist id="ddlPAModuleID" Runat="server" datavaluefield="ModuleID" datatextfield="ModuleTitle"></asp:dropdownlist>
    </div>	

			

 </div>
        			


  




    </fieldset>

</div>



	