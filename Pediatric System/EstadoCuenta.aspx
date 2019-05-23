<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="EstadoCuenta.aspx.cs" Inherits="Pediatric_System.EstadoCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="container-fluid col-10 col-auto">
        <div class="page-header">
            <h3 class="text-info">Estado de cuenta de usuario</h3>
        </div>
    </div>

    <hr style="color: #0056b2;" />

    <div class="container-fluid col-10 col-auto table-responsive">

        <br />

        <table class="table table-striped">

            <thead>
                <tr>
                    <th scope="col">Correo Electrónico</th>
                    <th scope="col">Estado</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>richardbomo26@gmail.com</td>
                    <td>


                        <div class="form-check">
                            <input class="form-check-input" type="radio" name="exampleRadios" id="exampleRadios1" value="habilitado" checked>
                            <label class="form-check-label" for="exampleRadios1">
                                Habilitado
                            </label>
                        </div>
                        <div class="form-check">
                            <input class="form-check-input" type="radio" name="exampleRadios" id="exampleRadios2" value="deshabilitado">
                            <label class="form-check-label" for="exampleRadios2">
                                Deshabilitado
                            </label>
                        </div>

                    </td>
                </tr>
                <tr>
                    <th scope="row"></th>
                    <td></td>
                </tr>
                <tr>
                    <th scope="row"></th>
                    <td></td>
                </tr>
            </tbody>
        </table>

    </div>

    <br />

    <div class="container-fluid col-10 col-auto">

        <div class="form-row">

            <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">

                <button type="submit" class="btn btn-outline-success form-control">GUARDAR</button>

            </div>

            <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">

                <button type="submit" class="btn btn-outline-danger form-control">REGRESAR</button>

            </div>

        </div>
    </div>

</asp:Content>
