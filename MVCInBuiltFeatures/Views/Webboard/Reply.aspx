<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reply.aspx.cs" Inherits="Webboard.Reply1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <nav>
        <a href="Default.aspx">กลับหน้าแรก</a>
        <a href="Post.aspx">ตั้งหัวข้อใหม่</a>
    </nav>
    <asp:LinqDataSource ID="linqTopic" runat="server" 
        ContextTypeName="Webboard.dbWebboardDataContext" 
        EntityTypeName="" 
        Select="new (Topic1, Description, UserName, RecordDate, TID)" 
        TableName="Topics" Where="TID == @TID">
        <WhereParameters>
            <asp:QueryStringParameter Name="TID" QueryStringField="TID" Type="String" />
        </WhereParameters>
    </asp:LinqDataSource>
    <asp:DataList ID="dlTopic" runat="server" CellPadding="4" 
        DataSourceID="linqTopic" ForeColor="#333333" Width="909px">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#0066FF" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#0066FF" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <ItemTemplate>
            <h2>
                <asp:Label ID="TopicLabel" runat="server" 
                           Text='<%# Eval("Topic1") %>' ForeColor="Blue" />
            </h2>
            <hr /><br /><br />
            <asp:Label ID="DescriptionLabel" runat="server" 
                       Text='<%# Eval("Description") %>' />
            <br /><br /><hr />
            ผู้ตั้งหัวข้อ :
            <asp:Label ID="UserNameLabel" runat="server" 
                       Text='<%# Eval("UserName") %>' />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; วันที่ตั้งหัวข้อ :
            <asp:Label ID="RecordDateLabel" runat="server" 
                       Text='<%# Eval("RecordDate") %>' />
        </ItemTemplate>
        <SelectedItemStyle BackColor="#66FF99" Font-Bold="True" ForeColor="#333333" />
    </asp:DataList>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LinqDataSource ID="linqReply" runat="server"
        ContextTypeName="Webboard.dbWebboardDataContext"
        EntityTypeName=""
        Select="new (TID, ReplyNO, Description, ReplyName, ReplyDate, IP)"
        TableName="Replies"
        Where="TID == @TID" 
        OrderBy="ReplyNO desc">
        <WhereParameters>
            <asp:QueryStringParameter Name="TID" 
                QueryStringField="TID" 
                Type="String" />
        </WhereParameters>
    </asp:LinqDataSource>
    <asp:DataList ID="dlReply" runat="server"
        DataKeyField="TID"
        DataSourceID="linqReply" 
        BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
        BorderWidth="1px" CellPadding="4" GridLines="Both">
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <ItemStyle BackColor="White" ForeColor="#003399" />
        <ItemTemplate>
            <table style="width: 100%;">
                <tr>
                    <td colspan="3" style="color: #0000FF">คำตอบที่ :
                        <asp:Label ID="ReplyNOLabel" runat="server" ForeColor="Blue"
                                   Text='<%# Eval("ReplyNO") %>' />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="DescriptionLabel" runat="server"
                            Text='<%# Eval("Description") %>' />
                    </td>
                </tr>
                <tr>
                    <td class="style3">จากคุณ :
                        <asp:Label ID="ReplyNameLabel" runat="server" 
                                   Text='<%# Eval("ReplyName") %>' />
                    </td>
                    <td class="style2">วันที่ตอบ :
                        <asp:Label ID="ReplyDateLabel" runat="server" 
                                   Text='<%# Eval("ReplyDate") %>' />
                    </td>
                    <td>IP :
                        <asp:Label ID="IPLabel" runat="server" 
                                   Text='<%# Eval("IP") %>' />
                    </td>
                </tr>
            </table><hr />
        </ItemTemplate>
        <SelectedItemStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
    </asp:DataList><br /><br /><br />
    <section>
        <table style="width: 85%;">
            <tr>
                <td class="style1">ความเห็น :<br /><br /><br /><br /><br /><br /></td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" 
                        Height="124px" TextMode="MultiLine"
                        Width="536px" MaxLength="255" 
                        TabIndex="0">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtDescription"
                        ErrorMessage="กรุณาระบุรายละเอียดของคำตอบด้วยครับ"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">จากคุณ :</td>
                <td>
                    <asp:TextBox ID="txtReplyName" runat="server" TabIndex="1" Width="200px">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="txtReplyName" ErrorMessage="กรุณาระบุชื่อด้วยครับ">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="cmdSave" runat="server" Text="บันทึก" TabIndex="2" OnClick="cmdSave_Click" />
        <asp:Button ID="cmdClear" runat="server" Text="ล้างข้อมูล" TabIndex="3" OnClick="cmdClear_Click" />
    </section>
</asp:Content>
