<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="EditarContrasena.aspx.cs" Inherits="Pediatric_System.EditarContrasena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid col-11 col-auto">
        <br>
        <div class="page-header margen-general-2-top">
            <h2 class="text-info">Contraseña</h2>
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
                                        <label class="nombre-input">Contraseña Actual</label>
                                        <asp:TextBox runat="server" ID="txtContraseñaActual" TextMode="Password" CssClass="form-control" required="required"></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Contraseña Nueva</label>
                                        <asp:TextBox runat="server" ID="txtContraseñaNueva1" TextMode="Password" CssClass="form-control" required="required"></asp:TextBox>
                                    </div>

                                </div>
                                  <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Repetir Contraseña</label>
                                        <asp:TextBox runat="server" ID="txtContraseñaNueva2" TextMode="Password" CssClass="form-control" required="required"></asp:TextBox>
                                    </div>
                                      <br>
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
            <div class="btnGuardarExpediente form-group col-lg-12 col-md-6 col-sm-6 col-xs-6" style="text-align: right;">
                <asp:Button ID="btnGuardar" runat="server" Text="EDITAR" CssClass="btn btn-guardar form-control" OnClick="btnGuardar_Click"></asp:Button>
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
