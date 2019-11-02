using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for ProjectConfigurator
/// </summary>
public class ProjectConfigurator
{
    #region[constants]
    public static string _Action = "@Action";
    public static string _PCId = "@PCId";
    public static string _PCNo = "@PCNo";
    public static string _PCName = "@PCName";
    public static string _ProjectTypeId = "@ProjectTypeId";
    public static string _ProjectSubTypeId = "@ProjectSubTypeId";
    public static string _Address = "@Address";
    public static string _NOofTowers = "@NOofTowers";
    public static string _TowerName = "@TowerName";
    public static string _Floors = "@Floors";
    public static string _Units = "@Units";
    public static string _IsAll = "@IsAll";
    public static string _SqftAll = "@SqftAll";
    public static string _SqftEven = "@SqftEven";
    public static string _SqftOdd = "@SqftOdd";
    public static string _LayoutPath = "@LayoutPath";
    public static string _MapPath = "@MapPath";
    public static string _VideoPath = "@VideoPath";
    public static string _FlatNo = "@FlatNo";
    public static string _FlatTypeId = "@FlatTypeId";
    public static string _UsedCount = "@UsedCount";
    public static string _PCDetailId = "@PCDetailId";
    public static string _IsActive = "@IsActive";

    public static string _ProjectBankName="@ProjectBankName";
    public static string _ProjectBranchName	="@ProjectBranchName";
    public static string _ProjectAccountNo="@ProjectAccountNo";
    public static string _ProjectIFSCCode="@ProjectIFSCCode";
    public static string _ProjectMICRCode = "@ProjectMICRCode";
    
    public static string _SqFt = "@SqFt";
    public static string _AmenityId = "@AmenityId";
    public static string _Title = "@Title";
    public static string _Details= "@Details";
    public static string _SpecificationId = "@SpecificationId"; 
    
    public static string _UserId = "@UserId";
    public static string _LoginDate = "@LoginDate";
    public static string _IsDeleted = "@IsDeleted";
    public static string _StrCondition = "@StrCond";

    public static string _FloorNo = "@FloorNo";
    public static string _FacingTypeId = "@FacingTypeId";
    public static string _TerraceArea = "@TerraceArea";
    public static string _GardenArea = "@GardenArea";
    public static string _SaleableArea = "@SaleableArea";
    public static string _CarpetArea = "@CarpetArea";

    public static string _SqftSaleBuiltUp = "@SqftSaleBuiltUp";
	public static string _TerraceAreaSaleBuiltUp = "@TerraceAreaSaleBuiltUp";
    public static string _GardenAreaSaleBuiltUp = "@GardenAreaSaleBuiltUp";
    public static string _FlatAgreementCarpet = "@FlatAgreementCarpet";
    public static string _TerraceAgreementCarpet = "@TerraceAgreementCarpet";
    public static string _FlatAgreementBuiltUp = "@FlatAgreementBuiltUp";
    public static string _TerraceAgreementBuiltUp = "@TerraceAgreementBuiltUp";

   


    //ProjectImageMaster
    public static string _ImagePath = "@ImagePath";
    public static string _PlanPath = "@PlanPath";
    public static string _LogoPath = "@LogoPath";
    public static string _AmenityPath = "@AmenityPath";
    public static string _SpecPath = "@SpecPath";

    //ProjectCompanyMaster
    public static string _Company ="@Company";
    public static string _CompanyAddress ="@CompanyAddress";
    public static string _LogoImg ="@LogoImg";
   
    //AccountName
     public static string _StampAC ="@StampAC";
     public static string _RegistrationAC ="@RegistrationAC";
     public static string _VatAC ="@VatAC";
     public static string _CollectionAC ="@CollectionAC";
     public static string _ServiceTaxAC = "@ServiceTaxAC";

    //Cancel Charge
     public static string _CancelCharge = "@CancelCharge";

     //Interest & Grace 
     public static string _InterestRate = "@InterestRate";
     public static string _GracePeriod = "@GracePeriod";

    //Percent for Terrace And Garden Area
     public static string _TerraceAreaPer = "@TerraceAreaPer";
     public static string _GardenAreaPer = "@GardenAreaPer";

     public static string _DocId = "@DocId";
     public static string _DocPath = "@DocPath";
     public static string _IsChecked = "@IsChecked";
     public static string _FlatLayoutPath = "@FlatLayoutPath";
     public static string _FlagBooked = "@FlagBooked";

    public static string _Loading = "@Loading";
    public static string _LandArea = "@LandArea";
    public static string _SaleableFSI = "@SaleableFSI";
     
    #endregion

    #region Defination

    #region RTGS DTLS
    private string m_ProjectBankName;

    public string ProjectBankName
    {
        get { return m_ProjectBankName; }
        set { m_ProjectBankName = value; }
    }
    private string m_ProjectBranchName;

    public string ProjectBranchName
    {
        get { return m_ProjectBranchName; }
        set { m_ProjectBranchName = value; }
    }
    private string m_ProjectAccountNo;

    public string ProjectAccountNo
    {
        get { return m_ProjectAccountNo; }
        set { m_ProjectAccountNo = value; }
    }
    private string m_ProjectIFSCCode;

    public string ProjectIFSCCode
    {
        get { return m_ProjectIFSCCode; }
        set { m_ProjectIFSCCode = value; }
    }
    private string m_ProjectMICRCode;

    public string ProjectMICRCode
    {
        get { return m_ProjectMICRCode; }
        set { m_ProjectMICRCode = value; }
    }
    #endregion

    private String m_Loading;

    public String Loading
    {
        get { return m_Loading; }
        set { m_Loading = value; }
    }

    private Decimal m_LandArea;

    public Decimal LandArea
    {
        get { return m_LandArea; }
        set { m_LandArea = value; }
    }

    private Decimal m_SaleableFSI;

    public Decimal SaleableFSI
    {
        get { return m_SaleableFSI; }
        set { m_SaleableFSI = value; }
    }

     private bool m_FlagBooked;
     public bool FlagBooked
     {
         get { return m_FlagBooked; }
         set { m_FlagBooked = value; }
     }
    
     private String m_FlatLayoutPath;

     public String FlatLayoutPath
     {
         get { return m_FlatLayoutPath; }
         set { m_FlatLayoutPath = value; }
     }
    private Int32 m_Action;
    public Int32 Action
    {
        get { return m_Action; }
        set { m_Action = value; }
    }

    private bool m_IsActive;
    public bool IsActive
    {
        get { return m_IsActive; }
        set { m_IsActive = value; }
    }

    private Int32 m_PCId;

    public Int32 PCId
    {
        get { return m_PCId; }
        set { m_PCId = value; }
    }
    
    private string m_PCNo;

    public string PCNo
    {
        get { return m_PCNo; }
        set { m_PCNo = value; }
    }
    private string m_PCName;

    public string PCName
    {
        get { return m_PCName; }
        set { m_PCName = value; }
    }
    private Int32 m_ProjectTypeId;

    public Int32 ProjectTypeId
    {
        get { return m_ProjectTypeId; }
        set { m_ProjectTypeId = value; }
    }
    private Int32 m_ProjectSubTypeId;

    public Int32 ProjectSubTypeId
    {
        get { return m_ProjectSubTypeId; }
        set { m_ProjectSubTypeId = value; }
    }

    private string m_Address;

    public string Address
    {
        get { return m_Address; }
        set { m_Address = value; }
    }
   
    private Int32 m_NOofTowers;

    public Int32 NOofTowers
    {
        get { return m_NOofTowers; }
        set { m_NOofTowers = value; }
    }
    private string m_TowerName;

    public string TowerName
    {
        get { return m_TowerName; }
        set { m_TowerName = value; }
    }
    private Int32 m_Floors;

    public Int32 Floors
    {
        get { return m_Floors; }
        set { m_Floors = value; }
    }
    private Int32 m_Units;

    public Int32 Units
    {
        get { return m_Units; }
        set { m_Units = value; }
    }
    private bool m_IsAll;

    public bool IsAll
    {
        get { return m_IsAll; }
        set { m_IsAll = value; }
    }
    private decimal m_SqftAll;

    public decimal SqftAll
    {
        get { return m_SqftAll; }
        set { m_SqftAll = value; }
    }
    private decimal m_SqftEven;

    public decimal SqftEven
    {
        get { return m_SqftEven; }
        set { m_SqftEven = value; }
    }
    private decimal m_SqftOdd;

    public decimal SqftOdd
    {
        get { return m_SqftOdd; }
        set { m_SqftOdd = value; }
    }
    private string m_LayoutPath;

    public string LayoutPath
    {
        get { return m_LayoutPath; }
        set { m_LayoutPath = value; }
    }
    private string m_MapPath;

    public string MapPath
    {
        get { return m_MapPath; }
        set { m_MapPath = value; }
    }
    private string m_VideoPath;

    public string VideoPath
    {
        get { return m_VideoPath; }
        set { m_VideoPath = value; }
    }


    private string m_FlatNo;

    public string FlatNo
    {
        get { return m_FlatNo; }
        set { m_FlatNo = value; }
    }

    private int m_FlatTypeId;

    public int FlatTypeId
    {
        get { return m_FlatTypeId; }
        set { m_FlatTypeId = value; }
    }

    
    private decimal m_Sqft;

    public decimal Sqft
    {
        get { return m_Sqft; }
        set { m_Sqft = value; }
    }

    private Int32 m_AmenityId;

    public Int32 AmenityId
    {
        get { return m_AmenityId; }
        set { m_AmenityId = value; }
    }

    private string m_Title;

    public string Title
    {
        get { return m_Title; }
        set { m_Title = value; }
    }

    private string m_Details;

    public string Details
    {
        get { return m_Details; }
        set { m_Details = value; }
    }

    private Int32 m_SpecificationId;

    public Int32 SpecificationId
    {
        get { return m_SpecificationId; }
        set { m_SpecificationId = value; }
    }

    private string m_ImagePath;

    public string ImagePath
    {
        get { return m_ImagePath; }
        set { m_ImagePath = value; }
    }

    private string m_PlanPath;

    public string PlanPath
    {
        get { return m_PlanPath; }
        set { m_PlanPath = value; }
    }


    private string m_LogoPath;

    public string LogoPath
    {
        get { return m_LogoPath; }
        set { m_LogoPath = value; }
    }
    //ProjectCompanyMaster
    private string m_Company;

    public string Company
    {
        get { return m_Company; }
        set { m_Company = value; }
    }
    private string m_CompanyAddress;

    public string CompanyAddress
    {
        get { return m_CompanyAddress; }
        set { m_CompanyAddress = value; }
    }
    private string m_LogoImg;

    public string LogoImg
    {
        get { return m_LogoImg; }
        set { m_LogoImg = value; }
    }
    private string m_AmenityPath;

    public string AmenityPath
    {
        get { return m_AmenityPath; }
        set { m_AmenityPath = value; }
    }
    private string m_SpecPath;

    public string SpecPath
    {
        get { return m_SpecPath; }
        set { m_SpecPath = value; }
    }

    private Int32 m_UserId;
    public Int32 UserId
    {
        get { return m_UserId; }
        set { m_UserId = value; }
    }

    private DateTime m_LoginDate;
    public DateTime LoginDate
    {
        get { return m_LoginDate; }
        set { m_LoginDate = value; }
    }

    private bool m_IsDeleted;

    public bool IsDeleted
    {
        get { return m_IsDeleted; }
        set { m_IsDeleted = value; }
    }

    private string m_StrCondition;

    public string StrCondition
    {
        get { return m_StrCondition; }
        set { m_StrCondition = value; }
    }

    private string m_StampAC;

    public string StampAC
    {
        get { return m_StampAC; }
        set { m_StampAC = value; }
    }
    private string m_RegistrationAC;

    public string RegistrationAC
    {
        get { return m_RegistrationAC; }
        set { m_RegistrationAC = value; }
    }
    private string m_VatAC;

    public string VatAC
    {
        get { return m_VatAC; }
        set { m_VatAC = value; }
    }
    private string m_CollectionAC;

    private string m_ServiceTaxAC;

    public string ServiceTaxAC
    {
        get { return m_ServiceTaxAC; }
        set { m_ServiceTaxAC = value; }
    }
    
    public string CollectionAC
    {
        get { return m_CollectionAC; }
        set { m_CollectionAC = value; }
    }

    private decimal m_CancelCharge;

    public decimal CancelCharge
    {
        get { return m_CancelCharge; }
        set { m_CancelCharge = value; }
    }

    private decimal m_InterestRate;

    public decimal InterestRate
    {
        get { return m_InterestRate; }
        set { m_InterestRate = value; }
    }
    private Int32 m_GracePeriod;

    public Int32 GracePeriod
    {
        get { return m_GracePeriod; }
        set { m_GracePeriod = value; }
    }

    private int m_FloorNo;

    public int FloorNo
    {
        get { return m_FloorNo; }
        set { m_FloorNo = value; }
    }

    private int m_FacingTypeId;

    public int FacingTypeId
    {
        get { return m_FacingTypeId; }
        set { m_FacingTypeId = value; }
    }

    private decimal m_TerraceArea;

    public decimal TerraceArea
    {
        get { return m_TerraceArea; }
        set { m_TerraceArea = value; }
    }
    private decimal m_GardenArea;

    public decimal GardenArea
    {
        get { return m_GardenArea; }
        set { m_GardenArea = value; }
    }

    private decimal m_CarpetArea;

    public decimal CarpetArea
    {
        get { return m_CarpetArea; }
        set { m_CarpetArea = value; }
    }


    private decimal m_SaleableArea;

    public decimal SaleableArea
    {
        get { return m_SaleableArea; }
        set { m_SaleableArea = value; }
    }

    private decimal m_SqftSaleBuiltUp;

    public decimal SqftSaleBuiltUp
    {
        get { return m_SqftSaleBuiltUp; }
        set { m_SqftSaleBuiltUp = value; }
    }
    private decimal m_TerraceAreaSaleBuiltUp;

    public decimal TerraceAreaSaleBuiltUp
    {
        get { return m_TerraceAreaSaleBuiltUp; }
        set { m_TerraceAreaSaleBuiltUp = value; }
    }
    private decimal m_GardenAreaSaleBuiltUp;

    public decimal GardenAreaSaleBuiltUp
    {
        get { return m_GardenAreaSaleBuiltUp; }
        set { m_GardenAreaSaleBuiltUp = value; }
    }
    private decimal m_FlatAgreementCarpet;

    public decimal FlatAgreementCarpet
    {
        get { return m_FlatAgreementCarpet; }
        set { m_FlatAgreementCarpet = value; }
    }
    private decimal m_TerraceAgreementCarpet;

    public decimal TerraceAgreementCarpet
    {
        get { return m_TerraceAgreementCarpet; }
        set { m_TerraceAgreementCarpet = value; }
    }

    private decimal m_FlatAgreementBuiltUp;

    public decimal FlatAgreementBuiltUp
    {
        get { return m_FlatAgreementBuiltUp; }
        set { m_FlatAgreementBuiltUp = value; }
    }

    private decimal m_TerraceAgreementBuiltUp;

    public decimal TerraceAgreementBuiltUp
    {
        get { return m_TerraceAgreementBuiltUp; }
        set { m_TerraceAgreementBuiltUp = value; }
    }


    private decimal m_TerraceAreaPer;

    public decimal TerraceAreaPer
    {
        get { return m_TerraceAreaPer; }
        set { m_TerraceAreaPer = value; }
    }
    private decimal m_GardenAreaPer;

    public decimal GardenAreaPer
    {
        get { return m_GardenAreaPer; }
        set { m_GardenAreaPer = value; }
    }


    private int m_DocId;

    public int DocId
    {
        get { return m_DocId; }
        set { m_DocId = value; }
    }
    private string m_DocPath;

    public string DocPath
    {
        get { return m_DocPath; }
        set { m_DocPath = value; }
    }

    private bool m_IsChecked;

    public bool IsChecked
    {
        get { return m_IsChecked; }
        set { m_IsChecked = value; }
    }
    private int m_UsedCount;

    public int UsedCount
    {
        get { return m_UsedCount; }
        set { m_UsedCount = value; }
    }
    private int m_PCDetailId;

    public int PCDetailId
    {
        get { return m_PCDetailId; }
        set { m_PCDetailId = value; }
    }
    

    #endregion

    #region[procedure]
    public static string SP_ProjectConfiguratorMaster = "SP_ProjectConfiguratorMaster";
    public static string SP_ProjectConfiguratorMaster1 = "SP_ProjectConfiguratorMaster1";
    public static string SP_ProjectConfiguratorMaster2 = "SP_ProjectConfiguratorMaster2";
    public static string SP_ProjectConfiguratorMaster_Part1 = "SP_ProjectConfiguratorMaster_Part1";
    
    #endregion

    public ProjectConfigurator()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
