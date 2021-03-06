﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 600px; margin-left: 50px; margin-top: 50px; height: auto; float: left;">
        <div class="form-group">
            <div style="padding-bottom: 7px; float: left; width: 130px; height: 34px; line-height: 34px;">
                <span>Mã sản phẩm</span>
            </div>
            <asp:TextBox Width="350px" class="textbox-add-product" CssClass="form-control" ID="id" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="id" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Vui lòng nhập mã sản phẩm"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <div style="padding-bottom: 7px; float: left; width: 130px; height: 34px; line-height: 34px;">
                <span>Tên sản phẩm</span>
            </div>
            <asp:TextBox Width="350px" class="textbox-add-product" CssClass="form-control" ID="name" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="name" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Vui lòng nhập Tên sản phẩm"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <div style="padding-bottom: 7px; float: left; width: 130px; height: 34px; line-height: 34px;">
                <span>Năm xuất bản</span>
            </div>
            <asp:TextBox Width="350px" class="textbox-add-product" CssClass="form-control" ID="Namsanxuat" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="Namsanxuat" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Vui lòng nhập Năm xuất bản"></asp:RequiredFieldValidator>

        </div>

        <div class="form-group">
            <div style="padding-bottom: 7px; float: left; width: 130px; height: 34px; line-height: 34px;">
                <span>Đơn giá</span>
            </div>
            <asp:TextBox Width="350px" class="textbox-add-product" CssClass="form-control" ID="price" runat="server"></asp:TextBox>
            <asp:RangeValidator ControlToValidate="price" Type="Double" ID="RangeValidator1" runat="server" ErrorMessage="Vui lòng nhập đúng đơn giá"></asp:RangeValidator>
            <asp:RequiredFieldValidator ControlToValidate="price" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Vui lòng nhập đơn giá"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <div style="padding-bottom: 7px; float: left; width: 130px; height: 34px; line-height: 34px;">
                <span>Số trang</span>
            </div>
            <asp:TextBox Width="350px" class="textbox-add-product" CssClass="form-control" ID="pages" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="pages" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Vui lòng nhập pages"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <div style="padding-bottom: 7px; float: left; width: 130px; height: 34px; line-height: 34px;">
                <span>Giá gốc</span>
            </div>
            <asp:TextBox Width="350px" class="textbox-add-product" CssClass="form-control" ID="price_pages" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="price_pages" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Vui lòng nhập Giá gốc"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <div style="padding-bottom: 7px; float: left; width: 130px; height: 34px; line-height: 34px;">
                <span>Số lượng tồn kho</span>
            </div>

            <asp:TextBox Width="350px" class="textbox-add-product" CssClass="form-control" ID="repository" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="repository" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Vui lòng nhập Số lượng tồn kho"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <div style="padding-bottom: 7px; float: left; width: 130px; height: 34px; line-height: 34px;">
                <span>Khối lượng</span>
            </div>
            <asp:TextBox Width="350px" class="textbox-add-product" CssClass="form-control" ID="weight" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="weight" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Vui lòng nhập Khối lượng"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <div style="padding-bottom: 7px; float: left; width: 130px; height: 34px; line-height: 34px;">
                <span>Nội dung</span>
            </div>
            <asp:TextBox Width="350px" class="textbox-add-product" CssClass="form-control" ID="content" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="content" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Vui lòng nhập Khối lượng"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <div style="padding-bottom: 7px; float: left; width: 130px; height: 34px; line-height: 34px;">
                <span>Tình trạng</span>
            </div>
            <asp:TextBox Width="350px" class="textbox-add-product" CssClass="form-control" ID="status" runat="server">Còn hàng</asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="status" ID="RequiredFieldValidator102" runat="server" ErrorMessage="Vui lòng nhập Tình trạng"></asp:RequiredFieldValidator>
        </div>
        <div style="margin-left: 130px; margin-top: 40px;">
            <asp:Button class="btn btn-primary" ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Sản Phẩm" />
            <asp:RequiredFieldValidator ControlToValidate="status" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Vui lòng nhập Tình trạng"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div style="float: left; margin-top: 50px;">

        <div style="line-height: 34px;" class="form-group">
            <div style="padding-bottom: 7px; float: left; width: 130px; height: 34px; line-height: 34px;">
                <span>Nhà xuất bản</span>
            </div>
            <asp:DropDownList ID="Producer" runat="server" Height="33px" Width="212px" class="btn btn-default dropdown-toggle btn-filter">
            </asp:DropDownList>
        </div>
        <div style="line-height: 34px;" class="form-group">
            <div style="padding-bottom: 7px; float: left; width: 130px; height: 34px; line-height: 34px;">
                <span>Thể loại</span>
            </div>
            <asp:DropDownList Height="33px" ID="productType" runat="server" Style="margin-bottom: 0px" Width="212px" class="btn btn-default dropdown-toggle btn-filter">
            </asp:DropDownList>
        </div>
        <div style="line-height: 34px;" class="form-group">
            <div style="padding-bottom: 7px; float: left; width: 130px; height: 34px; line-height: 34px;">
                <span>Tác giả</span>
            </div>

            <asp:DropDownList Height="33px" ID="author" runat="server" Width="212px" class="btn btn-default dropdown-toggle btn-filter">
            </asp:DropDownList>
        </div>

        <div style="line-height: 34px;" class="form-group">
            <div style="padding-bottom: 7px; float: left; width: 130px; height: 34px; line-height: 34px;">
                <span>Danh mục</span>
            </div>
            <asp:CheckBox ID="hot" runat="server" Text="Hot" />&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="new" runat="server" Text="New" />&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="sale" runat="server" Text="Sale" />

        </div>

        <br />
        <div style="line-height: 34px;" class="form-group">
            <%-- <div style="padding-bottom: 7px; float: left; width: 130px; height: 34px; line-height: 34px;">
                <span>Chọn ảnh</span>
            </div>
            <asp:FileUpload Height="34" ID="FileIMG" accept=".png,.jpg,.jpeg,.gif" AutoPostBack="false" runat="server" />--%>
            <div style="padding-bottom: 7px; float: left; width: 130px; height: 34px; line-height: 34px;">

                <asp:FileUpload ID="FileIMG" accept=".png,.jpg,.jpeg,.gif" AutoPostBack="false" runat="server" onchange="readURL(this);" />
                <asp:RequiredFieldValidator ControlToValidate="FileIMG" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Vui lòng chọn img"></asp:RequiredFieldValidator>

                <div style="padding-left: 120px;">
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

