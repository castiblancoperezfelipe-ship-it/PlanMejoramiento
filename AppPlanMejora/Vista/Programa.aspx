<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Programa.aspx.cs" Inherits="AppPlanMejora.Vista.Programa" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>SENA - Gestión de Programas</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="fw-bold text-dark mb-4">Gestión de Programas de Formación</h2>
            
            <asp:Label ID="lblMensaje" runat="server" CssClass="d-block mb-3 fw-bold"></asp:Label>

            <div class="row">
                <div class="col-md-4">
                    <div class="card p-3 shadow-sm bg-white">
                        <asp:HiddenField ID="hfIdPrograma" runat="server" />
                        
                        <div class="mb-2">
                            <label class="form-label small fw-bold">Código del Programa</label>
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                        <div class="mb-2">
                            <label class="form-label small fw-bold">Nombre del Programa</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                        <div class="mb-2">
                            <label class="form-label small fw-bold">Versión</label>
                            <asp:TextBox ID="txtVersion" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                        </div>
                        <div class="mb-2">
                            <label class="form-label small fw-bold">Nivel de Formación</label>
                            <asp:DropDownList ID="ddlNivel" runat="server" CssClass="form-select form-select-sm">
                                <asp:ListItem Text="Tecnólogo" Value="Tecnologo"></asp:ListItem>
                                <asp:ListItem Text="Técnico" Value="Tecnico"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="mb-2">
                            <label class="form-label small fw-bold">Duración (Meses)</label>
                            <asp:TextBox ID="txtDuracion" runat="server" CssClass="form-control form-control-sm" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label class="form-label small fw-bold">Estado</label>
                            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select form-select-sm">
                                <asp:ListItem Text="Activo" Value="Activo"></asp:ListItem>
                                <asp:ListItem Text="Inactivo" Value="Inactivo"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success w-100 fw-bold" Text="Guardar Programa" OnClick="btnGuardar_Click" />
                    </div>
                </div>

                <div class="col-md-8">
                    <div class="card p-3 shadow-sm bg-white">
                        <asp:GridView ID="gvProgramas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover small" DataKeyNames="Id" OnRowCommand="gvProgramas_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="CodigoPrograma" HeaderText="Código" />
                                <asp:BoundField DataField="NombrePrograma" HeaderText="Programa" />
                                <asp:BoundField DataField="Version" HeaderText="Versión" />
                                <asp:BoundField DataField="NivelFormacion" HeaderText="Nivel" />
                                <asp:BoundField DataField="Duracion" HeaderText="Meses" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning btn-sm py-0 text-dark">Editar</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>