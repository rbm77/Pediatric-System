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
            <h3 class="text-info">Agenda Semanal</h3>
        </div>
    </div>

    <hr style="color: #0056b2;" />

    <form runat="server">

        <br />

        <div class="container-fluid col-10 col-auto table-responsive">

            <div class="card">

                <h5 class="card-header text-center" style="color: dimgray;">Horario</h5>
                <div class="card-body">

                    <div class="form-check form-check-inline">
                        <input class="form-check-input" type="checkbox" id="lunes" value="lunes" runat="server">
                        <label class="form-check-label" for="lunes">Lunes</label>
                    </div>
                    <div class="form-check form-check-inline">
                        <input class="form-check-input" type="checkbox" id="martes" value="martes" runat="server">
                        <label class="form-check-label" for="martes">Martes</label>
                    </div>
                    <div class="form-check form-check-inline">
                        <input class="form-check-input" type="checkbox" id="miercoles" value="miercoles" runat="server">
                        <label class="form-check-label" for="miercoles">Miércoles</label>
                    </div>
                    <div class="form-check form-check-inline">
                        <input class="form-check-input" type="checkbox" id="jueves" value="jueves" runat="server">
                        <label class="form-check-label" for="jueves">Jueves</label>
                    </div>
                    <div class="form-check form-check-inline">
                        <input class="form-check-input" type="checkbox" id="viernes" value="viernes" runat="server">
                        <label class="form-check-label" for="viernes">Viernes</label>
                    </div>
                    <div class="form-check form-check-inline">
                        <input class="form-check-input" type="checkbox" id="sabado" value="sabado" runat="server">
                        <label class="form-check-label" for="sabado">Sábado</label>
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
                        <div class="form-group col-lg-3 col-md-3 col-sm-6 col-xs-6" style="display: inline-block">
                            <asp:Button type="button" runat="server" class="btn btn-outline-primary form-control" Text="ACTUALIZAR" ID="Actualizar" OnClick="Actualizar_Click" />
                        </div>
                        <div class="form-group col-lg-3 col-md-3 col-sm-6 col-xs-6" style="display: inline-block">
                            <asp:Button type="button" runat="server" class="btn btn-outline-danger form-control" Text="ELIMINAR" ID="Eliminar" />
                        </div>
                    </div>



                    <table class="table table-striped">
                        <thead>
                            <tr class="bg-light">
                                <th scope="col" style="width: 33%; font-size: 16px; font-weight: bold; color: dimgray">Día</th>
                                <th scope="col" style="width: 33%; font-size: 16px; font-weight: bold; color: dimgray">Desde</th>
                                <th scope="col" style="width: 33%; font-size: 16px; font-weight: bold; color: dimgray">Hasta</th>
                            </tr>
                        </thead>
                        <tbody id="contenedor" runat="server">
                        </tbody>
                    </table>


                </div>
            </div>

            <br />

            <div class="form-row" style="text-align: center; display: block">
                <div class="form-group col-lg-3 col-md-3 col-sm-6 col-xs-6" style="display: inline-block">
                    <asp:Button type="button" runat="server" class="btn btn-outline-warning form-control" Text="REGRESAR" ID="Regresar" />
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
