<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128547692/15.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T344062)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HorizontalAppointment.ascx](./CS/CustomStatusSample/AppointmentTemplates/HorizontalAppointment.ascx) (VB: [HorizontalAppointment.ascx](./VB/CustomStatusSample/AppointmentTemplates/HorizontalAppointment.ascx))
* [HorizontalAppointment.ascx.cs](./CS/CustomStatusSample/AppointmentTemplates/HorizontalAppointment.ascx.cs) (VB: [HorizontalAppointment.ascx.vb](./VB/CustomStatusSample/AppointmentTemplates/HorizontalAppointment.ascx.vb))
* [VerticalAppointment.ascx](./CS/CustomStatusSample/AppointmentTemplates/VerticalAppointment.ascx) (VB: [VerticalAppointment.ascx](./VB/CustomStatusSample/AppointmentTemplates/VerticalAppointment.ascx))
* [VerticalAppointment.ascx.cs](./CS/CustomStatusSample/AppointmentTemplates/VerticalAppointment.ascx.cs) (VB: [VerticalAppointment.ascx.vb](./VB/CustomStatusSample/AppointmentTemplates/VerticalAppointment.ascx.vb))
* **[Default.aspx](./CS/CustomStatusSample/Default.aspx) (VB: [Default.aspx](./VB/CustomStatusSample/Default.aspx))**
* [Default.aspx.cs](./CS/CustomStatusSample/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/CustomStatusSample/Default.aspx.vb))
<!-- default file list end -->
# How to show images for Tentative and Working Elsewhere appointment statuses


The following example illustrates how to create custom templates for vertical and horizontal appointments, and override the status displayed for these appointments. <br>By default, the Tentative and Working Elsewhere statuses are displayed as a colored line inside the appointment area of ASPxScheduler. Meanwhile, it's possible to display required images for these statuses in the same manner supported by MS Outlook. The example uses Div elements with repeating background images inside appointment templates for this purpose. Switch the Div visibility to show images or the default status line according to the current appointment status and the <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerAppointmentDisplayOptions_StatusDisplayTypetopic">status displaying mode</a>  (Never, Time, or Bounds) of the active Scheduler view.<br><br>Refer to the <a href="https://documentation.devexpress.com/#AspNet/CustomDocument4220">How to: Customize Appointment Appearance via Templates</a> documentation article to get more information about the appointment templates customization.

<br/>


