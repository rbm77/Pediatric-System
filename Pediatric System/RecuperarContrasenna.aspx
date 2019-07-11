<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarContrasenna.aspx.cs" Inherits="Pediatric_System.RecuperarContrasenna" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Recuperar Contraseña</title>
    <%-- Bootstrap ultima version --%>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <link href="CSS/sb-admin.css" rel="stylesheet" />
    <link href="CSS/general.css" rel="stylesheet" />
</head>
<body>

    <br />
    <form runat="server">
        <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
            <asp:Image ID="Image1" runat="server" ImageUrl="images/Logo_letras_azules.png"
                Width="233px" AlternateText="Imagen no disponible" Height="97px" />
        </asp:Panel>
        <br />

        <div class="container-fluid col-4 col-auto bg-light border border-info" style="margin-bottom:80px">


            <div class="form-row">
                <div class="alert col-lg-12 col-md-12 col-sm-12 col-xs-12" role="alert">
                    <h3 class="text-info" style="text-align: center">Recuperar contraseña</h3>
                    <br />
                    <p style="color: dimgray; text-align: center; margin-bottom: 0px">Escribe la dirección de correo electrónico asociado a tu cuenta de</p>
                    <p style="color: dimgray; text-align: center">Peditric System</p>
                    <hr />
                    <p style="color: dimgray; text-align: center" class="mb-0">Una vez que tenga acceso al sistema le recomendamos cambiar su contraseña en las opciones de configuración de la cuenta.</p>
                    <br />
                    <br />
                    <p style="color: dimgray; text-align: center; font-weight: bold">Correo Electronico</p>
                     <asp:TextBox ID="txtCorreo" class="form-control" type="email" name="email" runat="server" required="required"></asp:TextBox>
                </div>

                <%--<input type="email" class="form-control" id="txtCorreo" />--%>
            </div>

            <div style="text-align: center;" >
                <asp:Button ID="Button3" runat="server" Text="ENVIAR"  CssClass="btn btn-guardar" OnClick="BotonEnviar_Click" />
                 <br />
                <br />
                 <asp:Button type="button" runat="server" CssClass="btn btn-regresar" Text="REGRESAR" ID="Button2" OnClick="Regresar_Click" CausesValidation="False" UseSubmitBehavior="false" />
            </div>
                <br />
             <asp:Literal ID="mensajeConfirmacion" runat="server" Visible="false"></asp:Literal>
        </div>

           

    </form>
</body>
      <footer class="sticky-footer" style="width:100%">
        <div class="container my-auto">
          <div class="copyright my-auto" style="text-align: center;">
            <span style="color:#004085; text-align:center">Elaborado por estudiantes de Informática Empresarial - Universidad de Costa Rica 2019</span>
          </div>
        </div>
</html>
