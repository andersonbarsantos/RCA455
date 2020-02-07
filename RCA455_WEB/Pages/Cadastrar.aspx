<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Cadastrar.aspx.cs" Inherits="RCA455_WEB.Pages.Cadastrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cadastrar Domínios</title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitulo" runat="server">
    <div class="col-md-4"></div>
    <div class="col-md-4">
        <h5>Cadastrar Domínios</h5>
    </div>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPrincipal" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4">
                <div class="card" style="min-height: 200px">
                    <div class="card-body">
                        <nav>
                            <div class="nav nav-tabs nav-pills nav-justified nav-fill flex-column flex-sm-row" id="nav-tab" role="tablist">
                                <a class="nav-item nav-link flex-sm-fill text-sm-center" id="nav-responsavel-tab" data-toggle="tab" href="#nav-responsavel" role="tab" aria-controls="nav-responsavel" aria-selected="true">Responsável</a>
                                <a class="nav-item nav-link flex-sm-fill text-sm-center" id="nav-sistema-tab" data-toggle="tab" href="#nav-sistema" role="tab" aria-controls="nav-sistema" aria-selected="false">Sistema</a>
                                <a class="nav-item nav-link flex-sm-fill text-sm-center" id="nav-situacao-tab" data-toggle="tab" href="#nav-situacao" role="tab" aria-controls="nav-situacao" aria-selected="false">Situação</a>
                                <a class="nav-item nav-link flex-sm-fill text-sm-center" id="nav-tipo-tab" data-toggle="tab" href="#nav-tipo" role="tab" aria-controls="nav-tipo" aria-selected="false">Tipo</a>
                                <a class="nav-item nav-link flex-sm-fill text-sm-center" id="nav-retorno-tab" data-toggle="tab" href="#nav-retorno" role="tab" aria-controls="nav-retorno" aria-selected="false">Retorno</a>
                            </div>
                        </nav>
                        <!-- Responsável -->

                        <div class="tab-content" id="nav-tabContent">
                            <br />
                            <div class="tab-pane fade show active" id="nav-responsavel" role="tabpanel" aria-labelledby="nav-responsavel-tab">
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">
                                        <label>Responsável: </label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txtResponsavel" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="requiredRespos" runat="server"
                                            ControlToValidate="txtResponsavel"
                                            ErrorMessage="Informar Responsável"
                                            ForeColor="Red" Display="Dynamic"
                                            ValidationGroup="Responsavel" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">
                                        <label>Descrição: </label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txtDescricaoResp" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredDescricaoResp" runat="server"
                                            ControlToValidate="txtDescricaoResp"
                                            ErrorMessage="Informar Descrição"
                                            ForeColor="Red" Display="Dynamic"
                                            ValidationGroup="Responsavel" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-5">
                                        <asp:Label ID="lblMensagemSalvarRes" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10">
                                        <asp:Button ID="btnSalvarResp" runat="server" CssClass="btn btn-outline-success btn-sm" Text="Salvar"
                                            OnClick="btnSalvarResp_Click" ValidationGroup="Responsavel" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:GridView ID="gridConsultaResp" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="false"
                                            AllowPaging="true" EnableModelValidation="true" 
                                            RowStyle-BackColor="White" AlternatingRowStyle-BackColor="#f0f0f0" BorderColor="#dee2e6"
                                            HeaderStyle-Wrap="false" RowStyle-Wrap="false">
                                            <EmptyDataTemplate>Nenhum responsável encontrado </EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkResponavel" runat="server" />
                                                        <asp:Label ID="lblIdResponsavel" runat="server" Text='<%# Eval("IdResponsavel") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Responsável">
                                                    <ItemTemplate><%# Eval("Nome") %> </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Descrição">
                                                    <ItemTemplate><%# Eval("Descricao") %> </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-5">
                                        <asp:Label ID="lblMensagemExcRes" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:Button ID="btnExcluirResp" runat="server" CssClass="btn btn-outline-secondary btn-sm" Text="Excluir" OnClick="ConfirmaApagar_Click"  ValidationGroup="Responsavel" />
                                    </div>
                                </div>
                                <br />
                            </div>
                            <!-- Sistema -->
                            <div class="tab-pane fade" id="nav-sistema" role="tabpanel" aria-labelledby="nav-sistema-tab">
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-3">
                                        <label>Sistema: </label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txtSistema" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredSistema" runat="server"
                                            ControlToValidate="txtSistema"
                                            ErrorMessage="Informar Sistema"
                                            ForeColor="Red" Display="Dynamic"
                                            ValidationGroup="Sistema" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-3">
                                        <label>Descrição: </label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txtDescricaoSist" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredDescricaoSist" runat="server"
                                            ControlToValidate="txtDescricaoSist"
                                            ErrorMessage="Informar Descrição"
                                            ForeColor="Red" Display="Dynamic"
                                            ValidationGroup="Sistema" />                                    
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-5">
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10">
                                        <asp:Button ID="btnSalvarSist" runat="server" CssClass="btn btn-outline-success btn-sm" Text="Salvar"
                                            OnClick="btnSalvarSist_Click" ValidationGroup="Sistema" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:GridView ID="gridSistema" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="false"
                                            AllowPaging="true" EnableModelValidation="true" OnPageIndexChanging="gridSistema_PageIndexChanging"
                                            RowStyle-BackColor="White" AlternatingRowStyle-BackColor="#f0f0f0" BorderColor="#dee2e6"
                                            HeaderStyle-Wrap="false" RowStyle-Wrap="false">
                                            <EmptyDataTemplate>Nenhum sistema encontrado </EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSistema" runat="server" />
                                                        <asp:Label ID="lblIdSistema" runat="server" Text='<%# Eval("IdSistema") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sistema">
                                                    <ItemTemplate><%# Eval("Nome") %> </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Descrição">
                                                    <ItemTemplate><%# Eval("Descricao") %> </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-5">
                                        <asp:Label ID="Label5" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:Button ID="btnExcluirSist" runat="server" CssClass="btn btn-outline-secondary btn-sm" Text="Excluir" OnClick="btnExcluirSist_Click" />
                                        <asp:Button ID="btnAtualizarSist" runat="server" CssClass="btn btn-outline-info btn-sm" Text="Atualizar" OnClick="btnAtualizarSist_Click" ValidationGroup="Sistema" />
                                    </div>
                                </div>
                                <br />
                            </div>
                            <!-- Situação -->
                            <div class="tab-pane fade" id="nav-situacao" role="tabpanel" aria-labelledby="nav-situacao-tab">
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-3">
                                        <label>Situação: </label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txtSituacao" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredSituacao" runat="server"
                                            ControlToValidate="txtSituacao"
                                            ErrorMessage="Informar Situação"
                                            ForeColor="Red" Display="Dynamic"
                                            ValidationGroup="Situacao" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-3">
                                        <label>Descrição: </label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txtDescricaoSitu" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredDescricaoSitu" runat="server"
                                            ControlToValidate="txtDescricaoSitu"
                                            ErrorMessage="Informar Descrição"
                                            ForeColor="Red" Display="Dynamic"
                                            ValidationGroup="Situacao" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-5">
                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10">
                                        <asp:Button ID="btnSalvarSitu" runat="server" CssClass="btn btn-outline-success btn-sm" Text="Salvar"
                                            OnClick="btnSalvarSitu_Click" ValidationGroup="Situacao" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:GridView ID="gridSituacao" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="false"
                                            AllowPaging="true" EnableModelValidation="true" OnPageIndexChanging="gridSituacao_PageIndexChanging"
                                            RowStyle-BackColor="White" AlternatingRowStyle-BackColor="#f0f0f0" BorderColor="#dee2e6"
                                            HeaderStyle-Wrap="false" RowStyle-Wrap="false">
                                            <EmptyDataTemplate>Nenhuma situação encontrada </EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSit" runat="server" />
                                                        <asp:Label ID="lblIdSit" runat="server" Text='<%# Eval("IdSituacao") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Situação">
                                                    <ItemTemplate><%# Eval("Nome") %> </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Descrição">
                                                    <ItemTemplate><%# Eval("Descricao") %> </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-5">
                                        <asp:Label ID="Label6" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:Button ID="btnExcluirSitu" runat="server" CssClass="btn btn-outline-secondary btn-sm" Text="Excluir" OnClick="btnExcluirSitu_Click" onclientclick="return confirm('Confirma a exclusão da Situação?');" ValidationGroup="Situacao" />
                                        <asp:Button ID="btnAtualizarSitu" runat="server" CssClass="btn btn-outline-info btn-sm" Text="Atualizar" OnClick="btnAtualizarSitu_Click"  ValidationGroup="Situacao" />
                                    </div>
                                </div>
                                <br />
                            </div>
                            <!-- Tipo -->
                            <div class="tab-pane fade" id="nav-tipo" role="tabpanel" aria-labelledby="nav-tipo-tab">
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-3">
                                        <label>Tipo: </label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredTipo" runat="server"
                                            ControlToValidate="txtTipo"
                                            ErrorMessage="Informar Responsável"
                                            ForeColor="Red" Display="Dynamic"
                                            ValidationGroup="Tipo" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-3">
                                        <label>Descrição: </label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txtDescricaoTipo" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredDescricaoTipo" runat="server"
                                            ControlToValidate="txtDescricaoTipo"
                                            ErrorMessage="Informar Descrição"
                                            ForeColor="Red" Display="Dynamic"
                                            ValidationGroup="Tipo" />                                    
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-5">
                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10">
                                        <asp:Button ID="btnSalvarTipo" runat="server" CssClass="btn btn-outline-success btn-sm" Text="Salvar"
                                            OnClick="btnSalvarTipo_Click" ValidationGroup="Tipo" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:GridView ID="gridTipo" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="false"
                                            AllowPaging="true" EnableModelValidation="true"
                                            RowStyle-BackColor="White" AlternatingRowStyle-BackColor="#f0f0f0" BorderColor="#dee2e6"
                                            HeaderStyle-Wrap="false" RowStyle-Wrap="false">
                                            <EmptyDataTemplate>Nenhum tipo encontrado</EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkTipo" runat="server" />
                                                        <asp:Label ID="lblIdTipo" runat="server" Text='<%# Eval("IdTipo") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tipo">
                                                    <ItemTemplate><%# Eval("Nome") %> </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Descrição">
                                                    <ItemTemplate><%# Eval("Descricao") %> </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-5">
                                        <asp:Label ID="Label7" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:Button ID="btnExcluirTipo" runat="server" CssClass="btn btn-outline-secondary btn-sm" Text="Excluir" OnClick="btnExcluirTipo_Click" onclientclick="return confirm('Confirma a exclusão do Tipo?');"  ValidationGroup="Tipo"  />
                                        <asp:Button ID="btnAtualizarTipo" runat="server" CssClass="btn btn-outline-info btn-sm" Text="Atualizar" OnClick="btnAtualizarTipo_Click" ValidationGroup="Tipo" />
                                    </div>
                                </div>
                                <br />
                            </div>
                            <!-- Retorno -->
                            <div class="tab-pane fade" id="nav-retorno" role="tabpanel" aria-labelledby="nav-retorno-tab">
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-3">
                                        <label>Retorno: </label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txtRetorno" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredRetorno" runat="server"
                                            ControlToValidate="txtRetorno"
                                            ErrorMessage="Informar Retorno"
                                            ForeColor="Red" Display="Dynamic"
                                            ValidationGroup="Retorno" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-3">
                                        <label>Descrição: </label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txtDescricaoRet" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredDescricaoRet" runat="server"
                                            ControlToValidate="txtDescricaoRet"
                                            ErrorMessage="Informar Descrição"
                                            ForeColor="Red" Display="Dynamic"
                                            ValidationGroup="Retorno" />                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-5">
                                        <asp:Label ID="Label4" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10">
                                        <asp:Button ID="btnSalvarRetorno" runat="server" CssClass="btn btn-outline-success btn-sm" Text="Salvar"
                                            OnClick="btnSalvarRetorno_Click" ValidationGroup="Retorno" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:GridView ID="gridRetorno" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="false"
                                            AllowPaging="true" EnableModelValidation="true" OnPageIndexChanging="gridRetorno_PageIndexChanging"
                                            RowStyle-BackColor="White" AlternatingRowStyle-BackColor="#f0f0f0" BorderColor="#dee2e6"
                                            HeaderStyle-Wrap="false" RowStyle-Wrap="false">
                                            <EmptyDataTemplate>Nenhum retorno encontrado</EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkRetorno" runat="server" />
                                                        <asp:Label ID="lblIdRetorno" runat="server" Text='<%# Eval("IdRetorno") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Retorno">
                                                    <ItemTemplate><%# Eval("Nome") %> </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Descrição">
                                                    <ItemTemplate><%# Eval("Descricao") %> </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-5">
                                        <asp:Label ID="Label8" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-11">
                                        <asp:Button ID="btnExcluirRetorno" runat="server" CssClass="btn btn-outline-secondary btn-sm" Text="Excluir" OnClick="btnExcluirRetorno_Click" onclientclick="return confirm('Confirma a exclusão do Retorno?');" ValidationGroup="Retorno"/>
                                        <asp:Button ID="btnAtualizarRetorno" runat="server" CssClass="btn btn-outline-info btn-sm" Text="Atualizar" OnClick="btnAtualizarRetorno_Click" ValidationGroup="Retorno" />
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
