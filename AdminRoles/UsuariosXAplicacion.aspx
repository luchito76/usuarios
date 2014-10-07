<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuariosXAplicacion.aspx.cs" Inherits="AdminRoles.UsuariosXAplicacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


</head>
<body>
    <form id="form1" class="form-horizontal" runat="server">
        <div class="container">
            <div class="row clearfix">
                <div class="col-md-12 column">
                    <table id="tblUsuariosXAplicacion" data-toggle="table" data-pagination="true" data-search="true" data-page-size="10" data-page-list="[10, 10, 20, 50, 100, 200]">
                        <thead>
                            <tr>
                                <th data-field="idUsuario" data-align="center" data-sortable="true">ID</th>
                                <th data-field="Nombre" data-align="left" data-sortable="true">Nombre</th>
                                <th data-field="Apellido" data-align="left" data-sortable="true">Apellido</th>
                                <th data-field="Usuario" data-align="left" data-sortable="true">Usuario</th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>
        </div>
    </form>

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-table.css" rel="stylesheet" />

    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap-table.js"></script>

    <script>
        $table = $('#tblUsuariosXAplicacion').bootstrapTable({            
            data: <%= devuelveUsuariosXAplicacionJson() %>
            });
    </script>
</body>
</html>
