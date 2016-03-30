<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Webboard.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <nav>
        <a href="Default.aspx">กลับหน้าแรก</a> 
        <a href="Post.aspx">ตั้งหัวข้อใหม่</a>
    </nav>
    <section>
        ค้นหา :
        <asp:TextBox ID="txtSearch" runat="server" Width="275px"></asp:TextBox>
        <asp:Button ID="cmdSearch" runat="server" Text="ค้นหา" OnClick="cmdSearch_Click" /><br /><br />
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvTopic" runat="server" 
                  AutoGenerateColumns="False" 
                  CellPadding="4" 
                  ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="TID" HeaderText="ลำดับ" />
            <asp:TemplateField HeaderText="ชื่อหัวข้อ">
                    <ItemTemplate>
                        <a href="Reply.aspx?TID=<%# Eval("TID") %>">
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Topic1") %>' />
                        </a>
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="UserName" HeaderText="ผู้ตั้งหัวข้อ" />
            <asp:BoundField DataField="RecordDate" HeaderText="วันที่ตั้งหัวข้อ" />
            <asp:BoundField DataField="ViewCount" HeaderText="จำนวนอ่าน" />
            <asp:BoundField DataField="ReplyCount" HeaderText="จำนวนตอบ" />
            <asp:BoundField DataField="IP" HeaderText="หมายเลข IP" />
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
</asp:Content>
