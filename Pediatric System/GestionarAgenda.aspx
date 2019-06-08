<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="GestionarAgenda.aspx.cs" Inherits="Pediatric_System.GestionarAgenda" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="container-fluid col-10 col-auto">
        <div class="page-header">
            <h3 class="text-info">Citas</h3>
        </div>
    </div>

    <hr style="color: #0056b2;" />

    <div class="container-fluid col-10">

        <br />

        <div class="form-row" style="text-align: center; display: block">
            <div class="form-group" style="display: inline-block">
                <form id="form1" runat="server">
                    <asp:ScriptManager ID="scriptmng" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Calendar ID="calendario" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px"
                                Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth"
                                Width="350px" OnSelectionChanged="ActualizarAgenda" OnDayRender="calendario_DayRender">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#16ACB8" ForeColor="White" />
                                <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#16ACB8" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>

                            <%--  <asp:Label ID="miEtiqueta" runat="server" Text="Nada por ahora"></asp:Label>--%>

                            <br />
                            <br />


                            <asp:Repeater ID="repetidor" runat="server">

                                <HeaderTemplate>
                                </HeaderTemplate>

                                <ItemTemplate>

                                    <div class="row">
                                        <div class="col">
                                            <%# DataBinder.Eval(Container.DataItem, "Hora")%>
                                        </div>
                                        <div class="col">
                                        </div>
                                    </div>

                                </ItemTemplate>

                            </asp:Repeater>



                        </ContentTemplate>
                    </asp:UpdatePanel>








                </form>
            </div>
        </div>


    </div>



    <%-- <form runat="server">--%>

    <%-- <div class="container-fluid col-10 col-auto table-responsive">
    --%>

    <%--            <div class="form-row" style="text-align: center; display: block">
                <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-6" style="display: inline-block">
                    <asp:Button type="button" runat="server" class="btn btn-outline-info form-control" Text="SEMANA ACTUAL" ID="Actual" />
                </div>
                <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-6" style="display: inline-block">
                    <asp:Button type="button" runat="server" class="btn btn-outline-info form-control" Text="SIGUIENTE SEMANA" ID="Siguiente" />
                </div>
            </div>--%>


    <%-- <div style="text-align: center; display: block">

                <div class="btn-group btn-group-toggle col-lg-6 col-md-6 col-sm-6 col-xs-6" data-toggle="buttons">

                    <label class="btn btn-outline-info form-control active">
                        <input type="radio" name="options" id="option1" checked>
                        SEMANA ACTUAL
                    </label>
                    <label class="btn btn-outline-info form-control">
                        <input type="radio" name="options" id="option2">
                        SIGUIENTE SEMANA
                    </label>
                </div>
            </div>--%>



    <br />

    <%--          <table class="table table-bordered">

                <thead>
                    <tr class="bg-info">
                        <th scope="col" style="font-size: 18px; font-weight: bold; color: white; width: 14%; text-align: center; border: 2px solid;">Hora</th>
                        <th scope="col" style="font-size: 18px; font-weight: bold; color: white; width: 14%; text-align: center; border: 2px solid;">Lunes</th>
                        <th scope="col" style="font-size: 18px; font-weight: bold; color: white; width: 14%; text-align: center; border: 2px solid;">Martes</th>
                        <th scope="col" style="font-size: 18px; font-weight: bold; color: white; width: 14%; text-align: center; border: 2px solid;">Miércoles</th>
                        <th scope="col" style="font-size: 18px; font-weight: bold; color: white; width: 14%; text-align: center; border: 2px solid;">Jueves</th>
                        <th scope="col" style="font-size: 18px; font-weight: bold; color: white; width: 14%; text-align: center; border: 2px solid;">Viernes</th>
                        <%--                        <th scope="col" style="font-size: 18px; font-weight: bold; color: white; width: 14%; text-align: center; border: 2px solid;">Sábado</th>--%>
    <%--        </tr>
                </thead>--%>
    <%--                <tbody>
                    <tr>
                        <th class="bg-info" scope="row" style="font-size: 16px; font-weight: bold; color: white; text-align: center; border: 2px solid white;">4:30 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                    </tr>
                    <tr>
                        <th class="bg-info" scope="row" style="font-size: 16px; font-weight: bold; color: white; text-align: center; border: 2px solid white;">5:00 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                    </tr>
                    <tr>
                        <th class="bg-info" scope="row" style="font-size: 16px; font-weight: bold; color: white; text-align: center; border: 2px solid white;">5:30 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                    </tr>
                    <tr>
                        <th class="bg-info" scope="row" style="font-size: 16px; font-weight: bold; color: white; text-align: center; border: 2px solid white;">6:00 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                    </tr>
                    <tr>
                        <th class="bg-info" scope="row" style="font-size: 16px; font-weight: bold; color: white; text-align: center; border: 2px solid white;">6:30 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                    </tr>
                    <tr>
                        <th class="bg-info" scope="row" style="font-size: 16px; font-weight: bold; color: white; text-align: center; border: 2px solid white;">7:00 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                    </tr>
                    <tr>
                        <th class="bg-info" scope="row" style="font-size: 16px; font-weight: bold; color: white; text-align: center; border: 2px solid white;">7:30 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                    </tr>
                </tbody>
            </table>--%>

    <%--        </div>--%>


    <!-- Modal -->
    <%-- <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">ESTADO</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">

                        <div class="container-fluid">

                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="radio" name="inlineRadioOptions" id="disponible" value="option1">
                                <label class="form-check-label" for="inlineRadio1" style="font-size: 16px; font-weight: bold; color: dimgray;">DISPONIBLE</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="radio" name="inlineRadioOptions" id="deshabilitado" value="option2">
                                <label class="form-check-label" for="inlineRadio2" style="font-size: 16px; font-weight: bold; color: dimgray;">DESHABILITADO</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio3" value="option3" disabled>
                                <label class="form-check-label" for="inlineRadio3" style="font-size: 16px; font-weight: bold; color: dimgray;">OCUPADO</label>
                            </div>
                        </div>
                        <br />

                        <button class="btn btn-outline-primary form-control" type="button" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample" id="agendar">
                            AGENDAR CITA
                        </button>

                        <br />

                        <div class="collapse" id="collapseExample">
                            <div class="card card-body">
                                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <label for="correoElectronico">Correo Electrónico</label>
                                    <input type="email" class="form-control" id="correoElectronico" />
                                </div>
                                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <button type="submit" class="btn btn-outline-success form-control">GUARDAR</button>

                                </div>
                            </div>
                        </div>
                        <br />
                        <button class="btn btn-outline-danger form-control" type="button" id="cancelar">
                            CANCELAR CITA
                        </button>
                    </div>
                </div>
            </div>
        </div>--%>

    <br />

    <div class="container-fluid col-4 col-auto">
        <button type="submit" class="btn btn-outline-danger form-control col-lg-12 col-md-12 col-sm-12 col-xs-12">REGRESAR</button>
    </div>

    <br />

    <%-- </form>--%>






    <%--    <script>
        $(document).on('click', '#disponible', function () {
            $("#agendar").removeAttr("disabled");
            $("#correoElectronico").removeAttr("disabled");
        });


        $(document).on('click', '#deshabilitado', function () {
            $("#agendar").attr("disabled", "disabled");
            $("#correoElectronico").attr("disabled", "disabled");
        });

    </script>--%>
</asp:Content>
