<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AsociarPaciente.aspx.cs" Inherits="Pediatric_System.AsociarPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <div class="container-fluid col-10 col-auto">
        <div class="page-header">
            <h3 class="text-info">Vincular Pacientes</h3>
        </div>
    </div>

    <hr style="color: #0056b2;" />

    <form>

        <div class="container-fluid col-10 col-auto table-responsive">

            <br />

            <div class="card">
                <h5 class="card-header">Cuentas Asociadas</h5>
                <div class="card-body">

                    <div class="form-row">
                        <div class="form-group has-search col-lg-9 col-md-9 col-sm-9 col-xs-12">
                            <span class="fa fa-search form-control-feedback"></span>
                            <input type="search" class="form-control" placeholder="Correo Electrónico">
                        </div>


                        <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">

                            <button type="submit" class="btn btn-outline-primary form-control">BUSCAR</button>

                        </div>

                    </div>

                    <table class="table table-hover">
                        <thead>
                            <tr class="bg-light">
                                <th scope="col" style="width: 90%">Correo Electrónico</th>
                                <th scope="col" style="width: 10%"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>richardbomo26@gmail.com</td>
                                <td>
                                    <input type="radio" class="form-check-input" name="optradio">
                                </td>
                            </tr>
                            <tr>
                                <td>fabian.jimenez@ucrso.info</td>
                                <td>
                                    <input type="radio" class="form-check-input" name="optradio">
                                </td>
                            </tr>
                        </tbody>
                    </table>

                </div>
            </div>
            <br />

            <div class="card">
                <h5 class="card-header">Expedientes</h5>
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
                                <th scope="col" style="width: 45%">Nombre Completo</th>
                                <th scope="col" style="width: 45%">Cédula</th>
                                <th scope="col" style="width: 20%"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Richard Bolaños Moya</td>
                                <td>2-0785-0434</td>
                                <td>
                                    <input type="checkbox" class="form-check-input" id="check3" name="option1" value="something">
                                </td>
                            </tr>
                            <tr>
                                <td>Fabian Jimenez Morales</td>
                                <td>2-0264-0478</td>
                                <td>
                                    <input type="checkbox" class="form-check-input" id="check4" name="option1" value="something">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

            <br />

            <div class="form-row">

                <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">

                    <button type="submit" class="btn btn-outline-success form-control">GUARDAR</button>

                </div>

                <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">

                    <button type="submit" class="btn btn-outline-danger form-control">REGRESAR</button>

                </div>

            </div>


        </div>
    </form>
</asp:Content>
