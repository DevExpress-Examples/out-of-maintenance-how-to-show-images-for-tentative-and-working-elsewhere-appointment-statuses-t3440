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
    public partial class VerticalAppointment : System.Web.UI.UserControl
    {
        VerticalAppointmentTemplateContainer Container { get { return (VerticalAppointmentTemplateContainer)Parent; } }
        VerticalAppointmentTemplateItems Items { get { return Container.Items; } }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            appointmentDiv.Style.Value = Items.AppointmentStyle.GetStyleAttributes(Page).Value;
            horizontalSeparator.Style.Value = Items.HorizontalSeparator.Style.GetStyleAttributes(Page).Value;

            lblStartTime.ControlStyle.MergeWith(Items.StartTimeText.Style);
            lblEndTime.ControlStyle.MergeWith(Items.EndTimeText.Style);
            lblTitle.ControlStyle.MergeWith(Items.Title.Style);
            lblDescription.ControlStyle.MergeWith(Items.Description.Style);

            PrepareImageContainer();
            AppointmentStatusType type = Container.AppointmentViewInfo.Status.Type;
            if (type == AppointmentStatusType.Tentative || type == AppointmentStatusType.WorkingElsewhere)
                SetStatusImage();
            else
            {
                statusDiv.Visible = false;
                statusContainer.Controls.Add(Items.StatusControl);
            }
            LayoutAppointmentImages();
        }
        void SetStatusImage()
        {
            if (Container.AppointmentViewInfo.StatusDisplayType == AppointmentStatusDisplayType.Never)
                statusDiv.Visible = false;
            else
            {
                statusDiv.Visible = true;
                tentativeStatusDiv.Style.Remove("background-image");
                tentativeStatusDiv.Style.Remove("height");
                tentativeStatusDiv.Style.Remove("top");
                if(Container.AppointmentViewInfo.Status.Type == AppointmentStatusType.Tentative)
                    tentativeStatusDiv.Style.Add("background-image", "url('Images/TentativeStatus.png')");
                if (Container.AppointmentViewInfo.Status.Type == AppointmentStatusType.WorkingElsewhere)
                    tentativeStatusDiv.Style.Add("background-image", "url('Images/WorkingElseWhereStatus.png')");
                tentativeStatusDiv.Style.Add("height", "98%");
                tentativeStatusDiv.Style.Add("top", "1px");
            }
        }
        void PrepareImageContainer()
        {
            RenderUtils.SetTableSpacings(imageContainer, 1, 0);
        }
        void PrepareImageCell(HtmlTableCell targetCell)
        {
            targetCell.Attributes.Add("class", "dxscCellWithPadding");
        }
        void LayoutAppointmentImages()
        {
            int count = Items.Images.Count;
            for (int i = 0; i < count; i++)
            {
                HtmlTableRow row = new HtmlTableRow();
                HtmlTableCell cell = new HtmlTableCell();
                PrepareImageCell(cell);
                AddImage(cell, Items.Images[i]);
                row.Cells.Add(cell);
                imageContainer.Rows.Add(row);
            }
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