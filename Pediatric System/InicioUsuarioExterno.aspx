<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="InicioUsuarioExterno.aspx.cs" Inherits="Pediatric_System.InicioUsuarioExterno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript" src="JS/countereffect.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="container-fluid col-11 col-auto">
        <div class="page-header margen-general-2-top">
            <h3 class="text-info">Pediatric System</h3>
        </div>

        <hr class="linea-divisoria-titulo" />
        <!-- Icon Cards-->
        <div class="row clearfix">
            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                <div class="row">
                    <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12">
                        <div class="row clearfix">


                            <div class="col-xl-4 col-lg-4 col-md-4 col-sm-4 mb-3">
                                <div class="card text-white o-hidden h-100">
                                    <div class="row">
                                        <a class="card-body card-dash" href="ListaExpedientes.aspx">
                                            <i style="color: #1d5e93" class="far fa-id-card fa-4x"></i>
                                        </a>
                                        <a class="card-body card-dash col-4" href="ListaExpedientes.aspx" style="font-size: 20px; font-weight: 500; padding: 20px 39px 0px 0px;">
                                            <div class="" style="border-radius: 50%; width: 50px; height: 50px; padding: 8px; background: #fff; border: 2px solid #1d5e93; background-color: whitesmoke; color: #1d5e93; text-align: center; font: 26px Arial, sans-serif;">
                                                <asp:Label ID="lblCantidadExpedientes" runat="server" class="timer count-title count-number" data-speed="1500" ToolTip="Cantidad de Expedientes en el Sistema" />
                                            </div>
                                        </a>
                                    </div>
                                    <a class="card-footer text-white clearfix small z-1" href="ListaExpedientes.aspx">
                                        <span class="float-left">Expedientes</span>
                                        <span class="float-right">
                                            <i class="fas fa-angle-right"></i>
                                        </span>
                                    </a>
                                </div>
                            </div>

                            <div class="col-xl-3 col-lg-3 col-md-3 col-sm-3 mb-3">
                                <div class="card text-white o-hidden h-100">
                                    <a class="card-body card-dash" href="ExamenesLaboratorio.aspx">
                                        <i style="color: #1d5e93" class="fas fa-notes-medical fa-4x"></i>
                                    </a>
                                    <a class="card-footer text-white clearfix small z-1" href="ExamenesLaboratorio.aspx">
                                        <span class="float-left">Exámenes de Laboratorio</span>
                                        <span class="float-right">
                                            <i class="fas fa-angle-right"></i>
                                        </span>
                                    </a>
                                </div>
                            </div>

                            <div class="col-xl-3 col-lg-3 col-md-3 col-sm-3 mb-3">
                                <div class="card text-white o-hidden h-100">
                                    <div class="row">
                                        <a class="card-body card-dash col-8" href="ListaCitas.aspx">
                                            <i style="color: #1d5e93" class="fas fa-calendar-check fa-4x"></i>
                                        </a>
                                        <a class="card-body card-dash col-4" href="GestionarAgenda.aspx" style="font-size: 20px; font-weight: 500; padding: 20px 39px 0px 0px;">
                                            <div class="" style="border-radius: 50%; width: 50px; height: 50px; padding: 8px; background: #fff; border: 2px solid #1d5e93; background-color: whitesmoke; color: #1d5e93; text-align: center; font: 26px Arial, sans-serif;">
                                                <asp:Label ID="lblCantidadCitasPendientes" runat="server" class="timer count-title count-number" data-speed="1500" ToolTip="Citas Pendientes para Hoy" />

                                            </div>
                                        </a>

                                    </div>
                                    <a class="card-footer text-white clearfix small z-1" href="ListaCitas.aspx">
                                        <span class="float-left">Citas</span>
                                        <span class="float-right">
                                            <i class="fas fa-angle-right"></i>
                                        </span>
                                    </a>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
