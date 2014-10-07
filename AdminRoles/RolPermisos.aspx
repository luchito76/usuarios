<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RolPermisos.aspx.cs" Inherits="AdminRoles.RolPermisos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= devuelveNombreDeRol() %></h2>

    <div class="panel panel-primary" id="form">
        <div class="panel-heading">
            <h2 class="panel-title">Permisios del Rol</h2>
        </div>
        <br />
        <div class="col-md-12">
            <asp:DropDownList ID="ddlAplicaciones" DataTextField="name" DataValueField="id" runat="server" Width="300px" CssClass="col-sm-4 form-control"></asp:DropDownList>
            <div class="form-group">
                <div class="col-sm-4">
                    <asp:Button ID="btnGuardar" runat="server" Text="Agregar" CausesValidation="true" class="btn btn-primary" OnClick="btnGuardar_Click" />
                </div>
            </div>
            <table id="tblAppXRoles" data-toggle="table" data-pagination="true" data-search="true">
                <thead>
                    <tr>
                        <th data-field="id" data-align="center" data-sortable="true">ID</th>
                        <th data-field="name" data-align="left" data-sortable="true">Nombre</th>
                        <th data-field="operate" data-formatter="operateFormatter" data-events="operateEvents" data-align="center">Usuarios</th>
                        <th data-field="operate" data-formatter="operateFormatter" data-events="operateEvents" data-align="center">Eliminar</th>
                        <th data-field="operate" data-formatter="operateFormatter" data-events="operateEvents" data-align="center">Regenerar</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>

    <script>
        function operateFormatter(value, row, index) {
            return [
                '<a class="editar" href="javascript:void(0)" title="Editar">',
                    '<i class="fa fa-users"></i>',
                '</a>'
            ].join('');
        }

        window.operateEvents = {
            'click .editar': function (e, value, row, index) {                          
                 
            }
        };
    </script>

    <script>
        $table = $('#tblAppXRoles').bootstrapTable({            
            data: <%= devuelveAppXRolJson() %>
            });
    </script>
</asp:Content>
