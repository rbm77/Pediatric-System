<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaConsultas.aspx.cs" Inherits="Pediatric_System.ListaConsultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="JS/listaConsultas.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid col-10 col-auto">

        <br />

        <div class="page-header">
            <h2 class="text-info">Consultas</h2>
        </div>

        <hr style="color: #0056b2;" />

        <!-- ---------------------------------------------------- !-->

        <div class="col-12 bg-light border border-info rounded">
            <div class="form-row" style="margin-top: 15px;">
                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Fecha de Inicio</label>
                    <input id="datepickerInicio" placeholder="31/12/2018" />
                </div>

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Fecha de Fin</label>
                    <input id="datepickerFin" placeholder="31/12/2018" />
                </div>
            </div>

            <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6" style="margin-top: 15px; padding-left: 0px">
                <button type="submit" class="btn btn-outline-primary form-control">BUSCAR</button>
            </div>

        </div>

    <div class="card lista-resultados-columna" style="margin-top:25px">

        <div class="card-body">
            <table class="table table-hover table-responsive-sm">
                <thead>
                    <tr>
                        <th scope="col" style="width: 50px; font-size: 16px; font-weight: bold; color: dimgray">Fecha</th>
                        <th scope="col" style="width: 25px; font-size: 16px; font-weight: bold; color: dimgray">Cedula</th>
                        <th scope="col" style="width: 25px; font-size: 16px; font-weight: bold; color: dimgray">Nombre Completo</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>05/28/2019</td>
                        <td>6-0444-0297</td>
                        <td>Fabian Jimenez Morales</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <div class="form-row" style="margin-bottom: 15px; margin-top: 15px">
        <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">
            <button type="submit" class="btn btn-outline-primary form-control">CREAR NUEVA CONSULTA</button>
        </div>
        <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">
            <button type="submit" class="btn btn-outline-danger form-control">REGRESAR</button>
        </div>
    </div>

    </div>

</asp:Content>
