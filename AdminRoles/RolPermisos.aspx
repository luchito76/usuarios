<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RolPermisos.aspx.cs" Inherits="AdminRoles.RolPermisos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="myScriptManager" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <asp:HiddenField ID="hdnIdEfector" runat="server" />
    <asp:HiddenField ID="hdIdAplicacion" runat="server" />
    <asp:HiddenField ID="hdnIdPerfil" runat="server" />
    <asp:HiddenField ID="hdnNombreRol" runat="server" />

    <h3 style="display: inline"><%= devuelveNombreDeRol() %>  </h3>
    <h2 style="display: inline">- </h2>
    <h3 style="display: inline"><%= NombreDePerfil %></h3>

    <div class="panel panel-primary" id="form">
        <div class="panel-heading">
            <span class="panel-title">Permisios del Rol</span>
        </div>
        <br />
        <div class="col-md-12">
            <asp:DropDownList ID="ddlAplicaciones" DataTextField="description" DataValueField="id" runat="server" Width="300px" CssClass="col-sm-4 form-control"></asp:DropDownList>
            <div class="form-group">
                <div class="col-sm-4">
                    <asp:Button ID="btnGuardar" runat="server" Text="Agregar" CausesValidation="true" class="btn btn-primary" OnClick="btnGuardar_Click" OnClientClick="modal();" />
                </div>
            </div>
            <div id="divAppXRoles" runat="server" visible="false">
                <table id="tblAppXRoles" data-toggle="table" data-pagination="true" data-search="true" data-id-field="id">
                    <thead>
                        <tr>
                            <th data-field="id" data-align="center" data-sortable="true">ID</th>
                            <th data-field="nombreAplicacion" data-align="left" data-sortable="true">Nombre</th>
                            <th data-field="operate" data-formatter="formatoUsuario" data-events="eventoUsuario" data-align="center">Usuarios</th>
                            <th data-field="operate" data-formatter="formatoEliminar" data-events="eventoEliminar" data-align="center">Eliminar</th>
                            <th data-field="operate" data-formatter="formatoModulos" data-events="eventoModulos" data-align="center">Módulos</th>
                        </tr>
                    </thead>
                </table>
            </div>
            <div id="divAppXUsuarios" runat="server" visible="false">
                <table id="tblAppXUsuarios" data-toggle="table" data-pagination="true" data-search="true" data-id-field="id">
                    <thead>
                        <tr>
                            <th data-field="id" data-align="center" data-sortable="true">ID</th>
                            <th data-field="name" data-align="left" data-sortable="true">Nombre</th>
                            <th data-field="operate" data-formatter="formatoEliminar" data-events="eventoEliminar" data-align="center">Eliminar</th>
                            <th data-field="operate" data-formatter="formatoModulosXUsuario" data-events="eventoModulosXUsuario" data-align="center">Módulos</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>

    <div id="progressBarModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Eliminando Perfil...</h4>
                </div>
                <div class="modal-body center-block">
                    <div id="progressBarEliminarPerfil" class="progress progress-striped active">
                        <div id="progressEliminarPerfil" class="progress-bar progress-bar-info six-sec-ease-in-out" role="progressbar" data-transitiongoal="100"></div>
                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    <!-- Static Modal -->
    <div class="modal fade processing-modal" id="processing-modal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="text-center">
                        <img src="img/gif.GIF" class="icon" />
                        <h4>Creando permisos...</h4>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        function modal() {
            $('#processing-modal').modal('show');
        }
    </script>

    <script>
        function MostrarModulos(idAplicacion, idRol)
        {           
            var w = 800;
            var h = 700;
            var left = Number((screen.width/2)-(w/2));
            var tops = Number((screen.height/2)-(h/2));          
                
            var nombreAplicacion = '<%= nomApp %>';
            var idUsuario = '<%= IdUsuario %>';
            var idEfector = '<%= IdEfector %>';
            var llamada = "";    

            if (idUsuario == 0)
                llamada = "aplicacion";
            else
                llamada = "usuario";
                    
            window.open("Modulos.aspx?moduloNuevo=si&llamada=" + llamada + "&nombreAplicacion=" + nombreAplicacion +  "&idAplicacion=" + idAplicacion + "&idRol=" + idRol + "&idUsuario=" + idUsuario + "&idEfector=" + idEfector ,'', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width='+w+', height='+h+', top='+tops+', left='+left);                
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

                window.open("UsuariosXAplicacion.aspx?idAplicacion=" + row.id, '', 'toolbar=yes, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width='+w+', height='+h+', top='+tops+', left='+left);                
            }
        };  

        function formatoEliminar(value, row, index) {
            return [
                '<a class="eliminar" href="javascript:void(0)" title="Borrar">',
                    '<i class="fa fa-trash"></i>',                        
            '</a>'
            ].join('');
        }        

        window.eventoEliminar = {
            'click .eliminar': function (e, value, row, index) {                 
                $(document).ready(function () {

                    var idPerfil = '<%= IdPerfil %>';
                    var idEfector = '<%= IdEfector %>';

                    $.ajax({
                        type: "POST",
                        url: '<%= ResolveUrl("RolPermisos.aspx/eliminarAplicacion")%>' ,
                        data: "{'idPerfil':'" + idPerfil + "', 'idAplicacion':'" + row.id + "', 'idEfector':'" + idEfector + "'}",                        
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {                            
                            window.location = window.location.href;
                        },
                        error: function (e) {
                            alert("Error");                            
                        }
                    });  
                })                
            }
        }
        
        function formatoModulos(value, row, index) {
            return [
                '<a class="modulos" href="javascript:void(0)" title="Módulos">',
                    '<i class="fa fa-puzzle-piece"></i>',                    
                '</a>'
            ].join('');
        }

        window.eventoModulos = {
            'click .modulos': function (e, value, row, index) { 
               
                var w = 800;
                var h = 700;
                var left = Number((screen.width/2)-(w/2));
                var tops = Number((screen.height/2)-(h/2));

                var idPerfil = '<%= IdPerfil %>'; 
                var idEfector = '<%= IdEfector %>';

                window.open("Modulos.aspx?llamada=aplicacion&nombreAplicacion=" + row.nombreAplicacion +  "&idAplicacion=" + row.id + "&idRol=" + idPerfil + "&idEfector=" + idEfector,'', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width='+w+', height='+h+', top='+tops+', left='+left);                                
            }
        }; 

        function formatoModulosXUsuario(value, row, index) {           

            return [
                '<a class="usuarios" href="javascript:void(0)" title="Módulos">',
                    '<i class="fa fa-puzzle-piece"></i>',                    
                '</a>'
            ].join('');
        }

        window.eventoModulosXUsuario = {
            'click .usuarios': function (e, value, row, index) {            
                
                var w = 800;
                var h = 700;
                var left = Number((screen.width/2)-(w/2));
                var tops = Number((screen.height/2)-(h/2));

                var idUsuario = '<%= IdUsuario %>';
                var idEfector = '<%= IdEfector %>';
                var idPerfil = '<%= IdPerfil %>';

                window.open("Modulos.aspx?llamada=usuario&nombreAplicacion=" + row.nombreAplicacion +  "&idAplicacion=" + row.id + "&idUsuario=" + idUsuario + "&idEfector=" + idEfector + "&idRol=" + idPerfil,'', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width='+w+', height='+h+', top='+tops+', left='+left);                                
            }
        }; 
    </script>

    <script>
        $table = $('#tblAppXRoles').bootstrapTable({            
            data: <%= devuelveAppXRolJson() %>
            });  
            
        $table = $('#tblAppXUsuarios').bootstrapTable({            
            data: <%= devuelveAppXUsuario() %>
            }); 
    </script>


</asp:Content>
