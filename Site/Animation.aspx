<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Animation.aspx.cs" Inherits="Animation" %>
<%@ Register assembly="Artem.Google" namespace="Artem.Google.UI" tagprefix="artem" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">

    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager> 
    <div class="map">
        <asp:Label ID="Label1" runat="server" Width="1000px" CssClass="lbl"></asp:Label> 
        <div style="height: 600px; width: auto;">
            <artem:GoogleMap ID="GoogleMap1" runat="server" Width="100%" Height="600px" Key="AIzaSyAXe-NlSf2-39t-YM8iqsXoKrZwcHqTe70"
                Latitude="46.1229" Longitude="15.07879" Zoom="8" EnableViewState="false" MapType="Roadmap" >
            </artem:GoogleMap>    
        </div>
    </div>
</asp:Content>
