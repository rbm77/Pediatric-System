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

            <div class="form-row" style="margin-top: 15px;">
                <br />
                <input class="btn btn-primary next" type="button" value="Buscar" style="background-color: #56baed; border: none; padding: 10px 50px; margin-bottom: 25px;" />
            </div>
        </div>

        <div style="margin-top: 15px; margin-bottom:15px">
            <label style="font-size: 24px; font-weight: bold; color: dimgray">Lista de Consultas </label>
        </div>

        <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px; margin-bottom:25px">
            <div class="row col-12">
                
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>
        </div>



    </div>

</asp:Content>
