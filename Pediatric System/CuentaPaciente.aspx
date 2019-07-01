<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CuentaPaciente.aspx.cs" Inherits="Pediatric_System.CuentaPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <link rel="stylesheet" href="CSS/agenda.css" />
    <link rel="stylesheet" href="CSS/expediente.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid col-11 col-auto">
        <br>
        <div class="page-header margen-general-2-top">
            <h2 class="text-info">Cuenta de de Pacientes</h2>
        </div>

        <hr class="linea-divisoria-titulo" />
        <div style="text-align:center;">
        <form runat="server">

            <div class="tab-content" id="myTabContent">

                <!-- Datos para la Informacion Personal del Paciente !-->

                <div class="tab-pane fade show active margen-general-1-bottom" id="info-personal-paciente" role="tabpanel" aria-labelledby="info-personal-paciente-tab">

                    <div class="col-12 border rounded margen-general-0-top">
                        <br>
                        <div class="margen-general-1-top padding-general-inicio-bottom">
                            <div class="form-row">
                                   <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-label">Correo</label>
                                        <asp:TextBox runat="server" ID="txtCorreo" CssClass="form-control" required="required" TextMode="Email"></asp:TextBox>
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
           
                <div class="form-row" style="text-align: right; display: block">
                <div class="form-group col-lg-3 col-md-3 col-sm-6 col-xs-6" style="display: inline-block">
                    <asp:Button type="button" runat="server" class="btn btn-regresar" Text="REGRESAR" ID="Regresar"  CausesValidation ="False" UseSubmitBehavior="false" OnClick="Regresar_Click" />
                </div>
            </div>
            
             <div class="btnGuardarExpediente form-group col-lg-12 col-md-6 col-sm-6 col-xs-6" style="text-align: right;">
                <asp:Button ID="btnGuardar" runat="server" Text="GUARDAR" CssClass="btn btn-guardar form-control" OnClick="btnGuardar_Click"></asp:Button>
            </div>
        
        </form>
</div>
    </div>

    <script>
        $('.datepicker').datepicker({
            uiLibrary: 'bootstrap4',
            locale: 'es-es',
            format: 'dd/mm/yyyy'
        });

    </script>

</asp:Content>
