<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ToyShop.User.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        window.omload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblMsg.ClientID %>").style.display = "none;"

            }, seconds * 1000);


        };
      </script>
        <script type="text/javascript" language="javascript">
            function DisableBackButton() {
                window.history.forward()
            }
            DisableBackButton();
            window.onload = DisableBackButton;
            window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
            window.onunload = function () { void (0) }
        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="book_section layout_padding">
        <div class="container">
            <div class="heading_container">
                <div class="align-self-end">
                    <asp:Label runat="server" ID="lblMsg"></asp:Label>
                </div>
                <h2>Login</h2>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form_container">
                        <img id="userLogin" src="../Images/Login.jpg" alt="" class="img-thumbnail"/>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form_container">
                     <div>
                         <asp:Label ID="Label1" runat="server" Text="Username or Email:"></asp:Label>
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Username or Email is Required" ControlToValidate="txtUsername"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter Username or Email"></asp:TextBox>
                    </div>
                <div>
                     <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password is Required" ControlToValidate="txtPassword"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
                    </div>
                        <div style="margin-bottom:20px">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/User/forgotpasssword.aspx">ForgotPassword, Click Here</asp:HyperLink>
                        </div>
                    <div class="btn_box">
                        <asp:Button ID="btnLogin" runat="server" Text="Login"  CssClass="btn btn-success rounded-pill pl-4 pr-4 text-white"
                            OnClick="btnLogin_Click"/>
                        <spam class="pl-3 text-info">New User? <a href="Registration.aspx" class="badge badge-info">Register Here....</a></spam>

                    </div>
                </div>
                </div>
           
        </div>
     </div>
    </section>
</asp:Content>
