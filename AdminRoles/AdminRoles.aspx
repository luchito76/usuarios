﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminRoles.aspx.cs" Inherits="AdminRoles.AdminRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="hdfIdUsuario" runat="server" />

    <div class="container">
        <div class="page-header">
            <h1>Administración de Perfiles<span class="pull-right label label-default"></span></h1>
            <h3><%= devuelveEfector() %><span class="pull-left label label-default"></span></h3>
        </div>
        <div class="row">

            <div class="col-md-12">
                <div class="panel with-nav-tabs panel-primary">
                    <div class="panel-heading">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab1primary" data-toggle="tab">Perfiles</a></li>
                            <li><a href="#tab2primary" data-toggle="tab" runat="server" visible="false">Sistemas</a></li>
                            <!-- Se oculta para desarrollarlo en una versión posterior -->
                            <li><a href="#tab3primary" data-toggle="tab" runat="server" visible="false">Efectores</a></li>
                            <!-- Se oculta para desarrollarlo en una versión posterior -->
                            <li><a href="#tab4primary" data-toggle="tab">Usuarios</a></li>
                        </ul>
                    </div>
                    <div class="panel-body">
                        <div class="tab-content">
                            <div class="tab-pane fade in active" id="tab1primary">
                                <div class="col-md-12">
                                    <input type="button" class="btn btn-primary launch-modal" value="Crear Rol" />
                                    <table id="tblRoles" data-toggle="table" data-pagination="true" data-search="true">
                                        <thead class="table">
                                            <tr>
                                                <th data-field="Id" data-align="center" data-sortable="true">ID</th>
                                                <th data-field="Name" data-align="left" data-sortable="true">Nombre</th>
                                                <th data-field="operate" data-formatter="operateFormatter" data-events="operateEvents" data-align="center">Editar</th>
                                                <th data-field="operate" data-formatter="operateFormatter1" data-events="operateEvents1" data-align="center">Aplicaciones</th>
                                            </tr>
                                        </thead>
                                    </table>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="tab2primary">
                                <div class="col-md-12">
                                    <table id="tblAplicaciones" data-toggle="table" data-pagination="true" data-search="true">
                                        <thead>
                                            <tr>
                                                <th data-field="Id" data-align="center" data-sortable="true">ID</th>
                                                <th data-field="Name" data-align="left" data-sortable="true">Nombre</th>
                                                <th data-field="operate" data-formatter="operateFormatter" data-events="operateEvents" data-align="center">Editar</th>
                                                <th data-field="operate" data-formatter="operateFormatter1" data-events="operateEvents1" data-align="center">App</th>
                                            </tr>
                                        </thead>
                                    </table>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="tab3primary">
                                <div class="col-md-12">
                                    <table id="tblEfectores" data-toggle="table" data-pagination="true" data-search="true">
                                        <thead>
                                            <tr>
                                                <th data-field="Id" data-align="center" data-sortable="true">ID</th>
                                                <th data-field="Name" data-align="left" data-sortable="true">Nombre</th>
                                                <th data-field="operate" data-formatter="operateFormatter" data-events="operateEvents" data-align="center">Editar</th>
                                                <th data-field="operate" data-formatter="operateFormatter1" data-events="operateEvents1" data-align="center">App</th>
                                            </tr>
                                        </thead>
                                    </table>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="tab4primary">
                                <div class="col-md-12">
                                    <table id="tblUsuarios" data-toggle="table" data-pagination="true" data-search="true">
                                        <thead>
                                            <tr>
                                                <th data-field="IdUsuario" data-align="center" data-sortable="true">ID</th>
                                                <th data-field="DNI" data-align="center" data-sortable="true">DNI</th>
                                                <th data-field="Nombre" data-align="left" data-sortable="true">Nombre</th>
                                                <th data-field="Apellido" data-align="left" data-sortable="true">Apellido</th>
                                                <th data-field="Usuario" data-align="left" data-sortable="true">Usuario</th>
                                                <th data-field="RolId" data-align="left" data-sortable="true" data-visible="false">Perfil</th>
                                                <th data-field="operate" data-formatter="formatoAsignarPerfil" data-events="eventoAsignarPerfil" data-align="center">Asignar Perfil</th>
                                                <th data-field="operate" data-formatter="formatoEliminarPerfil" data-events="eventoEliminarPerfil" data-align="center">Eliminar Perfil</th>
                                                <th data-field="operate" data-formatter="formatoAplicaciones" data-events="eventosAplicaciones" data-align="center">Aplicaciones</th>
                                            </tr>
                                        </thead>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!--Modal para crear el rol o modificarlo  -->
        <div id="myModal" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">Nuevo</h4>
                    </div>
                    <div class="modal-body center-block">
                        <div class="form-group">
                            <b>
                                <asp:Label ID="lbRoles" runat="server" Text="Nombre" for="ddlAutorizado" class="col-sm-4 control-label">      
                                </asp:Label></b>
                            <div class="col-sm-5">
                                <asp:TextBox runat="server" ID="txtRol" CssClass="form-control" placeholder="Ingrese Nombre de Perfil" />
                                <asp:HiddenField ID="hdnIdRol" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button id="crearRoles" onserverclick="crearRol_Click" runat="server" type="button" class="btn btn-primary">Guardar</button>
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
    </div>


    <!--Modal para asignar perfiles a un usuario  -->
    <div id="asignarPerfilModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Asignar Perfil</h4>
                </div>
                <div class="modal-body center-block">
                    <div class="form-group">
                        <b>
                            <asp:Label ID="lblAsignarPerfil" runat="server" Text="Asignar Perfil" for="ddlAsignarPerfil" class="col-sm-4 control-label">      
                            </asp:Label></b>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="ddlAsignarPerfil" DataValueField="id" DataTextField="name" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div id="progressBarAsignarPerfil" class="progress progress-striped active">
                        <div id="progressAsignarPerfil" class="progress-bar progress-bar-info six-sec-ease-in-out" role="progressbar" data-transitiongoal="100"></div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="btnAsignarPerfil" onserverclick="btnAsignarPerfil_ServerClick" onclick="barraProgresoAsignarPerfil();" runat="server" type="button" class="btn btn-primary">Agregar</button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->


    <!--Modal para mostrar barra de progreso  -->
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

    <script>        
        function barraProgresoAsignarPerfil() {
            $(document).ready(function() {                
                $('#progressBarAsignarPerfil #progressAsignarPerfil').progressbar({
                    display_text: 'fill', 
                    use_percentage: true,
                    refresh_speed: 500
                });
            });
        }        
    </script>

    <script>
        function formatoAsignarPerfil(value, row, index) {
            
            var check = "";
            var btn = "";
                        
            if (row.RolId != null) {                
                btn = "btn  btn-info btn-circle btn-xs";
                check = "fa fa-check";
            } else if (row.RolId == null){
                btn = "btn btn-danger btn-circle btn-xs";
                check = "fa fa-times";
            }

            return [                               
                '<a class="asignarPerfil launch-modal1 ' + btn + '" href="javascript:void(0)" title="Asignar Perfil">',
                    '<i class="' + check + '"></i><asp:Label ID="lblNombreRol" Text=" ' + row.NombreRol + '" runat="server" ></asp:Label>',
                '</a>' ,                
            ].join('');
        }

        window.eventoAsignarPerfil = {
            'click .asignarPerfil': function (e, value, row, index) {                 
                $('#asignarPerfilModal').modal('show');                                    
                
                document.getElementById('<%= hdfIdUsuario.ClientID %>').value = row.IdUsuario;               
            }
        };

        function formatoEliminarPerfil(value, row, index) {
            return [               
                '<a class="eliminarPerfil" href="javascript:void(0)" title="Eliminar Perfil">',
                    '<i class="fa fa-times-circle-o fa-lg"></i>',
                '</a>'                
            ].join('');
        }

        window.eventoEliminarPerfil = {
            'click .eliminarPerfil': function (e, value, row, index) { 
                
                $('#progressBarModal').modal('show');

                $(document).ready(function () {
                    var idUser = row.IdUsuario;
                    
                    $.ajax({
                        type: "POST",
                        url: '<%= ResolveUrl("AdminRoles.aspx/eliminarPerfil")%>' ,
                        data: "{ 'idUsuario' : '" + idUser + "'}",                      
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        beforeSend:function(x){
                            $(document).ready(function() {
                                $('#progressBarEliminarPerfil #progressEliminarPerfil').progressbar({
                                    display_text: 'fill', 
                                    use_percentage: true,
                                    refresh_speed: 500});
                            });
                        },
                        success: function (msg) {    
                            
                            window.location = window.location.href;                            
                        },
                        complete:function(){
                            $('.progressBarModal').modal('hide');
                            $('.progress .progress-bar').progressbar().hide();
                        },
                        error: function (e) {
                            alert("Mal");
                            
                        }
                    });  
                })       
            }            
        }

        function operateFormatter(value, row, index) {
            return [
                '<a class="editar" href="javascript:void(0)" title="Editar">',
                    '<i class="fa fa-pencil-square-o"></i>',
                '</a>'
            ].join('');
        }

        window.operateEvents = {
            'click .editar': function (e, value, row, index) {                          
                $('#myModal').modal('show');                 
                document.getElementById('<%= txtRol.ClientID %>').value = row.Name;   
                document.getElementById('<%= hdnIdRol.ClientID %>').value = row.Id;   
            }
        };        

        function operateFormatter1(value, row, index) {
            return [                
                '<a class="app ml10" href="javascript:void(0)" title="Aplicaciones">',
                    '<i class="fa fa-desktop"></i>',
                '</a>'
            ].join('');
        }       

        window.operateEvents1 = {                      
            'click .app': function (e, value, row, index) {
                window.location = 'RolPermisos.aspx?rolName=' + row.Name + "&rolId=" + row.Id; 
            }
        };

        function formatoAplicaciones(value, row, index) {
            return [                
                '<a class="app ml10" href="javascript:void(0)" title="Aplicaciones">',
                    '<i class="fa fa-desktop"></i>',
                '</a>'
            ].join('');
        }       

        window.eventosAplicaciones = {                      
            'click .app': function (e, value, row, index) {
                window.location = 'RolPermisos.aspx?rolName=' + row.Nombre + " " + row.Apellido + "&idUsuario=" + row.IdUsuario; 
            }
        };       

    </script>

    <script>
        $table = $('#tblRoles').bootstrapTable({            
            data: <%= devuelveRolesJson() %>
            });


        <%--Se comenta para un desarrollo futuro.
        $table = $('#tblAplicaciones').bootstrapTable({            
            data: <%= devuelveAplicacionesJson() %>
            });
        $table = $('#tblEfectores').bootstrapTable({            
            data: <%= devuelveEfectoresJson() %>
            });--%>
        $table = $('#tblUsuarios').bootstrapTable({            
            data: <%= devuelveUsuariosJson() %>
            });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('.launch-modal').click(function () {
                $('#myModal').modal({
                    keyboard: true
                });
            });
        });
    </script>
</asp:Content>
