<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CuentaPersonal.aspx.cs" Inherits="Pediatric_System.CuentaPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="container-fluid col-10 col-auto">
        <div class="page-header">
            <h3 class="text-info">Cuenta de Usuario</h3>
        </div>
    </div>

    <hr style="color: #0056b2;" />

    <form>

        <br />

        <div class="container-fluid col-10 col-auto bg-light border border-info">

            <br />

            <div class="form-row">
                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label for="nombre" style="font-size: 16px; font-weight: bold; color: dimgray">Nombre</label>
                    <input type="text" class="form-control" id="nombre">
                </div>
                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label for="primerApellido" style="font-size: 16px; font-weight: bold; color: dimgray">Primer Apellido</label>
                    <input type="text" class="form-control" id="primerApellido">
                </div>

            </div>


            <div class="form-row">
                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label for="segundoApellido" style="font-size: 16px; font-weight: bold; color: dimgray">Segundo Apellido</label>
                    <input type="text" class="form-control" id="segundoApellido">
                </div>
                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label for="cedula" style="font-size: 16px; font-weight: bold; color: dimgray">Cédula</label>
                    <input type="text" class="form-control" id="cedula">
                </div>
            </div>

            <div class="form-row">

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label for="fechaNacimiento" style="font-size: 16px; font-weight: bold; color: dimgray">Fecha de nacimiento</label>
                    <input id="datepicker" />
                </div>
                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label for="telefono" style="font-size: 16px; font-weight: bold; color: dimgray">Teléfono</label>
                    <input type="tel" class="form-control" id="telefono" />
                </div>
            </div>


            <div class="form-row">

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label for="correoElectronico" style="font-size: 16px; font-weight: bold; color: dimgray">Correo Electrónico</label>
                    <input type="email" class="form-control" id="correoElectronico" />
                </div>
                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label for="rol" style="font-size: 16px; font-weight: bold; color: dimgray">Rol</label>
                    <select class="browser-default custom-select" id="rol">
                        <option value="medico">Médico</option>
                        <option value="asistente">Asistente</option>
                        <option value="administrador">Administrador</option>
                    </select>
                </div>
            </div>

            <div class="form-row">

                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label for="contrasenna" style="font-size: 16px; font-weight: bold; color: dimgray">Contraseña</label>
                    <input type="password" class="form-control" id="contrasenna" />
                </div>
                <div class="form-group col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <label for="confirmar" style="font-size: 16px; font-weight: bold; color: dimgray">Confirmar contraseña</label>
                    <input type="password" class="form-control" id="confirmar" />
                </div>
            </div>

            <br />

            <div class="form-row">

                <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">

                    <button type="submit" class="btn btn-guardar form-control">GUARDAR</button>

                </div>

                <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">

                    <button type="submit" class="btn btn-outline-danger form-control">REGRESAR</button>

                </div>

            </div>

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
