﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FichaBaseExpediente.aspx.cs" Inherits="Pediatric_System.FichaBaseExpediente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="CSS/expediente.css" />
    <script type="text/javascript" src="JS/expediente.js"></script>


    <script>


</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" onload="lee-json();">

    <div class="container-fluid col-11 col-auto">

        <div class="page-header margen-general-2-top">
            <h2 class="text-info">Expediente</h2>
        </div>

        <hr class="linea-divisoria-titulo" />

        <asp:Literal ID="mensajeConfirmacion1" runat="server"></asp:Literal>

        <form runat="server">
            <div class="margen-general-2-top" runat="server" id="informacionPaciente">
                <div class="col-12">
                    <div class="form-row">
                        <div class="form-group col-lg-3 col-md-6 col-sm-12 col-xs-12">
                            <div class="alinearFoto">
                                <asp:Image ID="imgPreview" Width="150" ImageUrl="~/images/foto_perfil_icono.jpg" runat="server" />
                            </div>
                        </div>

                        <div class="form-group col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <div class="form-row">
                                <label class="info-paciente">Paciente: </label>
                                <label class="nombre-input" id="nnn"></label>
                            </div>


                            <div class="form-row padding-info-exp">
                                <label class="info-paciente">Cédula: </label>
                                <label class="nombre-input"></label>
                            </div>

                            <div class="form-row padding-info-exp">
                                <label class="info-paciente">Edad: </label>
                                <label class="nombre-input"></label>
                            </div>
                        </div>

                        <div class="form-group col-lg-3 col-md-10 col-sm-12 col-xs-12">
                            <div class="alinearBtnConsulta">
                                <div class="form-group ubicacionBtn" runat="server">
                                    <asp:Button type="button" runat="server" class="btn btn-neutro  btnsConsulta" Text="CONSULTAS" ID="verConsultas" OnClick="verConsultas_Click" />

                                    <asp:Button type="button" runat="server" class="btn btn-neutro  btnsConsulta" Text="NUEVA CONSULTA" ID="nuevaConsulta" OnClick="nuevaConsulta_Click" />
                                </div>
                            </div>
                        </div>


                    </div>
                </div>
            </div>

            <!-- Inicio del titulo de los Tabs !-->

            <div>
                <ul class="nav nav-tabs" id="myTab" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active nombre-input" id="info-personal-paciente-tab" data-toggle="tab" href="#info-personal-paciente" role="tab" aria-controls="info-personal-paciente" aria-selected="true">Inf. del Paciente</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link nombre-input" id="info-personal-encargado-tab" data-toggle="tab" href="#info-personal-encargado" role="tab" aria-controls="info-personal-encargado" aria-selected="false">Inf. del Encargado</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link nombre-input" id="info-personal-facturante-tab" data-toggle="tab" href="#info-personal-facturante" role="tab" aria-controls="info-personal-facturante" aria-selected="false">Inf. del Facturante</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link nombre-input" id="historia-clinica-tab" data-toggle="tab" href="#historia-clinica" role="tab" aria-controls="historia-clinica" aria-selected="false">Historia Clínica</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link nombre-input" id="vacunas-tab" data-toggle="tab" href="#vacunas" role="tab" aria-controls="vacunas" aria-selected="false">Vacunas</a>
                    </li>
                </ul>
            </div>

            <!-- ----------------------------------------------------------- !-->

            <!-- Incio del contenido de los Tabs !-->


            <div class="tab-content" id="myTabContent">

                <!-- Datos para la Informacion Personal del Paciente !-->

                <div class="tab-pane fade show active margen-general-1-bottom" id="info-personal-paciente" role="tabpanel" aria-labelledby="info-personal-paciente-tab">

                    <div class="col-12 border rounded">

                        <div class="margen-general-1-top padding-general-inicio-bottom">
                            <div class="form-row">
                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Nombre</label>
                                        <asp:TextBox runat="server" ID="nombrePaciente" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Primer Apellido</label>
                                        <asp:TextBox runat="server" ID="primerApellidoPaciente" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Segundo Apellido</label>
                                        <asp:TextBox runat="server" ID="segundoApellidoPaciente" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <div class="form-row">
                                            <label class="nombre-input">Cédula</label>
                                            <asp:TextBox runat="server" ID="cedulaPaciente" CssClass="form-control" placeholder="102340567" MaxLength="9"></asp:TextBox>
                                        </div>
                                        <div class="form-row" style="padding-left: 20px;">
                                            <input runat="server" class="form-check-input" type="checkbox" value="noCedula" id="pacienteNoCedula">
                                            <label class="form-check-label nombre-input" for="noCedulaCheck">No posee cedula</label>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Fecha de Nacimiento</label>
                                        <asp:TextBox runat="server" ID="fechaNacimientoPaciente" CssClass="form-control datepicker" placeholder="31/12/2019"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Sexo</label>
                                        <asp:DropDownList ID="sexoPaciente" runat="server" CssClass="custom-select">
                                            <asp:ListItem Value="femenino"> Femenino </asp:ListItem>
                                            <asp:ListItem Value="masculino"> Masculino </asp:ListItem>
                                            <asp:ListItem Selected="True" Value="otro"> Otro </asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-row general-card padding-general-bottom">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="card">
                                    <label class="nombre-input card-header">Dirección</label>

                                    <div class="form-row card-body padding-general-top">
                                        <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                            <div class="padding-general-label">

                                                <%--<asp:DropDownList ID="provinciasJ" runat="server" CssClass="custom-select browser-default listaProvincias" placeHolder="provincia">
                                                    
                                                    
                                                </asp:DropDownList>--%>

                                                <select runat="server" class="browser-default custom-select listaProvinciasEX" id="provinciasEX">

                                                    <option value="" disabled selected>Provincia</option>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                            <div class="padding-general-label">
                                                <select class="browser-default custom-select listaCantonesEX" id="cantonesEX">
                                                    <option value="" disabled selected>Cantón</option>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                            <div class="padding-general-label">
                                                <select class="browser-default custom-select listaDistritosEX" id="distritosEX">
                                                    <option value="" disabled selected>Distrito</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>


                        <div class="form-row general-card padding-general-bottom">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="card">
                                    <label class="card-header nombre-input">Otro</label>

                                    <div class="card-body">
                                        <div class="form-row ">
                                            <div class="form-group col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <label class="nombre-input">Foto del Paciente</label>
                                                    <div class="custom-file">
                                                        <asp:FileUpload ID="fotoPaciente" runat="server" CssClass="custom-file-input form-control" />
                                                        <label class="custom-file-label" for="inputGroupFile01" data-browse="Buscar"></label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <label class="nombre-input">Vincular expediente</label>
                                                    <asp:TextBox runat="server" ID="VincExpedientePaciente" CssClass="form-control" placeholder="URL del expdiente antiguo"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- ----------------------------------------------------------- !-->

                <!-- Datos para Informacion Personal del Encargado del Paciente !-->

                <div class="tab-pane fade margen-general-1-bottom" id="info-personal-encargado" role="tabpanel" aria-labelledby="info-personal-encargado-tab">

                    <div class="col-12 border rounded">

                        <div class="margen-general-1-top padding-general-inicio-bottom">
                            <div class="form-row">
                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Nombre</label>
                                        <asp:TextBox runat="server" ID="nombreEncargado" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Primer Apellido</label>
                                        <asp:TextBox runat="server" ID="primerApellidoEncargado" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Segundo Apellido</label>
                                        <asp:TextBox runat="server" ID="segundoApellidoEncargado" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Cédula</label>
                                        <asp:TextBox runat="server" ID="cedulaEncargado" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Teléfono</label>
                                        <asp:TextBox runat="server" ID="telefonoEncargado" CssClass="form-control" placeholder="8123654"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Correo Electrónico</label>
                                        <asp:TextBox runat="server" ID="correoEncargado" CssClass="form-control" placeholder="ejm@gmail.com"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Parentezco</label>
                                        <asp:TextBox runat="server" ID="parentezcoEncargado" CssClass="form-control" placeholder="Padre, Madre, Encargado(a)..."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-row general-card padding-general-bottom">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="card">

                                    <label class="card-header nombre-input">Dirección</label>

                                    <div class="card-body">
                                        <div class="form-row">
                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <select class="browser-default custom-select listaProvinciasEN" id="provinciasEN">
                                                        <option value="" disabled selected>Provincia</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <select class="browser-default custom-select listaCantonesEN" id="cantonesEN">
                                                        <option value="" disabled selected>Cantón</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <select class="browser-default custom-select listaDistritosEN" id="distritosEN">
                                                        <option value="" disabled selected>Distrito</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <select class="browser-default custom-select listaBarriosEN" id="barriosEN">
                                                        <option value="" disabled selected>Barrio</option>
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- ----------------------------------------------------------- !-->

                <!-- Datos para Informacion Personal del Destinatario de la Factura !-->

                <div class="tab-pane fade margen-general-1-bottom" id="info-personal-facturante" role="tabpanel" aria-labelledby="info-personal-facturante">

                    <div class="col-12 border rounded">

                        <div class="margen-general-1-top padding-general-inicio-bottom">
                            <div class="form-row">
                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Nombre</label>
                                        <asp:TextBox runat="server" ID="nombreFacturante" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Primer Apelido</label>
                                        <asp:TextBox runat="server" ID="primerApellidoFacturante" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Segundo Apelido</label>
                                        <asp:TextBox runat="server" ID="segundoApellidoFacturante" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Cédula</label>
                                        <asp:TextBox runat="server" ID="cedulaFacturante" CssClass="form-control" placeholder="1-0234-0456"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Teléfono</label>
                                        <asp:TextBox runat="server" ID="telefonoFacturante" CssClass="form-control" placeholder="12345678"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Correo Electrónico</label>
                                        <asp:TextBox runat="server" ID="correoFacturante" CssClass="form-control" placeholder="ejm@gmail.com"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-row general-card padding-general-bottom">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                                <div class="card">

                                    <label class="card-header nombre-input">Dirección</label>

                                    <div class="card-body">
                                        <div class="form-row">
                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <select class="browser-default custom-select listaProvinciasFA" id="provinciasFA">
                                                        <option value="" disabled selected>Provincia</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <select class="browser-default custom-select listaCantonesFA" id="cantonesFA">
                                                        <option value="" disabled selected>Cantón</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <select class="browser-default custom-select listaDistritosFA" id="distritosFA">
                                                        <option value="" disabled selected>Distrito</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <select class="browser-default custom-select listaBarriosFA" id="barriosFA">
                                                        <option value="" disabled selected>Barrio</option>
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- ----------------------------------------------------------- !-->

                <!-- Datos para Historia Clinica Pediatrica !-->

                <div class="tab-pane fade margen-general-1-bottom" id="historia-clinica" role="tabpanel" aria-labelledby="historia-clinica-tab">

                    <div class="col-12 border rounded margen-general-1-bottom padding-general-inicio-top">

                        <div class="form-row margen-general-2-top general-card padding-general-bottom">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="card">
                                    <label class="card-header nombre-input">Antecedentes Perinatales</label>


                                    <div class="card-body">
                                        <div class="form-row">
                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <label class="nombre-input">Talla al nacer</label>
                                                    <asp:TextBox runat="server" ID="tallaNacer" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <label class="nombre-input">Peso al nacer</label>
                                                    <asp:TextBox runat="server" ID="pesoNacer" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <label class="nombre-input">Edad gestacional</label>
                                                    <asp:TextBox runat="server" ID="edadGestacional" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <label class="nombre-input">Calificación universal</label>
                                                    <select runat="server" id="clasificacionUniversal" class="clasificacionUniversalOpciones browser-default custom-select margen-general-1-bottom">
                                                        <option value="termino" selected>Recién nacido de término</option>
                                                        <option value="pretermino">Recién nacido de pretérmino</option>
                                                        <option value="postermino">Recién nacido de postérmino</option>
                                                    </select>
                                                </div>

                                                <div>
                                                    <div class="form-check">
                                                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <div class="padding-general-label">
                                                                <%--<input class="form-check-input" type="radio" name="opciones-tamaño" id="opcion-pequeño" value="pequeño">--%>
                                                                <asp:RadioButton CssClass="form-check-input" ID="opcion_pequeno" GroupName="opciones_tamano" runat="server" />
                                                                <label class="form-check-label nombre-input">Pequeño</label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="form-check form-check">
                                                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <div class="padding-general-label">
                                                                <asp:RadioButton CssClass="form-check-input" ID="opcion_adecuado" GroupName="opciones_tamano" runat="server" />
                                                                <%--<input class="form-check-input" type="radio" name="opciones-tamaño" id="opcion-adecuado" value="adecuado" checked>--%>
                                                                <label class="form-check-label nombre-input" for="opciones-tamaño">Adecuado</label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="form-check form-check">
                                                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <div class="padding-general-label">
                                                                <asp:RadioButton CssClass="form-check-input" ID="opcion_grande" GroupName="opciones_tamano" runat="server" />
                                                                <%--<input class="form-check-input" type="radio" name="opciones-tamaño" id="opcion-grande" value="grande">--%>
                                                                <label class="form-check-label nombre-input" for="opciones-tamaño">Grande</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <label class="nombre-input">Calificación APGAR</label>
                                                    <asp:TextBox runat="server" ID="apgar" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <label class="nombre-input">Perímetro cefálico al nacer</label>
                                                    <asp:TextBox runat="server" ID="perimetroCefalico" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <label class="nombre-input">Otras Complicaciones</label>
                                                    <select id="otrasComplicacionesAP" runat="server" class="estadoPerinatal browser-default custom-select">
                                                        <option value="ausentes" selected>Ausentes</option>
                                                        <option value="presentes">Presentes</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <div class="complicacionPerinatal">
                                                        <label class="nombre-input">Complicaciones</label>
                                                        <textarea runat="server" id="complicacionPerinatal" class="form-control"></textarea>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-row general-card">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 padding-general-inicio-bottom">
                                <div class="card">
                                    <label class="card-header nombre-input">Antecedentes Heredo-Familiares</label>

                                    <div class="card-body">
                                        <div class="form-row padding-general-checkB">
                                            <div class="form-check col-lg-3 col-md-6 col-sm-12 col-xs-12">
                                                <div class="form-group ">
                                                    <input runat="server" class="form-check-input" type="checkbox" value="asma" id="asmaCheck">
                                                    <label class="form-check-label nombre-input" for="asmaCheck">Asma</label>
                                                </div>
                                            </div>

                                            <div class="form-check col-lg-3 col-md-6 col-sm-12 col-xs-12">
                                                <div class="form-group">
                                                    <input runat="server" class="form-check-input" type="checkbox" value="diabetes" id="diabetesCheck">
                                                    <label class="form-check-label nombre-input" for="diabetesCheck">Diabetes</label>
                                                </div>
                                            </div>

                                            <div class="form-check col-lg-3 col-md-6 col-sm-12 col-xs-12">
                                                <div class="form-group">
                                                    <input runat="server" class="form-check-input" type="checkbox" value="hipertension" id="hipertensionCheck">
                                                    <label class="form-check-label nombre-input" for="hipertensionCheck">Hipertensión Arterial</label>
                                                </div>
                                            </div>

                                            <div class="form-check col-lg-3 col-md-6 col-sm-12 col-xs-12">
                                                <div class="form-group">
                                                    <input runat="server" class="form-check-input" type="checkbox" value="cardiovascular" id="cardiovascularCheck">
                                                    <label class="form-check-label nombre-input" for="cardiovascularCheck">Enfermedades Cardiovasculares</label>
                                                </div>
                                            </div>

                                            <div class="form-check col-lg-3 col-md-6 col-sm-12 col-xs-12">
                                                <div class="form-group ">
                                                    <input runat="server" class="form-check-input" type="checkbox" value="displidemia" id="displidemiaCheck">
                                                    <label class="form-check-label nombre-input" for="displidemiaCheck">Displidemia</label>
                                                </div>
                                            </div>

                                            <div class="form-check col-lg-3 col-md-6 col-sm-12 col-xs-12">
                                                <div class="form-group">
                                                    <input runat="server" class="form-check-input" type="checkbox" value="epilepsia" id="epilepsiaCheck">
                                                    <label class="form-check-label nombre-input" for="epilepsiaCheck">Epilepsia</label>
                                                </div>
                                            </div>

                                            <div class="form-check col-lg-3 col-md-6 col-sm-12 col-xs-12">
                                                <div class="form-group ">
                                                    <input runat="server" class="form-check-input" type="checkbox" value="otros" id="otrosCheck">
                                                    <label class="form-check-label nombre-input" for="otrosCheck">Otros</label>
                                                    <div class="descripcionOtros">
                                                        <label class="nombre-input">Descripción</label>
                                                        <textarea runat="server" id="descripcionOtrosHF" class="form-control"></textarea>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-row margin-card">
                            <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12 padding-general-inicio-bottom">
                                <div class="padding-card">
                                    <div class="card">
                                        <label class="card-header nombre-input">Antecedentes Patológicos</label>
                                        <div class="card-body padding-general-top padding-general-bottom">
                                            <div class="padding-general-label">
                                                <select id="apatEstado" runat="server" class="antecedentePatologico browser-default custom-select">
                                                    <option value="ausentesPat" selected>Ausentes</option>
                                                    <option value="presentesPat">Presentes</option>
                                                </select>
                                                <div class="descripcionPatologicos margen-general-2-top">
                                                    <label class="nombre-input">Descripción</label>
                                                    <textarea runat="server" id="descripcionPatologicos" class="form-control"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12 padding-general-inicio-bottom">
                                <div class="padding-card">
                                    <div class="card">
                                        <label class="card-header nombre-input">Antecedentes Quirúrgicos</label>
                                        <div class="card-body padding-general-top padding-general-bottom">
                                            <div class="padding-general-label">
                                                <select id="aqEstado" runat="server" class="antecedenteQuirurgico browser-default custom-select">
                                                    <option value="ausentesQui" selected>Ausentes</option>
                                                    <option value="presentesQui">Presentes</option>
                                                </select>
                                                <div class="descripcionQuirurgico margen-general-2-top">
                                                    <label class="nombre-input">Descripción</label>
                                                    <textarea runat="server" id="descripcionQuirurgico" class="form-control"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-row margin-card">
                            <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12 padding-general-inicio-bottom">
                                <div class="padding-card">
                                    <div class="card">
                                        <label class="card-header nombre-input">Antecedentes Traumáticos</label>
                                        <div class="card-body padding-general-top padding-general-bottom">
                                            <div class="padding-general-label">
                                                <select id="atEstado" runat="server" class="antecedenteTraumatico browser-default custom-select">
                                                    <option value="ausentesTrau" selected>Ausentes</option>
                                                    <option value="presentesTrau">Presentes</option>
                                                </select>
                                                <div class="descripcionTraumatico margen-general-2-top">
                                                    <label class="nombre-input">Descripcion</label>
                                                    <textarea runat="server" id="descripcionTraumatico" class="form-control"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12 padding-general-inicio-bottom">
                                <div class="padding-card">
                                    <div class="card">
                                        <label class="card-header nombre-input">Alergias</label>
                                        <div class="card-body padding-general-top padding-general-bottom">
                                            <div class="padding-general-label">
                                                <select id="alergiasEstado" runat="server" class="alergiasExpediente browser-default custom-select">
                                                    <option value="ausentesAlergia" selected>Ausentes</option>
                                                    <option value="presentesAlergia">Presentes</option>
                                                </select>
                                                <div class="descripcionAlergia form-row" style="margin-top: 15px;">
                                                    <label class="nombre-input">Descripción</label>
                                                    <textarea runat="server" id="descripcionAlergia" class="form-control"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- ----------------------------------------------------------- !-->

                <!-- Datos para el esquema de vacunacion !-->

                <div class="tab-pane fade margen-general-1-bottom" id="vacunas" role="tabpanel" aria-labelledby="vacunas-tab">

                    <div class="col-12 border rounded margen-general-1-bottom padding-general-inicio-top">

                        <div class="form-row margen-general-2-top general-card padding-general-bottom">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                <div class="card">
                                    <label class="nombre-input card-header" style="padding-left: 40px">Lista de Pendientes</label>

                                    <div class="card-body">

                                        <div class="table-responsive">
                                            <asp:GridView ID="esquemaVacunacion" runat="server" CssClass="table"
                                                AutoGenerateColumns="false" HeaderStyle-CssClass="thead-light"
                                                HeaderStyle-ForeColor="DimGray" GridLines="None" Style="text-align: center" >

                                                <Columns>
                                                    <asp:TemplateField HeaderText="Aplicada">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="aplicado" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Vacuna" DataField="NombreVacuna" />
                                                    <asp:BoundField HeaderText="Edad de aplicación" DataField="EdadAplicacion" />

                                                </Columns>

                                            </asp:GridView>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- ----------------------------------------------------------- !-->
                <!-- Fin del fromulario para expediente !-->

            </div>

            <div class="form-row alinearBtnGuardarExp">
                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12 ubicacionBtn" runat="server">
                    <asp:Button type="button" runat="server" CssClass="btn btn-regresar" Text="REGRESAR" ID="regresar" OnClick="regresar_Click" />

                    <asp:Button type="button" runat="server" CssClass="btn btn-guardar" Text="GUARDAR" ID="guardarExpediente" ValidationGroup="validarExpediente" OnClick="guardarExpediente_Click" />
                </div>
            </div>

            

        </form>

    </div>

    <script>
        $('.datepicker').datepicker({
            uiLibrary: 'bootstrap4',
            locale: 'es-es',
            format: 'dd/mm/yyyy'
        });
    </script>
</asp:Content>
