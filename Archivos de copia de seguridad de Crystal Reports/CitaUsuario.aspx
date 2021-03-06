﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CitaUsuario.aspx.cs" Inherits="Pediatric_System.CitaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="CSS/expediente.css" />
    <script type="text/javascript" src="JS/expediente.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid col-11 col-auto">

        <div class="page-header margen-general-2-top">
            <h3 class="text-info">Nueva Cita</h3>
        </div>

        <hr class="linea-divisoria-titulo" />

        

        <form runat="server">

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>



                    <asp:Literal ID="mensajeConfirmacion" runat="server" Visible="false"></asp:Literal>

                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                        <ProgressTemplate>
                            <br />
                            <div class="form-row" style="text-align: center; display: block">
                                <div class="form-group" style="display: inline-block">

                                    <div class="lds-spinner align-content-center" style="display: inline-block">
                                        <div></div>
                                        <div></div>
                                        <div></div>
                                        <div></div>
                                        <div></div>
                                        <div></div>
                                        <div></div>
                                        <div></div>
                                        <div></div>
                                        <div></div>
                                        <div></div>
                                        <div></div>
                                    </div>

                                </div>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                    <div class="card">
                        <label class="nombre-input card-header" style="padding-left: 40px">Formulario de datos</label>

                        <div class="form-row card-body padding-general-top">

                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">

                                <div class="padding-general-label">
                                    <label class="nombre-input">Paciente</label>
                                    <asp:DropDownList ID="nombrePaciente" CssClass="browser-default custom-select" runat="server" OnSelectedIndexChanged="nombrePaciente_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>

                            </div>

                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">

                                <div class="padding-general-label">
                                    <label class="nombre-input">Edad</label>
                                    <asp:TextBox runat="server" ID="edad" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>

                            </div>

                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">

                                <div class="padding-general-label">
                                    <label class="nombre-input">Correo (Encargado)</label>
                                    <asp:TextBox runat="server" ID="correo" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>

                            </div>

                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">

                                <div class="padding-general-label">
                                    <label class="nombre-input">Teléfono (Encargado)</label>
                                    <asp:TextBox runat="server" ID="telefono" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>

                            </div>

                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                <div class="padding-general-label">
                                    <label class="nombre-input">Médico</label>
                                    <asp:DropDownList ID="medico" CssClass="browser-default custom-select" runat="server" OnSelectedIndexChanged="medico_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                <div class="padding-general-label">
                                    <label class="nombre-input">Fecha</label>
                                    <asp:DropDownList ID="fecha" CssClass="browser-default custom-select" runat="server" OnSelectedIndexChanged="fecha_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                <div class="padding-general-label">
                                    <label class="nombre-input">Hora</label>
                                    <asp:DropDownList ID="hora" CssClass="browser-default custom-select" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                    </div>


                    <br />

                    <div class="form-row alinearBtnGuardarExp">
                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12 ubicacionBtn" runat="server">
                            <asp:Button type="button" runat="server" CssClass="btn btn-regresar" Text="REGRESAR" ID="regresar" OnClick="regresar_Click" />

                            <asp:Button type="button" runat="server" CssClass="btn btn-guardar" Text="AGENDAR CITA" ID="agendarCita" OnClick="agendarCita_Click" />
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

        </form>

    </div>


</asp:Content>
