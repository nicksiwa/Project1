<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Webboard._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        ค้นหา :
        <asp:TextBox ID="txtSearch" runat="server" Width="275px"></asp:TextBox>
        <asp:Button ID="cmdSearch" runat="server" Text="ค้นหา" OnClick="cmdSearch_Click" /><br /><br />
        <a href="Post.aspx">ตั้งหัวข้อใหม่</a>
        <asp:LinqDataSource ID="linqTopic" runat="server" 
            ContextTypeName="Webboard.dbWebboardDataContext" 
            EntityTypeName="" 
            Select="new (TID, Topic1, UserName, RecordDate, ViewCount, ReplyCount, IP)" 
            TableName="Topics" OrderBy="TID desc">
        </asp:LinqDataSource>
        <asp:GridView ID="gvTopic" runat="server" 
            AllowPaging="True" 
            AllowSorting="True" 
            AutoGenerateColumns="False" 
            DataSourceID="linqTopic" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="TID" HeaderText="ลำดับ" 
                                ReadOnly="True" SortExpression="TID" />
                <asp:TemplateField HeaderText="ชื่อหัวข้อ" SortExpression="Topic1">
                    <ItemTemplate>
                        <a href="Reply.aspx?TID=<%# Eval("TID") %>">
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Topic1") %>' />
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UserName" HeaderText="ผู้ตั้งหัวข้อ" 
                    ReadOnly="True" SortExpression="UserName" />
                <asp:BoundField DataField="RecordDate" HeaderText="วันที่ตั้งหัวข้อ" 
                    ReadOnly="True" SortExpression="RecordDate" />
                <asp:BoundField DataField="ViewCount" HeaderText="จำนวนอ่าน" 
                    ReadOnly="True" SortExpression="ViewCount" />
                <asp:BoundField DataField="ReplyCount" HeaderText="จำนวนตอบ" 
                    ReadOnly="True" SortExpression="ReplyCount" />
                <asp:BoundField DataField="IP" HeaderText="เลข IP" 
                    ReadOnly="True" SortExpression="IP" />
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
    </section>
</asp:Content>