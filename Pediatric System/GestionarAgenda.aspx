<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="GestionarAgenda.aspx.cs" Inherits="Pediatric_System.GestionarAgenda" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <form id="form1" runat="server">

                <asp:Calendar ID="Calendar1" runat="server"
                    SelectionMode="DayWeek"
                    ShowGridLines="True">

                    <SelectedDayStyle BackColor="SkyBlue"
                        ForeColor="White"></SelectedDayStyle>

                </asp:Calendar>

            </form>
                </div>
            <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <span class="help-block">Por favor seleccione la semana para la que desea observar la agenda.</span>
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
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <th scope="row">5:00 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light"></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <th scope="row">5:30 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success"></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <th scope="row">6:00 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light"></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <th scope="row">6:30 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success"></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <th scope="row">7:00 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger"></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <th scope="row">7:30 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success"></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
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
                        <br />

                        <div class="collapse" id="collapseExample">
                            <div class="card card-body">
                                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <label for="correoElectronico">Correo Electrónico</label>
                                    <input type="email" class="form-control" id="correoElectronico" />
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">

                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">

                            <button type="submit" class="btn btn-outline-success form-control">GUARDAR</button>

                        </div>

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
