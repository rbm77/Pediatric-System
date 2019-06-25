<%@ Page Culture="es-ES" Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="GestionarAgenda.aspx.cs" Inherits="Pediatric_System.GestionarAgenda" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="CSS/agenda.css" />
    <link rel="stylesheet" href="CSS/expediente.css" />
    <%--   <link rel="stylesheet" href="CSS/inicioSesion.css" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="container-fluid col-11 col-auto">
        <div class="page-header">
            <h3 class="text-info">Citas</h3>

        </div>
    </div>

    <hr style="color: #0056b2;" />

    <br />

    <div class="container-fluid col-11 col-auto">


        <%--        <div class="form-row" style="text-align: center; display: block">
            <div class="form-group" style="display: inline-block">--%>
        <form id="form1" runat="server">

            <%--El scriptmanager se utiliza para manejar las peticiones ajax--%>
            <asp:ScriptManager ID="scriptmng" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>



                    <div class="container-fluid border rounded">

                        <div class="form-row table-responsive" style="text-align: center; display: block">
                            <div class="form-group" style="display: inline-block">

                                <br />

                                <asp:Calendar ID="calendario" runat="server" BackColor="White" BorderColor="white" BorderWidth="1px" Font-Names="Verdana" Font-Size="11pt" ForeColor="#1e5f93" Height="200px" NextPrevFormat="FullMonth" Width="400px" OnSelectionChanged="ActualizarAgenda" OnDayRender="calendario_DayRender">
                                    <DayHeaderStyle />
                                    <NextPrevStyle />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#16ACB8" ForeColor="White" />
                                    <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#1ca5ac" />
                                    <TodayDayStyle BackColor="#CCCCCC" />
                                </asp:Calendar>

                            </div>
                        </div>

                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                            <ProgressTemplate>

                                <div class="form-row" style="text-align: center; display: block">
                                    <div class="form-group" style="display: inline-block">

                                        <div class="lds-spinner align-content-center" style="display: inline-block">
                                            <div></div>
                                            <div></div>
                                            <div></div>
                                            <div></div>
                                            <div></div>
                                            <div></div>
                                            <div></div>
                                            <div></div>
                                            <div></div>
                                            <div></div>
                                            <div></div>
                                            <div></div>
                                        </div>

                                    </div>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>



                        <asp:Literal ID="mensajeConfirmacion" runat="server" Visible="false"></asp:Literal>


                        <div class="table-responsive">

                            <asp:GridView ID="vistaAgenda" runat="server" CssClass="table"
                                Style="text-align: center" AutoGenerateColumns="false" HeaderStyle-CssClass="bg-light"
                                HeaderStyle-ForeColor="DimGray" GridLines="None"
                                OnRowCommand="vistaAgenda_RowCommand"
                                OnRowDataBound="vistaAgenda_RowDataBound" RowStyle-CssClass="resaltado">


                                <Columns>
                                    <asp:BoundField HeaderText="Hora" DataField="Hora" ControlStyle-Width="33.3%" />
                                    <asp:BoundField HeaderText="Estado" DataField="Estado" ControlStyle-Width="33.3%" />


                                    <asp:ButtonField HeaderText="Acción" CommandName="Seleccionar"
                                        ControlStyle-CssClass="btn btn-neutro fas fa-edit" runat="server" ControlStyle-Width="33.3%" />

                                </Columns>





                            </asp:GridView>

                        </div>


                    </div>

                    <asp:HiddenField ID="campoEscondido" runat="server" />



                    <asp:ModalPopupExtender ID="modalEdicion" runat="server"
                        PopupControlID="panelContenido" TargetControlID="campoEscondido"
                        CancelControlID="CerrarModal" BackgroundCssClass="modalBackground">
                    </asp:ModalPopupExtender>


                    <asp:Panel ID="panelContenido" runat="server" CssClass="modal-content container-fluid col-11 col-auto
                                  modal-dialog-scrollable">

                        <div class="modal-header">
                            <h5 class="modal-title" runat="server" id="exampleModalLabel">CITA</h5>

                            <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="CerrarModal">
                                <span aria-hidden="true">&times;</span>
                            </button>

                        </div>
                        <div class="modal-body">
                            <div class="form-row margen-general-1-top">
                                <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label for="fecha" class="nombre-label">Fecha</label>
                                        <asp:TextBox runat="server" ID="fecha" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label for="hora" class="nombre-label">Hora</label>
                                        <asp:TextBox runat="server" ID="horaTxt" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label for="nombre" class="nombre-label">Nombre Completo</label>
                                        <asp:TextBox runat="server" ID="nombre" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label for="edad" class="nombre-label">Edad</label>
                                        <asp:TextBox runat="server" ID="edad" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label for="correo" class="nombre-label">Correo Electrónico</label>
                                        <asp:TextBox runat="server" ID="correo" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label for="telefono" class="nombre-label">Número Telefónico</label>
                                        <asp:TextBox runat="server" ID="telefono" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                        </div>
                        <div class="modal-footer">

                            <div class="form-group" style="text-align: center; display: inline-block">

                                <asp:Button type="button" runat="server" class="btn btn-guardar" Text="CREAR CITA" ID="btnCrear" OnClick="btnCrear_Click" />

                                <br />
                                <br />

                                <div class="lds-spinner">
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                </div>
                            </div>

                            <div class="form-group" style="text-align: center; display: inline-block">

                                <asp:Button type="button" runat="server" class="btn btn-eliminar" Text="CANCELAR CITA" ID="btnCancelar" OnClick="btnCancelar_Click" />

                                <br />
                                <br />

                                <div class="lds-spinner">
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                    <div></div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>



                </ContentTemplate>
            </asp:UpdatePanel>





            <br />
            <div class="form-row" style="text-align: right; display: block">
                <div class="form-group col-lg-3 col-md-3 col-sm-6 col-xs-6" style="display: inline-block">
                    <asp:Button type="button" runat="server" class="btn btn-regresar" Text="REGRESAR" ID="Regresar" OnClick="Regresar_Click" />
                </div>
            </div>

        </form>



    </div>

    <script>


        $(document).ready(function () {
            $("#btnCrear").click(function () {
                // disable button
                $(this).prop("disabled", true);
                // add spinner to button
                $(this).html(
                    `<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> CARGANDO...`
                );
            });
        });

    </script>




</asp:Content>
