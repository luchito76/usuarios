<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EfectoresXPerfil.aspx.cs" Inherits="AdminRoles.EfectoresXPerfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-table.css" rel="stylesheet" />
    <link href="Content/font-awesome/font-awesome.css" rel="stylesheet" />
    <link href="Content/select2.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" class="form-horizontal" runat="server">
        <div class="panel panel-primary" id="form">
            <div class="panel-heading">
                <span class="panel-title"><%= devuelveNombreUsuario() %></span>
            </div>
            <br />
            <div class="col-md-12">
                <table id="tblEfectores" data-toggle="table" data-pagination="true" data-search="true" data-page-size="10" data-page-list="[10, 20, 30]">
                    <thead>
                        <tr>
                            <th data-field="id" data-align="left" data-sortable="true">ID</th>
                            <th data-field="Efector" data-align="left" data-sortable="true">Efector</th>
                            <th data-field="operate" id="columnaApp" runat="server" data-formatter="formatoAplicaciones" data-events="eventosAplicaciones" data-align="center">App</th>
                        </tr>
                    </thead>
                </table>
                <div class="form-group">
                    <div class="col-sm-4">
                        <%--<asp:Button ID="btnAgregar" runat="server" Text="Agregar efector" class="btn btn-primary" />--%>
                        <input type="button" class="btn btn-primary" onclick="agregarEfector();" value="Agregar" />
                        <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" OnClientClick="cerrarVentana();" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>

        <!--Modal para un listado de efectores  -->
        <div id="agregarEfectorAPerfil" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">Agregar Efector a Perfil</h4>
                    </div>
                    <div class="modal-body center-block">
                        <div class="form-group">
                            <b>
                                <asp:Label ID="lblAgregarEfector" runat="server" Text="Agregar Efector" for="ddlAgregarEfector" class="col-sm-4 control-label">
                                </asp:Label></b>
                            <div class="col-sm-5">
                                <asp:DropDownList ID="ddlAgregarEfector" DataValueField="Id" DataTextField="Name" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div id="progressBarAgregarEfector" class="progress progress-striped active">
                            <div id="progressAgregarEfector" class="progress-bar progress-bar-info six-sec-ease-in-out" role="progressbar" data-transitiongoal="100"></div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <%--<button id="btnAgregarEfector" onserverclick="btnAgregarEfector_ServerClick1"  onclick="barraProgresoAgregarEfector();" runat="server" type="button" class="btn btn-primary">Agregar</button>--%>
                        <asp:Button ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" Text="Agregar" class="btn btn-primary" />
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
    </form>

    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap-table.js"></script>
    <script src="Scripts/select2.js"></script>
    <script src="Scripts/select2_locale_es.js"></script>

    <script>
        window.onload = function(){          
            document.getElementById("nombrePerfil").innerHTML = '<%= devuelveNombrePerfil() %>';
        };
    </script>

    <script>
        function agregarEfector() {
            $('#agregarEfectorAPerfil').modal('show');                           
        }
    
        function cerrarVentana() {
            window.close();            
        }

        $('#<%= ddlAgregarEfector.ClientID %>').select2();  
    </script>

    <script>
        function formatoAplicaciones(value, row, index) {            
            return [
                '<a class="app" href="javascript:void(0)" data-toggle="tooltip" data-placement="left" title="Aplicaciones" >',
                    '<i class="fa fa-desktop"></i>',
                '</a>'
            ].join('');
        }

        window.eventosAplicaciones = {
            'click .app': function (e, value, row, index) {
                var idUsuario = '<%= IdUsuario %>';
                var idPerfil = '<%= IdPerfil %>';
                //if (row.RolId == null)
                //    $('#errorModal').modal('show');
                //else                    
                window.location = 'RolPermisos.aspx?llamada=usuario&idPerfil=' + idPerfil + "&idUsuario=" + idUsuario + "&idEfector=" + row.id;                                
            }
        };
    </script>

    <script>
        function barraProgresoAgregarEfector() {
            $(document).ready(function() {
                $('#progressBarAgregarEfector #progressAgregarEfector').progressbar({
                    display_text: 'fill',
                    use_percentage: true,
                    refresh_speed: 500
                });
            });
        }

    </script>

    <%--<script>
        function agregarEfectorFormato(value, row, index) {            
            return [
                    '<a class="agregarEfector" href="javascript:void(0)" data-toggle="tooltip" data-placement="left" title="Agregar Efectores">',
                        '<i class="fa fa-plus-square fa-lg"></i>',
                    '</a>' ,
            ].join('');
        }

        window.agregarEfectorEvento = {
            'click .agregarEfector': function (e, value, row, index) {
                
                $('#agregarEfectorAPerfil').modal('show');                             
            }
        };
    </script>--%>

    <script>
        $table = $('#tblEfectores').bootstrapTable({            
            data: <%= devuelveEfectores() %>,    
            nombrePerfil: true,
        });               
    </script>

</body>
</html>
