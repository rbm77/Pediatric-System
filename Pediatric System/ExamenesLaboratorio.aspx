<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ExamenesLaboratorio.aspx.cs" Inherits="Pediatric_System.ExamenesLaboratorio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(function () {
            $('[id*=gridExamenes]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "numbers"
            });
        });
    </script>

    <link href="CSS/listaExpedientes.css" rel="stylesheet" />
    <link rel="stylesheet" href="CSS/agenda.css" />



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid col-11 col-auto">

        <div class="page-header margen-general-2-top">
            <h3 class="text-info">Exámenes de Laboratorio</h3>
        </div>

        <hr class="linea-divisoria-titulo" />


        <form runat="server">

            <asp:Literal ID="mensajeConfirmacion" runat="server" Visible="false"></asp:Literal>

            <div class="margen-general-2-top" runat="server" id="informacionPaciente">
                <div class="col-12">
                    <div class="form-row">

                        <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-12">
                            <div class="alinearFoto">
                                <asp:Image ID="imgPreview" Width="150" ImageUrl="~/images/foto_perfil_icono.jpg" runat="server" />
                            </div>
                        </div>

                        <div class="form-group col-lg-9 col-md-6 col-sm-6 col-xs-12">
                            <div class="form-row">
                                <label class="info-paciente">Paciente: </label>
                                <label runat="server" id="paciGeneral" class="nombre-input"></label>
                            </div>

                            <div class="form-row padding-info-exp">
                                <label class="info-paciente">Cédula: </label>
                                <label id="cedGeneral" runat="server" class="nombre-input"></label>
                            </div>

                            <div class="form-row padding-info-exp">
                                <label class="info-paciente">Edad: </label>
                                <label id="edaGeneral" runat="server" class="nombre-input"></label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 margen-general-1-bottom paddingSidesCard">


                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">

                    <div class="padding-general-label">
                        <label class="nombre-input">Paciente</label>
                        <asp:DropDownList ID="nombrePaciente" CssClass="browser-default custom-select" runat="server" OnSelectedIndexChanged="nombrePaciente_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>

                </div>


                <div class="card">

                    <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-list"></i>Lista de Exámenes de Laboratorio</h5>

                    <div class="card-body">


                        <div class="table-responsive" style="padding-left: 0px; padding-right: 0px">

                            <asp:GridView ID="gridExamenes" runat="server" CssClass="table table-hover table-bordered" Style="text-align: center"
                                AutoGenerateColumns="false" HeaderStyle-CssClass="thead-light"
                                HeaderStyle-ForeColor="DimGray" GridLines="None" Width="100%" OnRowCommand="gridExamenes_RowCommand">


                                <Columns>
                                    <asp:BoundField HeaderText="Fecha y hora" DataField="Fecha" />
                                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                                    <asp:ButtonField HeaderText="Ver" CommandName="ver"
                                        ControlStyle-CssClass="btn btn-neutro fas fa-eye fa-2x" runat="server" />
                                </Columns>
                            </asp:GridView>

                        </div>


                        <br />


                        <div class="alinearBtnNuevo">
                            <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-12 ubicacionBtnNuevo">
                                <button type="button" class="btn btn-neutro btnNuevoExpediente" data-toggle="modal" data-target="#exampleModal" id="nuevaExamen">AÑADIR EXAMEN</button>
                            </div>
                        </div>
                    </div>

                </div>

            </div>


            <div class="form-row alinearBtnRegresar">
                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12 ubicacionBtnRegresar" runat="server">
                    <asp:Button type="button" runat="server" CssClass="btn btn-regresar" Text="REGRESAR" ID="regresar" OnClick="regresar_Click" />
                </div>
            </div>


            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h6 class="modal-title" id="exampleModalLabel">Añadir Examen de Laboratorio</h6>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="form-group">

                                <asp:FileUpload ID="archivoSeleccionado" CssClass="form-control-file" runat="server" />

                            </div>
                            <div class="form-group">
                                <label for="descripcion" class="col-form-label">Descripción</label>
                                <textarea class="form-control" id="descripcion" runat="server"></textarea>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">CERRAR</button>
                            <asp:Button type="button" runat="server" CssClass="btn btn-info" Text="AÑADIR" OnClick="btnAnadir_Click" ID="btnAnadir" />
                        </div>
                    </div>

                </div>
            </div>

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  
            <asp:HiddenField ID="campoEscondido" runat="server" />



            <asp:ModalPopupExtender ID="modalEdicion" runat="server"
                PopupControlID="panelContenido" TargetControlID="campoEscondido"
                CancelControlID="CerrarModal" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>


            <asp:Panel ID="panelContenido" runat="server" CssClass="modal-content container-fluid col-11 col-auto
                                  modal-dialog-scrollable">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="CerrarModal">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>


                <div class="modal-body">

                    <asp:Literal ID="errorCarga" runat="server" Visible="false"></asp:Literal>

                    <asp:Image ID="vistaExamen" runat="server" ImageUrl = "~/RecuperarImagen.aspx"/>

                </div>
            </asp:Panel>









        </form>


    </div>






</asp:Content>
