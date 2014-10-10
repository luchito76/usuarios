<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modulo.aspx.cs" Inherits="AdminRoles.Modulo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-table.css" rel="stylesheet" />


</head>
<body>
    <form id="form1" class="form-horizontal" runat="server" method="post">

        <div class="panel panel-primary" id="form">
            <div class="panel-heading">
                <h2 class="panel-title">Módulos de </h2>
            </div>
            <br />
            <div class="col-md-12">
                <table id="tblModulos" data-toggle="table" data-pagination="true" data-search="true" data-id-field="id">
                    <thead>
                        <tr>
                            <th data-field="IdModulo" data-align="center" data-sortable="true">ID</th>
                            <th data-field="Descripcion" data-align="left" data-sortable="true">Nombre</th>

                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </form>

    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap-table.js"></script>

    <script>
        $table = $('#tblModulos').bootstrapTable({            
            data: <%= devuelveModulosXAplicacionJson() %>
            });
    </script>
</body>
</html>
