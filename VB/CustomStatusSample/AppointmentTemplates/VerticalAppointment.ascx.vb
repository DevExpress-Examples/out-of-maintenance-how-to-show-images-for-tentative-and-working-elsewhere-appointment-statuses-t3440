Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.Web.ASPxScheduler.Drawing
Imports DevExpress.Web.ASPxScheduler.Internal
Imports DevExpress.Web.Internal
Imports DevExpress.XtraScheduler
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace CustomStatusSample.AppointmentTemplates
    Partial Public Class VerticalAppointment
        Inherits System.Web.UI.UserControl

        Private ReadOnly Property Container() As VerticalAppointmentTemplateContainer
            Get
                Return CType(Parent, VerticalAppointmentTemplateContainer)
            End Get
        End Property
        Private ReadOnly Property Items() As VerticalAppointmentTemplateItems
            Get
                Return Container.Items
            End Get
        End Property

        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            appointmentDiv.Style.Value = Items.AppointmentStyle.GetStyleAttributes(Page).Value
            horizontalSeparator.Style.Value = Items.HorizontalSeparator.Style.GetStyleAttributes(Page).Value

            lblStartTime.ControlStyle.MergeWith(Items.StartTimeText.Style)
            lblEndTime.ControlStyle.MergeWith(Items.EndTimeText.Style)
            lblTitle.ControlStyle.MergeWith(Items.Title.Style)
            lblDescription.ControlStyle.MergeWith(Items.Description.Style)

            PrepareImageContainer()
            Dim type As AppointmentStatusType = Container.AppointmentViewInfo.Status.Type
            If type = AppointmentStatusType.Tentative OrElse type = AppointmentStatusType.WorkingElsewhere Then
                SetStatusImage()
            Else
                statusDiv.Visible = False
                statusContainer.Controls.Add(Items.StatusControl)
            End If
            LayoutAppointmentImages()
        End Sub
        Private Sub SetStatusImage()
            If Container.AppointmentViewInfo.StatusDisplayType = AppointmentStatusDisplayType.Never Then
                statusDiv.Visible = False
            Else
                statusDiv.Visible = True
                tentativeStatusDiv.Style.Remove("background-image")
                tentativeStatusDiv.Style.Remove("height")
                tentativeStatusDiv.Style.Remove("top")
                If Container.AppointmentViewInfo.Status.Type = AppointmentStatusType.Tentative Then
                    tentativeStatusDiv.Style.Add("background-image", "url('Images/TentativeStatus.png')")
                End If
                If Container.AppointmentViewInfo.Status.Type = AppointmentStatusType.WorkingElsewhere Then
                    tentativeStatusDiv.Style.Add("background-image", "url('Images/WorkingElseWhereStatus.png')")
                End If
                tentativeStatusDiv.Style.Add("height", "98%")
                tentativeStatusDiv.Style.Add("top", "1px")
            End If
        End Sub
        Private Sub PrepareImageContainer()
            RenderUtils.SetTableSpacings(imageContainer, 1, 0)
        End Sub
        Private Sub PrepareImageCell(ByVal targetCell As HtmlTableCell)
            targetCell.Attributes.Add("class", "dxscCellWithPadding")
        End Sub
        Private Sub LayoutAppointmentImages()
            Dim count As Integer = Items.Images.Count
            For i As Integer = 0 To count - 1
                Dim row As New HtmlTableRow()
                Dim cell As New HtmlTableCell()
                PrepareImageCell(cell)
                AddImage(cell, Items.Images(i))
                row.Cells.Add(cell)
                imageContainer.Rows.Add(row)
            Next i
        End Sub
        Private Sub AddImage(ByVal targetCell As HtmlTableCell, ByVal imageItem As AppointmentImageItem)
            Dim image As New Image()
            imageItem.ImageProperties.AssignToControl(image, False)
            SchedulerWebEventHelper.AddOnDragStartEvent(image, ASPxSchedulerScripts.GetPreventOnDragStart())
            targetCell.Controls.Add(image)
        End Sub
    End Class
End Namespace