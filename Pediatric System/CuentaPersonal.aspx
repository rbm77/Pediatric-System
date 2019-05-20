<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CuentaPersonal.aspx.cs" Inherits="Pediatric_System.CuentaPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <form>
        <div class="form-row">
            <div class="form-group col-md-2">
                <input type="text" class="form-control" placeholder="Nombre">
            </div>
            <div class="form-group col-md-2">
                <input type="text" class="form-control" placeholder="Primer Apellido">
            </div>
            <div class="form-group col-md-2">
                <input type="text" class="form-control" placeholder="Segundo Apellido">
            </div>
            <div class="form-group col-md-2">
                <input type="text" class="form-control" placeholder="Cédula">
            </div>
        </div>
    </form>


</asp:Content>
