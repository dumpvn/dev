﻿using System.Collections;
using System.Linq;
using DevExpress.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxScheduler;
using DevExpress.XtraScheduler;
using dnSchedulev01.Models;
using dnSchedulev01.EFCFFDB;

public class SchedulerDataObject {
    public IEnumerable Appointments { get; set; }
    public IEnumerable Resources { get; set; }
}

public class SchedulerDataHelper {
    public static IEnumerable GetResources() {
        DBScheduleMVCV001 db = new DBScheduleMVCV001();
        //var t = db.Cars.ToList();
        //var ttt = (from res in db.Cars select res).ToList();
        return db.Opportunitys.ToList();// (from res in db.Cars select res).ToList();//db.Cars.Local;//from res in db.Cars select res;
    }
    public static IEnumerable GetAppointments() {
        DBScheduleMVCV001 db = new DBScheduleMVCV001();
        //var aptt =from obj in db.ScheduleCalendars.Where(t => t.UserId == 1) select obj;
        return db.ScheduleCalendars.ToList();//(from apt in db.ScheduleCalendars select apt).ToList();// db.ScheduleCalendars.Local;//from apt in db.ScheduleCalendars  select apt;
    }
    public static IEnumerable GetReminders(IEnumerable rawDataSource) {
        foreach (ListEditItem item in rawDataSource) {
            yield return new { Value = item.Value, Text = item.Text };
        }
    }
    public static SchedulerDataObject DataObject {
        get {
            return new SchedulerDataObject() {
                Appointments = GetAppointments(),
                Resources = GetResources()
            };
        }
    }
    static MVCxAppointmentStorage defaultAppointmentStorage;
    public static MVCxAppointmentStorage DefaultAppointmentStorage {
        get {
            if (defaultAppointmentStorage == null)
                defaultAppointmentStorage = CreateDefaultAppointmentStorage();
            return defaultAppointmentStorage;
        }
    }
    static MVCxAppointmentStorage CreateDefaultAppointmentStorage() {
        MVCxAppointmentStorage appointmentStorage = new MVCxAppointmentStorage();
        appointmentStorage.Mappings.AppointmentId = "ID";
        appointmentStorage.Mappings.Start = "StartTime";
        appointmentStorage.Mappings.End = "EndTime";
        appointmentStorage.Mappings.Subject = "Subject";
        appointmentStorage.Mappings.Description = "Description";
        appointmentStorage.Mappings.Location = "Location";
        appointmentStorage.Mappings.AllDay = "AllDay";
        appointmentStorage.Mappings.Type = "EventType";
        appointmentStorage.Mappings.RecurrenceInfo = "RecurrenceInfo";
        appointmentStorage.Mappings.ReminderInfo = "ReminderInfo";
        appointmentStorage.Mappings.Label = "Label";
        appointmentStorage.Mappings.Status = "Status";
        appointmentStorage.Mappings.ResourceId = "OpportunityId";
        
        #region dn Custome field
        appointmentStorage.CustomFieldMappings.Add("Price", "Price");
        appointmentStorage.CustomFieldMappings.Add("ContactInfo", "ContactInfo");
        appointmentStorage.CustomFieldMappings.Add("OpportunityId", "OpportunityId");
        #endregion
        return appointmentStorage;
    }
    static MVCxResourceStorage defaultResourceStorage;
    public static MVCxResourceStorage DefaultResourceStorage {
        get {
            if (defaultResourceStorage == null)
                defaultResourceStorage = CreateDefaultResourceStorage();
            return defaultResourceStorage;
        }
    }
    static MVCxResourceStorage CreateDefaultResourceStorage() {
        MVCxResourceStorage resourceStorage = new MVCxResourceStorage();
        resourceStorage.Mappings.ResourceId = "ID";
        resourceStorage.Mappings.Caption = "Name";
        //resourceStorage.Mappings.Color = "";
        return resourceStorage;
    }
    public static void InsertAppointment(ScheduleCalendar appt) {
        if (appt == null)
            return;
        DBScheduleMVCV001 db = new DBScheduleMVCV001();
        appt.ID = appt.GetHashCode();
        db.ScheduleCalendars.Local.Add(appt);
        db.SaveChanges();
        //db.ScheduleCalendars.InsertOnSubmit(appt);
        //db.SubmitChanges();
    }
    public static void UpdateAppointment(ScheduleCalendar appt) {
        if (appt == null)
            return;
        DBScheduleMVCV001 db = new DBScheduleMVCV001();
        ScheduleCalendar query = (ScheduleCalendar)(from carSchedule in db.ScheduleCalendars where carSchedule.ID == appt.ID select carSchedule).SingleOrDefault();

        query.ID = appt.ID;
        query.StartTime = appt.StartTime;
        query.EndTime = appt.EndTime;
        query.AllDay = appt.AllDay;
        query.Subject = appt.Subject;
        query.Description = appt.Description;
        query.Location = appt.Location;
        query.RecurrenceInfo = appt.RecurrenceInfo;
        query.ReminderInfo = appt.ReminderInfo;
        query.Status = appt.Status;
        query.EventType = appt.EventType;
        query.Label = appt.Label;
        query.OpportunityId = appt.OpportunityId;
        query.ContactInfo = appt.ContactInfo;
        query.Price = appt.Price;
        db.SaveChanges();
        //db.SubmitChanges();
    }
    public static void RemoveAppointment(ScheduleCalendar appt) {
        DBScheduleMVCV001 db = new DBScheduleMVCV001();
        ScheduleCalendar query = (ScheduleCalendar)(from carSchedule in db.ScheduleCalendars where carSchedule.ID == appt.ID select carSchedule).SingleOrDefault();
        db.ScheduleCalendars.Remove(query);
        db.SaveChanges();
        //db.ScheduleCalendars.DeleteOnSubmit(query);
        //db.SubmitChanges();
    }
}

public class CustomAppointmentTemplateContainer : AppointmentFormTemplateContainer {
    public CustomAppointmentTemplateContainer(MVCxScheduler scheduler)
        : base(scheduler) {
    }

    public new IEnumerable ResourceDataSource {
        get { return SchedulerDataHelper.GetResources(); }
    }
    public new IEnumerable ReminderDataSource {
        get { return SchedulerDataHelper.GetReminders(base.ReminderDataSource); }
    }
    #region dn Custom Field
    public string ContactInfo
    {
        get { return Convert.ToString(Appointment.CustomFields["ContactInfo"]); }
    }
    public decimal? Price
    {
        get
        {
            object priceRawValue = Appointment.CustomFields["Price"];
            return priceRawValue == DBNull.Value ? 0 : (decimal?)priceRawValue;
        }
    }
    public int? OpportunityId
    {
        get
        {
            object OpportunityId = Appointment.ResourceId;
            return OpportunityId == Resource.Empty ? 1 : (int?)OpportunityId; // select first resource if empty
        }
    }
    #endregion   
}

public class Schedule {
    public Schedule() {
    }
    public Schedule(ScheduleCalendar ScheduleCalendar) {
        if (ScheduleCalendar != null) {
            ID = ScheduleCalendar.ID;
            EventType = ScheduleCalendar.EventType;
            Label = ScheduleCalendar.Label;
            AllDay = ScheduleCalendar.AllDay;
            Location = ScheduleCalendar.Location;            
            Status = ScheduleCalendar.Status;
            RecurrenceInfo = ScheduleCalendar.RecurrenceInfo;
            ReminderInfo = ScheduleCalendar.ReminderInfo;
            Subject = ScheduleCalendar.Subject;           
            StartTime = ScheduleCalendar.StartTime.Value;
            EndTime = ScheduleCalendar.EndTime.Value;
            Description = ScheduleCalendar.Description;
            
            #region dn Custome Field
            OpportunityId = ScheduleCalendar.OpportunityId;
            Price = ScheduleCalendar.Price;
            ContactInfo = ScheduleCalendar.ContactInfo;
            #endregion
            
        }
    }

    public int ID { get; set; }
    public int? EventType { get; set; }
    public int? Label { get; set; }
    public bool AllDay { get; set; }
    public string Location { get; set; }    
    public int? Status { get; set; }
    public string RecurrenceInfo { get; set; }
    public string ReminderInfo { get; set; }
    [Required(ErrorMessage = "The Subject must contain at least one character.")]
    public string Subject { get; set; }    
    [Required]
    public DateTime StartTime { get; set; }
    [Required]
    public DateTime EndTime { get; set; }
    public string Description { get; set; }   
    public bool HasReminder { get; set; }
    public Reminder Reminder { get; set; }
    
    #region dn Custom Field
    public object OpportunityId { get; set; }
    public decimal? Price { get; set; }
    public string ContactInfo { get; set; }
    #endregion   

    public virtual void Assign(Schedule source) {
        if (source != null) {
            ID = source.ID;
            EventType = source.EventType;
            Label = source.Label;
            AllDay = source.AllDay;
            Location = source.Location;            
            Status = source.Status;
            RecurrenceInfo = source.RecurrenceInfo;
            ReminderInfo = source.ReminderInfo;
            Subject = source.Subject;           
            StartTime = source.StartTime;
            EndTime = source.EndTime;
            Description = source.Description;

            #region dn Custom Field
            OpportunityId = source.OpportunityId;
            ContactInfo = source.ContactInfo;
            Price = source.Price;
            #endregion            
        }
    }
}

// Developer Express Code Central Example:
// Scheduler - How to implement a custom Edit Appointment Form with custom fields
// 
// This example illustrates how to implement a custom Appointment Form and display
// it instead of the default one.
// 
// To include a custom Appointment Form to the
// SchedulerPartial view, the
// MVCxSchedulerOptionsForms.SetAppointmentFormTemplateContent Method
// (ms-help://DevExpress.NETv12.2/DevExpress.AspNet/DevExpressWebMvcMVCxSchedulerOptionsForms_SetAppointmentFormTemplateContenttopic.htm)
// should be handled.
// To add custom fields to the Appointment Form, implement a
// custom AppointmentFormTemplateContainer
// (ms-help://DevExpress.NETv12.2/DevExpress.AspNet/clsDevExpressWebASPxSchedulerAppointmentFormTemplateContainertopic.htm)
// and substitute the default container with your custom one by handling the
// ASPxScheduler.AppointmentFormShowing Event
// (ms-help://DevExpress.NETv12.2/DevExpress.AspNet/DevExpressWebASPxSchedulerASPxScheduler_AppointmentFormShowingtopic.htm).
// See
// Also:
// http://www.devexpress.com/scid=E2924
// http://www.devexpress.com/scid=E3984
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4520