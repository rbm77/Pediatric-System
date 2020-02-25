<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CrearReportes.aspx.cs" Inherits="Pediatric_System.CrearReportes" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script type="text/javascript" src="JS/reportes.js"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        @media (min-width: 768px) {
            .btnFiltro {
                width: 150px;
                position: absolute;
                bottom: 0;
            }
        }

    </style>


    <div class="container-fluid col-10 col-auto">

        <br />

        <div class="page-header">
            <h2 class="text-info">Reportes</h2>
        </div>

        <hr style="color: #0056b2;" />

        <!-- ---------------------------------------------------- !-->
       
        <form  runat="server">
            <div class="col-12 bg-light border border-info rounded table-responsive">
                <div class="form-row" style="margin-top: 15px;">
                    <div class="form-group col-lg-4 col-md-4 col-sm-12 col-xs-12">
                        <label style="font-size: 16px; font-weight: bold; color: dimgray">Fecha de Inicio</label>
                        <input  runat="server" id="dateIni" class="datepickerIni"  />
                    </div>

                    <div class="form-group col-lg-4 col-md-4 col-sm-12 col-xs-12">
                        <label style="font-size: 16px; font-weight: bold; color: dimgray">Fecha de Fin</label>
                        <input runat="server" id="dateFin" class="datepickerFin" />
                    </div>
                    
                    <div class="form-group col-lg-4 col-md-4 col-sm-12 col-xs-12">
                       <div class="padding-general-label">
                        <label class="nombre-input">Médico</label>
                        <asp:DropDownList ID="ddCodigoMedico" CssClass="browser-default custom-select" runat="server" ></asp:DropDownList>
                    </div>
                    </div>

                    <div class="form-group col-lg-4 col-md-4 col-sm-12 col-xs-12">
                        <label style="font-size: 16px; font-weight: bold; color: dimgray">Seleccionar reporte</label>
                        <select id="tipoReporte" runat="server" class="seleccionReporte browser-default custom-select">
                            
                            <option selected value="medicina_Mixta">Medicina Mixta</option>
                            <option disabled value="ve02">Boleta VE-02</option>
                        </select>
                    </div>
                     <div class="form-group col-lg-4 offset-4 col-md-4 col-sm-12 col-xs-12">
                         <asp:Button ID="btnFiltrar" CssClass="btn btn-neutro btnFiltro" runat="server" Text="FILTRAR" OnClick="btnFiltrar_Click" />
                    </div>
                </div>
                 <asp:Literal ID="mensajeConfirmacion" runat="server"></asp:Literal>
            </div>

            <div class="visualizacionTitulo" style="margin-top: 25px;">
                <div class="row col-12">
                    <asp:label  runat="server" id="lblresult" style="font-size: 20px; font-weight: bold; color: dimgray" Text="Resultado"/>
                </div>
            </div>
            <asp:Literal ID="Literal1" runat="server" Visible="false"></asp:Literal>
            <div class="card visualizacion-medicina-mixta">

               <div class="col-12 margen-general-1-bottom paddingSidesCard" style="padding-top:10px">
                <div class="table-responsive">
                    <div class="card">
                        <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-list"></i>  Lista de Consultas con Medicina Mixta</h5>
                        <div class="card-body"> 
                            <div>
                                <asp:GridView ID="gridConsultas" runat="server" CssClass="table" Style="text-align: center"
                                    AutoGenerateColumns="false" HeaderStyle-CssClass="thead-light"
                                    HeaderStyle-ForeColor="DimGray" GridLines="None" Width="100%" >
                                    <Columns>
                                        <asp:BoundField HeaderText="Expediente" DataField="CodigoExpediente" />
                                        <asp:BoundField HeaderText="Frecuencia" DataField="FRECUENCIA" />
                                        <asp:BoundField HeaderText="Referido" DataField="REFERIDO_A" />
                                        <asp:BoundField HeaderText="Fecha" DataField="Fecha_Hora" DataFormatString="{0:dd/MM/yyyy}" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                <%-- asdasd --%>
            </div>

            <div class="card visualizacion-boleta-ve02">

                <div class="card-body">
                    <table class="table table-hover table-responsive-md">
                        <thead>
                            <tr>
                                <th scope="col" style="font-size: 16px; font-weight: bold; color: dimgray">Fecha</th>
                                <th scope="col" style="font-size: 16px; font-weight: bold; color: dimgray">Enfermedad</th>
                                <th scope="col" style="font-size: 16px; font-weight: bold; color: dimgray">Sexo</th>
                                <th scope="col" style="font-size: 16px; font-weight: bold; color: dimgray">Edad (Meses)</th>
                                <th scope="col" style="font-size: 16px; font-weight: bold; color: dimgray">Dirección</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>27/05/2019</td>
                                <td>Escabisosis</td>
                                <td>Masculino</td>
                                <td>2</td>
                                <td>Buenos Aires, Palmares, Alajuela</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

            <br />
            <br />
                <div class="btnGuardarExpediente form-group col-lg-12 col-md-12 col-sm-12 col-xs-6" style="text-align: right;">
                <asp:Button type="button" runat="server" CssClass="btn btn-regresar" Text="REGRESAR" ID="regresar" />
                <asp:Button ID="btnGenerar" runat="server" Text="GENERAR" Enabled="false" CssClass="btn btn-guardar" OnClick="btnGenerar_Click"></asp:Button>
            </div>
           
        </form>


    </div>


    <script>
        var today = new Date();
            var dd = String(today.getDate()).padStart(2, '0');
            var mm = String(today.getMonth() + 1).padStart(2, '0');
            var yyyy = today.getFullYear();
            today = dd + '/' + mm + '/' + yyyy;
            $('input[id=ContentPlaceHolder1_dateIni]').attr('value', today);
        $('input[id=ContentPlaceHolder1_dateFin]').attr('value', today);



        $(function () {
            $('[id*=gridConsultas]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "numbers"
            });
        });

        $('.datepickerIni').datepicker({
            uiLibrary: 'bootstrap4',
            locale: 'es-es',
            format: 'dd/mm/yyyy'
        });
        $('.datepickerFin').datepicker({
            uiLibrary: 'bootstrap4',
            locale: 'es-es',
            format: 'dd/mm/yyyy'
        });
    </script>

</asp:Content>
