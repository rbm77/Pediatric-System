<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CuentaPersonal.aspx.cs" Inherits="Pediatric_System.CuentaPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="container-fluid col-xs-12 col-sm-6 col-md-8 col-md-offset-2">
        <div class="page-header">
            <h2 class="text-info">Cuenta de Usuario</h2>
        </div>
    </div>

    <hr style="color: #0056b2;" />

    <form>

        <br />

        <div class="container-fluid col-xs-12 col-sm-6 col-md-8 col-md-offset-2 bg-light border border-info rounded">

            <br />

            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="nombre">Nombre</label>
                    <input type="text" class="form-control" id="nombre">
                </div>
                <div class="form-group col-md-6">
                    <label for="primerApellido">Primer Apellido</label>
                    <input type="text" class="form-control" id="primerApellido">
                </div>

            </div>


            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="segundoApellido">Segundo Apellido</label>
                    <input type="text" class="form-control" id="segundoApellido">
                </div>
                <div class="form-group col-md-6">
                    <label for="cedula">Cédula</label>
                    <input type="text" class="form-control" id="cedula">
                </div>
            </div>

            <div class="form-row">

                <div class="form-group col-md-6">
                    <label for="fechaNacimiento">Fecha de nacimiento</label>
                    <input id="datepicker" />
                </div>
                <div class="form-group col-md-6">
                    <label for="telefono">Teléfono</label>
                    <input type="tel" class="form-control" id="telefono" />
                </div>
            </div>


            <div class="form-row">

                <div class="form-group col-md-6">
                    <label for="correoElectronico">Correo Electrónico</label>
                    <input type="email" class="form-control" id="correoElectronico" />
                </div>
                <div class="form-group col-md-6">
                    <label for="rol">Rol</label>
                    <select class="browser-default custom-select" id="rol">
                        <option value="medico">Médico</option>
                        <option value="asistente">Asistente</option>
                        <option value="administrador">Administrador</option>
                    </select>
                </div>
            </div>

            <div class="form-row">

                <div class="form-group col-md-6">
                    <label for="contrasenna">Contraseña</label>
                    <input type="password" class="form-control" id="contrasenna" />
                </div>
                <div class="form-group col-md-6">
                    <label for="confirmar">Confirmar contraseña</label>
                    <input type="password" class="form-control" id="confirmar" />
                </div>
            </div>

            <br />

            <div class="form-row">

                <div class="form-group col-md-3">

                    <button type="submit" class="btn btn-outline-success form-control">GUARDAR</button>

                </div>

                <div class="form-group col-md-3">

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
