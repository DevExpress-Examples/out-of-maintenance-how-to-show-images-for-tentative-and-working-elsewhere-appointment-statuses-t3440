<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="HorizontalAppointment.ascx.vb" Inherits="CustomStatusSample.AppointmentTemplates.HorizontalAppointment" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v15.2, Version=15.2.20.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.20.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<div id="appointmentDiv" runat="server" class='<%#CType(Container, HorizontalAppointmentTemplateContainer).Items.AppointmentStyle.CssClass%>'>
    <table style="width:100%; height:100%;" <%=DevExpress.Web.Internal.RenderUtils.GetTableSpacings(Me, 0, 0)%>>
        <tr>
            <td runat="server" id="statusContainer" style="vertical-align: top">
                <div id="statusDiv" runat="server" style="height:5px; background-color: white; border-bottom-width:thin; border-bottom-color:lightblue; border-bottom-style:solid">
                    <div id="tentativeStatusDiv" runat="server" style=" background-repeat:repeat-x; height:5px;  position:absolute; top: 1px; border-right: thin solid lightblue; border-left: thin solid lightblue" />
                </div>    
            </td>
        </tr>
        <tr>
            <td>
            <table <%=DevExpress.Web.Internal.RenderUtils.GetTableSpacings(Me, 0, 0)%>  style="width:100%; border-collapse:separate; padding-bottom:2px; padding-top:2px; padding-left:1px; padding-right:1px;">
                <tr class="dx-al" <%=DevExpress.Web.Internal.RenderUtils.GetAlignAttributes(Me, "left", "middle")%> style="vertical-align: middle;">
                    <td>
                        <asp:Image runat="server" ID="imgStartContinueArrow" Visible='<%#CType(Container, HorizontalAppointmentTemplateContainer).Items.StartContinueArrow.Visible%>'></asp:Image>
                    </td>
                    <td>
                        <dx:ASPxLabel runat="server" EnableViewState="false" EncodeHtml="true" ID="lblStartContinueText" Text='<%#CType(Container, HorizontalAppointmentTemplateContainer).Items.StartContinueText.Text%>' Visible='<%#CType(Container, HorizontalAppointmentTemplateContainer).Items.StartContinueText.Visible%>'> </dx:ASPxLabel>
                    </td>
                    <td runat="server" id="startTimeClockContainer"> </td>
                    <td>
                       <dx:ASPxLabel runat="server" EnableViewState="false" EncodeHtml="true" ID="lblStartTime" Text='<%#CType(Container, HorizontalAppointmentTemplateContainer).Items.StartTimeText.Text%>' Visible='<%#CType(Container, HorizontalAppointmentTemplateContainer).Items.StartTimeText.Visible%>' ></dx:ASPxLabel>
                    </td>
                    <td class="dx-ac" <%=DevExpress.Web.Internal.RenderUtils.GetAlignAttributes(Me, "center", Nothing)%> style="width: 100%;">
                        <table <%=DevExpress.Web.Internal.RenderUtils.GetTableSpacings(Me, 1, 1)%> style="border-collapse:separate; border-spacing: 1px; vertical-align: middle;">
                            <tr>
                                <td class="dxscCellWithPadding">
                                    <table id="imageContainer" runat="server" style="vertical-align: middle;">                                    
                                    </table>
                                </td>
                                <td class="dx-ac dxscCellWithPadding" <%=DevExpress.Web.Internal.RenderUtils.GetAlignAttributes(Me, "center", Nothing)%>>                            
                                     <dx:ASPxLabel runat="server" EnableViewState="false" EncodeHtml="true" ID="lblTitle" Text='<%#CType(Container, HorizontalAppointmentTemplateContainer).Items.Title.Text%>'></dx:ASPxLabel>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td runat="server" id="endTimeClockContainer"> 
                    </td>
                    <td>
                        <dx:ASPxLabel runat="server" EnableViewState="false" EncodeHtml="true" ID="lblEndTime" Text='<%#CType(Container, HorizontalAppointmentTemplateContainer).Items.EndTimeText.Text%>' Visible='<%#CType(Container, HorizontalAppointmentTemplateContainer).Items.EndTimeText.Visible%>' ></dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxLabel runat="server" EnableViewState="false" EncodeHtml="true" ID="lblEndContinueText" Text='<%#CType(Container, HorizontalAppointmentTemplateContainer).Items.EndContinueText.Text%>' Visible='<%#CType(Container, HorizontalAppointmentTemplateContainer).Items.EndContinueText.Visible%>'></dx:ASPxLabel>
                    </td>
                    <td>
                        <asp:Image runat="server" ID="imgEndContinueArrow" Visible='<%#CType(Container, HorizontalAppointmentTemplateContainer).Items.EndContinueArrow.Visible%>'></asp:Image>
                    </td>
                </tr>
            </table>
            </td>
        </tr>
    </table>
</div>