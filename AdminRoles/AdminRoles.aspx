<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminRoles.aspx.cs" Inherits="AdminRoles.AdminRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="container">
        <div class="page-header">
            <h1>Administración de Roles<span class="pull-right label label-default"></span></h1>
            <h3><%= devuelveEfector() %><span class="pull-left label label-default"></span></h3>
        </div>
        <div class="row">

            <div class="col-md-12">
                <div class="panel with-nav-tabs panel-primary">
                    <div class="panel-heading">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab1primary" data-toggle="tab">Roles</a></li>
                            <li><a href="#tab2primary" data-toggle="tab">Sistemas</a></li>
                            <li><a href="#tab3primary" data-toggle="tab">Efectores</a></li>
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
                                                <th data-field="operate" data-formatter="operateFormatter1" data-events="operateEvents1" data-align="center">App</th>
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
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="myModal" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">Crear Rol</h4>
                    </div>
                    <div class="modal-body center-block">
                        <div class="form-group">
                            <b>
                                <asp:Label ID="lbRoles" runat="server" Text="Nuevo Rol" for="ddlAutorizado" class="col-sm-4 control-label">      
                                </asp:Label></b>
                            <div class="col-sm-5">
                                <asp:TextBox runat="server" ID="txtRol" CssClass="form-control" placeholder="Ingrese Nombre de Rol" />
                                <asp:HiddenField ID="hdnIdRol" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <%--<button id="btnGuardar" type="button" class="btn btn-primary" data-dismiss="modal" onserverclick="btnGuardar_Click">Cerrar</button>--%>
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

    <script>        
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
    </script>

    <script>
        $table = $('#tblRoles').bootstrapTable({            
            data: <%= devuelveRolesJson() %>
            });

        $table = $('#tblAplicaciones').bootstrapTable({            
            data: <%= devuelveAplicacionesJson() %>
            });
        $table = $('#tblEfectores').bootstrapTable({            
            data: <%= devuelveEfectoresJson() %>
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
