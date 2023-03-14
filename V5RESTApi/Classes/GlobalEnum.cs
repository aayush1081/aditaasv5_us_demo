using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aditaas_v5.Classes
{

    public enum Enum_ModuleTypes
    {
        None = 0,
        Incident = 1,
        Request = 2,
        Change = 3,
        Problem = 4,
        Kb = 5,
        Task = 8,
        Interaction = 33,
        FieldService = 34,
        Assets = 19,
        AssetsSoftware = 109,
        Approval = 20,

        Incident_Notes = 21,
        Request_Notes = 22,
        Problem_Notes = 23,
        Task_Notes = 24,
        FieldService_Notes = 36,
        Change_Notes = 25,
        Kb_Notes = 26,
        Assets_Notes = 27,
        Release = 37,
        Azure_AD = 28
    }

    public enum Enum_ActivityLogType
    {
        CreateTicket = 10,
    }

    public enum Enum_EventTypes
    {
        TicketBusRule = 10,
        TicketReminder = 20,
        TicketSchedule = 30,
        TicketApproval = 35,
        RptScheduler = 40,
        //SelfUser_AddNotes = 50,
        //SelfUser_AddAttachment= 55,
        //TicketUpdate_MailManager = 60,
        SLA_Manager = 70,
        News_Bulletin = 80,
        Master_Updation = 90,
    }

    public enum Enum_ActionTypes
    {
        TicketCreate = 10,
        TicketUpdate = 20,
        TicketDelete = 30,
        TicketAddNotes=40,

        TicketAddNotes_Self = 45,
        TicketAddAttachment_Self = 46,
        TicketAddNotes_MailManager = 47,

        TicketChangesStatus = 50,
        TicketChangesPriority = 51,
        TicketChangesGroup = 60,
        TicketChangesAssignTo= 70,
        //TicketOnPropertyChange= 80,
        TicketOnSurveySubmission = 90,
        None = 1000,
    }

    public enum Enum_Schedule_Event_Status
    {
        Pending = 10,
        Success = 20,
        Cancel = 30,
        Fail = 40,
        Processing = 50,
    }

    public enum Enum_BusRule_IntervalType
    {
        OnTime = 10,
        OnAndAfter = 20,
        After = 30,
    }

    public enum Enum_Report_Type
    {
        Tabular_Report = 110,
        Matrix_Report = 120,
        Summary_Report = 130,
        Advance_Summary_Report = 140,
        
    }

    public enum EnumAdminModType
    {
        Customer = 1,
        User = 2,
        Department = 3,
        LDAP = 4,
        Site = 5,
        Flash = 6,
        SupportGroup = 7,
        Agent = 8,
        Incident = 9,
        Request = 10,
        Problem = 11,
        Change = 12,
        Role = 13,
        NewsBulletin = 14,
        PriorityMatrix = 15,
        EmailManagerSetting = 16,
        EmailNotification = 17,
        Modules = 18,
        DataDbView = 19,
        SurveyForm = 20,
        Holiday = 21,
        ShiftHour = 22,
        SLA = 23,
        BusinessRule = 24,
        DataArchive = 25,
        AzureAd=26
    }
}
