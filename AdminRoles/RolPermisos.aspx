<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RolPermisos.aspx.cs" Inherits="AdminRoles.RolPermisos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="myScriptManager" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hdnIdEfector" runat="server" />
    <asp:HiddenField ID="hdIdAplicacion" runat="server" />
    <asp:HiddenField ID="hdnIdPerfil" runat="server" />
    <asp:HiddenField ID="hdnNombreRol" runat="server" />

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
            <table id="tblAppXRoles" data-toggle="table" data-pagination="true" data-search="true" data-id-field="id">
                <thead>
                    <tr>
                        <th data-field="idAplicacion" data-align="center" data-sortable="true">ID</th>
                        <th data-field="nombreAplicacion" data-align="left" data-sortable="true">Nombre</th>
                        <th data-field="operate" data-formatter="formatoUsuario" data-events="eventoUsuario" data-align="center">Usuarios</th>
                        <th data-field="operate" data-formatter="operateFormatter1" data-events="operateEvents1" data-align="center">Eliminar</th>
                        <th data-field="operate" data-formatter="formatoModulos" data-events="eventoModulos" data-align="center">Módulos</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>    

    <script>
        function MostrarModulos(idAplicacion, idRol)
        {
            var w = 800;
            var h = 700;
            var left = Number((screen.width/2)-(w/2));
            var tops = Number((screen.height/2)-(h/2));          
                
            var nombreAplicacion = '<%= nomApp %>';

            window.open("Modulos.aspx?nombreAplicacion=" + nombreAplicacion +  "&idAplicacion=" + idAplicacion + "&idRol=" + idRol,'', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width='+w+', height='+h+', top='+tops+', left='+left);                
        }
    </script>

    <script>
        function formatoUsuario(value, row, index) {           

            return [
                '<a class="usuarios" href="javascript:void(0)" title="Usuarios">',
                    '<i class="fa fa-users launch-modal"></i>',                    
                '</a>'
            ].join('');
        }

        window.eventoUsuario = {
            'click .usuarios': function (e, value, row, index) {            
                             
                var w = 700;
                var h = 640;
                var left = Number((screen.width/2)-(w/2));
                var tops = Number((screen.height/2)-(h/2));
                
                window.open("UsuariosXAplicacion.aspx?idAplicacion=" + row.idAplicacion, '', 'toolbar=yes, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width='+w+', height='+h+', top='+tops+', left='+left);                
            }
        };  

        function operateFormatter1(value, row, index) {
            return [
                '<a class="eliminar" href="javascript:void(0)" title="Borrar">',
                    '<i class="fa fa-trash"></i>',                        
            '</a>'
            ].join('');
        }

        function formatoModulos(value, row, index) {
            return [
                '<a class="usuarios" href="javascript:void(0)" title="Usuarios">',
                    '<i class="fa fa-puzzle-piece"></i>',                    
                '</a>'
            ].join('');
        }

        

        window.operateEvents1 = {
            'click .eliminar': function (e, value, row, index) {                 
                $(document).ready(function () {
                    var idRol = '<%= devuelveIdRol() %>';
                    var idEfector = document.getElementById('<%= hdnIdEfector.ClientID %>').value;
                    $.ajax({
                        type: "POST",
                        url: '<%= ResolveUrl("RolPermisos.aspx/eliminarAplicacionXRol")%>' ,
                        data: "{'idEfector':'" + idEfector + "', 'idPerfil':'" + idRol + "', 'idAplicacion':'" + row.idAplicacion + "'}",                        
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {                            
                            window.location = window.location.href;
                        },
                        error: function (e) {
                            alert("Mal");
                            
                        }
                    });  
                })                
            }
        }
        
        window.eventoModulos = {
            'click .usuarios': function (e, value, row, index) { 
               
                var w = 800;
                var h = 700;
                var left = Number((screen.width/2)-(w/2));
                var tops = Number((screen.height/2)-(h/2));

                var idRol = '<%= devuelveIdRol() %>';
                
                window.open("Modulos.aspx?nombreAplicacion=" + row.nombreAplicacion +  "&idAplicacion=" + row.idAplicacion + "&idRol=" + idRol,'', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width='+w+', height='+h+', top='+tops+', left='+left);                                
            }
        }; 
    </script>

    <script>
        $table = $('#tblAppXRoles').bootstrapTable({            
            data: <%= devuelveAppXRolJson() %>
            });          
    </script>


</asp:Content>
