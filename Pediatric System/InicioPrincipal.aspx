<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="InicioPrincipal.aspx.cs" Inherits="Pediatric_System.InicioPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br />

    <div class="container-fluid col-10 col-auto">
        <div class="page-header">
            <h3 class="text-info">Inicio</h3>
        </div>
    </div>

    <hr style="color: #0056b2;" />

    <form>
        <br />

        <div class="container-fluid col-10 col-auto table-responsive">

            <div class="card">
                <h5 class="card-header text-center" style="color: dimgray;">Expedientes</h5>
                <div class="card-body">

                    <div class="form-row">
                        <div class="form-group has-search col-lg-9 col-md-9 col-sm-9 col-xs-12">
                            <span class="fa fa-search form-control-feedback"></span>
                            <input type="search" class="form-control" placeholder="Nombre o Cédula">
                        </div>


                        <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">

                            <button type="submit" class="btn btn-outline-primary form-control">BUSCAR</button>

                        </div>

                    </div>
                    <table class="table table-hover">
                        <thead>
                            <tr class="bg-light">
                                <th scope="col" style="color: dimgray;">Nombre Completo</th>
                                <th scope="col" style="color: dimgray;">Cédula</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Richard Bolaños Moya</td>
                                <td>2-0785-0434</td>
                            </tr>
                            <tr>
                                <td>Fabian Jimenez Morales</td>
                                <td>2-0264-0478</td>
                            </tr>
                        </tbody>
                    </table>

                    <hr style="color: #0056b2;" />
                    <br />

                    <div class="form-row">
                        <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-12">

                            <button type="submit" class="btn btn-outline-primary form-control">CREAR EXPEDIENTE</button>

                        </div>
                    </div>
                </div>
            </div>

            <br />

            <div class="card">
                <h5 class="card-header text-center" style="color: dimgray;">Cuentas de Usuario Externo</h5>
                <div class="card-body">

                    <div class="row">
                        <div class="col-sm-6">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title" style="color: dimgray;">Crear Cuenta Asociada</h5>
                                    <p class="card-text" style="color: dimgray;">
                                        Los usuarios externos a la clínica podrán hacer uso de la aplicación para consultar la información
                                        de los pacientes, así como la calendarización de citas para que estos reciban atención médica.
                                    </p>
                                    <div class="form-row">
                                        <div class="form-group col-lg-6 col-md-12 col-sm-12 col-xs-12">

                                            <button data-toggle="modal" data-target="#exampleModal" type="button" class="btn btn-outline-primary form-control">CREAR CUENTA</button>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title" style="color: dimgray;">Vincular Pacientes</h5>
                                    <p class="card-text" style="color: dimgray;">
                                        Las cuentas de usuario podrán vincularse a los expedientes de uno o más 
                                        pacientes según sea el caso.
                                    </p>
                                    <div class="form-row">
                                        <div class="form-group col-lg-6 col-md-12 col-sm-12 col-xs-12">

                                            <button type="submit" class="btn btn-outline-primary form-control">VINCULAR</button>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <br />

            <div class="card">
                <h5 class="card-header text-center" style="color: dimgray;">Herramientas</h5>
                <div class="card-body">

                    <div class="row">
                        <div class="col-sm-6">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title" style="color: dimgray;">Reportes</h5>
                                    <p class="card-text" style="color: dimgray;">
                                        El sistema permite la generación de dos tipos de reportes correspondientes la boleta VE-02 del
                                        Ministerio de salud, como también el informe diario de consulta externa.
                                    </p>
                                    <div class="form-row">
                                        <div class="form-group col-lg-6 col-md-12 col-sm-12 col-xs-12">

                                            <button type="submit" class="btn btn-outline-primary form-control">GENERAR REPORTE</button>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title" style="color: dimgray;">Agenda</h5>
                                    <p class="card-text" style="color: dimgray;">
                                        El sistema permite gestionar la agenda semanal del médico, de tal manera que se pueda establecer
                                        un horario de atención por citas.
                                    </p>
                                    <div class="form-row">
                                        <div class="form-group col-lg-6 col-md-12 col-sm-12 col-xs-12">

                                            <button type="submit" class="btn btn-outline-primary form-control">GESTIONAR AGENDA</button>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <!-- Modal -->
            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
            </div>

        </div>

        <br />
        <br />

    </form>



</asp:Content>
