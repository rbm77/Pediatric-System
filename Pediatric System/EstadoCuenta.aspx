<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="EstadoCuenta.aspx.cs" Inherits="Pediatric_System.EstadoCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $('[id*=gridCuentas]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="container-fluid col-10 col-auto">
        <div class="page-header">
            <h3 class="text-info">Estado de cuenta de usuario</h3>
        </div>
    </div>

    <hr style="color: #0056b2;" />

    <div class="container-fluid col-10 col-auto table-responsive">

        <br />

        <div class="card">
            <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-table"></i>  Lista de Cuentas de Personal</h5>
            <div class="card-body">
                <form id="form1" runat="server">
                    <div>
                        <asp:GridView ID="gridCuentas" runat="server" AutoGenerateColumns="false" class="table" Style="text-align: center"
                            Width="100%" HeaderStyle-ForeColor="DimGray" GridLines="None" HeaderStyle-CssClass="thead-light">
                            <Columns>
                                <asp:BoundField DataField="Correo" HeaderText="Correo" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </form>









                <%--<asp:Repeater ID="rptCustomers" runat="server">
            <HeaderTemplate>
                <div class="table-responsive">
                    <table class="table table-hover" id="dataTable">
                        <thead>
                            <tr class="bg-light">
                            <th scope="col" style="font-size: 16px; font-weight: bold; color: dimgray">Correo Electrónico</th>
                            <th scope="col" style="font-size: 16px; font-weight: bold; color: dimgray">Nombre</th>
                            <th scope="col" style="font-size: 16px; font-weight: bold; color: dimgray">Cedula</th>
                        </tr> 

                        </thead>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                 <tbody>
                <tr>
                    <td>
                        <asp:Label ID="lblCorreo" runat="server" Text='<%# Eval("Correo") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblCedula" runat="server" Text='<%# Eval("Cedula") %>' />
                    </td>
                </tr>
                     </tbody>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>--%>
            </div>
        </div>





        <%--        <table class="table table-striped" id="dataTable" >

            <thead>
                <tr>
                    <th scope="col" style="font-size: 16px; font-weight: bold; color: dimgray">Correo Electrónico</th>
                    <th scope="col" style="font-size: 16px; font-weight: bold; color: dimgray">Nombre</th>
                    <th scope="col" style="font-size: 16px; font-weight: bold; color: dimgray">Estado</th>
                </tr>
            </thead>
            <tbody>
                 <% 

                     foreach (var per in listaPersonal)
                     {%>
                <tr>
                    <td><% per.correo.ToString(); %></td>
                    <td><% per.nombre.ToString(); %></td>
  
                </tr>
 <% }%>
               <%-- <tr>
                    <th scope="row"></th>
                    <td></td>
                </tr>--%>
        <%--            </tbody>
        </table>--%>
    </div>

    <br />

    <%--    <div class="container-fluid col-10 col-auto">

        <div class="form-row">

            <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">

                <button type="submit" class="btn btn-outline-success form-control">GUARDAR</button>

            </div>

            <div class="form-group col-lg-3 col-md-3 col-sm-3 col-xs-6">

                <button type="submit" class="btn btn-outline-danger form-control">REGRESAR</button>

            </div>

        </div>
    </div>--%>
</asp:Content>
