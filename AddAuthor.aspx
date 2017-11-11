<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddAuthor.aspx.cs" Inherits="AddAuthor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width: 437px; margin-left: 50px; margin-top: 0px; height: auto; float: left;" >
        <div>
            <asp:Label ID="Label2" runat="server" Text="Tên tác giả"></asp:Label>
            <asp:TextBox CssClass="form-control" ID="txtAuthorName" runat="server" Width="347px"></asp:TextBox>
                </div>


        <div>
            <asp:Label ID="Label3" runat="server" Text="Mô tả"></asp:Label>
            </div>
    <div>
            <asp:TextBox ID="txtAuthorDescription" CssClass="form-control" runat="server" Height="80px" Width="347px"></asp:TextBox>
        </div>
        <br />
        <div style="padding-left:100px;">
            <asp:Button ID="addAuthors" class="btn btn-primary" runat="server" OnClick="addAuthors_Click" Text="Thêm tác giả" />
        </div>
        
        </div>
    <div >
             <div style="line-height: 34px;" class="form-group">
            <div style="padding-bottom: 7px; float: left; width: 130px; height: 34px; line-height: 34px; ">
                <asp:FileUpload ID="FileIMG" accept=".png,.jpg,.jpeg,.gif" AutoPostBack="false" runat="server" onchange="readURL(this);" />
                <div style ="padding-left: 0px; padding-right:100px"> 
                <img id="imgDisplay" />
                    </div>
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
        </div>
        </div>
    
        
</asp:Content>

