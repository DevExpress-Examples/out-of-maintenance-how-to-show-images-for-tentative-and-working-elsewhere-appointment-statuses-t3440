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
    Partial Public Class HorizontalAppointment
        Inherits System.Web.UI.UserControl

        Private ReadOnly Property Container() As HorizontalAppointmentTemplateContainer
            Get
                Return CType(Parent, HorizontalAppointmentTemplateContainer)
            End Get
        End Property
        Private ReadOnly Property Items() As HorizontalAppointmentTemplateItems
            Get
                Return Container.Items
            End Get
        End Property
        Protected Overrides Sub OnLoad(ByVal e As EventArgs)

            MyBase.OnLoad(e)
            appointmentDiv.Style.Value = Items.AppointmentStyle.GetStyleAttributes(Page).Value

            lblTitle.ControlStyle.MergeWith(Items.Title.Style)
            lblStartContinueText.ControlStyle.MergeWith(Items.StartContinueText.Style)
            lblEndContinueText.ControlStyle.MergeWith(Items.EndContinueText.Style)

            PrepareContainers()
            LayoutAppointmentImages()
            Dim type As AppointmentStatusType = Container.AppointmentViewInfo.Status.Type
            If type = AppointmentStatusType.Tentative OrElse type = AppointmentStatusType.WorkingElsewhere Then
                SetStatusImage()
            Else
                statusDiv.Visible = False
                statusContainer.Controls.Add(Items.StatusControl)
            End If
            startTimeClockContainer.Controls.Add(Items.StartTimeClock)
            endTimeClockContainer.Controls.Add(Items.EndTimeClock)
        End Sub
        Private Sub SetStatusImage()
            If Container.AppointmentViewInfo.StatusDisplayType = AppointmentStatusDisplayType.Never Then
                statusDiv.Visible = False
            Else
                statusDiv.Visible = True
                tentativeStatusDiv.Style.Remove("background-image")
                tentativeStatusDiv.Style.Remove("width")
                tentativeStatusDiv.Style.Remove("left")
                If Container.AppointmentViewInfo.Status.Type = AppointmentStatusType.Tentative Then
                    tentativeStatusDiv.Style.Add("background-image", "url('Images/TentativeStatusRotated.png')")
                End If
                If Container.AppointmentViewInfo.Status.Type = AppointmentStatusType.WorkingElsewhere Then
                    tentativeStatusDiv.Style.Add("background-image", "url('Images/WorkingElseWhereStatusRotated.png')")
                End If
                If Container.AppointmentViewInfo.StatusDisplayType = AppointmentStatusDisplayType.Bounds Then
                    tentativeStatusDiv.Style.Add("width", "98%")
                    tentativeStatusDiv.Style.Add("left", "1px")

                Else
                    Dim width As Integer = Convert.ToInt32(Container.AppointmentViewInfo.Appointment.Duration.TotalSeconds / Container.AppointmentViewInfo.Interval.Duration.TotalSeconds * 100)
                    Dim fromStart As TimeSpan = Container.AppointmentViewInfo.Appointment.Start.Subtract(Container.AppointmentViewInfo.Interval.Start)
                    Dim left As Integer = Convert.ToInt32(fromStart.TotalSeconds / Container.AppointmentViewInfo.Interval.Duration.TotalSeconds * 100)
                    tentativeStatusDiv.Style.Add("width", width & "%")
                    tentativeStatusDiv.Style.Add("left", left & "%")
                End If
            End If
        End Sub
        Private Sub PrepareContainers()
            RenderUtils.SetTableSpacings(imageContainer, 0, 0)
            RenderUtils.SetAlignAttributes(statusContainer, Nothing, "top")
        End Sub
        Private Sub LayoutAppointmentImages()
            Dim count As Integer = Items.Images.Count
            Dim row As New HtmlTableRow()
            row.Cells.Add(New HtmlTableCell())
            For i As Integer = 0 To count - 1
                Dim cell As New HtmlTableCell()
                AddImage(cell, Items.Images(i))
                row.Cells.Add(cell)
            Next i
            imageContainer.Rows.Add(row)

            Items.StartContinueArrow.ImageProperties.AssignToControl(imgStartContinueArrow, False)
            Items.EndContinueArrow.ImageProperties.AssignToControl(imgEndContinueArrow, False)
        End Sub
        Private Sub AddImage(ByVal targetCell As HtmlTableCell, ByVal imageItem As AppointmentImageItem)
            Dim image As New Image()
            imageItem.ImageProperties.AssignToControl(image, False)
            SchedulerWebEventHelper.AddOnDragStartEvent(image, ASPxSchedulerScripts.GetPreventOnDragStart())
            targetCell.Controls.Add(image)
        End Sub
    End Class
End Namespace