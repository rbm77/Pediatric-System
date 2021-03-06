﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CuentaPersonal.aspx.cs" Inherits="Pediatric_System.CuentaPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <link rel="stylesheet" href="CSS/agenda.css" />
    <link rel="stylesheet" href="CSS/expediente.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid col-11 col-auto">
        <br>
        <div class="page-header margen-general-2-top">
            <h2 class="text-info">Cuenta de Usuario</h2>
        </div>

        <hr class="linea-divisoria-titulo" />

        <form runat="server">
                        <ul class="nav nav-tabs">
                    <li class="nav-item">
                        <a class="nav-link nombre-input" id="info-personal-paciente-tab" " href="EstadoCuenta.aspx" role="tab" aria-controls="info-personal-paciente" aria-selected="false">Cuentas</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link active nombre-input" id="info-personal-encargado-tab"  href="CuentaPersonal.aspx" role="tab" aria-controls="info-personal-encargado" aria-selected="true">Nueva Cuenta</a>
                    </li>
</ul>
            <div class="tab-content" id="myTabContent">

                <!-- Datos para la Informacion Personal del Paciente !-->

                <div class="tab-pane fade show active margen-general-1-bottom" id="info-personal-paciente" role="tabpanel" aria-labelledby="info-personal-paciente-tab">

                    <div class="col-12 border rounded margen-general-0-top">
                        <br>
                        <div class="margen-general-1-top padding-general-inicio-bottom">
                            <div class="form-row">
                                <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Nombre</label>
                                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"  required="required"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Apellido</label>
                                        <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control"  required="required"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Cédula</label>
                                        <asp:TextBox runat="server" ID="txtCedula" CssClass="form-control" placeholder="102340567" TextMode="Number" required="required"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Rol</label>
                                  
                                        <asp:DropDownList ID="Rol" runat="server" AutoPostBack="true" CssClass="custom-select" OnSelectedIndexChanged="Rol_SelectedIndexChanged">
                                            <asp:ListItem Value="Administrador"> Administrador </asp:ListItem>
                                            <asp:ListItem Value="Asistente"> Asistente </asp:ListItem>
                                            <asp:ListItem Value="Medico"> Médico </asp:ListItem>
                                            
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                   <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-label">Correo</label>
                                        <asp:TextBox runat="server" ID="txtCorreo" CssClass="form-control" TextMode="Email" required="required"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-label">Teléfono</label>
                                        <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" TextMode="Number" required="required"></asp:TextBox>
                                    </div>
                                </div>

                                   <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-label">Codigo Médico</label>
                                        <asp:TextBox  runat="server" ID="txtCodigo" Enabled="false" CssClass="form-control" required="required"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>


                <!-- ----------------------------------------------------------- !-->

            </div>
                    <asp:Literal ID="mensajeConfirmacion" runat="server" Visible="false"></asp:Literal> 
            <br>
            <div class="btnGuardarExpediente form-group col-lg-12 col-md-6 col-sm-6 col-xs-6" style="text-align: right;">
                <asp:Button ID="btnGuardar" runat="server" Text="GUARDAR" CssClass="btn btn-guardar" OnClick="btnGuardar_Click"></asp:Button>
            </div>
        </form>

    </div>

    <script>
        $('.datepicker').datepicker({
            uiLibrary: 'bootstrap4',
            locale: 'es-es',
            format: 'dd/mm/yyyy'
        });

    </script>

</asp:Content>
