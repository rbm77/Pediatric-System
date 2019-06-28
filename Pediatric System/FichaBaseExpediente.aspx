<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FichaBaseExpediente.aspx.cs" Inherits="Pediatric_System.FichaBaseExpediente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="CSS/expediente.css" />
    <script type="text/javascript" src="JS/expediente.js"></script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid col-11 col-auto">

        <div class="page-header margen-general-2-top">
            <h2 class="text-info">Expediente</h2>
        </div>

        <hr class="linea-divisoria-titulo" />

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
                                        <asp:TextBox runat="server" ID="nombre" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Primer Apellido</label>
                                        <asp:TextBox runat="server" ID="primerApellido" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Segundo Apellido</label>
                                        <asp:TextBox runat="server" ID="segundoApellido" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Cédula</label>
                                        <asp:TextBox runat="server" ID="cedula" CssClass="form-control" placeholder="102340567" MaxLength="9"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="validacionFormatoCedulaPaciente" CssClass="containerValidacion" runat="server" ErrorMessage="Solo números" ControlToValidate="cedula" ValidationGroup="validarExpediente" ValidationExpression="^\d+" ForeColor="Red"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="validacionVacioCedulaPaciente" CssClass="containerValidacion" runat="server" ErrorMessage="Este campo no puede quedar vacio" ControlToValidate="cedula" ForeColor="Red" ValidationGroup="validarExpediente"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Fecha de Nacimiento</label>
                                        <asp:TextBox runat="server" ID="fechaNacimiento" CssClass="form-control datepicker" placeholder="31/12/2019"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Sexo</label>
                                        <asp:DropDownList ID="sexo" runat="server" CssClass="custom-select">
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
                                                <select class="browser-default custom-select">

                                                    <option value="" disabled selected>Provincia</option>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                            <div class="padding-general-label">
                                                <select class="browser-default custom-select">
                                                    <option value="" disabled selected>Cantón</option>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                            <div class="padding-general-label">
                                                <select class="browser-default custom-select">
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
                                                    <asp:TextBox runat="server" ID="VincExpediente" CssClass="form-control" placeholder="URL del expdiente antiguo"></asp:TextBox>
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
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Primer Apellido</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Segundo Apellido</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Cédula</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Teléfono</label>
                                        <input type="text" class="form-control" placeholder="12345678">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Correo Electrónico</label>
                                        <input type="text" class="form-control" placeholder="ejm@gmail.com">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Parentezco</label>
                                        <input type="text" class="form-control" placeholder="Padre, Madre, Encargado(a)...">
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
                                                    <select class="browser-default custom-select">
                                                        <option value="" disabled selected>Provincia</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <select class="browser-default custom-select">
                                                        <option value="" disabled selected>Cantón</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <select class="browser-default custom-select">
                                                        <option value="" disabled selected>Distrito</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <select class="browser-default custom-select">
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
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Primer Apelido</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Segundo Apelido</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Cédula</label>
                                        <input type="text" class="form-control" placeholder="1-0234-0456">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Teléfono</label>
                                        <input type="text" class="form-control" placeholder="12345678">
                                    </div>
                                </div>

                                <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                    <div class="padding-general-label">
                                        <label class="nombre-input">Correo Electrónico</label>
                                        <input type="text" class="form-control" placeholder="ejm@gmail.com">
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
                                                    <select class="browser-default custom-select">
                                                        <option value="" disabled selected>Provincia</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <select class="browser-default custom-select">
                                                        <option value="" disabled selected>Cantón</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <select class="browser-default custom-select">
                                                        <option value="" disabled selected>Distrito</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <select class="browser-default custom-select">
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
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <label class="nombre-input">Peso al nacer</label>
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <label class="nombre-input">Edad gestacional</label>
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <label class="nombre-input">Calificación universal</label>
                                                    <select class="clasificacionUniversalOpciones browser-default custom-select margen-general-1-bottom">
                                                        <option value="termino" selected>Recién nacido de término</option>
                                                        <option value="pretermino">Recién nacido de pretérmino</option>
                                                        <option value="postermino">Recién nacido de postérmino</option>
                                                    </select>
                                                </div>

                                                <div>
                                                    <div class="form-check">
                                                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <div class="padding-general-label">
                                                                <input class="form-check-input" type="radio" name="opciones-tamaño" id="opcion-pequeño" value="pequeño">
                                                                <label class="form-check-label nombre-input" for="opciones-tamaño">Pequeño</label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="form-check form-check">
                                                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <div class="padding-general-label">
                                                                <input class="form-check-input" type="radio" name="opciones-tamaño" id="opcion-adecuado" value="adecuado" checked>
                                                                <label class="form-check-label nombre-input" for="opciones-tamaño">Adecuado</label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="form-check form-check">
                                                        <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <div class="padding-general-label">
                                                                <input class="form-check-input" type="radio" name="opciones-tamaño" id="opcion-grande" value="grande">
                                                                <label class="form-check-label nombre-input" for="opciones-tamaño">Grande</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <label class="nombre-input">Calificación APGAR</label>
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <label class="nombre-input">Perímetro cefálico al nacer</label>
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <label class="nombre-input">Otras Complicaciones</label>
                                                    <select class="estadoPerinatal browser-default custom-select">
                                                        <option value="ausentes" selected>Ausentes</option>
                                                        <option value="presentes">Presentes</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                <div class="padding-general-label">
                                                    <div class="complicacionPerinatal">
                                                        <label class="nombre-input">Complicaciones</label>
                                                        <textarea id="complicacionPerinatal" class="form-control"></textarea>
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
                                                    <input class="form-check-input" type="checkbox" value="asma" id="asmaCheck">
                                                    <label class="form-check-label nombre-input" for="asmaCheck">Asma</label>
                                                </div>
                                            </div>

                                            <div class="form-check col-lg-3 col-md-6 col-sm-12 col-xs-12">
                                                <div class="form-group">
                                                    <input class="form-check-input" type="checkbox" value="diabetes" id="diabetesCheck">
                                                    <label class="form-check-label nombre-input" for="diabetesCheck">Diabetes</label>
                                                </div>
                                            </div>

                                            <div class="form-check col-lg-3 col-md-6 col-sm-12 col-xs-12">
                                                <div class="form-group">
                                                    <input class="form-check-input" type="checkbox" value="hipertension" id="hipertencionCheck">
                                                    <label class="form-check-label nombre-input" for="hipertencionCheck">Hipertensión Arterial</label>
                                                </div>
                                            </div>

                                            <div class="form-check col-lg-3 col-md-6 col-sm-12 col-xs-12">
                                                <div class="form-group">
                                                    <input class="form-check-input" type="checkbox" value="cardiovascular" id="cardiovascularCheck">
                                                    <label class="form-check-label nombre-input" for="cardiovascularCheck">Enfermedades Cardiovasculares</label>
                                                </div>
                                            </div>

                                            <div class="form-check col-lg-3 col-md-6 col-sm-12 col-xs-12">
                                                <div class="form-group ">
                                                    <input class="form-check-input" type="checkbox" value="displidemia" id="displidemiaCheck">
                                                    <label class="form-check-label nombre-input" for="displidemiaCheck">Displidemia</label>
                                                </div>
                                            </div>

                                            <div class="form-check col-lg-3 col-md-6 col-sm-12 col-xs-12">
                                                <div class="form-group">
                                                    <input class="form-check-input" type="checkbox" value="epilepsia" id="epilepsiaCheck">
                                                    <label class="form-check-label nombre-input" for="epilepsiaCheck">Epilepsia</label>
                                                </div>
                                            </div>

                                            <div class="form-check col-lg-3 col-md-6 col-sm-12 col-xs-12">
                                                <div class="form-group ">
                                                    <input class="form-check-input" type="checkbox" value="otros" id="otrosCheck">
                                                    <label class="form-check-label nombre-input" for="otrosCheck">Otros</label>
                                                    <div class="descripcionOtros">
                                                        <label class="nombre-input">Descripción</label>
                                                        <textarea id="descripcionOtros" class="form-control"></textarea>
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
                                                <select class="antecedentePatologico browser-default custom-select">
                                                    <option value="ausentesPat" selected>Ausentes</option>
                                                    <option value="presentesPat">Presentes</option>
                                                </select>
                                                <div class="descripcionPatologicos margen-general-2-top">
                                                    <label class="nombre-input">Descripción</label>
                                                    <textarea id="descripcionPatologicos" class="form-control"></textarea>
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
                                                <select class="antecedenteQuirurgico browser-default custom-select">
                                                    <option value="ausentesQui" selected>Ausentes</option>
                                                    <option value="presentesQui">Presentes</option>
                                                </select>
                                                <div class="descripcionQuirurgico margen-general-2-top">
                                                    <label class="nombre-input">Descripción</label>
                                                    <textarea id="descripcionQuirurgico" class="form-control"></textarea>
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
                                                <select class="antecedenteTraumatico browser-default custom-select">
                                                    <option value="ausentesTrau" selected>Ausentes</option>
                                                    <option value="presentesTrau">Presentes</option>
                                                </select>
                                                <div class="descripcionTraumatico margen-general-2-top">
                                                    <label class="nombre-input">Descripcion</label>
                                                    <textarea id="descripcionTraumatico" class="form-control"></textarea>
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
                                                <select class="alergiasExpediente browser-default custom-select">
                                                    <option value="ausentesAlergia" selected>Ausentes</option>
                                                    <option value="presentesAlergia">Presentes</option>
                                                </select>
                                                <div class="descripcionAlergia form-row" style="margin-top: 15px;">
                                                    <label class="nombre-input">Descripción</label>
                                                    <textarea id="descripcionAlergia" class="form-control"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <!-- Fin del fromulario para expediente !-->

            </div>

            <div class="form-row alinearBtnGuardarExp">
                <div class="form-group col-lg-12 col-md-12 col-sm-12 col-xs-12 ubicacionBtn" runat="server">
                    <asp:Button type="button" runat="server" CssClass="btn btn-regresar" Text="REGRESAR" ID="regresar" OnClick="regresar_Click" />

                    <asp:Button type="button" runat="server" CssClass="btn btn-guardar" Text="GUARDAR" ID="guardarExpediente" ValidationGroup="validarExpediente" OnClick="guardarExpediente_Click" />
                </div>
            </div>

            <asp:Literal ID="mensajeConfirmacion1" runat="server"></asp:Literal>

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
