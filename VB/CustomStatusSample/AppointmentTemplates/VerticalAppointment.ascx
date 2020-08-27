<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="VerticalAppointment.ascx.vb" Inherits="CustomStatusSample.AppointmentTemplates.VerticalAppointment" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v15.2, Version=15.2.20.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.20.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<div id="appointmentDiv" runat="server" class='<%#CType(Container, VerticalAppointmentTemplateContainer).Items.AppointmentStyle.CssClass%>'>
    <table <%=DevExpress.Web.Internal.RenderUtils.GetTableSpacings(Me, 0, 0)%> style="width: 100%">
        <tr <%=DevExpress.Web.Internal.RenderUtils.GetAlignAttributes(Me, Nothing, "top")%> style="vertical-align: top">
            <td runat="server" id="statusContainer">
                <div id="statusDiv" runat="server" style="width: 5px; background-color: white; border-right-width: thin; border-right-color: lightblue; border-right-style: solid">
                    <div id="tentativeStatusDiv" runat="server" style="background-repeat: repeat-y; width: 5px; position: absolute; left: 1px" />
                </div>
            </td>
            <td style="width: 100%">
                <table <%=DevExpress.Web.Internal.RenderUtils.GetTableSpacings(Me, 1, 0)%> style="width: 100%">
                    <tr <%=DevExpress.Web.Internal.RenderUtils.GetAlignAttributes(Me, Nothing, "top")%> style="vertical-align: top">
                        <td class="dxscCellWithPadding">
                            <table id="imageContainer" runat="server" style="text-align: center">
                                <tr>
                                    <td class="dxscCellWithPadding"></td>
                                </tr>
                            </table>
                        </td>
                        <td class="dxscCellWithPadding" style="width: 100%">
                            <table <%=DevExpress.Web.Internal.RenderUtils.GetTableSpacings(Me, 1, 0)%> style="width: 100%">
                                <tr>
                                    <td class="dxscCellWithPadding">
                                        <dx:ASPxLabel runat="server" EnableViewState="false" EncodeHtml="true" ID="lblStartTime" Text='<%#CType(Container, VerticalAppointmentTemplateContainer).Items.StartTimeText.Text%>' Visible='<%#CType(Container, VerticalAppointmentTemplateContainer).Items.StartTimeText.Visible%>'></dx:ASPxLabel>
                                        <dx:ASPxLabel runat="server" EnableViewState="false" EncodeHtml="true" ID="lblEndTime" Text='<%#CType(Container, VerticalAppointmentTemplateContainer).Items.EndTimeText.Text%>' Visible='<%#CType(Container, VerticalAppointmentTemplateContainer).Items.EndTimeText.Visible%>'></dx:ASPxLabel>
                                        <dx:ASPxLabel runat="server" EnableViewState="false" EncodeHtml="true" ID="lblTitle" Text='<%#CType(Container, VerticalAppointmentTemplateContainer).Items.Title.Text%>'></dx:ASPxLabel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="dxscCellWithPadding">
                                        <div runat="server" id="horizontalSeparator" class='<%#CType(Container, VerticalAppointmentTemplateContainer).Items.HorizontalSeparator.Style.CssClass%>' visible='<%#CType(Container, VerticalAppointmentTemplateContainer).Items.HorizontalSeparator.Visible%>'></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="dxscCellWithPadding">
                                        <dx:ASPxLabel runat="server" EnableViewState="false" EncodeHtml="true" ID="lblDescription" Text='<%#CType(Container, VerticalAppointmentTemplateContainer).Items.Description.Text%>'></dx:ASPxLabel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>