﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarContrasenna.aspx.cs" Inherits="Pediatric_System.RecuperarContrasenna" %>

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
</head>
<body>

    <br />

    <div class="container-fluid col-10 col-auto">
        <div class="page-header">
            <h3 class="text-info">Recuperar contraseña</h3>
        </div>
    </div>


    <form runat ="server">

        <br />

        <div class="container-fluid col-10 col-auto bg-light border border-info">

            <br />
            <div class="form-row">
                <div class="alert col-lg-12 col-md-12 col-sm-12 col-xs-12" role="alert">
                    <p style="color: dimgray">Si desea acceder nuevamente al sistema, por favor ingrese la dirección de correo electrónico asociada a su cuenta de usuario. Posteriormente se le enviará un correo con una nueva contraseña.</p>
                    <hr />
                    <p style="color: dimgray" class="mb-0">Una vez que tenga acceso al sistema le recomendamos cambiar su contraseña en las opciones de configuración de la cuenta.</p>
                </div>
                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label style="color: dimgray" for="correo">Correo Electrónico</label>

                    <asp:TextBox ID="txtCorreo" class="form-control" type="email" name="email" runat="server"></asp:TextBox>
                    <%--<input type="email" class="form-control" id="txtCorreo" />--%>
                </div>
            </div>

            <div class="form-row">
                
                <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">
                    
                    <%--<button type="submit" class="btn btn-outline-primary form-control">ENVIAR</button>--%>
                    <asp:Button ID="BotonEnviar" class="btn btn-outline-primary form-control" runat="server" Text="ENVIAR" OnClick="BotonEnviar_Click" /> 
                      
                </div>
                
                <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">
                     <asp:Button ID="BotonRegresar" class="btn btn-outline-danger form-control" runat="server" Text="Regresar" OnClick="BotonRegresar_Click" /> 
                    <%--<button type="submit" class="btn btn-outline-danger form-control">REGRESAR</button>--%>

                </div>

            </div>
        </div>
    </form>
</body>
</html>
