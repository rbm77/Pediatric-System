<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="InicioUsuarioExterno.aspx.cs" Inherits="Pediatric_System.InicioUsuarioExterno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                    <a class="card-body card-dash" href="ListaExpedientes.aspx">
                                        <i style="color: #1d5e93" class="far fa-id-card fa-4x"></i>
                                    </a>
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
                                    <a class="card-body card-dash" href="ListaExpedientes.aspx">
                                        <i style="color: #1d5e93" class="far fa-calendar-check fa-4x"></i>
                                    </a>
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
