﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modulos.aspx.cs" Inherits="AdminRoles.Modulo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-table.css" rel="stylesheet" />
    <link href="Content/bootstrap-switch.css" rel="stylesheet" />
    <link href="Content/font-awesome/font-awesome.css" rel="stylesheet" />

</head>
<body>

    <form id="form1" class="form-horizontal" runat="server">
        <asp:ScriptManager ID="myScriptManager" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <div class="panel panel-primary" id="form">
            <div class="panel-heading">
                <h2 class="panel-title">Módulos de <%= devuelveNombreAplicacion() %> </h2>
            </div>
            <br />
            <div class="col-md-12">
                <table id="tblModulos" data-toggle="table" data-pagination="true" data-search="true" data-id-field="id">
                    <thead>
                        <tr>
                            <th data-field="operate" data-formatter="formatoCheck" data-events="eventosCheck" data-align="center">App</th>
                            <th data-field="IdModulo" data-align="center" data-sortable="true">ID</th>
                            <th data-field="Nombre" data-align="left" data-sortable="true">Nombre</th>
                            <th data-field="Descripcion" data-align="left" data-sortable="true">Descripcion</th>
                            <th data-field="Habilitado" data-align="left" data-sortable="true">Habilitado</th>
                        </tr>
                    </thead>
                </table>
                <div class="form-group">
                    <div class="col-sm-2">
                        <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" OnClientClick="cerrarVentana();" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap-table.js"></script>
    <script src="Scripts/bootstrap-switch.js"></script>

    <script>
        function cerrarVentana() {
            window.close();
        }

        function formatoCheck(value, row, index) {

            jQuery(document).ready(function() {             
                var habilitado = row.Habilitado;                    

                $("[name='" + row.IdModulo + "']").bootstrapSwitch('onText', '<i class="fa fa-power-off"></i>');  
                $("[name='" + row.IdModulo + "']").bootstrapSwitch('offText', '<i class="fa fa-power-off"></i>'); 

                if (habilitado == false) {                    
                    $("[name='" + row.IdModulo + "']").bootstrapSwitch('state', false, false);                      
                } else if (habilitado == true) {                    
                    $("[name='" + row.IdModulo + "']").bootstrapSwitch('state', true, true);                       
                }                
            });  
            return [
            
                '<a class="habilitar" href="javascript:void(0)" title="Habilitar">',
                    '<input name="' + row.IdModulo + '" checked="' + row.Habilitado +'" type="checkbox" data-on-color="info" data-off-color="danger" data-size="mini"  > ',
                '</a>'               
            ].join('');
        }

        window.eventosCheck = {            
            'click .habilitar': function (e, value, row, index) {                   
                $.ajax({
                    type: "POST",
                    url: '<%= ResolveUrl("Modulos.aspx/guardarModulos")%>' ,
                    data: "{'habilitados':'" + row.IdModulo + "'}",                    
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {                            
                        //window.location = window.location.href;                        
                    },
                    error: function (e) {                        
                        
                    }
                });                  
            }
        };       
    </script>

    <script>
            $table = $('#tblModulos').bootstrapTable({            
            data: <%= devuelveModulosXAplicacionJson() %>           
                });               
    </script>

</body>
</html>