﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="EstadoCuenta.aspx.cs" Inherits="Pediatric_System.EstadoCuenta" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="JS/jquery/highlight.pack.js"></script>
     <script src="JS/jquery/jquery.min.js"></script>
    <script src="JS/jquery/iphone-style-checkboxes.js"></script>
    <link href="CSS/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="CSS/agenda.css" />
    <link rel="stylesheet" href="CSS/expediente.css" />
    <script type="text/javascript">
        $(function () {
            $('[id*=gridCuentas]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "numbers"
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container-fluid col-11 col-auto">
        <br>
        <div class="page-header margen-general-2-top">
            <h2 class="text-info">Administración Cuentas</h2>
        </div>

        <hr class="linea-divisoria-titulo" />
    </div>

    <div class="container-fluid col-11 col-auto table-responsive">
        <form id="form1" runat="server">
               <ul class="nav nav-tabs">
                    <li class="nav-item">
                        <a class="nav-link active nombre-input" id="info-personal-paciente-tab" " href="EstadoCuenta.aspx" role="tab" aria-controls="info-personal-paciente" aria-selected="true">Cuentas</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link nombre-input" id="info-personal-encargado-tab"  href="CuentaPersonal.aspx" role="tab" aria-controls="info-personal-encargado" aria-selected="false">Nueva Cuenta</a>
                    </li>
               </ul>
                <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-list"></i>  Cuenta de Personal</h5>
                <div class="card-body">
                    <div>
                        <div class="table-responsive">

                            <asp:GridView ID="gridCuentas" runat="server" AutoGenerateColumns="false" class="table table-hover" OnRowCommand="grdAccidentMaster_OnRowCommand"
                                Style="text-align: center" Width="100%" HeaderStyle-ForeColor="DimGray" GridLines="None" HeaderStyle-CssClass="thead-light" OnRowDataBound="vistaCuentas_RowDataBound">
                                <Columns>
                                       <asp:TemplateField HeaderText="Nombre Completo">
                                      <ItemTemplate>
                                      <%# Eval("Nombre") + " " + Eval("Apellido")%>
                                       </ItemTemplate>
                                        </asp:TemplateField>
                                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                                    <asp:BoundField DataField="Cedula" HeaderText="Cédula" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="false" />
                                    <asp:ButtonField HeaderText="Editar" CommandName="enviarCorreo"
                                     ControlStyle-CssClass="btn btn-neutro fas fa-edit" runat="server" ControlStyle-Width="40px" ControlStyle-Height="40px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"/>                                                             

                                    <asp:TemplateField HeaderText="Estado" ItemStyle-Wrap="true">                                                                                                                   
                                      <ItemTemplate>
                                          <asp:Button ID="Button1" runat="server" Text="Deshabilitada" Visible ='<%#(DataBinder.Eval(Container.DataItem, "Estado").ToString() == "Deshabilitada") ? true : false  %>'  Enabled ='<%#(DataBinder.Eval(Container.DataItem, "Estado").ToString() == "Habilitada") ? true : false %>' ClientIDMode="Static" ControlStyle-CssClass="btn btn-deshabilitar "/>
                                          <asp:Button ID="btnHabilitar" runat="server" ToolTip='<%# Eval("Correo") %>' CommandName="habilitarCuenta" Text="Habilitada" Visible ='<%#(DataBinder.Eval(Container.DataItem, "Estado").ToString() == "Deshabilitada") ? true : false %>' ClientIDMode="Static" ControlStyle-CssClass="btn btn-blancoDer fas fa-edit"/>
                                          <asp:Button ID="Button3" runat="server"  ToolTip='<%# Eval("Correo") %>' CommandName="deshabilitarCuenta" Text="Deshabilitada" Visible ='<%#(DataBinder.Eval(Container.DataItem, "Estado").ToString() == "Habilitada") ? true : false %>' ClientIDMode="Static" ControlStyle-CssClass="btn btn-blancoIzq fas fa-edit"/>
                                          <asp:Button ID="Button2"  runat="server" Text="Habilitada" Visible ='<%#(DataBinder.Eval(Container.DataItem, "Estado").ToString() == "Habilitada") ? true : false %>' Enabled ='<%#(DataBinder.Eval(Container.DataItem, "Estado").ToString() == "Deshabilitada") ? true : false %>'  ClientIDMode="Static" ControlStyle-CssClass="btn btn-habilitar fas fa-edit"/>                                                                                                     
                                          </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
       
                    </div>
                </div>
            </div>

            <br />
            <asp:Literal ID="mensajeConfirmacion" runat="server" Visible="false"></asp:Literal>
            <br />

            <asp:ScriptManager ID="scriptmng" runat="server"></asp:ScriptManager>

            <asp:HiddenField ID="campoEscondido" runat="server" />

            <asp:ModalPopupExtender ID="modalEdicion" runat="server"
                PopupControlID="panelContenido" TargetControlID="campoEscondido"
                CancelControlID="CerrarModal" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>

            <asp:Panel ID="panelContenido" runat="server" CssClass="modal-content container-fluid col-9 col-auto
                                  modal-dialog-scrollable">
                <div class="modal-header">
                    <h5 class="modal-title" runat="server" id="exampleModalLabel">Cuenta</h5>

                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="CerrarModal">
                        <span aria-hidden="true">&times;</span>
                    </button>

                </div>
                <div class="modal-body">
                    <div class="tab-content" id="myTabContent">
                        <div class="tab-pane fade show active margen-general-1-bottom" id="info-personal-paciente" role="tabpanel" aria-labelledby="info-personal-paciente-tab">
                            <div class="col-12 border rounded margen-general-2-top">
                                <br>
                                <div class="margen-general-1-top padding-general-inicio-bottom">
                                    <div class="form-row">
                                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                            <div class="padding-general-label">
                                                <label class="nombre-input">Nombre</label>
                                                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"  required="required"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                            <div class="padding-general-label">
                                                <label class="nombre-input">Apellido</label>
                                                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" required="required"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                            <div class="padding-general-label">
                                                <label class="nombre-input">Cédula</label>
                                                <asp:TextBox runat="server" ID="txtCedula" CssClass="form-control" placeholder="102340567" TextMode="Number" required="required"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                            <div class="padding-general-label">
                                                <label class="nombre-label">Rol</label>
                                                <asp:TextBox runat="server" ID="txtRol" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                            <div class="padding-general-label">
                                                <label class="nombre-label">Correo</label>
                                                <asp:TextBox runat="server" ID="txtCorreo" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                            <div class="padding-general-label">
                                                <label class="nombre-label">Teléfono</label>
                                                <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" TextMode="Number" required="required"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                                            <div class="padding-general-label">
                                                <asp:Label class="nombre-label" ID="lblCodigo" Visible="false" runat="server" Text="Código Médico"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtCodigo" Visible="false" Enabled="false" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="btnGuardarExpediente form-group col-lg-12 col-md-6 col-sm-6 col-xs-6" style="text-align: right;">
                        <asp:Button ID="btnEditar" runat="server" Text="GUARDAR" CssClass="btn btn-guardar" OnClick="btnEditarSeleccion_Click" style="height: 45px;width: 170px;"></asp:Button>
                    </div>


                </div>
            </asp:Panel>

        </form>

    </div>
    <br />


 
    <script type="text/javascript">


        $(document).ready(function () {
            $('input[type=checkbox][id$=chk]').iphoneStyle();
        });

        $(':checkbox').iphoneStyle({
            checkedLabel: 'Hab ',
            uncheckedLabel: 'Des'
        });

        $('input[value=Habilitar]').attr('Text', "Que onda");


    </script>

    <script>
        function validation() {

            alert("Clicked, new value")
        }
    </script>
</asp:Content>
