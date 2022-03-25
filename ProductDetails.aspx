<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="ProductDetails.aspx.cs" Inherits="vxdlite.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="productDetail" runat="server" ItemType="vxdlite.Models.Produto" SelectMethod ="GetProduct" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.ProdutoNome %></h1>
            </div>
            <br />
            <table style="min-height:700px;display:flex;align-items:center;font-size:30px;justify-content:space-between;text-align:left;">
                <tr>
                    <td>
                        <img src="/Imagens/Produtos/<%#:Item.ImagemPath %>" style="border-radius:25px; height:300px" alt="<%#:Item.ProdutoNome %>"/>
                    </td>
                    <td>&nbsp;</td>  
                    <td style="vertical-align: top; text-align:left;">
                        <b>Descrição:</b><br /><%#:Item.Descricao %>
                        <br />
                        <span><b>Preço:</b>&nbsp;<%#: String.Format("{0:c}", Item.PrecoUnitario) %></span>
                        <br />
                        <span id="hello"><b>ID:</b>&nbsp;<%#:Item.ProdutoID %></span>
                        <br />
                        <span><b>Em estoque:</b>&nbsp;<%#:Item.Estoque %></span>
                        <br />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>

    <section style="padding:20px;margin:15px;background-color:black;border-radius:25px;">
        <div>
            <hgroup>
                <h2>Comentários</h2>
            </hgroup>

                <asp:Label ID="Label1" runat="server" Text="Adicione um comentário"></asp:Label>
            <br />
        <asp:TextBox ID="avaliacaocomment" runat="server" TextMode="MultiLine" Height="300" Width="700" style="border-radius:15px;padding:15px;"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Avalie o produto"></asp:Label>
            <br />
        <asp:TextBox TextMode=Number ID="avaliacaostar" runat="server" style="border-radius:15px;"></asp:TextBox>
            <br />
            <br />
     <asp:Button ID="btnadd" runat="server" Text="Adicionar" style="margin-bottom:20px;" OnClick="btnadd_Click" />

            <asp:ListView ID="commentList" runat="server" 
                DataKeyNames="ProdutoID" GroupItemCount="1"
                ItemType="vxdlite.Models.ProdutoComment" SelectMethod="GetComment">
                <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td style="border: 2px solid gray;border-radius:10px;padding:15px;min-width:1100px;">
                                        <b style="color:lightblue;">
                                            Usuário Anônimo
                                        </b>
                                    <b style="color:lightblue;float:right;">
                                            <%#:Item.Rating %> estrelas
                                        </b>

                                    <br />
                                        <span><%#:Item.Comments%></span>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>

