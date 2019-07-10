<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaCitas.aspx.cs" Inherits="Pediatric_System.ListaCitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
    <script type="text/javascript">
        $(function () {
            $('[id*=gridCitas]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
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
            <h3 class="text-info">Citas</h3>
        </div>

        <hr class="linea-divisoria-titulo" />

        <form runat="server">

            <div class="col-12 margen-general-1-bottom paddingSidesCard">
                <div class="table-responsive">
                    <div class="card">
                        <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-list"></i>  Lista de Citas Pendientes</h5>
                        <div class="card-body">
                            <div>

                                <asp:GridView ID="gridCitas" runat="server" CssClass="table" Style="text-align: center"
                                    AutoGenerateColumns="false" HeaderStyle-CssClass="thead-light"
                                    HeaderStyle-ForeColor="DimGray" GridLines="None" Width="100%"
                                    >


                                    <Columns>
                                        <asp:BoundField HeaderText="Paciente" DataField="NombrePaciente" />
                                        <asp:BoundField HeaderText="Médico" DataField="Medico" />
                                        <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                                        <asp:BoundField HeaderText="Hora" DataField="Hora" />
                                        <asp:ButtonField HeaderText="Acción" CommandName="cancelar"
                                            ControlStyle-CssClass="btn btn-eliminar" runat="server" ControlStyle-Width="25%" Text="Cancelar" />
                                    </Columns>
                                </asp:GridView>

                            </div>

                            <br />


                            <div class="alinearBtnNuevo">
                                <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-12 ubicacionBtnNuevo">
                                    <asp:Button type="button" runat="server" CssClass="btn btn-neutro btnNuevoExpediente" Text="NUEVA CITA" ID="nuevaCita"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="form-row alinearBtnRegresar">
                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12 ubicacionBtnRegresar" runat="server">
                    <asp:Button type="button" runat="server" CssClass="btn btn-regresar" Text="REGRESAR" ID="regresar"/>
                </div>
            </div>

        </form>






    </div>
</asp:Content>
