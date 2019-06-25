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
            <h5 class="card-header text-center" style="color: dimgray;"><i class="fas fa-table"></i>Lista de Cuentas de Personal</h5>
            <div class="card-body">
                <form id="form1" runat="server">
                    <div>
                        <asp:GridView ID="gridCuentas" runat="server" AutoGenerateColumns="false" class="table table-hover"
                            Width="100%" HeaderStyle-ForeColor="DimGray" GridLines="None" HeaderStyle-CssClass="thead-light">
                            <Columns>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                <asp:BoundField DataField="Correo" HeaderText="Correo" />
                                <asp:BoundField DataField="Cedula" HeaderText="Cédula" />
                               
                                 <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                  <asp:Button ID="btnEditar" runat="server" ClientIDMode="Static"  Text="Editar" />
                                  <asp:Button ID="btnEstado" runat="server" ClientIDMode="Static" Text="Estado" />
                                </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
