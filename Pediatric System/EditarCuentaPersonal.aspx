﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="EditarCuentaPersonal.aspx.cs" Inherits="Pediatric_System.EditarCuentaPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid col-11 col-auto">
        <br>
        <div class="page-header margen-general-2-top">
            <h2 class="text-info">Cuenta de Usuario</h2>
        </div>

        <hr class="linea-divisoria-titulo" />

        <form runat="server">
            <div class="tab-content" id="myTabContent">

                <!-- Datos para la Informacion Personal del Paciente !-->

                <div class="tab-pane fade show active margen-general-1-bottom" id="info-personal-paciente" role="tabpanel" aria-labelledby="info-personal-paciente-tab">

                    <div class="col-12 border rounded margen-general-2-top">
                        <br>
                        <div class="margen-general-1-top padding-general-inicio-bottom">
                            <div class="form-row">
                                <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Nombre</label>
                                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Apellido</label>
                                        <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Cédula</label>
                                        <asp:TextBox runat="server" ID="txtCedula" CssClass="form-control" placeholder="102340567"></asp:TextBox>
                                    </div>
                                </div>


                                    <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-label">Rol</label>
                                        <asp:TextBox runat="server" ID="Tipo" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                   <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-label">Correo</label>
                                        <asp:TextBox runat="server" ID="txtCorreo" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-label">Teléfono</label>
                                        <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                   <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <asp:Label class="nombre-label" ID="lblCodigo" Visible="false" runat="server" Text="Código Médico"></asp:Label>                                     
                                        <asp:TextBox  runat="server" ID="txtCodigo" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="padding-general-label">
                                        <asp:Label class="nombre-label" ID="lblCodAsist" Visible="false" runat="server" Text="Asistente de:"></asp:Label>
                                        <asp:DropDownList ID="ddCodAsist" CssClass="browser-default custom-select" Visible="false"  runat="server" ></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>


                <!-- ----------------------------------------------------------- !-->

            </div>
            <br>
                    <asp:Literal ID="mensajeConfirmacion" runat="server" Visible="false"></asp:Literal> 
            <br>
         
            
       
            <div class="btnGuardarExpediente form-group col-lg-12 col-md-12 col-sm-12 col-xs-6" style="text-align: right;">
                <asp:Button type="button" runat="server" CssClass="btn btn-regresar" Text="REGRESAR" ID="regresar" OnClick="regresar_Click" />
                <asp:Button ID="btnEditar" runat="server" Text="GUARDAR" CssClass="btn btn-guardar" OnClick="btnEditar_Click"></asp:Button>
            </div>
        </form>

    </div>

    <script>
        $('.datepicker').datepicker({
            uiLibrary: 'bootstrap4',
            locale: 'es-es',
            format: 'dd/mm/yyyy'
        });
        
        //$(".seleccionarRol").on("change", function () {
        //    if (this.value == "Medico") {
        //        document.getElementById('txtCodigo').innerHTML = "enabled"
        //        //document.getElementById('txtCodigo').disabled = true;
        //    } else {
        //        document.getElementById('txtCodigo').innerHTML = "disabled"
        //        // document.getElementById("txtCodigo").disabled = true;
        //    }
        //});
      
      
    </script>

</asp:Content>
