Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.XtraScheduler
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace CustomStatusSample
    Partial Public Class [Default]
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            ApplyStatusOption()
        End Sub
        Protected Sub ApplyStatusOption()
            ASPxScheduler1.BeginUpdate()
            Try
                Dim options As AppointmentDisplayOptions = ASPxScheduler1.ActiveView.GetAppointmentDisplayOptions()
                options.StatusDisplayType = CType(cbStatus.Value, AppointmentStatusDisplayType)
            Finally
                ASPxScheduler1.EndUpdate()
            End Try
            ASPxScheduler1.ApplyChanges(ASPxSchedulerChangeAction.RenderAppointments)
        End Sub

        Protected Sub ASPxScheduler1_ActiveViewChanged(ByVal sender As Object, ByVal e As EventArgs)
            ApplyStatusOption()
        End Sub
    End Class
End Namespace