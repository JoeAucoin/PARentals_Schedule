<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewPARentals_Schedule.ascx.cs" Inherits="GIBS.Modules.PARentals_Schedule.ViewPARentals_Schedule" %>

<asp:Label ID="lblDebug" runat="server" Text=""></asp:Label>


<asp:Repeater ID="Repeater1" OnItemDataBound="Repeater1_OnItemDataBound" runat="server">
    
    <HeaderTemplate>
  <table class="dnnGrid" width="100%">
    <thead >
       <tr class="dnnGridHeader">
         <th>Starting</th>
         <th>Ending</th>
         <th>Rate</th>
       </tr>
    </thead>
    <tbody>
  </HeaderTemplate>
    
    <ItemTemplate>
	  	<tr class="dnnGridItem">
            <td><asp:Label ID="lblStartDate" runat="server" Text="" /></td>
            <td><asp:Label ID="lblEndDate" runat="server" Text="Label" /></td>
            <td><asp:Label ID="lblRent" runat="server" Text="Label" /></td>
        </tr>
        
        
    </ItemTemplate>
    <AlternatingItemTemplate>
	  	<tr class="dnnGridAltItem">
            <td><asp:Label ID="lblStartDate" runat="server" Text="" /></td>
            <td><asp:Label ID="lblEndDate" runat="server" Text="Label" /></td>
            <td><asp:Label ID="lblRent" runat="server" Text="Label" /></td>
        </tr>    
    
    </AlternatingItemTemplate>
    <FooterTemplate>
    </tbody>
    </table>
  </FooterTemplate>

</asp:Repeater>
