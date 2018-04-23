using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Drawing;
using DevExpress.Web.ASPxScheduler.Internal;
using DevExpress.Web.Internal;
using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CustomStatusSample.AppointmentTemplates
{
    public partial class HorizontalAppointment : System.Web.UI.UserControl
    {
        HorizontalAppointmentTemplateContainer Container { get { return (HorizontalAppointmentTemplateContainer)Parent; } }
        HorizontalAppointmentTemplateItems Items { get { return Container.Items; } }
        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);
            appointmentDiv.Style.Value = Items.AppointmentStyle.GetStyleAttributes(Page).Value;

            lblTitle.ControlStyle.MergeWith(Items.Title.Style);
            lblStartContinueText.ControlStyle.MergeWith(Items.StartContinueText.Style);
            lblEndContinueText.ControlStyle.MergeWith(Items.EndContinueText.Style);

            PrepareContainers();
            LayoutAppointmentImages();
            AppointmentStatusType type = Container.AppointmentViewInfo.Status.Type;
            if (type == AppointmentStatusType.Tentative || type == AppointmentStatusType.WorkingElsewhere)
                SetStatusImage();
            else
            {
                statusDiv.Visible = false;
                statusContainer.Controls.Add(Items.StatusControl);
            }
            startTimeClockContainer.Controls.Add(Items.StartTimeClock);
            endTimeClockContainer.Controls.Add(Items.EndTimeClock);
        }
        void SetStatusImage()
        {
            if (Container.AppointmentViewInfo.StatusDisplayType == AppointmentStatusDisplayType.Never)
                statusDiv.Visible = false;
            else
            {
                statusDiv.Visible = true;
                tentativeStatusDiv.Style.Remove("background-image");
                tentativeStatusDiv.Style.Remove("width");
                tentativeStatusDiv.Style.Remove("left");
                if (Container.AppointmentViewInfo.Status.Type == AppointmentStatusType.Tentative)
                    tentativeStatusDiv.Style.Add("background-image", "url('Images/TentativeStatusRotated.png')");
                if (Container.AppointmentViewInfo.Status.Type == AppointmentStatusType.WorkingElsewhere)
                    tentativeStatusDiv.Style.Add("background-image", "url('Images/WorkingElseWhereStatusRotated.png')");
                if (Container.AppointmentViewInfo.StatusDisplayType == AppointmentStatusDisplayType.Bounds)
                {
                    tentativeStatusDiv.Style.Add("width", "98%");
                    tentativeStatusDiv.Style.Add("left", "1px");
                    
                }
                else
                {
                    int width = Convert.ToInt32(Container.AppointmentViewInfo.Appointment.Duration.TotalSeconds / Container.AppointmentViewInfo.Interval.Duration.TotalSeconds * 100);
                    TimeSpan fromStart = Container.AppointmentViewInfo.Appointment.Start.Subtract(Container.AppointmentViewInfo.Interval.Start);
                    int left = Convert.ToInt32(fromStart.TotalSeconds / Container.AppointmentViewInfo.Interval.Duration.TotalSeconds * 100);
                    tentativeStatusDiv.Style.Add("width", width + "%");
                    tentativeStatusDiv.Style.Add("left", left + "%");
                }
            }
        }
        void PrepareContainers()
        {
            RenderUtils.SetTableSpacings(imageContainer, 0, 0);
            RenderUtils.SetAlignAttributes(statusContainer, null, "top");
        }
        void LayoutAppointmentImages()
        {
            int count = Items.Images.Count;
            HtmlTableRow row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            for (int i = 0; i < count; i++)
            {
                HtmlTableCell cell = new HtmlTableCell();
                AddImage(cell, Items.Images[i]);
                row.Cells.Add(cell);
            }
            imageContainer.Rows.Add(row);

            Items.StartContinueArrow.ImageProperties.AssignToControl(imgStartContinueArrow, false);
            Items.EndContinueArrow.ImageProperties.AssignToControl(imgEndContinueArrow, false);
        }
        void AddImage(HtmlTableCell targetCell, AppointmentImageItem imageItem)
        {
            Image image = new Image();
            imageItem.ImageProperties.AssignToControl(image, false);
            SchedulerWebEventHelper.AddOnDragStartEvent(image, ASPxSchedulerScripts.GetPreventOnDragStart());
            targetCell.Controls.Add(image);
        }
    }
}