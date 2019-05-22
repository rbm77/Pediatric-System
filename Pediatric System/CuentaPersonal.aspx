<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CuentaPersonal.aspx.cs" Inherits="Pediatric_System.CuentaPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <form>

        <br />

        <div class="container-fluid col-md-8 col-md-offset-2 bg-light border border-info rounded">

            <br />

            <div class="form-row">
                <div class="form-group col-md-3">
                    <input type="text" class="form-control" placeholder="Nombre">
                </div>
                <div class="form-group col-md-3">
                    <input type="text" class="form-control" placeholder="Primer Apellido">
                </div>
                <div class="form-group col-md-3">
                    <input type="text" class="form-control" placeholder="Segundo Apellido">
                </div>
                <div class="form-group col-md-3">
                    <input type="text" class="form-control" placeholder="Cédula">
                </div>
            </div>


            <div class="form-row">

                <div class="form-group col-md-3">
                    <input id="datepicker" placeholder="Fecha de Nacimiento"/>
                </div>
            </div>

            <br />

        </div>

        <br />

    </form>


    <script>
        $('#datepicker').datepicker({
            uiLibrary: 'bootstrap4',
            locale: 'es-es',
            format: 'dd/mm/yyyy'
        });
    </script>


</asp:Content>
