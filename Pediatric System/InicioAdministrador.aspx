<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="InicioAdministrador.aspx.cs" Inherits="Pediatric_System.InicioAdministrador" %>

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

        <div class="container-fluid col-10 col-auto">

            <br />

            <div class="card">
                <h5 class="card-header text-center" style="color: dimgray;">Cuentas del Personal de la Clínica</h5>
                <div class="card-body">

                    <div class="row">
                        <div class="col-sm-6">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title" style="color: dimgray;">Cuenta de Usuario</h5>
                                    <p class="card-text" style="color: dimgray;">
                                        Las personas que laboran en la clínica pueden acceder al sistema a través de una cuenta, la
                                        cual define las funcionalidades que pueden desempeñar en base a su rol de usuario.
                                    </p>
                                    <div class="form-row">
                                        <div class="form-group col-lg-6 col-md-12 col-sm-12 col-xs-12">

                                            <button type="button" class="btn btn-neutro form-control">CREAR CUENTA</button>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title" style="color: dimgray;">Estados de Cuenta</h5>
                                    <p class="card-text" style="color: dimgray;">
                                        Cada cuenta de usuario interno posee un estado que indica si se encuentra habilitada o deshabilitada. El administrador
                                        podrá modificar dicho estado cuando lo requiera.
                                    </p>
                                    <div class="form-row">
                                        <div class="form-group col-lg-6 col-md-12 col-sm-12 col-xs-12">

                                            <button type="submit" class="btn btn-neutro form-control">GESTIONAR ESTADOS</button>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>






        </div>
    </form>
</asp:Content>
