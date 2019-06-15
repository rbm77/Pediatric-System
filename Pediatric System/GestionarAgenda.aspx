<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="GestionarAgenda.aspx.cs" Inherits="Pediatric_System.GestionarAgenda" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="CSS/agenda.css" />
    <link rel="stylesheet" href="CSS/sesion1.css" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="container-fluid col-10 col-auto">
        <div class="page-header">
            <h3 class="text-info">Citas</h3>

        </div>
    </div>

    <hr style="color: #0056b2;" />

    <div class="container-fluid col-10 col-auto">

        <br />

        <div class="form-row" style="text-align: center; display: block">
            <div class="form-group" style="display: inline-block">
                <form id="form1" runat="server">

                    <%--El scriptmanager se utiliza para manejar las peticiones ajax--%>
                    <asp:ScriptManager ID="scriptmng" runat="server"></asp:ScriptManager>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Calendar ID="calendario" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px"
                                Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth"
                                Width="350px" OnSelectionChanged="ActualizarAgenda" OnDayRender="calendario_DayRender">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#16ACB8" ForeColor="White" />
                                <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#16ACB8" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>

                            <br />
                            <br />


                            <div class="table-responsive">
                                <asp:GridView ID="vistaAgenda" runat="server" CssClass="table"
                                    Style="text-align: center" AutoGenerateColumns="true" HeaderStyle-CssClass="thead-light"
                                    HeaderStyle-ForeColor="DimGray" GridLines="None"
                                    OnSelectedIndexChanged="vistaAgenda_SelectedIndexChanged"
                                    OnRowDataBound="vistaAgenda_RowDataBound" RowStyle-CssClass="resaltado">
                                </asp:GridView>
                            </div>

                            <asp:HiddenField ID="campoEscondido" runat="server" />



                            <asp:ModalPopupExtender ID="modalEdicion" runat="server"
                                PopupControlID="panelContenido" TargetControlID="campoEscondido"
                                CancelControlID="CerrarModal" BackgroundCssClass="modalBackground">
                            </asp:ModalPopupExtender>


                            <asp:Panel ID="panelContenido" runat="server" CssClass="modal-content container-fluid col-10 col-auto">

                                <div class="modal-header">
                                    <h5 class="modal-title" runat="server" id="exampleModalLabel">Estado</h5>



                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="CerrarModal">
                                        <span aria-hidden="true">&times;</span>
                                    </button>

                                </div>
                                <div class="modal-body">

                                    <div class="card">
                                        <h5 class="card-header text-center" style="color: dimgray;">Cita</h5>
                                        <div class="card-body">

                                            <div class="form-row">
                                                <div class="form-group col-lg-4 col-md-8 col-sm-6 col-xs-12">
                                                    <label for="nombre" style="font-size: 16px; color: dimgray">Nombre del Paciente</label>
                                                    <input type="text" class="form-control" id="nombretxt" />
                                                </div>
                                                <div class="form-group col-lg-4 col-md-8 col-sm-6 col-xs-12">
                                                    <label for="nombre" style="font-size: 16px; color: dimgray">Edad del Paciente</label>
                                                    <input type="text" class="form-control" id="edadtxt" />
                                                </div>
                                                <div class="form-group col-lg-4 col-md-8 col-sm-6 col-xs-12">
                                                    <label for="nombre" style="font-size: 16px; color: dimgray; font-family:">Número Teléfonico del Encargado</label>
                                                    <input type="text" class="form-control" id="numerotxt" />
                                                </div>

                                            </div>




                                            <hr style="color: #0056b2;" />
                                            <br />

                                            <div class="form-row">
                                                <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-12">

                                                    <button type="submit" class="btn btn-outline-primary form-control">CREAR EXPEDIENTE</button>

                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                </div>

                            </asp:Panel>

                        </ContentTemplate>
                    </asp:UpdatePanel>








                </form>
            </div>
        </div>


    </div>



    <%-- <form runat="server">--%>

    <%-- <div class="container-fluid col-10 col-auto table-responsive">
    --%>

    <%--            <div class="form-row" style="text-align: center; display: block">
                <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-6" style="display: inline-block">
                    <asp:Button type="button" runat="server" class="btn btn-outline-info form-control" Text="SEMANA ACTUAL" ID="Actual" />
                </div>
                <div class="form-group col-lg-3 col-md-6 col-sm-6 col-xs-6" style="display: inline-block">
                    <asp:Button type="button" runat="server" class="btn btn-outline-info form-control" Text="SIGUIENTE SEMANA" ID="Siguiente" />
                </div>
            </div>--%>


    <%-- <div style="text-align: center; display: block">

                <div class="btn-group btn-group-toggle col-lg-6 col-md-6 col-sm-6 col-xs-6" data-toggle="buttons">

                    <label class="btn btn-outline-info form-control active">
                        <input type="radio" name="options" id="option1" checked>
                        SEMANA ACTUAL
                    </label>
                    <label class="btn btn-outline-info form-control">
                        <input type="radio" name="options" id="option2">
                        SIGUIENTE SEMANA
                    </label>
                </div>
            </div>--%>



    <br />

    <%--          <table class="table table-bordered">

                <thead>
                    <tr class="bg-info">
                        <th scope="col" style="font-size: 18px; font-weight: bold; color: white; width: 14%; text-align: center; border: 2px solid;">Hora</th>
                        <th scope="col" style="font-size: 18px; font-weight: bold; color: white; width: 14%; text-align: center; border: 2px solid;">Lunes</th>
                        <th scope="col" style="font-size: 18px; font-weight: bold; color: white; width: 14%; text-align: center; border: 2px solid;">Martes</th>
                        <th scope="col" style="font-size: 18px; font-weight: bold; color: white; width: 14%; text-align: center; border: 2px solid;">Miércoles</th>
                        <th scope="col" style="font-size: 18px; font-weight: bold; color: white; width: 14%; text-align: center; border: 2px solid;">Jueves</th>
                        <th scope="col" style="font-size: 18px; font-weight: bold; color: white; width: 14%; text-align: center; border: 2px solid;">Viernes</th>
                        <%--                        <th scope="col" style="font-size: 18px; font-weight: bold; color: white; width: 14%; text-align: center; border: 2px solid;">Sábado</th>--%>
    <%--        </tr>
                </thead>--%>
    <%--                <tbody>
                    <tr>
                        <th class="bg-info" scope="row" style="font-size: 16px; font-weight: bold; color: white; text-align: center; border: 2px solid white;">4:30 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                    </tr>
                    <tr>
                        <th class="bg-info" scope="row" style="font-size: 16px; font-weight: bold; color: white; text-align: center; border: 2px solid white;">5:00 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                    </tr>
                    <tr>
                        <th class="bg-info" scope="row" style="font-size: 16px; font-weight: bold; color: white; text-align: center; border: 2px solid white;">5:30 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                    </tr>
                    <tr>
                        <th class="bg-info" scope="row" style="font-size: 16px; font-weight: bold; color: white; text-align: center; border: 2px solid white;">6:00 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                    </tr>
                    <tr>
                        <th class="bg-info" scope="row" style="font-size: 16px; font-weight: bold; color: white; text-align: center; border: 2px solid white;">6:30 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                    </tr>
                    <tr>
                        <th class="bg-info" scope="row" style="font-size: 16px; font-weight: bold; color: white; text-align: center; border: 2px solid white;">7:00 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                    </tr>
                    <tr>
                        <th class="bg-info" scope="row" style="font-size: 16px; font-weight: bold; color: white; text-align: center; border: 2px solid white;">7:30 pm</th>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-light" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-danger" style="cursor: pointer; border: 2px solid white;"></td>
                        <td data-toggle="modal" data-target="#exampleModal" class="table-success" style="cursor: pointer; border: 2px solid white;"></td>
                    </tr>
                </tbody>
            </table>--%>

    <%--        </div>--%>




    <br />



    <div class="container-fluid col-4 col-auto">
        <button type="submit" class="btn btn-outline-danger form-control col-lg-12 col-md-12 col-sm-12 col-xs-12">REGRESAR</button>
    </div>

    <br />






</asp:Content>
