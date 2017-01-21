<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="dbenson2749ex1a._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>COMC2749 Exercise 1A: Purchase Order</h2>
        <p class="lead">Entity Framework, Bootstrap</p>        
    </div>
    <h3>Purchase Orders</h3>
    <div class="row">
        <div class="col-md-8 form-horizontal">   
               <div class="form-group">
                   <asp:Label ID="Label15" runat="server" Text="" CssClass="control-label col-sm-3" ></asp:Label>
                   <div class="col-sm-9">
                       <asp:Label ID="messageLabel" runat="server" Text="" CssClass="control-label" ></asp:Label> 
                   </div>
               </div>        
               <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Vendor:" CssClass="control-label col-sm-3" ></asp:Label>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="vendorDropDownList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="vendorDropDownList_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label14" runat="server" Text="PO:" CssClass="control-label col-sm-3" ></asp:Label>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="purchaseOrderHeaderDropDownList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="purchaseOrderHeaderDropDownList_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>               
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Revision Number:" CssClass="control-label col-sm-3" ></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="revisionNumberTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="Status:" CssClass="control-label col-sm-3" ></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="statusTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="Employee:" CssClass="control-label col-sm-3" ></asp:Label>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="employeeDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label6" runat="server" Text="Order Date:" CssClass="control-label col-sm-3" ></asp:Label>
                    <div class="col-sm-3">
                        <asp:Calendar ID="orderDateCalendar" runat="server"></asp:Calendar>
                    </div>
                    <asp:Label ID="Label8" runat="server" Text="Ship Date:" CssClass="control-label col-sm-3" ></asp:Label>
                    <div class="col-sm-3">
                        <asp:Calendar ID="shipDateCalendar" runat="server" ></asp:Calendar>
                    </div>
                </div>                      
                 <div class="form-group">
                    <asp:Label ID="Label7" runat="server" Text="Shipping:" CssClass="control-label col-sm-3" ></asp:Label>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="shippingDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div> 
                <div class="form-group">
                    <asp:Label ID="Label9" runat="server" Text="Details:" CssClass="control-label col-sm-3" ></asp:Label>                   
                </div> 
                <div class="form-group">
                    <asp:Label ID="Label10" runat="server" Text="Subtotal:" CssClass="control-label col-sm-3" ></asp:Label>
                    <div class="col-sm-9">
                        <asp:Label ID="subTotalLabel" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label11" runat="server" Text="Tax:" CssClass="control-label col-sm-3" ></asp:Label>
                    <div class="col-sm-9">
                        <asp:Label ID="taxLabel" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </div>
                </div>
                 <div class="form-group">
                    <asp:Label ID="Label12" runat="server" Text="Freight:" CssClass="control-label col-sm-3" ></asp:Label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="freightTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div> 
                <div class="form-group">
                    <asp:Label ID="Label13" runat="server" Text="Total:" CssClass="control-label col-sm-3" ></asp:Label>
                    <div class="col-sm-9">
                        <asp:Label ID="totalLabel" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </div>
                </div> 
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="" CssClass="control-label col-sm-3" ></asp:Label>
                    <div class="col-sm-9">
                        <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="saveButton_Click"  />
                        <asp:Button ID="newButton" runat="server" Text="New" CssClass="btn btn-secondary" OnClick="newButton_Click"  />
                        <asp:Button ID="removeButton" runat="server" Text="Remove" CssClass="btn btn-secondary" OnClick="removeButton_Click"/>
                    </div>
                </div> 
                                                            
        </div>
        <div class="col-md-4">
             <h3>Program Features</h3>
             <ul>
                 <li>Entity Framework</li>
                 <li>Bootstrap</li>
             </ul>     
        </div>       
    </div>

</asp:Content>
