<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="Scripts/slider.js"></script>
    <style type="text/css">        
        #pollSlider {
            position:fixed;
            height:500px;
            background: url(images/Opacity.png) no-repeat;
            width:300px;
            top: 150px;
            right:0px;
            margin-right: -300px;
        }
        
        #pollSlider-bottom {
            position:fixed;
            height:30px;
            background: url(images/OpacityBottom.png) no-repeat;
            width:300px;
            right:0px;
            top: 630px;
            margin-right: -300px;
        }
        
        #pollSlider-top {
            position:fixed;
            height:30px;
            background: url(images/OpacityTop.png) no-repeat;
            width:300px;
            right:0px;
            top: 100px;
            margin-right: -300px;
        }
        #pollSlider-button {
            position:fixed;
            width:40px;
            height:150px;
            right:0px;
            background: url(images/arrowOpen.png) no-repeat center top;
            top:300px;
        }​
        
        .lbl
        {
            color: Yellow; 
            height: 100px;
            width: 100px;
            border: 5px solid red;
              
        }
        .mapGoogle
        {
            right:0;
            bottom:0;
            top:0;
            left: 0;
            margin-top: 100px;
            padding-bottom: 50px;
            position: fixed;
        }
        
        .panelasp
        {
            margin: 30px;  
            background-color: green;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <!-- ************ START SLIDING PANEL *************** -->
    
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server" ViewStateMode="Enabled" RenderMode="Inline">
        <ContentTemplate>
            <div class="mapGoogle">
                <artem:GoogleMap ID="GoogleMap1" runat="server" Width="100%" Height="100%">
                </artem:GoogleMap>
            </div>
        <artem:GoogleMarkers TargetControlID="GoogleMap1" runat="server">
            <Markers>
                <artem:Marker Position-Latitude="46.06160082" Position-Longitude="14.52628776" Title="Click on the marker"
                    Info="Text of marker 2">
                </artem:Marker>
            </Markers>
        </artem:GoogleMarkers>
            <asp:Button ID="button" runat="server" Text="Button" CssClass="buttonTest" 
                onclick="button_Click"/>
        </ContentTemplate>
    </asp:UpdatePanel>


    <div id="pollSlider">
    </div>
    <div id="pollSlider-button"></div>​

    <!-- ************ END SLIDING PANEL *************** -->
</asp:Content>
