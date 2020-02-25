<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaConsultasActivas.aspx.cs" Inherits="Pediatric_System.ListaConsultasActivas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(function () {
            $('[id*=gridConsultasActivas]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
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
            <h3 class="text-info">Consultas Activas</h3>
        </div>

        <hr class="linea-divisoria-titulo" />


        <form runat="server">

            <asp:Literal ID="mensajeConfirmacion" runat="server" Visible="false"></asp:Literal>


            <div class="col-12 margen-general-1-bottom paddingSidesCard">

                <div class="card">

                    <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-list"></i>  Lista de Consultas Activas</h5>

                    <div class="card-body">
                        <div class="table-responsive" style="padding-left: 0px; padding-right: 0px">

                            <asp:GridView ID="gridConsultasActivas" runat="server" CssClass="table" Style="text-align: center"
                                AutoGenerateColumns="false" HeaderStyle-CssClass="thead-light"
                                HeaderStyle-ForeColor="DimGray" GridLines="None" Width="100%" OnRowCommand="gridConsultasActivas_RowCommand">


                                <Columns>
                                    <asp:BoundField HeaderText="Paciente" DataField="Paciente" />
                                    <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                                    <asp:ButtonField HeaderText="Ver Consulta" CommandName="seleccionar"
                                        ControlStyle-CssClass="btn btn-neutro fas fa-eye" runat="server" ControlStyle-Width="25%" />
                                </Columns>
                            </asp:GridView>

                        </div>


                        <br />

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
