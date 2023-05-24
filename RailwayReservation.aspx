<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RailwayReservation.aspx.cs" Inherits="WebApplication2.RailwayReservation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 169px;
        }
        .auto-style3 {
            width: 147px;
        }
        .auto-style4 {
            width: 111px;
        }
        .auto-style5 {
            width: 106px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Button ID="Button1" runat="server" Text="NEW" OnClick="Button1_Click" />
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="Button2" runat="server" Text="SHOW" OnClick="Button2_Click" />
                    </td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;&nbsp;&nbsp;&nbsp; PNR No.&nbsp;</td>
                    <td class="auto-style3">
                        Date Of Journey</td>
                    <td class="auto-style4">
                        From</td>
                    <td class="auto-style5">
                        To</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox2" runat="server"  ReadOnly="True" TextMode="Date" AutoPostBack="True" OnTextChanged="TextBox2_TextChanged" ToolTip="Please select a date after today's date"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="DropDownList1" runat="server" Enabled="False">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="DropDownList2" runat="server" Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" ToolTip="City shoul be different from boarding city">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr >
                    <td class="auto-style2" aria-disabled="False">
                        Name</td>
                    <td class="auto-style3" aria-disabled="False">
                        DOB</td>
                    <td class="auto-style4" aria-disabled="False">
                        Gender</td>
                    <td class="auto-style5" aria-disabled="False">
                        Seat Type</td>
                    <td aria-disabled="False">
                        &nbsp;</td>
                    <td aria-disabled="False">&nbsp;</td>
                    <td aria-disabled="False">&nbsp;</td>
                    <td aria-disabled="False">&nbsp;</td>
                    <td aria-disabled="False">&nbsp;</td>
                    <td aria-disabled="False">&nbsp;</td>
                </tr>
                <tr >
                    <td class="auto-style2" aria-disabled="False">
                        <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style3" aria-disabled="False">
                        <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True" TextMode="Date" AutoPostBack="True" OnTextChanged="TextBox4_TextChanged" ToolTip="Please select a date before today's date"></asp:TextBox>
                    </td>
                    <td class="auto-style4" aria-disabled="False">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Enabled="False">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="auto-style5" aria-disabled="False">
                        <asp:DropDownList ID="DropDownList3" runat="server" Enabled="False">
                            <asp:ListItem>Business Class</asp:ListItem>
                            <asp:ListItem>First AC</asp:ListItem>
                            <asp:ListItem>Second Sitting</asp:ListItem>
                            <asp:ListItem>Third AC</asp:ListItem>
                            <asp:ListItem>Sleeper</asp:ListItem>
                            <asp:ListItem>Extra Luxury</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td aria-disabled="False">
                        <asp:Button ID="Button3" runat="server" Text="SAVE" Enabled="False" OnClick="Button3_Click" />
                    </td>
                    <td aria-disabled="False">&nbsp;</td>
                    <td aria-disabled="False">&nbsp;</td>
                    <td aria-disabled="False">&nbsp;</td>
                    <td aria-disabled="False">&nbsp;</td>
                    <td aria-disabled="False">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    <script>
        function Show() {
            let table = document.getElementById("abc")
            table.style.display = "block";
        }
    </script>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
      <Columns>
               <asp:BoundField HeaderText="ID" DataField="Id" ReadOnly="true"/>
               <asp:BoundField HeaderText="PNR No." DataField="PNR" ReadOnly="true"/>
               <asp:BoundField HeaderText="Date Of Journey" DataField="DateOfJourney"/>
               <asp:BoundField HeaderText="Boarding City" DataField="Boarding" />
               <asp:BoundField HeaderText="Destination City" DataField="Destination"/>
               <asp:BoundField HeaderText="Passenger Name" DataField="Name" ReadOnly="true"/>
               <asp:BoundField HeaderText="DOB" DataField="DOB"/>
               <asp:BoundField HeaderText="Passenger Gender" DataField="Gender"/>
               <asp:BoundField HeaderText="Seat Type" DataField="SeatType"/>
               <asp:CommandField ShowEditButton="true" ShowDeleteButton="true"/>
      </Columns>
  </asp:GridView>
    </form>
    </body>
</html>
