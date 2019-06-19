<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="MiAgenda.aspx.cs" Inherits="Pediatric_System.MiAgenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="CSS/hora1.css">
    <script src="JS/hora1.js"></script>
    <script src="JS/hora2.js"></script>
    <script src="JS/selectorHora.js"></script>


    <script type="text/javascript">

        $(document).ready(function () {

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {

                $('.clockpicker').clockpicker({
                    'default': 'now',
                    vibrate: true,
                    placement: "down",
                    align: "right",
                    autoclose: true,
                    twelvehour: true
                });
                $('.clockpicker2').clockpicker({
                    'default': 'now',
                    vibrate: true,
                    placement: "down",
                    align: "right",
                    autoclose: true,
                    twelvehour: true
                });

            }

        });
    </script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <div class="container-fluid col-10 col-auto">
        <div class="page-header">
            <h3 class="text-info">Agenda Laboral Estándar</h3>
        </div>
    </div>

    <hr style="color: #0056b2;" />

    <form runat="server">

        <br />

        <div class="container-fluid col-10 col-auto">

            <div class="card">

                <h5 class="card-header text-center" style="color: dimgray;">Horario</h5>


                <div class="card-body">

                    <asp:ScriptManager ID="scriptmng" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="checkbox" id="lunes" value="Lunes" runat="server">
                                <label class="form-check-label" for="lunes">Lunes</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="checkbox" id="martes" value="Martes" runat="server">
                                <label class="form-check-label" for="martes">Martes</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="checkbox" id="miercoles" value="Miércoles" runat="server">
                                <label class="form-check-label" for="miercoles">Miércoles</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="checkbox" id="jueves" value="Jueves" runat="server">
                                <label class="form-check-label" for="jueves">Jueves</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="checkbox" id="viernes" value="Viernes" runat="server">
                                <label class="form-check-label" for="viernes">Viernes</label>
                            </div>

                            <br />
                            <br />

                            <div class="form-row">

                                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                    <div class="input-group clockpicker">
                                        <input type="text" class="form-control" placeholder="Hora de Inicio" id="horaInicio" runat="server">
                                    </div>
                                </div>
                                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                    <div class="input-group clockpicker2">
                                        <input type="text" class="form-control" placeholder="Hora de Fin" id="horaFin" runat="server">
                                    </div>
                                </div>

                            </div>

                            <div class="form-row" style="text-align: center; display: block">
                                <div class="form-group col-lg-3 col-md-3 col-sm-6 col-xs-6 " runat="server" style="display: inline-block" id="form_actualizar">
                                    <asp:Button type="button" runat="server" class="btn btn-neutro form-control" Text="ACTUALIZAR" ID="Actualizar" OnClick="Actualizar_Click" />
                                   
                                </div>
                            </div>

                            <asp:Literal ID="mensajeConfirmacion" runat="server" Visible="false"></asp:Literal>

                            <div class="table-responsive">
                                <asp:GridView ID="vistaAgenda" runat="server" CssClass="table"
                                    Style="text-align: center" AutoGenerateColumns="false" HeaderStyle-CssClass="thead-light"
                                    HeaderStyle-ForeColor="DimGray" GridLines="None" OnRowCommand="vistaAgenda_RowCommand">

                                    <Columns>
                                        <asp:BoundField HeaderText="Día" DataField="Dia" ControlStyle-Width="25%" />
                                        <asp:BoundField HeaderText="Inicio" DataField="HoraInicio" ControlStyle-Width="25%" />
                                        <asp:BoundField HeaderText="Fin" DataField="HoraFin" ControlStyle-Width="25%" />
                                        <asp:ButtonField HeaderText="Acción" CommandName="Eliminar"
                                            ControlStyle-CssClass="btn btn-eliminar form-control fas fa-trash-alt" runat="server" ControlStyle-Width="25%" />


                                    </Columns>
                                </asp:GridView>


                            </div>


                        </ContentTemplate>

                    </asp:UpdatePanel>


                </div>


                <br />

                <div class="form-row" style="text-align: right; display: block; margin-right: 15px;">
                    <div class="form-group col-lg-3 col-md-3 col-sm-6 col-xs-6" style="display: inline-block">
                        <asp:Button type="button" runat="server" class="btn btn-regresar  form-control" Text="REGRESAR" ID="Regresar" />
                    </div>
                </div>
            </div>
        </div>
    </form>

    <br />

    <script type="text/javascript">

        $('.clockpicker').clockpicker({
            'default': 'now',
            vibrate: true,
            placement: "down",
            align: "right",
            autoclose: true,
            twelvehour: true
        });
        $('.clockpicker2').clockpicker({
            'default': 'now',
            vibrate: true,
            placement: "down",
            align: "right",
            autoclose: true,
            twelvehour: true
        });

    </script>


</asp:Content>
