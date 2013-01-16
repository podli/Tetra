<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register assembly="Artem.Google" namespace="Artem.Google.UI" tagprefix="artem" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="Scripts/slider.js"></script>
    <script src="http://code.jquery.com/jquery-1.8.3.js"></script>
    <script src="http://code.jquery.com/ui/1.9.2/jquery-ui.js"></script>
    <script type="text/javascript">
        function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;

            //Get the reference of GridView
            var GridView = row.parentNode;

            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];

                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;

        }

        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        if (row.rowIndex % 2 == 0) {
                            row.style.backgroundColor = "#C2D69B";
                        }
                        else {
                            row.style.backgroundColor = "white";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("#accordion").accordion({
                heightStyle: "content"
            });
        });
    </script>
    <script type="text/javascript" language="javascript">
        function SetupAccordion() {
            $("#accordion").accordion({
                heightStyle: "content"
            });
        }
        $(document).ready(function () {
            SetupAccordion();
            if (typeof Sys.WebForms != 'undefined') {
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(SetupAccordion);
            }
        });   
</script>
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
        
        #pollSliderBottom {
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
        #pollSliderButton {
            position:fixed;
            width:40px;
            height:150px;
            right:0px;
            background: url(images/arrowOpen.png) no-repeat center top;
            top:300px;
        }​
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager> 
    <div class="exceptHeader">
        <div id="AllDefaultDivNotLoggedIn" runat="server" visible="true">
            <div style="height: 100px;"></div>
            <asp:Label ID="lblLogout" runat="server" Width="200px" Height="50px"></asp:Label>
        </div>
        
        <!--  ***** START TIMER STUFF *********-->
        <div id="AllDefaultDiv" runat="server" visible="false">
            <div>
                <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="4000" Enabled="false">
                </asp:Timer>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server" ViewStateMode="Enabled" RenderMode="Inline">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                </Triggers>
                <ContentTemplate>
                <div class="map">
                    <artem:GoogleMap ID="GoogleMap1" runat="server" Width="100%" Height="100%" Key="AIzaSyAXe-NlSf2-39t-YM8iqsXoKrZwcHqTe70"
                        Latitude="46.06160082" Longitude="14.52628776" Zoom="14" EnableViewState="false" MapType="Roadmap">
                    </artem:GoogleMap>     
                </div>
                <div id="pollSlider" runat="server" clientidmode="Static">
                    <div id="accordion" style="margin: 10px 10px 10px 10px;">
                        <h3>Izbira postaj za prikaz</h3>
                        <div style="padding-left: 60px;">
                            <asp:GridView ID="gvAll" runat="server" 
                                AutoGenerateColumns = "false" Font-Names = "Arial"
                                Font-Size = "11pt" AlternatingRowStyle-BackColor = "#dde4ec" HeaderStyle-ForeColor="#dde4ec"
                                HeaderStyle-BackColor = "#507CD1" AllowPaging ="true"   
                                OnPageIndexChanging = "OnPaging" PageSize = "10" >
                               <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" onclick = "checkAll(this);" 
                                        AutoPostBack = "true"  OnCheckedChanged = "CheckBox_CheckChanged"/>
                                    </HeaderTemplate> 
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" onclick = "Check_Click(this)" 
                                        AutoPostBack = "true"  OnCheckedChanged = "CheckBox_CheckChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                <asp:BoundField DataField = "deviceID" HeaderText = "ID postaje"
                                    HtmlEncode = "false" />
                                <asp:BoundField DataField = "veichleID" HeaderText = "ID vozila"
                                    HtmlEncode = "false" />
                               </Columns> 
                               <AlternatingRowStyle BackColor="#dde4ec"  />
                            </asp:GridView>
                            <asp:Table runat="server" ID="tblTag"></asp:Table>
                            <asp:GridView ID="gvSelected" runat="server" 
                            AutoGenerateColumns = "false" Font-Names = "Arial" 
                            Font-Size = "11pt" AlternatingRowStyle-BackColor = "#C2D69B"  
                            HeaderStyle-BackColor = "green" EmptyDataText = "No Records Selected"  Visible="false">
                                <Columns>
                                    <asp:BoundField DataField = "deviceID" HeaderText = "deviceID" />
                                    <asp:BoundField DataField = "veichleID" HeaderText = "ID vozila" />
                                 </Columns>
                            </asp:GridView>
                            <asp:GridView ID="gvDrawOnMap" runat="server"></asp:GridView>
                        </div>
                        <h3>Izbira opreme za prikaz</h3>
                        <div>
                            <p>Če bomo slučajno potrebovali še kak dodaten meni po moje bomo :) </p>
                        </div>  
                        <h3>Stran osvežena</h3>
                        <div>
                            <asp:Label ID="lblRefresh" runat="server"></asp:Label>
                        </div>
                    </div>

                    
                    <div id="contentDivImg" style="display: none;">
                        <asp:Label ID="lblButton1" runat="server" Text="Avtomatsko osveževanje: " Font-Size="16px"></asp:Label>
                        <asp:ImageButton ID="Button1" runat="server" ImageUrl="~/Images/plus.png" ImageAlign="AbsMiddle" onclick="Button1_Click"/>            
                        <asp:Button ID="Button2" runat="server" Text="Osveži"  Font-Size="16px" onclick="Button2_Click" />
                    </div>
                    <div style="width:200px; float: left;">
                        

                    </div>
                </div>
                <div id="pollSliderButton" runat="server" clientidmode="Static"></div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <!--  ***** END TIMER STUFF *********-->
    </div>
</asp:Content>
