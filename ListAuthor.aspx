<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListAuthor.aspx.cs" Inherits="ListAuthor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div style="width:100%;height:auto;">
            <asp:Button style="float:left;" class="btn btn-primary" ID="btnAddAuthor" runat="server" OnClick="btnAddAuthor_Click" Text="Thêm tác giả " />
            
            <asp:DropDownList style="float:left;" ID="TypeSearch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="TypeSearch_SelectedIndexChanged" class="btn btn-default dropdown-toggle btn-filter">
                <asp:ListItem Value="1">Theo mã tác giả</asp:ListItem>
                <asp:ListItem Value="2">Theo tên tác giả</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox style="float:left;" ID="txtSearch" runat="server" Height="32px" Width="203px" placeholder="Nhập từ khóa tìm kiếm ..." class="form-control form-large search-input"></asp:TextBox>
            <asp:Button class="btn btn-primary" ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" Height="30px" />
            <br />
        </div>

        
             <asp:GridView CssClass="test"  ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="id_author" Height="59px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" Style="margin-top: 36px" Width="543px">
            <Columns>
                <asp:BoundField DataField="id_author" HeaderText="Mã TG" />
                <asp:BoundField DataField="name_author" HeaderText="Tên tác giả" />
                <asp:BoundField DataField="description" HeaderText="Thông tin" />
                <asp:TemplateField HeaderText="Sửa">
                    <EditItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Update" ImageUrl="~/image/icons8-Save Close-15.png" />
                        <asp:ImageButton ID="ImageButton3" runat="server" CommandName="Cancel" ImageUrl="~/image/icons8-Minus-15.png" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Edit" ImageUrl="~/image/icons8-Edit-15.png" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        

       
    </div>
</asp:Content>

