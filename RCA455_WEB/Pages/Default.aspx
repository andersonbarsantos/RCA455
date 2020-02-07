<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RCA455_WEB.Pages.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Página Inicial</title>
    <link href="Layout/css/layout_master.css" rel="stylesheet" />
</asp:Content>




<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitulo" runat="server">
    <div class="col-md-1"></div>
    <div class="col-md-4">
        <h5>Classificações relatório de
        <asp:Label ID="lblDataClassificações" runat="server"></asp:Label></h5>
    </div>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
    <div class="container-fluid">
        <div class="row">            
            <div class="col-md-12">
                <div class="card">
                    <div class="card-body">
                        <div style="overflow-x: auto; width: 100%">
                            <asp:GridView ID="gridClassificacoes" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="false"
                                AllowPaging="true" EnableModelValidation="true" OnPageIndexChanging="gridClassificacoes_PageIndexChanging"
                                RowStyle-BackColor="White" AlternatingRowStyle-BackColor="#f0f0f0" BorderColor="#dee2e6"
                                HeaderStyle-Wrap="false" RowStyle-Wrap="true">
                                <EmptyDataTemplate>Nenhuma classificação encontrada </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Classificação">
                                        <ItemTemplate><%# Eval("Descricao") %> </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantidade">
                                        <ItemTemplate><%# Eval("Quantidade ") %> </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
