<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Pediatric_System.dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <br />
    <div class="container-fluid col-10 col-auto">
        <div class="page-header">
            <h3 class="text-info">Pediatric System</h3>
        </div>
    </div>
      <hr style="color: #0056b2;" />
    <!-- Icon Cards-->
    <div class="row clearfix">
        <div class="col-md-12 ">
            <div class="row">
                <div class="col-sm-4 col-md-6">
                    <div class="row clearfix">


                        <div class="col-xs-12 col-sm-6 col-md-6 mb-20">
                            <div class="card text-white o-hidden h-100">
                                <div class="card-body card-dash">
                                    <i class="far fa-id-card fa-4x"></i>
                                </div>
                                <a class="card-footer text-white clearfix small z-1" href="#">
                                    <span class="float-left">Expedientes</span>
                                    <span class="float-right">
                                        <i class="fas fa-angle-right"></i>
                                    </span>
                                </a>
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-3 col-md-6  mb-20">
                            <div class="card text-white o-hidden h-100">
                                <div class="card-body card-dash">
                                    <div class="mr-5">Expedientes</div>
                                </div>
                                <a class="card-footer text-white clearfix small z-1" href="#">
                                    <span class="float-left">View Details</span>
                                    <span class="float-right">
                                        <i class="fas fa-angle-right"></i>
                                    </span>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-8  col-md-6">
                    <div class="row clearfix">
                        <div class="col-xs-6 col-sm-3 col-md-6  mb-20">
                            <div class="card text-white o-hidden h-100">
                                <div class="card-body card-dash">
                                    <i class="far fa-calendar-check fa-4x"></i>
                                </div>
                                <a class="card-footer text-white clearfix small z-1" href="#">
                                    <span class="float-left">Agenda</span>
                                    <span class="float-right">
                                        <i class="fas fa-angle-right"></i>
                                    </span>
                                </a>
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-3 col-md-6  mb-20">
                            <div class="card text-white o-hidden h-100">
                                <div class="card-body card-dash">
                                    <div class="mr-5">Expedientes</div>
                                </div>
                                <a class="card-footer text-white clearfix small z-1" href="#">
                                    <span class="float-left">View Details</span>
                                    <span class="float-right">
                                        <i class="fas fa-angle-right"></i>
                                    </span>
                                </a>
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-3 col-md-6  mb-20">
                            <div class="card text-white o-hidden h-100">
                                <div class="card-body card-dash">
                                   <i class="fas fa-chart-pie fa-4x"></i>
                                </div>
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
</asp:Content>
