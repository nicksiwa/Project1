<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="Webboard.Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <h1>ตั้งหัวข้อใหม่</h1>
        <a href="Default.aspx">กลับไปหน้าแรก</a><br />
        <br />
        <table style="width: 100%;">
            <tr>
                <td>หัวข้อ :</td>
                <td>
                    <asp:TextBox ID="txtTopic" runat="server" MaxLength="100" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtTopic" ErrorMessage="กรุณาตั้งหัวข้อด้วยครับ"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>คำถาม :<br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" Height="124px" TextMode="MultiLine"
                        Width="500px" MaxLength="255" TabIndex="0"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="txtDescription"
                        ErrorMessage="กรุณาระบุรายละเอียดด้วยครับ"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>จากคุณ :</td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" TabIndex="1" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="txtUserName" ErrorMessage="กรุณาระบุชื่อด้วยครับ"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <asp:Button ID="cmdSave" runat="server" Text="บันทึก" TabIndex="2" OnClick="cmdSave_Click" />
        <asp:Button ID="cmdClear" runat="server" Text="ล้างข้อมูล" TabIndex="3" OnClick="cmdClear_Click"/>
    </section>
</asp:Content>