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

    <div class="container-fluid col-11 col-auto">
        <br>
        <div class="page-header margen-general-2-top">
            <h2 class="text-info">Cuentas Pacientes</h2>
        </div>

        <hr class="linea-divisoria-titulo" />
    </div>
    <div class="container-fluid col-11 col-auto table-responsive">

        <div>
            <ul class="nav nav-tabs" id="myTab" role="tablist">
                <li class="nav-item">
                    <a class="nav-link active nombre-input" id="asociar-pacientes-tab" data-toggle="tab" href="#asociar-pacientes" role="tab" aria-controls="asociar-pacientes" aria-selected="true">Asociar Expedientes</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link nombre-input" id="cuenta-paciente-tab" data-toggle="tab" href="#cuenta-paciente" role="tab" aria-controls="cuenta-paciente" aria-selected="false">Cuenta Paciente</a>
                </li>
            </ul>
        </div>
        <asp:Label ID="lblCorreo" runat="server" Text="Label" Visible="false"></asp:Label>

        <form id="form1" runat="server">

            <div class="tab-content" id="myTabContent">
                <%--________________Asociar Expediente_______________--%>
                <%--________________Asociar Expediente_______________--%>

                <div class="tab-pane fade show active margen-general-1-bottom" id="asociar-pacientes" role="tabpanel" aria-labelledby="asociar-pacientes-tab">
                    <div class="card">
                        <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-list"></i>Cuentas de Usuario Externo</h5>
                        <div class="card-body">
                            <asp:GridView ID="gridCuentas" runat="server" AutoGenerateColumns="false" class="table table-hover" OnRowCommand="gridCuentas_RowCommand"
                                Width="100%" HeaderStyle-ForeColor="DimGray" GridLines="None" HeaderStyle-CssClass="thead-light">
                                <Columns>
                                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                                    <asp:ButtonField HeaderText="Asociar" CommandName="AsociarExpediente" Text="Asociar Expediente(s)"
                                        ControlStyle-CssClass="btn btn-neutro fas fa-edit" runat="server" ControlStyle-Width="190px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                    <br>

                    <asp:Literal ID="mensajeConfirmacion" runat="server" Visible="false"></asp:Literal>

                    <div class="form-row" style="text-align: right; display: block">
                        <div class="form-group col-lg-3 col-md-3 col-sm-6 col-xs-6" style="display: inline-block">
                            <asp:Button type="button" runat="server" class="btn btn-regresar" Text="REGRESAR" ID="Button1" CausesValidation="False" UseSubmitBehavior="false" OnClick="Regresar_Click" />
                        </div>
                    </div>

                </div>
                <%--________________Crear Cuenta de paciente_______________--%>
                <%--________________Crear Cuenta de paciente_______________--%>

                <div class="tab-pane fade show margen-general-1-bottom" id="cuenta-paciente" role="tabpanel" aria-labelledby="cuenta-paciente-tab">
                    <div class="col-12 border rounded margen-general-0-top">
                        <br>
                        <div class="margen-general-1-top padding-general-inicio-bottom" style="width: 50%; margin: 0 auto;">
                            <div class="form-row">
                                <div class="form-group col-lg-8 col-md-6 col-sm-6 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-label">Correo</label>
                                        <asp:TextBox runat="server" ID="txtCorreo" CssClass="form-control" required="required" TextMode="Email"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br>
                    <div class="form-row alinearBtnGuardarExp">
                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12 ubicacionBtn" runat="server">
                            <asp:Button type="button" runat="server" CssClass="btn btn-regresar" Text="REGRESAR" ID="Button2" OnClick="Regresar_Click" CausesValidation="False" UseSubmitBehavior="false" />
                            <asp:Button type="button" runat="server" CssClass="btn btn-guardar" Text="GUARDAR" ID="guardarExpediente" OnClick="btnGuardar_Click" />
                        </div>
                    </div>
                </div>
            </div>

        </form>
    </div>


</asp:Content>
