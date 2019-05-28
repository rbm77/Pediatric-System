<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="InicioUsuarioExterno.aspx.cs" Inherits="Pediatric_System.InicioUsuarioExterno" %>

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
                <h5 class="card-header text-center" style="color: dimgray;">Expedientes Vinculados</h5>
                <div class="card-body">

                    <table class="table table-hover">
                        <thead>
                            <tr class="bg-light">
                                <th scope="col" style="width: 45%; color: dimgray;">Nombre Completo</th>
                                <th scope="col" style="width: 45%; color: dimgray;">Cédula</th>
                                <th scope="col" style="width: 20%"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Richard Bolaños Moya</td>
                                <td>2-0785-0434</td>
                                <td>
                                    <input type="radio" class="form-check-input" id="check3" name="option1" value="something">
                                </td>
                            </tr>
                            <tr>
                                <td>Fabian Jimenez Morales</td>
                                <td>2-0264-0478</td>
                                <td>
                                    <input type="radio" class="form-check-input" id="check4" name="option1" value="something">
                                </td>
                            </tr>
                        </tbody>
                    </table>

                    <hr style="color: #0056b2;" />
                    <br />

                    <div class="form-row">
                        <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-12">

                            <button type="submit" class="btn btn-outline-primary form-control">AGENDAR CITA</button>

                        </div>
                        <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-12">

                            <button type="submit" class="btn btn-outline-primary form-control">VER EXPEDIENTE</button>

                        </div>
                    </div>
                </div>
            </div>

            <br />
        </div>

    </form>
</asp:Content>
