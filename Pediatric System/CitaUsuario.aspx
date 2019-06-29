<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CitaUsuario.aspx.cs" Inherits="Pediatric_System.CitaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="CSS/expediente.css" />
    <script type="text/javascript" src="JS/expediente.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid col-11 col-auto">

        <div class="page-header margen-general-2-top">
            <h2 class="text-info">Nueva Cita</h2>
        </div>

        <hr class="linea-divisoria-titulo" />

        <asp:Literal ID="mensajeConfirmacion" runat="server" Visible="false"></asp:Literal>

        <form runat="server">

            <br />


            <div class="card">
                <label class="nombre-input card-header" style="padding-left: 40px">Formulario de datos</label>

                <div class="form-row card-body padding-general-top">

                    <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">

                        <div class="padding-general-label">
                            <label class="nombre-input">Nombre Completo</label>
                            <asp:TextBox runat="server" ID="nombre" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>

                    <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">

                        <div class="padding-general-label">
                            <label class="nombre-input">Edad</label>
                            <asp:TextBox runat="server" ID="edad" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>

                    <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">

                        <div class="padding-general-label">
                            <label class="nombre-input">Correo (Encargado)</label>
                            <asp:TextBox runat="server" ID="correo" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>

                    <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">

                        <div class="padding-general-label">
                            <label class="nombre-input">Teléfono (Encargado)</label>
                            <asp:TextBox runat="server" ID="telefono" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>

                    <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                        <div class="padding-general-label">
                            <label class="nombre-input">Médico</label>
                            <asp:DropDownList ID="medico" CssClass="browser-default custom-select" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                        <div class="padding-general-label">
                            <label class="nombre-input">Fecha</label>
                            <asp:DropDownList ID="fecha" CssClass="browser-default custom-select" runat="server"></asp:DropDownList>
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

            <asp:Literal ID="mensajeConfirmacion1" runat="server"></asp:Literal>

        </form>

    </div>


</asp:Content>
