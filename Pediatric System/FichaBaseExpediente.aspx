<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FichaBaseExpediente.aspx.cs" Inherits="Pediatric_System.FichaBaseExpediente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <form>

        <!--Para que es el col-md-offset-2 !-->

        <asp:label class="container" runat="server" text="Informacion Personal del Paciente" style="font-size: 24px; font-weight: bold; color: dimgray"> </asp:label>

        <br />
        <br />

        <div class="container-fluid col-md-8 col-md-offset-2 bg-light border border-info rounded">

            <br />

            <asp:label runat="server" text="Nombre Completo" style="font-size: 16px; font-weight: bold; color: dimgray"> </asp:label>

            <br />

            <div class="form-row justify-content-center">
                <div class="form-group col-md-3 ">
                    <input type="text" class="form-control" placeholder="Nombre">
                </div>
                <div class="form-group col-md-3">
                    <input type="text" class="form-control" placeholder="Primer Apellido">
                </div>
                <div class="form-group col-md-3">
                    <input type="text" class="form-control" placeholder="Segundo Apellido">
                </div>
            </div>


        </div>

        <br />

        <div class="container-fluid col-md-8 col-md-offset-2 bg-light border border-info rounded">

            <br />

            <div class="form-row justify-content-center">
                <div class="form-group col-md-3">
                    <asp:label runat="server" text="Cedula" style="font-size: 16px; font-weight: bold; color: dimgray"> </asp:label>
                    <br />
                    <input type="text" class="form-control" placeholder="1-0234-0456">
                </div>
                <div class="form-group col-md-3">
                    <asp:label runat="server" text="Sexo" style="font-size: 16px; font-weight: bold; color: dimgray"> </asp:label>
                    <br />
                    <select class="browser-default custom-select">
                        <option value="" disabled selected>Seleccionar Sexo</option>
                        <option value="Femenino">Femenino</option>
                        <option value="Maculino">Masculino</option>
                        <option value="Otro">Otro</option>
                    </select>

                </div>
                <div class="form-group col-md-3">
                    <asp:label runat="server" text="Fecha de Nacimiento" style="font-size: 16px; font-weight: bold; color: dimgray"> </asp:label>
                    <input id="datepicker" placeholder="31/12/2018" />

                </div>

            </div>

        </div>

        <br />

        <div class="container-fluid col-md-8 col-md-offset-2 bg-light border border-info rounded">

            <br />

            <asp:label runat="server" text="Direccion" style="font-size: 16px; font-weight: bold; color: dimgray"> </asp:label>

            <br />

            <div class="form-row justify-content-center">
                <div class="form-group col-md-3">
                    <select class="browser-default custom-select">
                        <option value="" disabled selected>Provincia</option>
                    </select>
                </div>
                <div class="form-group col-md-3">
                    <select class="browser-default custom-select">
                        <option value="" disabled selected>Canton</option>
                    </select>
                </div>
                <div class="form-group col-md-3">
                    <select class="browser-default custom-select">
                        <option value="" disabled selected>Distrito</option>
                    </select>

                </div>
            </div>
        </div>
    </form>

    <script>
        $('#datepicker').datepicker({
            uiLibrary: 'bootstrap4',
            locale: 'es-es',
            format: 'dd/mm/yyyy'
        });
    </script>

</asp:Content>



