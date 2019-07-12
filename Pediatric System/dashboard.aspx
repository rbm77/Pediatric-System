<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Pediatric_System.dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="JS/countereffect.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container-fluid col-11 col-auto">
        <div class="page-header margen-general-2-top">
            <h3 class="text-info">Pediatric System</h3>
        </div>
        <% if (Session["Rol"].ToString() == ("Administrador") || Session["Rol"].ToString() == ("Paciente"))
            {
                Session.Clear();

            } %>
        <hr class="linea-divisoria-titulo" />
        <!-- Icon Cards-->
        <div class="row clearfix">
            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12 ">
                <div class="row">
                    <div class="col-xl-5 col-lg-5 col-md-5 col-sm-5">
                        <div class="row clearfix">


                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 mb-20">
                                <div class="card text-white o-hidden h-100">
                                    <div class="row">
                                        <a class="card-body card-dash" href="ListaExpedientes.aspx">
                                            <i style="color: #1d5e93" class="far fa-id-card fa-4x"></i>
                                        </a>
                                        <a class="card-body card-dash col-4" href="#" style="font-size: 20px; font-weight: 500; padding: 20px 39px 0px 0px;">
                                            <div class="" style="border-radius: 50%; width: 50px; height: 50px; padding: 8px; background: #fff; border: 2px solid #1d5e93; color: #1d5e93; text-align: center; font: 26px Arial, sans-serif;">

                                                <asp:Label ID="lblCantidadExpedientes" runat="server" class="timer count-title count-number" data-speed="1500" ToolTip="Cantidad de Expedientes en el Sistema" />
                                                <%-- <span id="countExpe" class="timer count-title count-number" data-to="1" data-speed="1500"></span>--%>
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
                            <div class="col-sm-12 col-xl-6 col-lg-6 col-md-12 mb-20">
                                <div class="card text-white o-hidden h-100">
                                    <div class="row">
                                        <a class="card-body card-dash col-8" href="#">
                                            <i style="color: #1d5e93" class="fas fa-user-check fa-4x"></i>
                                        </a>
                                        <a class="card-body card-dash col-4" href="#" style="font-size: 20px; font-weight: 500; padding: 20px 39px 0px 0px;">
                                            <div class="" style="border-radius: 50%; width: 50px; height: 50px; padding: 8px; background: #fff; border: 2px solid #1d5e93; color: #1d5e93; text-align: center; font: 26px Arial, sans-serif;">
                                                <asp:Label ID="lblCantidadConsultaActiva" runat="server" class="timer count-title count-number" data-speed="1500" ToolTip="Cantidad de Consultas Activas" />
                                            </div>
                                        </a>
                                    </div>
                                    <a class="card-footer text-white clearfix small z-1" href="ListaConsultasActivas.aspx">
                                        <span class="float-left">Consultas Activas</span>
                                        <span class="float-right">
                                            <i class="fas fa-angle-right"></i>
                                        </span>
                                    </a>
                                </div>
                            </div>
                            <div class=" col-sm-12 col-xl-6 col-lg-6 col-md-12 mb-20">
                                <div class="card text-white o-hidden h-100">
                                    <a class="card-body card-dash" href="FichaBaseExpediente.aspx">
                                        <i style="color: #1d5e93" class="fas fa-plus-circle fa-4x"></i>
                                    </a>
                                    <a class="card-footer text-white clearfix small z-1" href="FichaBaseExpediente.aspx">
                                        <span class="float-left">Nuevo Expediente</span>
                                        <span class="float-right">
                                            <i class="fas fa-angle-right"></i>
                                        </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="offset-xl-1 col-xl-5 offset-lg-1 col-lg-5 offset-md-1 col-md-5 offset-sm-1 col-sm-5">
                        <div class="row clearfix">
                            <%if (Session["Rol"].ToString() != "Asistente")
                        {%>
                            <div class=" col-sm-12 col-xl-6 col-lg-12 col-md-12 mb-20">
                                <div class="card text-white o-hidden h-100">
                                    <a class="card-body card-dash" href="MiAgenda.aspx">
                                        <i style="color: #1d5e93" class="far fa-calendar-alt fa-4x"></i>
                                    </a>
                                    <a class="card-footer text-white clearfix small z-1" href="MiAgenda.aspx">
                                        <span class="float-left">Administrar Agenda</span>
                                        <span class="float-right">
                                            <i class="fas fa-angle-right"></i>
                                        </span>
                                    </a>
                                </div>
                            </div>
                             <% } %>
                            <div class="col-sm-12 col-xl-6 col-lg-6 col-md-12 mb-20">
                                <div class="card text-white o-hidden h-100">
                                    <a class="card-body card-dash" href="AsociarPaciente.aspx">
                                        <i style="color: #1d5e93" class="fas fa-user-plus fa-4x"></i>
                                    </a>
                                    <a class="card-footer text-white clearfix small z-1" href="AsociarPaciente.aspx">
                                        <span class="float-left">Vincular Expediente</span>
                                        <span class="float-right">
                                            <i class="fas fa-angle-right"></i>
                                        </span>
                                    </a>
                                </div>
                            </div>
                            <div class="col-sm-12 col-xl-6 col-lg-6 col-md-12 mb-20">
                                <div class="card text-white o-hidden h-100">

                                    <div class="row">
                                        <a class="card-body card-dash col-8" href="#">
                                            <i style="color: #1d5e93" class="fas fa-calendar-check fa-4x"></i>
                                        </a>
                                        <a class="card-body card-dash col-4" href="#" style="font-size: 20px; font-weight: 500; padding: 20px 39px 0px 0px;">
                                            <div class="" style="border-radius: 50%; width: 50px; height: 50px; padding: 8px; background: #fff; border: 2px solid #1d5e93; color: #1d5e93; text-align: center; font: 26px Arial, sans-serif;">
                                                <asp:Label ID="lblCantidadCitasPendientes" runat="server" class="timer count-title count-number" data-speed="1500" ToolTip="Citas Pendientes para Hoy" />

                                            </div>
                                        </a>

                                    </div>
                                    <a class="card-footer text-white clearfix small z-1" href="GestionarAgenda.aspx">
                                        <span class="float-left">Citas</span>
                                        <span class="float-right">
                                            <i class="fas fa-angle-right"></i>
                                        </span>
                                    </a>
                                </div>
                            </div>
                            <div class="col-sm-12 col-xl-6 col-lg-6 col-md-12  mb-20">
                                <div class="card text-white o-hidden h-100">
                                    <a class="card-body card-dash">
                                        <i style="color: #1d5e93" class="fas fa-chart-pie fa-4x"></i>
                                    </a>
                                    <a class="card-footer text-white clearfix small z-1" href="#">
                                        <span class="float-left">Reportes</span>
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
            <asp:Literal ID="mensajeConfirmacion" runat="server" Visible="false"></asp:Literal>
        </div>
    </div>


</asp:Content>
