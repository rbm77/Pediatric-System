<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="SelecionExpedientes.aspx.cs" Inherits="Pediatric_System.SelecionExpedientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(function () {
            $('[id*=gridConExpedientes]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "numbers"
            });
        });
    </script>

    <link href="CSS/listaExpedientes.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid col-11 col-auto">
        <div class="page-header margen-general-2-top">
            <h3 class="text-info">Expedientes</h3>
        </div>

        <hr class="linea-divisoria-titulo" />


        <form runat="server">

            <div class="col-12 margen-general-1-bottom paddingSidesCard">
                <div style="text-align: center;" >
                 <asp:Label ID="lblCuentaSel" runat="server" Text="" CssClass="text-info" Font-Size="20px"></asp:Label>
               </div>
               
                 <div class="table-responsive">
                        <br />
                    <div class="card">
                        <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-list"></i>  Lista de Expedientes Sin Cuenta Asociada</h5>
                        <div class="card-body">
                            <div>

                                <asp:GridView ID="gridConExpedientes" runat="server" CssClass="table" Style="text-align: center"
                                    AutoGenerateColumns="false" HeaderStyle-CssClass="thead-light"
                                    HeaderStyle-ForeColor="DimGray" GridLines="None" Width="100%"
                                    OnRowCommand="gridExpedientes_RowCommand">
                                    <Columns>
                                        <asp:BoundField HeaderText="Paciente" DataField="Nombre" />
                                        <asp:BoundField HeaderText="Cédula" DataField="Cedula" />
                                        <asp:BoundField HeaderText="Sexo" DataField="Sexo" />
                                        <asp:ButtonField HeaderText="Asociar" CommandName="AsociarExpedienteEspecifico" Text="Asociar"
                                            ControlStyle-CssClass="btn btn-neutro fas fa-edit" runat="server" ControlStyle-Width="38%" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                    </Columns>
                                </asp:GridView>

                            </div>

                            <br />
                        </div>
                    </div>
                </div>
            </div>

            <!-- Modal >
            <div-- class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel" style="color: dimgray;">CUENTA DE USUARIO EXTERNO</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="card">
                                <div class="card-body">
                                    <p class="card-text col-lg-12 col-md-12 col-sm-12 col-xs-12" style="color: dimgray;">
                                        Se enviará un correo a la dirección ingresada, el cual contiene la contraseña
                                    de acceso al sistema.
                                    </p>
                                    <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <label style="color: dimgray;" for="correoElectronico">Correo Electrónico</label>
                                        <input type="email" class="form-control" id="correoElectronico" />
                                    </div>
                                    <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                        <button type="submit" class="btn btn-outline-primary form-control">ENVIAR</button>

                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div-->
            <asp:Literal ID="mensajeConfirmacion" runat="server" Visible="false"></asp:Literal>
            <div class="form-row alinearBtnRegresar">
                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12 ubicacionBtnRegresar" runat="server">
                    <asp:Button type="button" runat="server" CssClass="btn btn-regresar" Text="REGRESAR" ID="regresar" OnClick="regresar_Click" />
                </div>
            </div>

        </form>
    </div>
</asp:Content>
