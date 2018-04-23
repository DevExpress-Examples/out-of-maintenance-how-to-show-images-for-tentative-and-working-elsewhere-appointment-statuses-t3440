using DevExpress.Web.ASPxScheduler;
using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomStatusSample
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ApplyStatusOption();
        }
        protected void ApplyStatusOption()
        {
            ASPxScheduler1.BeginUpdate();
            try
            {
                AppointmentDisplayOptions options = ASPxScheduler1.ActiveView.GetAppointmentDisplayOptions();
                options.StatusDisplayType = (AppointmentStatusDisplayType)cbStatus.Value;
            }
            finally
            {
                ASPxScheduler1.EndUpdate();
            }
            ASPxScheduler1.ApplyChanges(ASPxSchedulerChangeAction.RenderAppointments);
        }

        protected void ASPxScheduler1_ActiveViewChanged(object sender, EventArgs e)
        {
            ApplyStatusOption();
        }
    }
}