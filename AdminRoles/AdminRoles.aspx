﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminRoles.aspx.cs" Inherits="AdminRoles.AdminRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="hdfIdUsuario" runat="server" />

    <script>
        window.onload = function(){
            var fil = '<%= filtros() %>';           
            
            if (fil == 'false' || fil == '')                 
                document.getElementById('filtro').checked = false;            
            else               
                document.getElementById('filtro').checked = true;            
        };
    </script>

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="panel with-nav-tabs panel-primary">
                    <div class="panel-heading">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab1primary" data-toggle="tab">Usuarios</a></li>
                            <li><a href="#tab2primary" data-toggle="tab">Perfiles</a></li>
                            <!-- Se oculta para desarrollarlo en una versión posterior -->
                            <li><a href="#tab3primary" data-toggle="tab" runat="server" visible="false">Sistemas</a></li>
                            <!-- Se oculta para desarrollarlo en una versión posterior -->
                            <li><a href="#tab4primary" data-toggle="tab" runat="server" visible="false">Efectores</a></li>
                        </ul>
                    </div>


                    <div class="panel-body">
                        <div class="tab-content">
                            <div class="tab-pane fade in active" id="tab1primary">
                                <div class="col-md-12">
                                    <table id="tblUsuarios" class="table-responsive" data-toggle="table" data-pagination="true" data-search="true">
                                        <thead>
                                            <tr>
                                                <th data-field="IdUsuario" data-align="center" data-sortable="true">ID</th>
                                                <th data-field="DNI" data-align="center" data-sortable="true" data--visible="false">DNI</th>
                                                <th data-field="Nombre" data-align="left" data-sortable="true">Nombre</th>
                                                <th data-field="Apellido" data-align="left" data-sortable="true">Apellido</th>
                                                <th data-field="Usuario" data-align="left" data-sortable="true">Usuario</th>
                                                <th data-field="RolId" data-align="left" data-sortable="true" data-visible="false">Perfil</th>
                                                <th data-field="operate" data-formatter="formatoMostrarPerfil" data-events="eventoMostrarPerfil" id="columnaMostrarPerfil" runat="server" data-align="center">Perfil</th>
                                                <th data-field="operate" data-formatter="formatoPerfilXEfector" data-events="eventoPerfilXEfector" id="columnaAsignarPerfilXEfector" runat="server" data-align="center">Asignar Perfil</th>
                                                <th data-field="operate" data-formatter="formatoAsignarPerfil" data-events="eventoAsignarPerfil" id="columnaPerfil" runat="server" data-align="center">Asignar Perfil</th>
                                                <th data-field="operate" data-formatter="formatoEfectores" data-events="eventoEfectores" id="columnaEfectores" runat="server" data-align="center">Efectores</th>
                                                <th data-field="operate" data-formatter="formatoEliminarPerfil" data-events="eventoEliminarPerfil" id="columnaEliminarPerfil" runat="server" data-align="center">Eliminar Perfil</th>
                                                <th data-field="operate" data-formatter="formatoAplicaciones" id="columnaApp" runat="server" data-events="eventosAplicaciones" data-align="center">App</th>
                                                <th data-field="operate" data-formatter="formatoEditarUsuario" data-events="eventosEditarUsuario" data-align="center">Editar</th>
                                                <th data-field="operate" data-formatter="formatoStatus" data-events="eventosStatus" data-align="center">Hab/Bloq</th>
                                                <th data-field="Habilitado" data-align="left" data-sortable="true" data-visible="false">Habilitado</th>
                                                <th data-field="Bloqueado" data-align="left" data-sortable="true" data-visible="false">Bloqueado</th>
                                            </tr>
                                        </thead>
                                    </table>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="tab2primary">
                                <div class="col-md-12">
                                    <%--<input type="button" class="btn btn-primary launch-modal" value="Crear Perfil" />--%>
                                    <table id="tblRoles" data-toggle="table" data-pagination="true" data-search="true">
                                        <thead class="table">
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
                            <div class="tab-pane fade" id="tab4primary">
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
                        <button type="button" class="btn btn-primary" data-dismiss="modal" onclick="document.getElementById('<%= txtRol.ClientID %>').value = ''">Cerrar</button>
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

    <!--Modal para informar que el usuario no tiene permiso a ninguna aplicación  -->
    <div id="errorModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Usuarios</h4>
                </div>
                <div class="modal-body center-block">
                    <a>
                        <i class="fa fa-user fa-4x"></i>
                    </a>
                    <h5>El usuario seleccionado no tiene permiso a ninguna aplicación.</h5>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    <!--Modal para asignar perfiles a un usuario en un determinado efector  -->
    <div id="asignarPerfilXEfector" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Asignar Perfil</h4>
                </div>
                <div class="modal-body center-block">
                    <div class="form-group">
                        <b>
                            <asp:Label ID="lblPerfil" runat="server" Text="Elegir Perfil" for="ddPerfil" class="col-sm-4 control-label">
                            </asp:Label></b>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="ddlPerfil" DataValueField="id" DataTextField="name" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <b>
                            <asp:Label ID="lblEfector" runat="server" Text="Elegir Efector" for="ddEfector" class="col-sm-4 control-label">
                            </asp:Label></b>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="ddlEfector" DataValueField="id" DataTextField="name" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="btnPerfilXEfector" onserverclick="btnPerfilXEfector_ServerClick" onclick="barraProgresoAsignarPerfil();" runat="server" type="button" class="btn btn-primary">Agregar</button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
    <script>
        $(function() {
            $('#filtro').click(function() {
                if (document.getElementById('filtro').checked) {
                    
                    var filtro = true;

                    $.ajax({
                        type: "POST",
                        url: '<%= ResolveUrl("AdminRoles.aspx/filtroUsuarios")%>' ,
                        data: "{'filtro':'" + filtro + "'}",                        
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {                            
                            window.location = window.location.href;
                        },
                        error: function (e) {
                            alert("Error");                            
                        }
                    });  
                    
                } else {
                    var filtro = false;

                    $.ajax({
                        type: "POST",
                        url: '<%= ResolveUrl("AdminRoles.aspx/filtroUsuarios")%>' ,
                        data: "{'filtro':'" + filtro + "'}",                        
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {                            
                            window.location = window.location.href;
                        },
                        error: function (e) {
                            alert("Error");                            
                        }
                    });  
                }                
            });
        });           
    </script>

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

        $('#<%= ddlPerfil.ClientID %>').select2();  
        $('#<%= ddlEfector.ClientID %>').select2();  
    </script>

    <script>
        function limpiarTextbox() {
            document.getElementById('<%= txtRol.ClientID %>').value = '';              
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
                '<a class="asignarPerfil launch-modal1 ' + btn + '" href="javascript:void(0)" data-toggle="tooltip" data-placement="left" title="Asignar Perfil">',
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

        function formatoPerfilXEfector(value, row, index) {
            return [
                    '<a class="perfilXEfector launch-modal1" href="javascript:void(0)" data-toggle="tooltip" data-placement="left" title="Asignar Perfil">',
                        '<i class="fa fa-plus-circle fa-lg">',
                    '</a>' ,
            ].join('');
        }

        window.eventoPerfilXEfector = {
            'click .perfilXEfector': function (e, value, row, index) {
            
                document.getElementById('<%= hdfIdUsuario.ClientID %>').value = row.IdUsuario;                
                
                $('#asignarPerfilXEfector').modal('show');
            }
        };

            function formatoMostrarPerfil(value, row, index) {
                return [                        
                            '<asp:Label ID="lblMostrarPerfil" Text=" ' + row.NombreRol + '" runat="server" ></asp:Label>',                        
                ].join('');
            }

            window.eventoMostrarPerfil = {
                'click .asignarPerfil': function (e, value, row, index) {
                
                }
            };

            function formatoEfectores(value, row, index) {
                return [
                        '<a class="efectores" href="javascript:void(0)" data-toggle="tooltip" data-placement="left" title="Efectores">',
                            '<i class="fa fa-h-square fa-lg"></i>',
                        '</a>' ,
                ].join('');
            }

            window.eventoEfectores = {
                'click .efectores': function (e, value, row, index) {
                    var w = 780;
                    var h = 700;
                    var left = Number((screen.width/2)-(w/2));
                    var tops = Number((screen.height/2)-(h/2));  

                    var nombreUsuario = row.Nombre + ' ' + row.Apellido;

                    if (row.RolId != null)
                        window.open("EfectoresXPerfil.aspx?idUsuario=" + row.IdUsuario + "&nombreUsuario=" + nombreUsuario + "&idPerfil=" + row.RolId,'', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width='+w+', height='+h+', top='+tops+', left='+left);                
                    else
                        alerta();
                }
            };

            function formatoEliminarPerfil(value, row, index) {
                return [
                    '<a class="eliminarPerfil" href="javascript:void(0)" data-toggle="tooltip" data-placement="left" title="Eliminar Perfil">',
                        '<i class="fa fa-trash fa-lg"></i>',
                    '</a>'
                ].join('');
            }

            window.eventoEliminarPerfil = {
                'click .eliminarPerfil': function (e, value, row, index) {

                    $('#progressBarModal').modal('show');

                    $(document).ready(function () {
                        var idUsuario = row.IdUsuario;
                        var idPerfil = row.RolId;

                        $.ajax({
                            type: "POST",
                            url: '<%= ResolveUrl("AdminRoles.aspx/eliminarPerfil")%>' ,
                            data: "{ 'idUsuario' : '" + idUsuario + "','idPerfil' : '" + idPerfil + "'}",
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
                                alert("Error");
                            }
                        });
                    })
                }
            }

            function operateFormatter(value, row, index) {
                return [
                    '<a class="editar" href="javascript:void(0)" data-toggle="tooltip" data-placement="left" title="Editar">',
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
                    '<a class="app ml10" href="javascript:void(0)" data-toggle="tooltip" data-placement="left" title="Aplicaciones">',
                        '<i class="fa fa-desktop"></i>',
                    '</a>'
                ].join('');
            }

            window.operateEvents1 = {
                'click .app': function (e, value, row, index) {
                    window.location = 'RolPermisos.aspx?llamada=aplicacion&rolName=' + row.Name + "&idPerfil=" + row.Id;
                }
            };

            function formatoAplicaciones(value, row, index) {            
                return [
                    '<a class="app ml10" href="javascript:void(0)" data-toggle="tooltip" data-placement="left" title="Aplicaciones" >',
                        '<i class="fa fa-desktop"></i>',
                    '</a>'
                ].join('');
            }

            window.eventosAplicaciones = {
                'click .app': function (e, value, row, index) {
                    if (row.RolId == null)
                        $('#errorModal').modal('show');
                    else                    
                        window.location = 'RolPermisos.aspx?llamada=usuario&rolId=' + row.RolId + '&rolName=' + row.Nombre + " " + row.Apellido + "&idUsuario=" + row.IdUsuario + "&perfil=" + row.NombreRol;                                
                }
            };

            function formatoEditarUsuario(value, row, index) {
                return [
                '<a class="editarUsuario ml10" href="javascript:void(0)" data-toggle="tooltip" data-placement="left" title="Editar Usuario">',
                    '<i class="fa fa-pencil-square-o"></i>',
                '</a>'
                ].join('');
            }

            window.eventosEditarUsuario = {
                'click .editarUsuario': function (e, value, row, index) {
                    window.location = 'EditarUsuario.aspx?idUsuario=' + row.IdUsuario;
                }
            };

            function formatoStatus(value, row, index) {

                var habilitado = row.Habilitado; 
                var bloqueado = row.Bloqueado;

                var btnHabilitado = "";
                var iconoHabilitado = "";
                var tooltipHabilitado = "";
            
                if (habilitado === true) {
                    btnHabilitado = "btn btn-info btn-status";
                    iconoHabilitado = "fa fa-thumbs-o-up";
                    tooltipHabilitado = "Habilitado";
                }
                else {
                    btnHabilitado = "btn btn-danger btn-status";
                    iconoHabilitado = "fa fa-thumbs-o-down";                
                    tooltipHabilitado = "Deshabilitado";
                }

                var btnBloqueado = "";
                var iconoBloqueado = "";
                var tooltipBloqueado = "";

                if (bloqueado === true) {
                    btnBloqueado = "btn btn-danger btn-status";
                    iconoBloqueado = "fa fa-thumbs-o-down";   
                    tooltipBloqueado = "Bloqueado";
                }
                else {
                    btnBloqueado = "btn btn-info btn-status";
                    iconoBloqueado = "fa fa-thumbs-o-up";                
                    tooltipBloqueado = "Desbloqueado";
                }

                return [            
              "<button type='button' class='" + btnHabilitado + "' data-toggle='tooltip' data-placement='left' Title='" + tooltipHabilitado + "'>",
               "<i class='" + iconoHabilitado + "'></i></button>&nbsp",

               "<button type='button' class='" + btnBloqueado + "' data-toggle='tooltip' data-placement='right' Title='" + tooltipBloqueado + "'>",
               "<i class='" + iconoBloqueado + "'></i></button>"
                ].join('');
            }

            window.eventosStatus = {
                'click .statusUsuario': function (e, value, row, index) {
                
                }
            };
    </script>

    <script>
        function alerta(){
            swal({
                title: "El usuario no tiene perfil!",               
                type: "error",
                showCancelButton: false,
                confirmButtonClass: 'btn-success',
                confirmButtonText: 'OK!'
            });
        };
    </script>
    <script>
        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
        })
    </script>

    <script>
        $table = $('#tblRoles').bootstrapTable({
            data: <%= devuelveRolesJson() %>,
            btnCrearPerfil: true
        });        

        $table = $('#tblUsuarios').bootstrapTable({
            data: <%= devuelveUsuariosJson() %>,
            btnCrearPerfil: false,
            filtro: true
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
