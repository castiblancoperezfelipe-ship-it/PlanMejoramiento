<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ficha.aspx.cs" Inherits="AppPlanMejora.Vista.Ficha" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>SENA - Gestión de Fichas</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="fw-bold text-dark mb-4">Gestión de Fichas de Formación</h2>
            
            <asp:Label ID="lblMensaje" runat="server" CssClass="d-block mb-3 fw-bold"></asp:Label>

            <div class="row">
                <div class="col-md-4">
                    <div class="card p-3 shadow-sm bg-white">
                        <h5 class="fw-bold text-success mb-3">Nueva Ficha</h5>
                        
                        <div class="mb-2">
                            <label class="form-label small fw-bold">Número de Ficha</label>
                            <asp:TextBox ID="txtNumeroFicha" runat="server" CssClass="form-control form-control-sm" placeholder="Ej: 2503412"></asp:TextBox>
                        </div>

                        <div class="mb-2">
                            <label class="form-label small fw-bold">Programa de Formación</label>
                            <asp:DropDownList ID="ddlProgramas" runat="server" CssClass="form-select form-select-sm"></asp:DropDownList>
                        </div>

                        <div class="mb-2">
                            <label class="form-label small fw-bold">Jornada</label>
                            <asp:DropDownList ID="ddlJornada" runat="server" CssClass="form-select form-select-sm">
                                <asp:ListItem Text="Diurna" Value="Diurna"></asp:ListItem>
                                <asp:ListItem Text="Nocturna" Value="Nocturna"></asp:ListItem>
                                <asp:ListItem Text="Mixta" Value="Mixta"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="mb-2">
                            <label class="form-label small fw-bold">Fecha Inicio</label>
                            <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control form-control-sm" TextMode="Date"></asp:TextBox>
                        </div>

                        <div class="mb-2">
                            <label class="form-label small fw-bold">Fecha Finalización</label>
                            <asp:TextBox ID="txtFechaFin" runat="server" CssClass="form-control form-control-sm" TextMode="Date"></asp:TextBox>
                        </div>

                        <div class="mb-2">
                            <label class="form-label small fw-bold">Descripción / Observaciones</label>
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label class="form-label small fw-bold">Estado</label>
                            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select form-select-sm">
                                <asp:ListItem Text="Lectiva" Value="Lectiva"></asp:ListItem>
                                <asp:ListItem Text="Productiva" Value="Productiva"></asp:ListItem>
                                <asp:ListItem Text="Finalizada" Value="Finalizada"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success w-100 fw-bold" Text="Guardar Ficha" OnClick="btnGuardar_Click" />
                    </div>
                </div>

                <div class="col-md-8">
                    <div class="card p-3 shadow-sm bg-white">
                        <h5 class="fw-bold text-secondary mb-3">Fichas Registradas</h5>
                        <asp:GridView ID="gvFichas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover small">
                            <Columns>
                                <asp:BoundField DataField="NumeroFicha" HeaderText="Ficha" />
                                <asp:BoundField DataField="IdPrograma" HeaderText="ID Prog" />
                                <asp:BoundField DataField="Jornada" HeaderText="Jornada" />
                                <asp:BoundField DataField="FechaInicio" HeaderText="Inicio" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="FechaFinalizacion" HeaderText="Fin" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>