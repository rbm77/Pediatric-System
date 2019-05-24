<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FichaConsultaPaciente.aspx.cs" Inherits="Pediatric_System.FichaConsultaPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="JS/consulta.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid col-10 col-auto">

        <br />

        <div class="page-header">
            <h2 class="text-info">Consulta Medica</h2>
        </div>

        <hr style="color: #0056b2;" />


        <%--<div class="row col-12">
            <label style="font-size: 24px; font-weight: bold; color: dimgray">Padecimiento Actual</label>
        </div>--%>

        <div class="col-12 bg-light border border-info rounded">
            <div class="form-row" style="margin-top: 15px;">

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Padecimiento Actual</label>
                    <input type="text" class="form-control">
                </div>

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12" style="text-align: center">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Fecha y Hora</label>
                    <%--<input type="text" class="form-control">--%>
                </div>

            </div>
        </div>

        <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">

            <label style="font-size: 16px; font-weight: bold; color: dimgray; margin-top: 15px">Primera Parte del Examen Fisico</label>

            <div class="form-row" style="margin-top: 15px;">

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Talla</label>
                    <input type="text" class="form-control">
                </div>

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12" style="text-align: center">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Peso</label>
                    <input type="text" class="form-control">
                </div>

            </div>

            <div class="form-row" style="margin-top: 15px;">

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Perimetro Cefalico</label>
                    <input type="text" class="form-control">
                </div>

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12" style="text-align: center">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Temperatura</label>
                    <input type="text" class="form-control">
                </div>

            </div>

            <div class="form-row" style="margin-top: 15px;">

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">SO2</label>
                    <input type="text" class="form-control">
                </div>

            </div>
        </div>

        <div class="col-12 bg-light border border-info rounded" style="margin-top: 15px">

            <label style="font-size: 16px; font-weight: bold; color: dimgray; margin-top: 15px">Segunda Parte del Examen Fisico</label>

            <div class="form-row" style="margin-top: 15px;">

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Estado de alerta</label>
                    <input type="text" class="form-control">
                </div>

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12" style="text-align: center">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Estado de hidratacion</label>
                    <input type="text" class="form-control">
                </div>

            </div>

            <div class="form-row" style="margin-top: 15px;">

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Ruidos cardiacos</label>
                    <input type="text" class="form-control">
                </div>

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12" style="text-align: center">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Campos pulmunares</label>
                    <input type="text" class="form-control">
                </div>

            </div>

            <div class="form-row" style="margin-top: 15px;">

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Abdomen</label>
                    <input type="text" class="form-control">
                </div>

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label style="font-size: 16px; font-weight: bold; color: dimgray">Faringe</label>
                    <input type="text" class="form-control">
                </div>

            </div>
        </div>
    </div>

</asp:Content>
