<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="CadastrarRegras.aspx.cs" Inherits="RCA455_WEB.Pages.CadastrarRegras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cadastrar Regras</title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitulo" runat="server">
    <div class="col-md-3"></div>
    <div class="col-md-4">
        <h5>Cadastrar Regras</h5>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6">
                <div class="card" style="min-height: 200px; max-height: 1000%">
                    <div class="card-body">
                        <br />
                        <br />
                        <div class="col-md-12">
                            <div class="col-md-1"></div>
                            <div class="col-md-11">
                                <div class="row">
                                    <div class="col-md-2">
                                        <label>Sistema: </label>
                                    </div>
                                    <%--        </div>
        <div class="row">--%>
                                    <div class="col-md-10">
                                        <asp:DropDownList ID="ddlSistema" runat="server" CssClass="form-control form-control-sm">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="requiredSistema" runat="server"
                                            ControlToValidate="ddlSistema"
                                            ErrorMessage="Informar Sistema"
                                            ForeColor="Red" Display="Dynamic"
                                            ValidationGroup="Regra" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-2">
                                        <label>Responsável: </label>
                                    </div>
                                    <%--        </div>
        <div class="row">--%>
                                    <div class="col-md-10">
                                        <asp:DropDownList ID="ddlResponsavel" runat="server" CssClass="form-control form-control-sm">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredResponsavel" runat="server"
                                            ControlToValidate="ddlResponsavel"
                                            ErrorMessage="Informar Responsável"
                                            ForeColor="Red" Display="Dynamic"
                                            ValidationGroup="Regra" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-2">
                                        <label>Situação: </label>
                                    </div>
                                    <%--        </div>
        <div class="row">--%>
                                    <div class="col-md-10">
                                        <asp:DropDownList ID="ddlSituacao" runat="server" CssClass="form-control form-control-sm">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredSituacao" runat="server"
                                            ControlToValidate="ddlSituacao"
                                            ErrorMessage="Informar Situação"
                                            ForeColor="Red" Display="Dynamic"
                                            ValidationGroup="Regra" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-2">
                                        <label>Tipo: </label>
                                    </div>
                                    <%--        </div>
        <div class="row">--%>
                                    <div class="col-md-10">
                                        <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control form-control-sm">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredTipo" runat="server"
                                            ControlToValidate="ddlTipo"
                                            ErrorMessage="Informar Tipo"
                                            ForeColor="Red" Display="Dynamic"
                                            ValidationGroup="Regra" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-2">
                                        <label>Retorno: </label>
                                    </div>
                                    <%--        </div>
        <div class="row">--%>
                                    <div class="col-md-10">
                                        <asp:DropDownList ID="ddlRetorno" runat="server" CssClass="form-control form-control-sm">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredRetorno" runat="server"
                                            ControlToValidate="ddlRetorno"
                                            ErrorMessage="Informar Retorno"
                                            ForeColor="Red" Display="Dynamic"
                                            ValidationGroup="Regra" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-2">
                                        <label>Descrição: </label>
                                    </div>
                                    <%--        </div>
        <div class="row">--%>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredDescricao" runat="server"
                                            ControlToValidate="txtDescricao"
                                            ErrorMessage="Informar Descrição"
                                            ForeColor="Red" Display="Dynamic"
                                            ValidationGroup="Regra" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-2">
                                        <label visible="false"></label>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:CheckBox ID="checkRegra" runat="server" CssClass="form-check form-check-inline form-check-label" />
                                    </div>
                                    <div class="col-md-2">
                                        <label>Ativo</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-5">
                                        <asp:Label ID="lblMensagemSalvar" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Button ID="btnSalvar" runat="server" CssClass="btn btn-outline-info btn-sm" Text="Salvar"
                                            OnClick="btnSalvar_Click" ValidationGroup="Regra" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <%--<div class="col-md-1"></div>--%>
                                    <div style="overflow-x: auto; width: 100%;">
                                        <div class="col-md-12">
                                            <asp:GridView ID="gridRegras" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="false"
                                                AllowPaging="true" EnableModelValidation="true" OnPageIndexChanging="gridRegras_PageIndexChanging"
                                                RowStyle-BackColor="White" AlternatingRowStyle-BackColor="#f0f0f0" BorderColor="#dee2e6"
                                                HeaderStyle-Wrap="false" RowStyle-Wrap="true">
                                                <EmptyDataTemplate>Nenhuma regra encontrada </EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkRegra" runat="server" />
                                                            <asp:Label ID="lblIdRegra" runat="server" Text='<%# Eval("Id_regra") %>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sistema">
                                                        <ItemTemplate><%# Eval("Sistema.Nome") %> </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Responsável">
                                                        <ItemTemplate><%# Eval("Responsavel.Nome") %> </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Situação">
                                                        <ItemTemplate><%# Eval("Situacao.Nome") %> </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tipo">
                                                        <ItemTemplate><%# Eval("Tipo.Nome") %> </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Retorno">
                                                        <ItemTemplate><%# Eval("Retorno.Nome") %> </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Ativo">
                                                        <ItemTemplate><%# Eval("Ativo") %> </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Descrição" ItemStyle-Wrap="true">
                                                        <ItemTemplate><%# Eval("Descricao") %> </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-5">
                                        <asp:Label ID="lblMensagemExcl" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-5">
                                        <asp:Button ID="btnExcluir" runat="server" CssClass="btn btn-outline-secondary btn-sm" Text="Excluir" 
                                            OnClick="btnExcluir_Click" />
                                    </div>
                                    <div class="col-md-7">
                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
