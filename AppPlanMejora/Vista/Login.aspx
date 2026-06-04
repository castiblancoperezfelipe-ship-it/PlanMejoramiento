<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AppPlanMejora.Vista.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>SENA - Sistema de Gestión de Planes de Mejoramiento</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f4f6f9;
        }
        .login-container {
            max-width: 450px;
            margin-top: 100px;
        }
        .btn-sena {
            background-color: #39A900; /* Verde institucional SENA */
            color: white;
        }
        .btn-sena:hover {
            background-color: #2e8600;
            color: white;
        }
    </style>
</head>
<body>
    <div class="container d-flex justify-content-center">
        <div class="card login-container shadow-sm p-4 bg-white rounded">
            <div class="text-center mb-4">
                <h4 class="fw-bold text-dark">Planes de Mejoramiento</h4>
                <p class="text-muted small">Ingresa tus credenciales institucionales</p>
            </div>

            <form id="form1" runat="server">
                
                <div class="mb-3">
                    <label class="form-label fw-semibold text-secondary">Correo Electrónico</label>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="ejemplo@sena.edu.co"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label class="form-label fw-semibold text-secondary">Contraseña</label>
                    <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password" placeholder="••••••••"></asp:TextBox>
                </div>

                <div class="mb-3 text-center">
                    <asp:Label ID="lblMensajeError" runat="server" CssClass="text-danger fw-bold small"></asp:Label>
                </div>

                <div class="d-grid gap-2 mt-4">
                    <asp:Button ID="btnIngresar" runat="server" CssClass="btn btn-sena fw-bold p-2" Text="Iniciar Sesión" OnClick="btnIngresar_Click" />
                </div>

            </form>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>