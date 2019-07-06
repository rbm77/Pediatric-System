<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="MiAgenda.aspx.cs" Inherits="Pediatric_System.MiAgenda" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="CSS/hora1.css">
    <script src="JS/hora1.js"></script>
    <script src="JS/hora2.js"></script>


    <script type="text/javascript">


        function limpiar() {

            $('.clockpicker').val('');
            $('.duracion').val('');
            $('.lun').prop('checked', false);
            $('.mar').prop('checked', false);
            $('.mier').prop('checked', false);
            $('.jue').prop('checked', false);
            $('.vie').prop('checked', false);
            $('.sab').prop('checked', false);
            $('.dom').prop('checked', false);

        }

    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="container-fluid col-11 col-auto">
        <div class="page-header">
            <h3 class="text-info">Agenda Laboral</h3>
        </div>
    </div>

    <hr style="color: #0056b2;" />

    <form runat="server">


        <asp:ScriptManager ID="scriptmng" runat="server">
        </asp:ScriptManager>

        <br />

        <div class="container-fluid col-11 col-auto">

            <div class="card">

                <h5 class="card-header text-center" style="color: dimgray;">Horario</h5>


                <div class="card-body">



                    <%--                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">

                        <ContentTemplate>--%>

                    <div class="form-row">

                        <div class="form-group col-lg-10 col-md-10 col-sm-10 col-xs-12">

                            <div class="form-check form-check-inline">
                                <input class="form-check-input lun" type="checkbox" id="lunes" value="Lunes" runat="server" name="diaSemana">
                                <label class="form-check-label" for="lunes">Lunes</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input mar" type="checkbox" id="martes" value="Martes" runat="server" name="diaSemana">
                                <label class="form-check-label" for="martes">Martes</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input mier" type="checkbox" id="miercoles" value="Miércoles" runat="server" name="diaSemana">
                                <label class="form-check-label" for="miercoles">Miércoles</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input jue" style="padding-left: 30px" type="checkbox" id="jueves" value="Jueves" runat="server" name="diaSemana">
                                <label class="form-check-label" for="jueves">Jueves</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input vie" type="checkbox" id="viernes" value="Viernes" runat="server" name="diaSemana">
                                <label class="form-check-label" for="viernes">Viernes</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input sab" type="checkbox" id="sabado" value="Sabado" runat="server" name="diaSemana">
                                <label class="form-check-label" for="sabado">Sábado</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input dom" type="checkbox" id="domingo" value="Domingo" runat="server" name="diaSemana">
                                <label class="form-check-label" for="domingo">Domingo</label>
                            </div>

                        </div>




                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>


                                <div runat="server" style="display: inline-block; padding-left: 5px; width: 150px" id="form_actualizar">

                                    <asp:Button type="button" runat="server" class="btn btn-neutro" Text="ACTUALIZAR" ID="Actualizar" OnClick="Actualizar_Click" ValidationGroup="datosEntrada" />

                                </div>



                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>


                    <%--                        </ContentTemplate>
                    </asp:UpdatePanel>--%>

                    <br />

                    <div class="form-row">
                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <div class="padding-general-label">
                                <label class="nombre-input">Hora de Inicio</label>
                                <input type="text" class="form-control clockpicker" id="clockpicker" runat="server" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo requerido" ControlToValidate="clockpicker" Font-Size="Small" ForeColor="Red" ValidationGroup="datosEntrada"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <div class="padding-general-label">
                                <label class="nombre-input">Hora de Fin</label>
                                <input type="text" class="form-control clockpicker" id="clockpicker2" runat="server" /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo requerido" ControlToValidate="clockpicker2" Font-Size="Small" ForeColor="Red" ValidationGroup="datosEntrada"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-lg-4 col-md-6 col-sm-6 col-xs-12">
                            <div class="padding-general-label">
                                <label class="nombre-input">Duración de la cita (minutos)</label>
                                <input type="number" class="form-control duracion" id="duracion" step="5" runat="server" />
                            </div>
                        </div>

                    </div>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <asp:Literal ID="mensajeConfirmacion" runat="server" Visible="false"></asp:Literal>

                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                                <ProgressTemplate>

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


                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                <ProgressTemplate>

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

                            <div class="table-responsive">
                                <asp:GridView ID="vistaAgenda" runat="server" CssClass="table"
                                    Style="text-align: center" AutoGenerateColumns="false" HeaderStyle-CssClass="thead-light"
                                    HeaderStyle-ForeColor="DimGray" GridLines="None" OnRowCommand="vistaAgenda_RowCommand">

                                    <Columns>
                                        <asp:BoundField HeaderText="Día" DataField="Dia" ControlStyle-Width="25%" />
                                        <asp:BoundField HeaderText="Inicio" DataField="HoraInicio" ControlStyle-Width="25%" />
                                        <asp:BoundField HeaderText="Fin" DataField="HoraFin" ControlStyle-Width="25%" />

                                        <asp:ButtonField HeaderText="Acción" CommandName="Eliminar"
                                            ControlStyle-CssClass="btn btn-eliminar fas fa-trash-alt" runat="server" ControlStyle-Width="25%" />

                                    </Columns>
                                </asp:GridView>


                            </div>


                        </ContentTemplate>

                    </asp:UpdatePanel>


                </div>


                <br />


            </div>
            <br />


            <div class="form-row" style="text-align: right; display: block">
                <div class="form-group col-lg-3 col-md-3 col-sm-6 col-xs-6" style="display: inline-block">
                    <asp:Button type="button" runat="server" class="btn btn-regresar" Text="REGRESAR" ID="Regresar" OnClick="Regresar_Click" />
                </div>
            </div>
        </div>

    </form>

    <br />

    <script type="text/javascript">

        $('.clockpicker').clockpicker({
            'default': 'now',
            vibrate: true,
            placement: "top",
            align: "right",
            autoclose: true,
            twelvehour: true,
        });
        $('.clockpicker2').clockpicker({
            'default': 'now',
            vibrate: true,
            placement: "top",
            align: "right",
            autoclose: true,
            twelvehour: true
        });
    </script>



</asp:Content>
