<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" Inherits="AdminRoles.EditarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row clearfix">
            <div id="selectUsuarios" runat="server" visible="false" class="col-md-8 column">
                <div class="form-group">
                    <b>
                        <asp:Label ID="lblUsuarios" runat="server" Text="Usuarios" for="ddlUsuarios" class="col-md-3 control-label">
                        </asp:Label></b>
                    <div class="col-md-6" style="width: 300px;">
                        <asp:DropDownList ID="ddlUsuarios" runat="server" DataTextField="Surname" DataValueField="Id" AutoPostBack="true" OnSelectedIndexChanged="ddlUsuarios_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="panel panel-primary">
        <div class="panel-heading">
            <span class="panel-title">Editar Datos de Usuario
            </span>
        </div>
        <div class="panel-body">
            <div class="container">
                <div class="row clearfix">
                    <div class="form-group">
                        <b>
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre" for="txtNombre" class="col-sm-2 control-label">      
                            </asp:Label></b>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" class="form-control" ID="txtNombre" placeholder="Nombre"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Ingrese un Nombre" ControlToValidate="txtNombre" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <b>
                            <asp:Label ID="lblApellido" runat="server" Text="Apellido" for="txtApellido" class="col-sm-2 control-label">      
                            </asp:Label></b>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" class="form-control" ID="txtApellido" placeholder="Apellido"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ErrorMessage="Ingrese un Apellido" ControlToValidate="txtApellido" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <b>
                            <asp:Label ID="lblUsuario" runat="server" Text="Usuario" for="txtUsuario" class="col-sm-2 control-label">      
                            </asp:Label></b>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" class="form-control" ID="txtUsuario" placeholder="Usuario" ReadOnly="true"></asp:TextBox>
                        </div>

                        <b>
                            <asp:Label ID="lblDocumento" runat="server" Text="DNI" for="txtDocumento" class="col-sm-2 control-label">      
                            </asp:Label></b>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" class="form-control" ID="txtDocumento" placeholder="Documento" MaxLength="8"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" ErrorMessage="Ingrese DNI" ControlToValidate="txtDocumento" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <b>
                            <asp:Label ID="lblEmail" runat="server" Text="e-Mail" for="txtEmail" class="col-sm-2 control-label">      
                            </asp:Label></b>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" class="form-control" ID="txtEmail" placeholder="e-Mail"></asp:TextBox>
                        </div>
                        <b>
                            <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones" for="txtObservaciones" class="col-sm-2 control-label">      
                            </asp:Label></b>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtObservaciones" class="form-control" Rows="2" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <b>
                            <asp:Label ID="lblProfesional" runat="server" Text="Profesional" for="txtProfesionalVinculado" class="col-sm-2 control-label">      
                            </asp:Label></b>
                        <div class="col-sm-3">
                            <div class="input-group">
                                <input type="text" id="txtProfesional" runat="server" class="form-control">
                                <span class="input-group-btn">
                                    <button id="" class="btn btn-primary launch-modal" type="button"><i class="fa fa-chain"></i></button>
                                </span>
                            </div>
                        </div>

                        <div id="capaTrabajaEnGuardia" runat="server">
                            <b>
                                <asp:Label ID="lblTrabajaENGuardia" runat="server" Text="Trabaja En Guardia" for="option1" class="col-sm-2 control-label">      
                                </asp:Label></b>
                            <div id="capaGuardia" class="col-sm-3" runat="server">
                                <label for="trabajaEnGuardia" class="chkbox">
                                    <input name="trabajaEnGuardia" type="checkbox" data-on-color="info" data-off-color="danger" data-size="mini" data-on-text="SI" data-off-text="NO">
                                </label>
                            </div>
                        </div>

                    </div>

                    <div id="capaHabilitado" runat="server" visible="false" class="form-group">
                        <b>
                            <asp:Label ID="lblhabilitado" runat="server" Text="Habilitado" for="option1" class="col-sm-2 control-label">      
                            </asp:Label></b>
                        <div class="col-sm-3">
                            <label for="habilitado" class="chkbox">
                                <input name="chkHabilitado" type="checkbox" data-on-color="info" data-off-color="danger" data-size="mini" data-on-text="SI" data-off-text="NO">
                            </label>
                        </div>

                        <b>
                            <asp:Label ID="lblBloqueado" runat="server" Text="Desbloqueado" for="option1" class="col-sm-2 control-label">      
                            </asp:Label></b>
                        <div class="col-sm-3">
                            <label for="bloqueado" class="chkbox">
                                <input name="chkBloqueado" type="checkbox" data-on-color="info" data-off-color="danger" data-size="mini" data-on-text="SI" data-off-text="NO">
                            </label>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-4">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-primary" OnClick="btnGuardar_Click" />
                            <asp:Button ID="btnResetClave" runat="server" Text="Reset Clave" class="btn btn-primary" OnClick="btnResetClave_Click" OnClientClick="return aler();" />
                        </div>

                        <div id="alerta" runat="server" class="col-lg-4">
                            <div class="alert alert-dismissable alert-success">
                                <button id="btnAlerta" type="button" class="close" data-dismiss="alert">&times;</button>
                                <strong>El Usuario se actualizó correctamente.</strong>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Modal para vincular profesionales con usuarios  -->
    <div id="profesionalModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Profesionales</h4>
                </div>
                <div class="modal-body center-block">
                    <div class="form-group">
                        <b>
                            <asp:Label ID="lbProfesionales" runat="server" Text="Profesionales" for="ddlProfesional" class="col-sm-4 control-label">
                            </asp:Label></b>
                        <div class="col-sm-7">
                            <asp:DropDownList ID="ddlProfesional" runat="server" DataTextField="Nombre" DataValueField="Codigo"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="btnGuardarProfesionalVinculado" onserverclick="btnGuardarProfesionalVinculado_ServerClick" runat="server" type="button" class="btn btn-primary">Guardar</button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->


    <link href="Content/sweet-alert.css" rel="stylesheet" />
    <script src="Scripts/sweet-alert.js"></script>

    <script>        
        function aler(){            
            swal({
                title: "Clave reseteada!",
                text: "La nueva clave es: 12345"                
            });
        };       
    </script>

    <script>
        $('#<%= ddlProfesional.ClientID %>').select2();  
        $('#<%= ddlUsuarios.ClientID %>').select2();        
    </script>

    <%--<script>
        var idHospital = '<%= IdHospital %>';

        if (idHospital == 0)
            document.getElementById("ctl00_lnkInicio").style.visibility = "hidden";
    </script>--%>

    <script type="text/javascript">       

        $(document).ready(function () {
            $('.launch-modal').click(function () {
                $('#profesionalModal').modal({
                    keyboard: true
                });
            });
        });

        
        $("[name='chkHabilitado']").bootstrapSwitch('state', <%= esusuarioHabilitado(IdUsuario) %>, <%= esusuarioHabilitado(IdUsuario) %>).on('switchChange.bootstrapSwitch', function (event, state) { 
            
            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("EditarUsuario.aspx/habilitarUsuario")%>',                
                data: "{'estado':'" + state + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    //alert("Bien");
                },
                error: function (e) {
                    alert("Error");
                }
            });
        
        });

        $("[name='chkBloqueado']").bootstrapSwitch('state', <%= esusuarioBloqueado(IdUsuario) %>, <%= esusuarioBloqueado(IdUsuario) %>).on('switchChange.bootstrapSwitch', function (event, state) { 
            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("EditarUsuario.aspx/desbloquearUsuario")%>',
                data: "{'estado':'" + state  + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    //alert("Bien");
                },
                error: function (e) {
                    alert("Error");
                }
            });
        });        
    </script>

    <script>
        var idHospital = '<%= IdHospital %>';
        
        if (idHospital != 0) {
            $("[name='trabajaEnGuardia']").bootstrapSwitch('state', <%= trabajaEnGuardia() %>, <%= trabajaEnGuardia() %>).on('switchChange.bootstrapSwitch', function (event, state) {
                
                $.ajax({
                    type: "POST",
                    url: '<%= ResolveUrl("EditarUsuario.aspx/trabajaEnGuardia")%>',
                    data: "{'estado':'" + state + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        //alert("Bien");
                    },
                    error: function (e) {
                        alert("Error");
                    }
                });
            });
        }
    </script>

</asp:Content>
