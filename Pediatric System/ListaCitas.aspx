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

            <asp:Literal ID="mensajeConfirmacion" runat="server" Visible="false"></asp:Literal>


            <div class="col-12 margen-general-1-bottom paddingSidesCard">

                <div class="card">

                    <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-list"></i>  Lista de Citas Pendientes</h5>

                    <div class="card-body">
                        <div class="table-responsive" style="padding-left: 0px; padding-right: 0px">

                            <asp:GridView ID="gridCitas" runat="server" CssClass="table" Style="text-align: center"
                                AutoGenerateColumns="false" HeaderStyle-CssClass="thead-light"
                                HeaderStyle-ForeColor="DimGray" GridLines="None" Width="100%" OnRowCommand="gridCitas_RowCommand">


                                <Columns>
                                    <asp:BoundField HeaderText="Paciente" DataField="Nombre" />
                                    <asp:BoundField HeaderText="Médico" DataField="NombreMedico" />
                                    <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                                    <asp:BoundField HeaderText="Hora" DataField="Hora" />
                                    <asp:ButtonField HeaderText="Cancelar Cita" CommandName="cancelar"
                                        ControlStyle-CssClass="btn btn-eliminar fas fa-calendar-times fa-2x" runat="server" ControlStyle-Width="25%" />
                                </Columns>
                            </asp:GridView>

                        </div>


                        <br />


                        <div class="alinearBtnNuevo">
                            <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-12 ubicacionBtnNuevo">
                                <asp:Button type="button" runat="server" CssClass="btn btn-neutro btnNuevoExpediente" Text="NUEVA CITA" ID="nuevaCita" OnClick="nuevaCita_Click" />
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
        </form>






    </div>
</asp:Content>
