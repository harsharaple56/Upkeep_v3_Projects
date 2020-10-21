using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eFacilito_MobileApp_WebAPI.Models
{
    public class ClsTicketDashboard
    {
        public int OpenTicket { get; set; }
        public int AssignedTicket { get; set; }
        public int AcceptedTicket { get; set; }
        public int InProgressTicket { get; set; }
        public int HoldTicket { get; set; }
        public int ClosedTicket { get; set; }
        public int ExpiredTicket { get; set; }
        public int TotalTicket { get; set; }
        public decimal ClosedTicketPercentage { get; set; }

    }


    public class ClsGatepassDashboard
    {
        public int InProgress { get; set; }
        public int OnHold { get; set; }
        public int Approved { get; set; }
        public int Rejected { get; set; }
        public int Expired { get; set; }
        public int Closed { get; set; }
        public decimal PendingPercentage { get; set; }
        public int PendingApprovals { get; set; }
        public int Total { get; set; }
    }

    public class ClsWorkpermitDashboard
    {
        public int InProgress { get; set; }
        public int OnHold { get; set; }
        public int Approved { get; set; }
        public int Rejected { get; set; }
        public int Expired { get; set; }
        public int Closed { get; set; }
        public decimal PendingPercentage { get; set; }
        public int PendingApprovals { get; set; }
        public int Total { get; set; }
    }

    public class ClsChecklistsDashboard
    {
        public int AvailableDeptChk { get; set; }
        public int Pending { get; set; }
        public int Closed { get; set; }
        public int Total { get; set; }
        public decimal PendingChkPercentage { get; set; }
    }

    public class ClsProfile
    {
        public string User_Code { get; set;}
        public string ProfileName { get; set; }
        public string User_Mobile { get; set; }
        public string User_Designation { get; set; }
        public string User_Email { get; set; }
        public string Login_ID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Postcode { get; set; }
        public string Company_Code { get; set; }
        public string Role_Name { get; set; }
        public string Reporting_Manager { get; set; }
        public string ProfilePhoto { get; set; }
    }
}