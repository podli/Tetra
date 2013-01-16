<%@ Page Title="Posodobi" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Update.aspx.cs" Inherits="Update" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="width: 500px; margin: 0 auto;padding-top: 20px;">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TetraConnectionStringNew %>" 
            DeleteCommand="DELETE FROM [Data] WHERE [ID] = @ID" 
            InsertCommand="INSERT INTO [Data] ([deviceID], [Latitude], [Longtitude], [Altitude], [TimeStamp], [Alarm]) VALUES (@deviceID, @Latitude, @Longtitude, @Altitude, @TimeStamp, @Alarm)" 
            SelectCommand="SELECT * FROM [Data]" 
            UpdateCommand="UPDATE [Data] SET [deviceID] = @deviceID, [Latitude] = @Latitude, [Longtitude] = @Longtitude, [Altitude] = @Altitude, [TimeStamp] = @TimeStamp, [Alarm] = @Alarm WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="deviceID" Type="Int32" />
                <asp:Parameter Name="Latitude" Type="Decimal" />
                <asp:Parameter Name="Longtitude" Type="Decimal" />
                <asp:Parameter Name="Altitude" Type="Decimal" />
                <asp:Parameter Name="TimeStamp" Type="DateTime" />
                <asp:Parameter Name="Alarm" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="deviceID" Type="Int32" />
                <asp:Parameter Name="Latitude" Type="Decimal" />
                <asp:Parameter Name="Longtitude" Type="Decimal" />
                <asp:Parameter Name="Altitude" Type="Decimal" />
                <asp:Parameter Name="TimeStamp" Type="DateTime" />
                <asp:Parameter Name="Alarm" Type="Boolean" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" Visible="false">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="deviceID" HeaderText="deviceID" 
                    SortExpression="deviceID" />
                <asp:BoundField DataField="Latitude" HeaderText="Latitude" 
                    SortExpression="Latitude" />
                <asp:BoundField DataField="Longtitude" HeaderText="Longtitude" 
                    SortExpression="Longtitude" />
                <asp:BoundField DataField="Altitude" HeaderText="Altitude" 
                    SortExpression="Altitude" />
                <asp:BoundField DataField="TimeStamp" HeaderText="TimeStamp" 
                    SortExpression="TimeStamp" />
                <asp:CheckBoxField DataField="Alarm" HeaderText="Alarm" 
                    SortExpression="Alarm" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
     <div style="width: 400px; margin: 0 auto; padding-top: 20px;">
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TetraConnectionStringNew %>" 
            DeleteCommand="DELETE FROM [mobileUnits] WHERE [deviceID] = @deviceID" 
            InsertCommand="INSERT INTO [mobileUnits] ([deviceID], [veichleID], [AED], [flashlamp], [trioPan], [LightSaber]) VALUES (@deviceID, @veichleID, @AED, @flashlamp, @trioPan, @LightSaber)" 
            SelectCommand="SELECT * FROM [mobileUnits]" 
            
             UpdateCommand="UPDATE [mobileUnits] SET [veichleID] = @veichleID, [AED] = @AED, [flashlamp] = @flashlamp, [trioPan] = @trioPan, [LightSaber] = @LightSaber WHERE [deviceID] = @deviceID">
        <DeleteParameters>
            <asp:Parameter Name="deviceID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="deviceID" Type="Int32" />
            <asp:Parameter Name="veichleID" Type="Int32" />
            <asp:Parameter Name="AED" Type="Boolean" />
            <asp:Parameter Name="flashlamp" Type="Boolean" />
            <asp:Parameter Name="trioPan" Type="Boolean" />
            <asp:Parameter Name="LightSaber" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="veichleID" Type="Int32" />
            <asp:Parameter Name="AED" Type="Boolean" />
            <asp:Parameter Name="flashlamp" Type="Boolean" />
            <asp:Parameter Name="trioPan" Type="Boolean" />
            <asp:Parameter Name="LightSaber" Type="Boolean" />
            <asp:Parameter Name="deviceID" Type="Int32" />
        </UpdateParameters>
        </asp:SqlDataSource>
         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
             CellPadding="4" DataKeyNames="deviceID" DataSourceID="SqlDataSource2" 
             ForeColor="#333333" GridLines="None">
             <AlternatingRowStyle BackColor="White" />
             <Columns>
                 <asp:BoundField DataField="deviceID" HeaderText="deviceID" ReadOnly="True" 
                     SortExpression="deviceID" />
                 <asp:BoundField DataField="veichleID" HeaderText="veichleID" 
                     SortExpression="veichleID" />
                 <asp:CheckBoxField DataField="AED" HeaderText="Jopič" SortExpression="AED" />
                 <asp:CheckBoxField DataField="flashlamp" HeaderText="Čelada" 
                     SortExpression="flashlamp" />
                 <asp:CheckBoxField DataField="trioPan" HeaderText="trioPan" 
                     SortExpression="trioPan" />
                 <asp:CheckBoxField DataField="LightSaber" HeaderText="Trak" 
                     SortExpression="LightSaber" />
                 <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
             </Columns>
             <EditRowStyle BackColor="#2461BF" />
             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
             <RowStyle BackColor="#EFF3FB" />
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             <SortedAscendingCellStyle BackColor="#F5F7FB" />
             <SortedAscendingHeaderStyle BackColor="#6D95E1" />
             <SortedDescendingCellStyle BackColor="#E9EBEF" />
             <SortedDescendingHeaderStyle BackColor="#4870BE" />
         </asp:GridView>
    </div>
</asp:Content>
