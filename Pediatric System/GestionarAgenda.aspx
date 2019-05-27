<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="GestionarAgenda.aspx.cs" Inherits="Pediatric_System.GestionarAgenda" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="CSS/SelectorTabla.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="container-fluid col-10 col-auto">
        <div class="page-header">
            <h3 class="text-info">Agenda Semanal</h3>
        </div>
    </div>

    <hr style="color: #0056b2;" />

    <div class="container-fluid col-10">

        <br />

        <div class="form-row">
            <div class="form-group">
                <form id="form1" runat="server">
                    <asp:ScriptManager ID="scriptmng" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Calendar ID="CalendFechaIni" runat="server" SelectionMode="DayWeek" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#16ACB8" ForeColor="White" />
                                <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#16ACB8" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </form>
            </div>
        </div>

    </div>



    <form>

        <div class="container-fluid col-10 col-auto table-responsive">

            <br />

            <table class="table table-bordered">

                <thead>
                    <tr class="table-primary">
                        <th scope="col">HORA</th>
                        <th scope="col">LUNES</th>
                        <th scope="col">MARTES</th>
                        <th scope="col">MIÉRCOLES</th>
                        <th scope="col">JUEVES</th>
                        <th scope="col">VIERNES</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope="row">4:30 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success"></td>
                    </tr>
                    <tr>
                        <th scope="row">5:00 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger"></td>
                    </tr>
                    <tr>
                        <th scope="row">5:30 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger"></td>
                    </tr>
                    <tr>
                        <th scope="row">6:00 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light"></td>
                    </tr>
                    <tr>
                        <th scope="row">6:30 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger"></td>
                    </tr>
                    <tr>
                        <th scope="row">7:00 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger"></td>
                    </tr>
                    <tr>
                        <th scope="row">7:30 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success"></td>
                    </tr>
                </tbody>
            </table>

        </div>


        <!-- Modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
                                <label class="form-check-label" for="inlineRadio1">DISPONIBLE</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="radio" name="inlineRadioOptions" id="deshabilitado" value="option2">
                                <label class="form-check-label" for="inlineRadio2">DESHABILITADO</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio3" value="option3" disabled>
                                <label class="form-check-label" for="inlineRadio3">OCUPADO</label>
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
        </div>

        <br />

        <div class="container-fluid col-4 col-auto">
            <button type="button" class="btn btn-outline-danger form-control col-lg-12 col-md-12 col-sm-12 col-xs-12">REGRESAR</button>
        </div>

        <br />

    </form>






    <script>
        $(document).on('click', '#disponible', function () {
            $("#agendar").removeAttr("disabled");
            $("#correoElectronico").removeAttr("disabled");
        });


        $(document).on('click', '#deshabilitado', function () {
            $("#agendar").attr("disabled", "disabled");
            $("#correoElectronico").attr("disabled", "disabled");
        });

    </script>

</asp:Content>
