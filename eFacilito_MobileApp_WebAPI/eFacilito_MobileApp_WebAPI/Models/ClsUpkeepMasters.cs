using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Xml;

namespace eFacilito_MobileApp_WebAPI.Models
{
    public class ClsUpkeepLogin
    {
        public string ProPubStrEmployeeID { get; set; }
        public string ProPubStrUsername { get; set; }
        public string ProPubStrRights { get; set; }
        public string ProPubStrName { get; set; }
        public string ProPubStrRollCd { get; set; }
        public string ProPubStrEmpCd { get; set; }
        public string ProPubStrPrtycd { get; set; }
        public string ProPubStrGroupCompany { get; set; }
    }


    public class ClsGroupMaster
    {
        public string ProPubStrGroupId { get; set; }
        public string ProPubStrGroupDesc { get; set; }

    }

    public class ClsZoneLocationMaster
    {
        public string ProPubStrUnitId { get; set; }
        public string ProPubStrUnitDesc { get; set; }
        public string ProPubStrUnitCode { get; set; }
        public string ProPubStrUnitPrefix { get; set; }
        public string ProPubStrCompanyId { get; set; }
        public string ProPubStrCompanyDesc { get; set; }

    }

    public class ClsCompanyMaster
    {
        public string ProPubStrGroupId { get; set; }
        public string ProPubStrGroupDesc { get; set; }
        public string ProPubStrAddress { get; set; }
        public string ProPubStrCompanyCode { get; set; }
        public string ProPubStrCompanyId { get; set; }
        public string ProPubStrCompanyDesc { get; set; }

    }

    public class ClsSubLocationMaster
    {
        public string ProPubStrDeptId { get; set; }
        public string ProPubStrDeptDesc { get; set; }
        public string ProPubStrDeptPrefix { get; set; }
        public string ProPubStrLocationId { get; set; }
    }

    public class ClsAreaMaster
    {
        public string ProPubStrCategoryId { get; set; }
        public string ProPubStrCategoryDesc { get; set; }
        public string ProPubStrDeptId { get; set; }
    }

    public class ClsEmployeeList
    {
        public string ProPubStrEmployeeId { get; set; }
        public string ProPubStrCode { get; set; }
        public string ProPubStrName { get; set; }
        public string ProPubCompany { get; set; }
        public string ProPubSubLocation { get; set; }
        public string ProPubDesignation { get; set; }
    }

    public class ClsActionInfoDetails
    {
        public string ProPubStrActionInfoId { get; set; }
        public string ProPubStrActionInfoDesc { get; set; }
        public string ProPubStrEmployeeName { get; set; }
    }

    public class ClsActionInfoGroupLinkup
    {
        public string ProPubStrActionInfoGId { get; set; }
        public string ProPubStrActionInfoDesc { get; set; }
        public string ProPubStrActInLinkUp { get; set; }

    }
    public class ClsApplyRequest
    {
        public string ProPubStrStatus { get; set; }
    }


    //Added By Ravindra Muthe on 10-March-2019 STARTS
    public class ClsMyGatePassMst
    {
        public string ProPubStrretailerid { get; set; }
        public string ProPubStrRetailername { get; set; }
        public string ProPubStrDesignation { get; set; }
        public string ProPubStrRequestDate { get; set; }
        public string ProPubStrmobileno { get; set; }
        public string ProPubStrGatepassID { get; set; }
    }


    public class ClsGatePass
    {
        public string ProPubStrGatePassID { get; set; }
        public string ProPubStrretailerid { get; set; }
        public string ProPubStrRetailername { get; set; }
        public string ProPubStrmobileno { get; set; }
        public string ProPubStrexpecteddate { get; set; }
        public string ProPubStrreqStatus { get; set; }
        public string ProPubStrGatePassType { get; set; }
        public string ProPubStrApprovedBy { get; set; }
        public string ProPubStrRemark { get; set; }
    }

    public class ClsStatusApprovalDetails
    {
        public string ProPubStrGatePassID { get; set; }
        public string ProPubStrretailerid { get; set; }
        public string ProPubStrRetailername { get; set; }
        public string ProPubStrmobileno { get; set; }
        public string ProPubStrexpecteddate { get; set; }
        public string ProPubStrreqStatus { get; set; }
        public string ProPubStrGatePassType { get; set; }
    }


    public class ClsGatePassRply
    {
        public string ProPubStrretailerid { get; set; }
        public string ProPubStrRetailername { get; set; }
        public string ProPubStrmobileno { get; set; }
        public string ProPubStrSrNo { get; set; }
        public string ProPubStrIDescription { get; set; }
        public string ProPubStrNoOfBoxes { get; set; }
        public string ProPubStrNoOfPieces { get; set; }
        public string ProPubStrBalanceStock { get; set; }
        public string ProPubStrTransLocation { get; set; }
    }


    public class ClsMyworkorderid
    {
        public string ProPubStrretailerid { get; set; }
        public string ProPubStrRetailername { get; set; }
        public string ProPubStrDesignation { get; set; }
        public string ProPubStrRequestDate { get; set; }
        public string ProPubStrmobileno { get; set; }
        public string ProPubStrWorkorderID { get; set; }
    }


    public class ClsWorkPass
    {
        public string ProPubStrWorkorderID { get; set; }
        public string ProPubStrretailerid { get; set; }
        public string ProPubStrRetailername { get; set; }
        public string ProPubStrmobileno { get; set; }
        public string ProPubStrexpectedfromdate { get; set; }
        public string ProPubStrreqStatus { get; set; }
        public string ProPubStrApprovedBy { get; set; }
        public string ProPubStrRemark { get; set; }

    }

    public class ClsWorkStatusApprovalDetails
    {
        public string ProPubStrWorkorderID { get; set; }
        public string ProPubStrretailerid { get; set; }
        public string ProPubStrRetailername { get; set; }
        public string ProPubStrmobileno { get; set; }
        public string ProPubStrexpectedfromdate { get; set; }
        public string ProPubStrreqStatus { get; set; }
    }


    public class ClsworkpermitRply
    {
        public string ProPubStrretailerid { get; set; }
        public string ProPubStrRetailername { get; set; }
        public string ProPubStrmobileno { get; set; }
        public string ProPubStrNameofcontractor { get; set; }
        public string ProPubStrContactNoofContractor { get; set; }
        public string ProPubStrNameofSiteIncharge { get; set; }
        public string ProPubStrContactNoofsiteincharge { get; set; }
        public string ProPubStrSupervisorname { get; set; }
        public string ProPubStrsupervisorcontact { get; set; }
        public string ProPubStrnooflabours { get; set; }
        public string ProPubStrExactlocofjob { get; set; }
        public string ProPubStrElectricalsystem { get; set; }
        public string ProPubStrwatersupply { get; set; }
        public string ProPubStrcarpenterandfurniture { get; set; }
        public string ProPubStrstorestockaudit { get; set; }
        public string ProPubStrpestcontrol { get; set; }
        public string ProPubStrHvacSystem { get; set; }
        public string ProPubStrSecuritySurveillancesystem { get; set; }
        public string ProPubStrCivilwork { get; set; }
        public string ProPubStrVMdisplay { get; set; }
        public string ProPubStrfirefightingdetectionsystem { get; set; }
        public string ProPubStrOthers { get; set; }
        public string ProPubStrworktobecarriedout { get; set; }
        public string ProPubStrpowersupplyrequired { get; set; }
        public string ProPubStrworkinconfinedspace { get; set; }
        public string ProPubStrwatersupplyrequired { get; set; }
        public string ProPubStrworkatheight { get; set; }
        public string ProPubStrfemalestaff { get; set; }
        public string ProPubStrTollkit { get; set; }
        public string ProPubStrnote2 { get; set; }
    }

    // Added By Ravindra Muthe on 10-March-2019 ENDS

    // Added By Ravindra Muthe on 04-Jan-2019
    public class ClsSaveImg
    {
        public string StrMyRequestID { get; set; }
        public string StrImgPath { get; set; }
    }


    // Added By Ravindra Muthe on 04-Jan-2019
    public class ClsSaveImgChklist
    {
        public int StrParkedId { get; set; }
        public string StrImgPathChklist { get; set; }
    }


    public class ClsImage
    {
        public string ProPubStrImagePath { get; set; }
    }


    public class ClsRequestList
    {
        public string ProPubStrMyRequestID { get; set; }
        public string ProPubStrPubFlowID { get; set; }
        public string ProPubStrTicketNo { get; set; }
        public string ProPubStrArea { get; set; }
        public string ProPubStrSubArea { get; set; }
        public string ProPubStrZone { get; set; }
        public string ProPubStrLocation { get; set; }
        public string ProPubStrSubLocation { get; set; }
        public string ProPubStrPendingWith { get; set; }
        public string ProPubStrRequestDate { get; set; }
        public string ProPubStrFromEmployee { get; set; }
        public string ProPubStrRequestStatus { get; set; }
        public string ProPubStrStatus { get; set; }
        public string ProPubStrMessage { get; set; }
        public string ProPubStrCloseMessage { get; set; }
        //public string ProPubStrcurrentlevel { get; set; }
        // public string ProPubStrImagePath { get; set; }

    }
    public class ClsStatus
    {
        public string ProPubStrStatus { get; set; }
    }


    public class ClsCheckListHolder
    {

        public string ProPubStrChkListId { get; set; }
        public string ProPubStrChkListHolder { get; set; }


    }

    public class ClsCheckListData
    {
        public string ProPubStrTicketId { get; set; }
        public string ProPubStrGroupDesc { get; set; }
        public string ProPubStrCompanyDesc { get; set; }
        public string ProPubStrDepartmentName { get; set; }
        public string ProPubStrCheckListHolder { get; set; }
        public string ProPubStrScheduleDate { get; set; }
        public string ProPubStrPriority { get; set; }
        public string ProPubStrFrequency { get; set; }
        public string ProPubStrStartTime { get; set; }
        public string ProPubStrTransactionID { get; set; }
        public string ProPubStrUsername { get; set; }
        public string ProPubStrZone { get; set; }
        public string ProPubStrLocation { get; set; }
        public string ProPubStrSubLocation { get; set; }
        public string ProPubStrZoneID { get; set; }
        public string ProPubStrLocationID { get; set; }
        public string ProPubStrSubLocationID { get; set; }
    }
    public class ClsCheckListOFFline
    {
        public string ProPubStrTicketId { get; set; }
        public string ProPubStrGroupDesc { get; set; }
        public string ProPubStrCompanyDesc { get; set; }
        public string ProPubStrDepartmentName { get; set; }
        public string ProPubStrCheckListHolder { get; set; }
        public string ProPubStrTempID { get; set; }

    }
    public class ClsCheckList
    {
        public string ProPubStrId { get; set; }
        public string ProPubStrCheckID { get; set; }
        public string ProPubStrChekList { get; set; }
        public string ProPubStrWeigthage { get; set; }
        public string ProPubStrImagePath { get; set; }
        public string ProPubStrRemark { get; set; }

        public string ProPubStrChkImgRequired { get; set; }

    }
    public class ClsCheckRadio
    {
        public string ProPubStrId { get; set; }
        public string ProPubStrCktId { get; set; }
        public string ProPubStrChekListID { get; set; }
        public string ProPubStrYes { get; set; }
        public string ProPubStrNo { get; set; }
        public string ProPubStrNA { get; set; }


    }
    public class ClsChkList
    {
        public string ProPubStrImagePath { get; set; }
    }


    public class ClsDepartment
    {
        public string ProPubStrDepartment { get; set; }
    }

    public class ClsCheck
    {
        public List<ClsCheckListData> CheckListData { get; set; }
        public List<ClsCheckList> CheckList { get; set; }
        public List<ClsCheckRadio> CheckListRadio { get; set; }
    }

    public class ClsCheckActionable
    {
        public string ProPubStrChkTransactionId { get; set; }
        public string ProPubStrCktListRequestId { get; set; }
        public string ProPubStrTicketID { get; set; }
        public string ProPubStrCheckListHolder { get; set; }
        public string ProPubStrScheduleDate { get; set; }
        public string ProPubStrStartTime { get; set; }
        public string ProPubStrEndTime { get; set; }
        public string ProPubStrRequestStatus { get; set; }
        public string ProPubStrStatus { get; set; }
        public string ProPubStrDepartmentName { get; set; }
        public string ProPubStrUsername { get; set; }


    }


    public class ClsMobileDashboard
    {
        public CLsRequestDashboard clsReqDashboard { get; set; }
        public CLsChecklistDashboard clsChkDashboard { get; set; }
    }

    public class CLsRequestDashboard
    {
        public string ProPubStrOpen { get; set; }
        public string ProPubStrClose { get; set; }
    }

    public class CLsChecklistDashboard
    {
        public string ProPubStrOpen { get; set; }
        public string ProPubStrClose { get; set; }
    }

    public class ClsCheckListPending
    {
        public string ProPubStrPrkId { get; set; }
        public string ProPubStrCompanyDesc { get; set; }
        public string ProPubStrCategoryDesc { get; set; }
        public string ProPubStrCheckList { get; set; }
        public string ProPubStrCheckListHolder { get; set; }
        public string ProPubStrScheduleDate { get; set; }
        public string ProPubStrRemark { get; set; }
        public string ProPubStrRequestStatus { get; set; }
        public string proPubImgPath { get; set; }

    }
    public class ClsLocationMaster
    {
        public string ProPubStrLocationID { get; set; }
        public string ProPubStrLocName { get; set; }
        public string ProPubStrUnitID { get; set; }
        public string ProPubStrUnitDesc { get; set; }
        public string ProPubStrLocPrefix { get; set; }
        public string ProPubStrLocationUnit { get; set; }

    }

    public class ClsSubArea
    {
        public string ProPubStrCategoryId { get; set; }
        public string ProPubStrSubCategoryId { get; set; }
        public string ProPubStrSubCategoryDesc { get; set; }
        public string ProPubStrImmediateAssistance { get; set; }
        public string ProPubStrExplicitLinkUp { get; set; }
        public string ProPubStrLeadtime { get; set; }
        public string ProPubStrRemarks { get; set; }


    }

    public class ClsRequestData
    {

        public string ProPubStrTempID { get; set; }
        public string ProPubStrRequestID { get; set; }
        public string ProPubStrFlowID { get; set; }
        public string ProPubStrTicketId { get; set; }
        public string ProPubStrPendingWith { get; set; }
        public string ProPubStrPendingRollcd { get; set; }
        public string ProPubStrPendingEmpcd { get; set; }
    }

    public class ClsCheckListReportData
    {
        public string ProPubTicketID { get; set; }
        public string ProPubGroupDesc { get; set; }
        public string ProPubCompanyDesc { get; set; }
        public string ProPubDepartmentName { get; set; }
        public string ProPubCheckListHolder { get; set; }
        public string ProPubScheduleDate { get; set; }
        public string ProPubPriority { get; set; }
        public string ProPubFrequency { get; set; }
        public string ProPubStartTime { get; set; }
        public string ProPubEndTime { get; set; }
        public string ProPubRequeststatus { get; set; }

    }

    public class ClsCheckListReportDataForChart
    {
        public string ProPubCheckListHolder { get; set; }
        public int ProPubCheckListCount { get; set; }

    }

    public class ClsCheckReport
    {
        public List<ClsCheckListReportData> CheckListData1 { get; set; }
        public List<ClsCheckListReportDataForChart> CheckList1 { get; set; }

    }

    public class ClsCheckListDetailGv
    {
        public string ProPubCHECKLIST { get; set; }
        public string ProPubYES { get; set; }
        public string ProPubNO { get; set; }
        public string ProPubREMARK { get; set; }
    }

    public class ClsChekListCalc
    {
        public string ProPubTOTAL { get; set; }
        public string ProPubCORRECT { get; set; }
        public string ProPubINCORRECT { get; set; }
        public string ProPubCARRIED_FORWARD { get; set; }
    }

    public class ClsCheckListDepartmentName
    {
        public string ProPubDEPARTMENT_NAME { get; set; }
    }

    public class ClsCheckListDetailReport
    {
        public List<ClsCheckListDetailGv> CheckListDetailGv { get; set; }
        public List<ClsChekListCalc> ChekListCalc { get; set; }
        public List<ClsCheckListDepartmentName> CheckListDepartmentName { get; set; }
    }

    public class ClsCheckListWiseReport
    {
        public string ProPubCHECKLIST { get; set; }
        public string ProPubYES { get; set; }
        public string ProPubNO { get; set; }
        public string ProPubREMARK { get; set; }
    }

    public class ClsCountCKTandTKT
    {
        public string ProPubTotalTicket { get; set; }
        public string ProPubOpenTicket { get; set; }
        public string ProPubCloseTicket { get; set; }
        public string ProPubTotalCheckList { get; set; }
        public string ProPubOpenCheckList { get; set; }
        public string ProPubClosedCheckList { get; set; }

    }

    public class ClsReportTicketRaised
    {
        public string ProPubTicketID { get; set; }
        public string ProPubCategoryDesc { get; set; }
        public string ProPubSubCategoryDesc { get; set; }
        public string ProPubUnit { get; set; }
        public string ProPubPendingWith { get; set; }
        public string ProPubstatus { get; set; }
        public string ProPubRequestStatus { get; set; }
        public string ProPubRequestDate { get; set; }
        public string ProPubMessage { get; set; }

    }

    public class ClsCheckListNew
    {
        public string ProPubStrId { get; set; }
        public string ProPubStrCheckID { get; set; }
        public string ProPubStrChekList { get; set; }
        public string ProPubStrWeigthage { get; set; }
        public string ProPubStrImagePath { get; set; }
        public string ProPubStrRemark { get; set; }
        public string ProPubStrCheckListHolderId { get; set; }
        public string ProPubStrTicketId { get; set; }

    }


    public class ClsCheckListDataBulk
    {
        public List<ClsCheckActionable> CheckListActionable { get; set; }
        public List<ClsCheckListData> CheckListData { get; set; }
        public List<ClsCheckListNew> CheckList { get; set; }
        public List<ClsCheckRadio> CheckListRadio { get; set; }
    }


    // Created By Tanmay Pradhan 09-April-2019

    public class ClsSaveChckDetails
    {
        public string StrTicketID { get; set; }
        public string StrId { get; set; }
        public string StrYes { get; set; }
        public string StrNo { get; set; }
        public string StrNA { get; set; }
        public string StrRemark { get; set; }
        public string StrCheckListId { get; set; }
        public string StrChkTransactionId { get; set; }

    }

    public class ClsQRIDs
    {
        public string ProPubStrZone { get; set; }
        public string ProPubStrLocation { get; set; }
        public string ProPubStrSubLocation { get; set; }
    }

    public class ClsBeaconMst
    {

        public string ProPubStrBeaconId { get; set; }
        public string ProPubStrBeaconName { get; set; }
        public string ProPubStrBeaconDesc { get; set; }
        public string ProPubStrBeaconCode { get; set; }

    }

    public class ClsAndroidVersions
    {
        public string ProPubStrVersionCode { get; set; }
        public string ProPubStrVersionName { get; set; }
        public string ProPubStrCreatedOn { get; set; }
    }

    public class ClsWowCustomerDetails
    {
        public string ProPubStrCustomer_id { get; set; }
        public string ProPubStrFull_Name { get; set; }
        public string ProPubStrAddress { get; set; }
        public string ProPubStrEmail_id { get; set; }
        public string ProPubStrContact_No { get; set; }
        public string ProPubStrAlter_No { get; set; }
        public string ProPubStrImage { get; set; }
        public string ProPubStrOprc { get; set; }
        public string ProPubStrDtc { get; set; }
    }

    public class ClsWowWowImageDetails
    {
        public string ProPubStrcustomerid { get; set; }
        public string ProPubStrImage { get; set; }
    }

    public class ClsWowBaggageDetails
    {
        public string ProPubStrCustomer_id { get; set; }
        public string ProPubStrBaggageId { get; set; }
        public string ProPubStrTotalBag { get; set; }
        public string ProPubStrPrice { get; set; }
        public string ProPubStrStatus { get; set; }
        public string ProPubStrBagTicketId { get; set; }
        public string ProPubStrFull_Name { get; set; }
        public string ProPubStrAddress { get; set; }
        public string ProPubStrEmail_id { get; set; }
        public string ProPubStrContact_No { get; set; }
        public string ProPubStrAlter_No { get; set; }
        public string ProPubStrDtc { get; set; }
        public string ProPubStrBagTagID { get; set; }
        public string ProPubStrAssociate { get; set; }
    }

    public class ClsWowPowerBankDetails
    {
        public string ProPubStrAssignId { get; set; }
        public string ProPubStrCustomerId { get; set; }
        public string ProPubStrPowerBankId { get; set; }
        public string ProPubStrStatus { get; set; }
        public string ProPubStrFullName { get; set; }
        public string ProPubStrAddress { get; set; }
        public string ProPubStrEmailId { get; set; }
        public string ProPubStrContactNo { get; set; }
        public string ProPubStrAlterNo { get; set; }
        public string ProPubStrMake { get; set; }
        public string ProPubStrModel { get; set; }
        public string ProPubStrColor { get; set; }
        public string ProPubStrSerialNo { get; set; }
        public string ProPubStrDtc { get; set; }
    }

    public class ClsGatePassRequestDetails
    {
        public string GP_TrancationID { get; set; }
        public string GP_TicketNo { get; set; }
        public string GP_Config_ID { get; set; }
        public string GP_Title { get; set; }
        public string GP_Department { get; set; }
        public string GP_Type_Desc { get; set; }
        public string GP_Date { get; set; }
        public string GP_RequestDate { get; set; }
        public string GP_Status { get; set; }
        public string GP_CreatedBy { get; set; }
    }

    public class ClsGatePassAction
    {
        public string GP_TransacationID { get; set; }
        public string GP_CurrentLevel { get; set; }
        public string GP_ActionStatus { get; set; }
        public string GP_Remarks { get; set; }
        public string GP_EmpCD { get; set; }
        public string GP_RollCD { get; set; }
    }


    #region "WorkPermit" 
    public class ClsWorkPermitRequestDetails
    {
        public string WP_Trans_ID { get; set; }
        public string TicketNo { get; set; }
        public string Wp_Config_ID { get; set; }
        public string WP_Title { get; set; }
        public string DepartmentName { get; set; }
        public string WorkPermitDate { get; set; }
        public string RequestDate { get; set; }
        public string WP_Status { get; set; }
        public string Created_By { get; set; }
    }

    public class ClsWorkPermitAction
    {
        public string WP_TransacationID { get; set; }
        public string WP_ActionStatus { get; set; }
        public string WP_Remarks { get; set; }
        public string WP_EmpCD { get; set; }
        public string WP_RollCD { get; set; }
    }

    #region "FetchSavedWorkPermit"

    public class ClsWorkPermitMain
    {
        public List<ClsWorkPermitTransaction> ObjClsTransaction { get; set; }
        public List<ClsWorkPermitInitiator> ObjClsInitiator { get; set; }
        public List<ClsWorkPermitSection> ObjClsSection { get; set; }
        public List<ClsWorkPermitApprover> ObjClsApprover { get; set; }
        public List<ClsWorkPermitApproverMatrix> ObjClsApproverMatrix { get; set; }
        public List<ClsWorkPermitActions> ObjClsActions { get; set; }
        //public List<ClsWorkPermitTransaction> ObjClsTransaction = new List<ClsWorkPermitTransaction>();
        //public List<ClsWorkPermitInitiator> ObjClsInitiator = new List<ClsWorkPermitInitiator>();
        //public List<ClsWorkPermitSection> ObjClsSection = new List<ClsWorkPermitSection>();
        //public List<ClsWorkPermitApprover> ObjClsApprover = new List<ClsWorkPermitApprover>(); 

    }

    public class ClsWorkPermitActions
    {
        public string ActionID { get; set; }
        public string Action_Desc { get; set; }
    }

    public class ClsWorkPermitTransaction
    {
        //0
        public string WP_Config_ID { get; set; }
        public string Level { get; set; }
        public string TicketNo { get; set; }
        public string Wp_Status { get; set; }
        public string WP_Title { get; set; }
        public string Initiator { get; set; }
        public string Created_By { get; set; }
        public string Created_Date { get; set; }
        public string Wp_date { get; set; }
        public string Wp_To_date { get; set; }
    }
    public class ClsWorkPermitInitiator
    {
        //1
        public string UserType { get; set; }
        public string Username { get; set; }
        public string Store_Name { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string EmailID { get; set; }

    }
    public class ClsWorkPermitSection
    {
        //2
        public string SectionName { get; set; }
        public List<ClsWorkPermitHeader> ObjHeader = new List<ClsWorkPermitHeader>();
    }
    public class ClsWorkPermitHeader
    {
        //2.1
        public List<ClsWorkPermitSectionHeader> ObjSectionHeader = new List<ClsWorkPermitSectionHeader>();
    }
    public class ClsWorkPermitSectionHeader
    {
        //2.1.1
        public string Header { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
    public class ClsWorkPermitApprover
    {
        //3
        public string Level { get; set; }
        public string Approver { get; set; }
        public string Remarks { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }

    }

    public class ClsWorkPermitApproverMatrix
    {
        //3
        public string Level { get; set; }
        public string LevelDescription { get; set; }
        public string User { get; set; }

    }

    public class ClsWorkPermitSectionHeaderData
    {
        //XXX
        public string SectionName { get; set; }
        public List<ClsWorkPermitSectionHeader> ObjSectionHeader = new List<ClsWorkPermitSectionHeader>();
    }
    #endregion

    #endregion


    #region Checklist

    public class ClChecklistConfig
    {
        public List<ClChecklistConfigHead> ObjClChecklistConfigHead { get; set; }
        public List<ClChecklistConfigSection> ObjClChecklistConfigSection { get; set; }
        public List<ClChecklistConfigAnswerType> ObjClChecklistConfigAnswerType { get; set; }

    }
    public class ClChecklistConfigHead
    {
        //XXX
        public int Chk_Response_ID { get; set; }
        public int Location_ID { get; set; }
        public int Department_ID { get; set; }
        public string Status { get; set; }
        public string ActionStatus { get; set; }

        public int Chk_Config_ID { get; set; }
        public string Chk_Title { get; set; }
        public string Chk_Desc { get; set; }
        public bool Is_Enable_Score { get; set; }
        public int TotalScore { get; set; }
    }
    public class ClChecklistConfigSection
    {
        //XXX
        //public int SrNo { get; set; }
        public int Chk_Section_ID { get; set; }
        public int Chk_Config_ID { get; set; }
        public string Chk_Section_Desc { get; set; }
        public List<ClChecklistConfigQuestion> ObjClChecklistConfigQuestion { get; set; }

    }
    public class ClChecklistConfigQuestion
    {
        //XXX
        public int CHK_Question_ID { get; set; }
        public int Chk_Section_ID { get; set; }
        public string Qn_Desc { get; set; }
        public bool Is_Attach_Mandatory { get; set; }
        public bool Is_Qn_Mandatory { get; set; }
        public int Qn_Score { get; set; }
        public string Chk_Qn_Ref_Desc { get; set; }
        public string Chk_Qn_Ref_Photo { get; set; }
        public int Chk_Ans_Type_ID { get; set; }
        public bool Is_Raise_Flag_Issue { get; set; }

        public List<ClChecklistConfigAnswerType> ObjClChecklistConfigAnswerType { get; set; }

        public List<ClChecklistConfigAnswer> ObjClChecklistConfigAnswer { get; set; }
        public List<ClChecklist_Response_Data_Values> ObjClChecklist_Response_Data_Values { get; set; }
    }

    public class ClChecklistConfigAnswer
    {
        //XXX
        public int Chk_Ans_Value_ID { get; set; }
        public int CHK_Question_ID { get; set; }
        public bool Ans_Is_Flag { get; set; }
        public bool Is_Default { get; set; }
        public string Chk_Ans_Desc { get; set; }
        public int Chk_Ans_Type_ID { get; set; }
    }
    public class ClChecklistConfigAnswerType
    {
        //XXX 
        public int Ans_Type_ID { get; set; }
        public string Ans_Type_Desc { get; set; }
        public string SDesc { get; set; }
        public bool Is_MultiValue { get; set; }
    }

    public class ClChecklist_Response_Data_Values
    {
        public int AnswerID { get; set; }
        public string value { get; set; }
    }


    public class ClsChecklist_Response
    {
        public int Chk_Response_ID { get; set; }
        public int Chk_Config_ID { get; set; }
        public string User_Code { get; set; }
        public int CompanyID { get; set; }
        public int LocationID { get; set; }
        public int DepartmentID { get; set; }
        public List<ClsChecklist_Response_Data> ObjChkResponseData { get; set; }
    }

    public class ClsChecklist_Response_Data
    {
        //public int AnsResponseID { get; set; }
        public int SectionID { get; set; }
        public int QuestionID { get; set; }
        //public string AnswerID { get; set; }
        public int AnswerTypeID { get; set; }
        public List<ClsChecklist_Response_Data_Values> ObjChkResponseDataValue { get; set; }
    }
    public class ClsChecklist_Response_Data_Values
    {

        public int AnswerID { get; set; }
        public string value { get; set; }
    }

    #endregion

    #region Ticketing

    public class clsMasterTicketDetails
    {

        public List<ClsMyActionableTicket> objTickets = new List<ClsMyActionableTicket>();
        public List<ClsTicketActionHistory> objTicketAction = new List<ClsTicketActionHistory>();

    }

    public class ClsMyActionableTicket
    {
        public string TicketID { get; set; }
        public string TicketCode { get; set; }
        public string LocID { get; set; }
        public string Loc_Desc { get; set; }
        public string CategoryID { get; set; }
        public string Category_Desc { get; set; }
        public string SubCategoryID { get; set; }
        public string SubCategory_Desc { get; set; }
        public string Ticket_Date { get; set; }
        public string Ticket_Status { get; set; }
        public string Ticket_ActionStatus { get; set; }
        public string Ticket_Message { get; set; }
        public string Ticket_ImagePath { get; set; }
        public string Level { get; set; }

    }

    public class ClsTicketActionHistory
    {
        public int Level { get; set; }
        public string User { get; set; }
        public string Remarks { get; set; }
        public string ActionDateTime { get; set; }
        public string ExpectedDateTime { get; set; }
        public string Ticket_Status { get; set; }
        public string Ticket_ActionStatus { get; set; }
    }

    public class ClsTicketRaise
    {
        //public string TicketPrefix { get; set; }
        public string LocationID { get; set; }
        public string CategoryID { get; set; }
        public string SubCategoryID { get; set; }
        public string Ticket_Message { get; set; }
        //public string Ticket_ImagePath { get; set; }
        public string EmpCD { get; set; }
        public string RollCD { get; set; }

    }

    public class ClsTicketUpdateAction
    {
        public string TicketID { get; set; }
        public string CloseTicketDesc { get; set; }
        public string TicketAction { get; set; }
        public string CurrentLevel { get; set; }
        public string EmpCD { get; set; }
        public string RollCD { get; set; }

    }

    public class ClsTicketImage
    {
        public string TicketID { get; set; }
        public string EmpCD { get; set; }
        public string RollCD { get; set; }
        public string Ticket_ImagePath { get; set; }
        public string TicketFlag { get; set; }
    }


    public class ClsTicketWorkflow
    {
        public string Level { get; set; }
        public string User_Desc { get; set; }
        public string Group_Desc { get; set; }
        public string Escalate_Time { get; set; }
    }

    public class ClsValidateCompany
    {
        public int Status { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Client_URL { get; set; }
        public string Module_ID { get; set; }
    }


    public class clsSubCate_DeptMst
    {
        public List<ClsSubCategory> objSubCategory = new List<ClsSubCategory>();
        public List<ClsDepartmentName> objDepartmentName = new List<ClsDepartmentName>();
    }

    public class ClsSubCategory
    {
        public int SubCategoryID { get; set; }
        public string CategoryName { get; set; }
    }

    public class ClsDepartmentName
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }

    public class ClsTicketDashboard
    {
        public int OpenTicket { get; set; }
        public int AssignedTicket { get; set; }
        public int AcceptedTicket { get; set; }
        public int InProgressTicket { get; set; }
        public int HoldTicket { get; set; }
        public int ClosedTicket { get; set; }
        public int TotalTicket { get; set; }
        public decimal ClosedTicketPercentage { get; set; }

    }
    #endregion


    #region "ASSET"

    #region "ASSET MASTER DATA"
    public class clsMasterAsset
    {

        public List<clsMasterAssestType> objAssetType = new List<clsMasterAssestType>();
        public List<clsMasterAssestCategory> objAssetCategory = new List<clsMasterAssestCategory>();
        public List<clsMasterAssestVendor> objAssetVendor = new List<clsMasterAssestVendor>();
        public List<clsMasterAssestDepartement> objAssetDepartment = new List<clsMasterAssestDepartement>();
        public List<clsMasterAssestLocation> objAssetLocation = new List<clsMasterAssestLocation>();
        public List<clsMasterAssestAmcType> objAssetAMCType = new List<clsMasterAssestAmcType>();
        public List<clsMasterAssestCurrency> objAssetCurrency = new List<clsMasterAssestCurrency>();
        public List<clsMasterAssestUsers> objAssetUser = new List<clsMasterAssestUsers>();
    }
    public class clsMasterAssestType
    {
        public int Asset_Type_ID { get; set; }
        public string Asset_Type_Desc { get; set; }
    }
    public class clsMasterAssestCategory
    {
        public int Asset_Category_ID { get; set; }
        public int Asset_Type_ID { get; set; }
        public string Category_Desc { get; set; }
    }
    public class clsMasterAssestVendor
    {
        public int Vendor_ID { get; set; }
        public string Vendor_Name { get; set; }
    }

    public class clsMasterAssestDepartement
    {
        public int Department_ID { get; set; }
        public string Dept_Desc { get; set; }
    }
    public class clsMasterAssestLocation
    {
        public int Loc_id { get; set; }
        public string Loc_Desc { get; set; }
    }
    public class clsMasterAssestAmcType
    {
        public int Asset_AMC_Type_ID { get; set; }
        public string Asset_AMC_Type_Desc { get; set; }
    }

    public class clsMasterAssestCurrency
    {
        public int Currency_ID { get; set; }
        public string Currency_Code { get; set; }
    }
    public class clsMasterAssestUsers
    {
        public int User_ID { get; set; }
        public string User_Code { get; set; }
        public string Name { get; set; }
    }


    #endregion

    #region "ASSET Request"
    public class ClsAssetRequest
    {
        public List<ClsAssetRequestDetail> objAssetDetail = new List<ClsAssetRequestDetail>();
        public ClsAssetAMCRequest objAssetAmcDetail = new ClsAssetAMCRequest();
        public List<ClsAssetServiceDetail> objAssetServiceDetailc = new List<ClsAssetServiceDetail>();
    }
    public class ClsAssetRequestDetail
    {
        public int Asset_ID { get; set; }
        public int Asset_Type_ID { get; set; }
        public int Asset_Category_ID { get; set; }
        public string Asset_Name { get; set; }
        public string Asset_Desc { get; set; }
        public string Asset_Make { get; set; }
        public string Asset_Serial_No { get; set; }
        public int Vendor_ID { get; set; }
        public int Department_ID { get; set; }
        public int Loc_id { get; set; }
        public decimal Asset_Cost { get; set; }
        public string Currency_Type { get; set; }
        public string Asset_Purchase_Date { get; set; }
        public bool Asset_Is_AMC_Active { get; set; }
        public int Company_ID { get; set; }
        public string Loc_Desc { get; set; }

        public List<ClsAssetRequestDoc> objAssetDoc = new List<ClsAssetRequestDoc>();
    }
    public class ClsAssetRequestDoc
    {
        public string Asset_Doc_Type { get; set; }
        public string ImagePath { get; set; }
    }
    public class ClsAssetAMCRequest
    {
        public List<ClsAssetAMCDetail> objAssetAmc = new List<ClsAssetAMCDetail>();
        public List<ClsAssetAMCHistoryDetail> objAssetAmcHistory = new List<ClsAssetAMCHistoryDetail>();
    }
    public class ClsAssetAMCDetail
    {
        public int Asset_AMC_ID { get; set; }
        public int Asset_AMC_Type_ID { get; set; }
        public int Asset_ID { get; set; }
        public string AMC_Desc { get; set; }
        public string AMC_Start_Date { get; set; }
        public string AMC_End_Date { get; set; }
        public int Assigned_Vendor { get; set; }
        public string AMC_Inclusions { get; set; }
        public string AMC_Exclusions { get; set; }
        public string AdditionalRemarks { get; set; }
        public string AMC_Status { get; set; }
        public string Vendor_Name { get; set; }

        public List<ClsAssetAMCDoc> objAssetAmcDoc = new List<ClsAssetAMCDoc>();
    }
    public class ClsAssetAMCDoc
    {
        public string Asset_AMC_Doc_Type { get; set; }
        public string ImagePath { get; set; }
    }
    public class ClsAssetAMCHistoryDetail
    {
        public int Asset_AMC_ID { get; set; }
        public int Asset_AMC_Type_ID { get; set; }
        public int Asset_ID { get; set; }
        public string AMC_Desc { get; set; }
        public string AMC_Start_Date { get; set; }
        public string AMC_End_Date { get; set; }
        public int Assigned_Vendor { get; set; }
        public string AMC_Inclusions { get; set; }
        public string AMC_Exclusions { get; set; }
        public string AdditionalRemarks { get; set; }
        public string AMC_Status { get; set; }
        public string Vendor_Name { get; set; }
        public string Asset_AMC_Type_Desc { get; set; }

        public List<ClsAssetAMCHistoryDoc> objAssetAmcHistoryDoc = new List<ClsAssetAMCHistoryDoc>();
    }
    public class ClsAssetAMCHistoryDoc
    {
        public string Asset_AMC_Doc_Type { get; set; }
        public string ImagePath { get; set; }
    }
    public class ClsAssetServiceDetail
    {
        public int Schedule_ID { get; set; }
        public int Asset_ID { get; set; }
        public string Service_Date { get; set; }
        public string Alert_Date { get; set; }
        public int Assigned_To { get; set; }
        public string Service_Status { get; set; }
        public string Remarks { get; set; }
        public int Alert_Day { get; set; }
    }
    #endregion


    public class ClsAssetService_Response
    {
        public string LoggedInUserID { get; set; }
        public string AssetID { get; set; }
        public string AssetScheduleID { get; set; }
        public string Flag { get; set; }
        public List<ClsAssetService_Response_Data> ObjAssetServResponseData { get; set; }
    }
    public class ClsAssetService_Response_Data
    {
        // public int Asset_Service_ID { get; set; } 
        public string Asset_Service_Date { get; set; }
        public string Asset_Service_AssignTo { get; set; }
        public string AlertBeforeDays { get; set; }
        public string Asset_Service_Remarks { get; set; }
    }

    #endregion

    #region CSM
    public class ClCSMConfig
    {
        public List<ClCSMConfigHead> CSMConfigData { get; set; }
        public List<ClCSMConfigQuestion> CSMConfigInQuestion { get; set; }
        public List<ClCSMConfigQuestion> CSMConfigOutQuestion { get; set; }
        public List<ClCSMConfigAnswerType> CSMConfigAnswerType { get; set; }
        public List<ClCSMConfigTerms> CSMConfigTerms { get; set; }

    }
    public class ClCSMConfigHead
    {
        //XXX
        public int CSM_Response_ID { get; set; }
        public int Location_ID { get; set; }
        public int Department_ID { get; set; }
        public string Status { get; set; }
        public string ActionStatus { get; set; }

        public int CSM_Config_ID { get; set; }
        //public string CSM_Title { get; set; }
        public string CSM_Desc { get; set; }
        public bool Is_Cost_Enable { get; set; }
        public string Cost { get; set; }
    }
    public class ClCSMConfigQuestion
    {
        //XXX
        public int CSM_Question_ID { get; set; }
        public string Qn_Desc { get; set; }
        public int CSM_Ans_Type_ID { get; set; }

        //public List<ClCSMConfigAnswerType> ObjClCSMConfigAnswerType { get; set; }

        public List<ClCSMConfigAnswer> ObjClCSMConfigAnswer { get; set; }
        //public List<ClCSM_Response_Data_Values> ObjClCSM_Response_Data_Values { get; set; }
    }
    
    public class ClCSMConfigAnswer
    {
        //XXX
        //public int CSM_Ans_Value_ID { get; set; }
        public int CSM_Question_ID { get; set; }
        public bool Ans_Is_Flag { get; set; }
       // public bool Is_Default { get; set; }
        public string CSM_Ans_Desc { get; set; }
        public int CSM_Ans_Type_ID { get; set; }
    }
    public class ClCSMConfigAnswerType
    {
        //XXX 
        public int Ans_Type_ID { get; set; }
        public string Ans_Type_Desc { get; set; }
        public string SDesc { get; set; }
        public bool Is_MultiValue { get; set; }
    }
    public class ClCSMConfigTerms
    {
        //XXX 
        public int Terms_ID { get; set; }
        public int Config_Id { get; set; }
        public string Term_Desc { get; set; }
    }

    #endregion
}