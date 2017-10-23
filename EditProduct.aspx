<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditProduct.aspx.cs" Inherits="EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: left; width: auto; padding-left: 50px">
        <br />
        <div style="float: left">
            ID:
            <asp:TextBox Enabled="false" ReadOnly="true" ID="IDProduct" runat="server"  Width="280px" border-radius="4px"></asp:TextBox>
            <br />
            <br />
            Tên sản phẩm:
            <asp:TextBox ID="name" runat="server" Width="300px" class="form-control form-large search-input"></asp:TextBox>
            <br />
            Giá sản phẩm:
            <asp:TextBox ID="price" runat="server"  Width="300px" class="form-control form-large search-input"></asp:TextBox>
            <br />
            Số trang:
            <asp:TextBox ID="Pages" runat="server"  Width="300px" class="form-control form-large search-input"></asp:TextBox>
            <br />
            Hàng trong kho:
            <asp:TextBox ID="repository" runat="server"  Width="300px" class="form-control form-large search-input"></asp:TextBox>
            <br />
            Cân nặng:<asp:TextBox ID="weight" runat="server"  Width="300px" class="form-control form-large search-input"></asp:TextBox>
            <br />
            Nội dung:
            <asp:TextBox ID="conten" runat="server"  Width="300px" class="form-control form-large search-input"></asp:TextBox>
            <br />
            Trạng thái:
            <asp:TextBox ID="stt" runat="server"  Width="300px" class="form-control form-large search-input"></asp:TextBox>

            <br />
            <div style="padding-left:60px">
                <asp:CheckBox ID="Hot" runat="server" Text="Hot" />
            &nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="New" runat="server" Text="New" />
            &nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="Sale" runat="server" Text="Sale" />
                  </div>
            
            <br />
            <br />
           
            <br />
            <br />
            <br />

        </div>
        <div style="float: right; padding-left:70px">
            Nhà sản xuất:<asp:DropDownList ID="Producer" runat="server"  class="btn btn-default dropdown-toggle btn-filter" Width="200px">
            </asp:DropDownList>
            <br />
            <br />
            Thể loại:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ProductType" runat="server"  class="btn btn-default dropdown-toggle btn-filter" Width="200px">
            </asp:DropDownList>
            <br />
            <br />
            Tác giả:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="author" runat="server"  class="btn btn-default dropdown-toggle btn-filter" Width="200px">
            </asp:DropDownList>
            <br /><br />
            <div style="padding-left:80px">
                <asp:FileUpload ID="FileUpload1" accept=".png,.jpg,.jpeg,.gif" AutoPostBack="false" runat="server" onchange="readURL(this);"/><br />
            <asp:Image ID="Image1" runat="server" Width="208px" Height="259px" />
                <img id="imgDisplay" />
                <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgDisplay')
                        .attr('src', e.target.result)
                        .width(150)
                        .height(200);

                };

                reader.readAsDataURL(input.files[0]);


            }
        }
    </script>
            </div>
            
            <br /><br />
            <div style="padding-left:50px">
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Sua" runat="server" Height="31px" OnClick="Sua_Click" Text="Sửa" Width="60px" class="btn btn-primary"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Height="30px" OnClick="Button2_Click" Text="Trở lại" Width="65px" class="btn btn-primary" />
            &nbsp;&nbsp;
            </div>
        </div>
    </div>

</asp:Content>
