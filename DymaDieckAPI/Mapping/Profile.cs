using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;


namespace DymaDieckAPI.Mapping
{
    /// <summary>
    /// Listado de mapeos para la aplicacion
    /// </summary>
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {

            this.CreateMap<TimeSpan?, string>().ConvertUsing(new TimeSpanTypeConverter());
            this.CreateMap<DateTime, string>().ConvertUsing(new DateTimeTypeConverter());


            //this.CreateMap<Supervisor, YfosERPBackend.Entity.SupervisorCustomer>();
            //this.CreateMap<YfosERPBackend.Entity.SupervisorCustomer, Supervisor>();

            //this.CreateMap<Models.Employees, YfosERPBackend.Entity.Employee>();
            //this.CreateMap<YfosERPBackend.Entity.Employee, Models.Employees>();

            //this.CreateMap<WorkAssigment, YfosERPBackend.Entity.vw_WorkAssigment>();
            //this.CreateMap<YfosERPBackend.Entity.vw_WorkAssigment, WorkAssigment>();

            //this.CreateMap<Job, YfosERPBackend.Entity.vw_job>();
            //this.CreateMap<YfosERPBackend.Entity.vw_job, Job>();

            //this.CreateMap<YfosERPBackend.Entity.checkin_WorkAssignment, Models.AssignmentForm>();
            //this.CreateMap<Models.AssignmentForm, YfosERPBackend.Entity.checkin_WorkAssignment>();

            //this.CreateMap<YfosERPBackend.Entity.Qrcheckin_WorkAssignment, Models.QRAssignmentForm>();
            //this.CreateMap<Models.QRAssignmentForm, YfosERPBackend.Entity.Qrcheckin_WorkAssignment>();

            //this.CreateMap<YfosERPBackend.Entity.Qrcheckin_WorkAssignmentV2, Models.QRAssignmentFormV2>();
            //this.CreateMap<Models.QRAssignmentFormV2, YfosERPBackend.Entity.Qrcheckin_WorkAssignmentV2>();

            //this.CreateMap<YfosERPBackend.Entity.DailyReportEquipment, Models.DailyReportEquipmentForm>();
            //this.CreateMap<Models.DailyReportEquipmentForm, YfosERPBackend.Entity.DailyReportEquipment>();

            //this.CreateMap<YfosERPBackend.Entity.DailyReportMaterial, Models.DailyReportMaterialForm>();
            //this.CreateMap<Models.DailyReportMaterialForm, YfosERPBackend.Entity.DailyReportMaterial>();

            //this.CreateMap<YfosERPBackend.Entity.ActivityReport, Models.ActivityReportForm>();
            //this.CreateMap<Models.ActivityReportForm, YfosERPBackend.Entity.ActivityReport>();

            //this.CreateMap<YfosERPBackend.Entity.JobExpenses, Models.JobExpensesForm>();
            //this.CreateMap<Models.JobExpensesForm, YfosERPBackend.Entity.JobExpenses>();

            //this.CreateMap<YfosERPBackend.Entity.LocationTracking, Models.TrackingForm>();
            //this.CreateMap<Models.TrackingForm, YfosERPBackend.Entity.LocationTracking>();

            //this.CreateMap<YfosERPBackend.Entity.JobLocation, Models.JobLocationForm>();
            //this.CreateMap<Models.JobLocationForm, YfosERPBackend.Entity.JobLocation>();

            //this.CreateMap<YfosERPBackend.Entity.AFE, Models.AFE>();
            //this.CreateMap<Models.AFE, YfosERPBackend.Entity.AFE>();

            //this.CreateMap<YfosERPBackend.Entity.PhaseTask, Models.PhaseTask>();
            //this.CreateMap<Models.PhaseTask, YfosERPBackend.Entity.PhaseTask>();

            //this.CreateMap<YfosERPBackend.Entity.CentroCostosAssignment, Models.AFEForm>();
            //this.CreateMap<Models.AFEForm, YfosERPBackend.Entity.CentroCostosAssignment>();
        }


        public class DateTimeTypeConverter : ITypeConverter<DateTime, string>
        {
            public string Convert(DateTime source, string destination, ResolutionContext context)
            {
                return source.ToString("yyyy-MM-dd");
            }
        }

        public class TimeSpanTypeConverter : ITypeConverter<TimeSpan?, string>
        {
            public string Convert(TimeSpan? source, string destination, ResolutionContext context)
            {
                if (source == null)
                    return "";
                else
                    return source.Value.ToString(@"hh\:mm");
            }
        }
    }
}