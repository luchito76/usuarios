<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EfectoresXPerfil.aspx.cs" Inherits="AdminRoles.EfectoresXPerfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-table.css" rel="stylesheet" />
    <link href="Content/font-awesome/font-awesome.css" rel="stylesheet" />
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
                            <th data-field="IdModulo" data-align="center" data-sortable="true">ID</th>
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

    <script>
        function cerrarVentana() {
            window.close();            
        }
    </script>

    <script>
        $table = $('#tblEfectores').bootstrapTable({            
            data: <%= devuelveEfectores() %>           
            });               
    </script>

</body>
</html>
