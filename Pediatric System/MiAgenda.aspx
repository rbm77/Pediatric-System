<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="MiAgenda.aspx.cs" Inherits="Pediatric_System.MiAgenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="CSS/hora1.css">
    <script src="JS/hora1.js"></script>
    <script src="JS/hora2.js"></script>
    <script src="JS/selectorHora.js"></script>


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

                            <%--                    <div class="form-row" style="text-align: center; display: block">
                        <div class="form-group col-lg-3 col-md-3 col-sm-6 col-xs-6" style="display: inline-block">
                            <asp:Button type="button" runat="server" class="btn btn-outline-danger form-control" Text="ELIMINAR" ID="Eliminar" />
                        </div>
                    </div>--%>

                            <div class="form-row" style="text-align: center; display: block">
                                <div class="form-group col-lg-3 col-md-3 col-sm-6 col-xs-6" style="display: inline-block">
                                    <asp:Button type="button" runat="server" class="btn btn-outline-primary form-control" Text="ACTUALIZAR" ID="Actualizar" OnClick="Actualizar_Click" />
                                </div>
                            </div>


                            <div class="table-responsive">
                                <asp:GridView ID="vistaAgenda" runat="server" CssClass="table"
                                    Style="text-align: center" AutoGenerateColumns="false" HeaderStyle-CssClass="thead-light"
                                    HeaderStyle-ForeColor="DimGray" GridLines="None" OnRowCommand="vistaAgenda_RowCommand">

                                    <Columns>
                                        <asp:BoundField HeaderText="Día" DataField="Dia" />
                                        <asp:BoundField HeaderText="Inicio" DataField="HoraInicio" />
                                        <asp:BoundField HeaderText="Fin" DataField="HoraFin" />
                                        <asp:ButtonField CommandName="Eliminar" Text="ELIMINAR"
                                            ControlStyle-CssClass="btn btn-outline-danger form-control" runat="server" />


                                    </Columns>
                                </asp:GridView>


                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>



                    <%--                    <asp:Repeater ID="repetidor" runat="server">

                        <HeaderTemplate>
                            <table class="table" style="text-align: center">
                                <thead>
                                    <tr class="bg-light">
                                        <th scope="col" style="width: 25%; color: dimgray;">Día</th>
                                        <th scope="col" style="width: 25%; color: dimgray;">Inicio</th>
                                        <th scope="col" style="width: 25%; color: dimgray;">Fin</th>
                                        <th scope="col" style="width: 25%; color: dimgray;"></th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>

                        <ItemTemplate>

                            <tr>
                                <td><%# DataBinder.Eval(Container.DataItem, "Dia")%></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "HoraInicio")%></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "HoraFin")%></td>
                                <td>
                                    <asp:Button type="button" runat="server" class="btn btn-outline-danger form-control" Text="ELIMINAR" ID="<%# DataBinder.Eval(Container.DataItem, "Dia")%>" OnClick="" />
                                </td>
                            </tr>

                        </ItemTemplate>

                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>

                    </asp:Repeater>--%>







                    <%--                    <table class="table table-striped" style="text-align: center">
                        <thead>
                            <tr class="bg-light">
                                <th scope="col" style="width: 25%; font-size: 16px; font-weight: bold; color: dimgray">Día</th>
                                <th scope="col" style="width: 25%; font-size: 16px; font-weight: bold; color: dimgray">Desde</th>
                                <th scope="col" style="width: 25%; font-size: 16px; font-weight: bold; color: dimgray">Hasta</th>
                                <th scope="col" style="width: 25%; font-size: 16px; font-weight: bold; color: dimgray"></th>
                            </tr>
                        </thead>
                        <tbody id="contenedor" runat="server">
                        </tbody>
                    </table>--%>
                </div>


                <br />

                <div class="form-row" style="text-align: center; display: block">
                    <div class="form-group col-lg-3 col-md-3 col-sm-6 col-xs-6" style="display: inline-block">
                        <asp:Button type="button" runat="server" class="btn btn-outline-warning form-control" Text="REGRESAR" ID="Regresar" />
                    </div>
                </div>
            </div>
        </div>
    </form>










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

    <br />

</asp:Content>
