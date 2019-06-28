<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AsociarPaciente.aspx.cs" Inherits="Pediatric_System.AsociarPaciente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="CSS/agenda.css" />
    <link rel="stylesheet" href="CSS/expediente.css" />
    <script type="text/javascript">
        $(function () {
            $('[id*=gridCuentas]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "numbers"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <div class="container-fluid col-11 col-auto">
        <br>
        <div class="page-header margen-general-2-top">
            <h2 class="text-info">Vincular Pacientes</h2>
        </div>

        <hr class="linea-divisoria-titulo" />
    </div>
    <div class="container-fluid col-11 col-auto table-responsive">
        <form id="form1" runat="server">
            <div class="card">
                <div>
                </div>
                <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-table"></i>Lista de Cuentas de Pacientes</h5>

                <div class="card-body">
                    <div>
                        <asp:GridView ID="gridCuentas" runat="server" AutoGenerateColumns="false" class="table table-hover" OnRowCommand="grdAccidentMaster_OnRowCommand"
                            Width="100%" HeaderStyle-ForeColor="DimGray" GridLines="None" HeaderStyle-CssClass="thead-light" OnSelectedIndexChanged="gridCuentas_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Correo" HeaderText="Correo" />
                                <asp:TemplateField HeaderText="Asociar" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Button ID="btnAsociar" ControlStyle-CssClass="btn btn-neutro fas fa-edit" ControlStyle-Width="33.3%" runat="server" ClientIDMode="Static"
                                            Text="Asociar Expediente(s)" CommandName="enviarCorreo" CommandArgument='<%# Eval("Correo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                <asp:HiddenField ID="campoEscondido" runat="server" />

                <asp:ModalPopupExtender ID="modalExpedientes" runat="server"
                    PopupControlID="panelContenido" TargetControlID="campoEscondido"
                    CancelControlID="CerrarModal" BackgroundCssClass="modalBackground">
                </asp:ModalPopupExtender>

                <asp:Panel ID="panelContenido" runat="server" CssClass="modal-content container-fluid col-9 col-auto
                                  modal-dialog-scrollable">
                    <div class="modal-header">
                        <h5 class="modal-title" runat="server" id="exampleModalLabel">Expedientes</h5>

                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="CerrarModal">
                            <span aria-hidden="true">&times;</span>
                        </button>

                    </div>

                    <asp:ScriptManager ID="scriptmng" runat="server"></asp:ScriptManager>

                    <div class="modal-body">
            <div class="card">
                <div>
                </div>
                <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-table"></i>Lista de Expedientes</h5>
                <div class="card-body">
                    <div>
                        <asp:GridView ID="gridExpedientes" runat="server" AutoGenerateColumns="false" class="table table-hover" OnRowCommand="grdAccidentMaster_OnRowCommand"
                            Width="100%" HeaderStyle-ForeColor="DimGray" GridLines="None" HeaderStyle-CssClass="thead-light" OnSelectedIndexChanged="gridCuentas_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Cedula_Expediente" HeaderText="Cedula" />
                                <asp:TemplateField HeaderText="Acciones" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
<%--                                        <asp:Button ID="btnEditarCuenta" ControlStyle-CssClass="btn btn-neutro fas fa-edit" ControlStyle-Width="33.3%" runat="server" ClientIDMode="Static"
                                            Text="Editar / Mirar" CommandName="enviarCorreo" CommandArgument='<%# Eval("Correo") %>' />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
                    </div>
                </asp:Panel>
            </div>
        </form>
    </div>
</asp:Content>
