<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CrearReportes.aspx.cs" Inherits="Pediatric_System.CrearReportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
    <script type="text/javascript" src="JS/reportes.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid col-10 col-auto">

        <br />

        <div class="page-header">
            <h2 class="text-info">Reportes</h2>
        </div>

        <hr style="color: #0056b2;" />

        <!-- ---------------------------------------------------- !-->

        <div class="col-12 bg-light border border-info rounded">
            <div class="form-row" style="margin-top: 15px;">
                <div class="form-group col-lg-4 col-md-4 col-sm-12 col-xs-12">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Fecha de Inicio</label>
                    <input id="datepickerInicio" placeholder="31/12/2018" />
                </div>

                <div class="form-group col-lg-4 col-md-4 col-sm-12 col-xs-12">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Fecha de Fin</label>
                    <input id="datepickerFin" placeholder="31/12/2018" />
                </div>
            <%--</div>--%>

            <%--<div class="form-row">--%>
                <div class="form-group col-lg-4 col-md-4 col-sm-12 col-xs-12">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Seleccionar reporte</label>
                    <select class="browser-default custom-select">
                        <option value="" disabled selected></option>
                        <option value="" >Reporte 1</option>
                        <option value="" >Reporte 2</option>
                    </select>
                </div>
            </div>

            <div class="form-row col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin-top: 15px; text-align:center; display:inline-block">
                <br />
                <input class="btn btn-primary next" type="button" value="Aceptar" style="background-color: #56baed; border: none; padding: 10px 50px; margin-bottom: 45px;" />
            </div>
        </div>
    </div>

</asp:Content>
