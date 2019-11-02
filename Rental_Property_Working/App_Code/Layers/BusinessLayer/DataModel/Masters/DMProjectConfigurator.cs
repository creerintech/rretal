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
using System.Collections.Generic;

using System.Data.SqlClient;
using Build.DALSQLHelper;
using Build.DB;
using Build.EntityClass;
using Build.Utility;
/// <summary>
/// Summary description for DMProjectConfigurator
/// </summary>

namespace Build.DataModel
{
    public class DMProjectConfigurator:Utility.Setting
    {
        public int InsertProjectConfi(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCNo = new SqlParameter(ProjectConfigurator._PCNo, SqlDbType.NVarChar);
                SqlParameter pPCName = new SqlParameter(ProjectConfigurator._PCName, SqlDbType.NVarChar);

                SqlParameter pProjectTypeId = new SqlParameter(ProjectConfigurator._ProjectTypeId, SqlDbType.BigInt);
                SqlParameter pProjectSubTypeId = new SqlParameter(ProjectConfigurator._ProjectSubTypeId, SqlDbType.BigInt);
                SqlParameter pAddress = new SqlParameter(ProjectConfigurator._Address, SqlDbType.NVarChar);

                SqlParameter pNOofTowers = new SqlParameter(ProjectConfigurator._NOofTowers, SqlDbType.BigInt);
                SqlParameter pStampAC = new SqlParameter(ProjectConfigurator._StampAC, SqlDbType.NVarChar);
                SqlParameter pRegistrationAC = new SqlParameter(ProjectConfigurator._RegistrationAC, SqlDbType.NVarChar);

                SqlParameter pVatAC = new SqlParameter(ProjectConfigurator._VatAC, SqlDbType.NVarChar);
                SqlParameter pServiceTaxAC = new SqlParameter(ProjectConfigurator._ServiceTaxAC, SqlDbType.NVarChar);
                SqlParameter pCollectionAC = new SqlParameter(ProjectConfigurator._CollectionAC, SqlDbType.NVarChar);

                SqlParameter pCancelCharge = new SqlParameter(ProjectConfigurator._CancelCharge, SqlDbType.Decimal);
                SqlParameter pTerraceAreaPer = new SqlParameter(ProjectConfigurator._TerraceAreaPer, SqlDbType.Decimal);
                SqlParameter pGardenAreaPer = new SqlParameter(ProjectConfigurator._GardenAreaPer, SqlDbType.Decimal);

                SqlParameter pLoading = new SqlParameter(ProjectConfigurator._Loading, SqlDbType.NVarChar);
                SqlParameter pLandArea = new SqlParameter(ProjectConfigurator._LandArea, SqlDbType.Decimal);
                SqlParameter pSaleableFSI = new SqlParameter(ProjectConfigurator._SaleableFSI, SqlDbType.Decimal);

                SqlParameter pInterestRate = new SqlParameter(ProjectConfigurator._InterestRate, SqlDbType.Decimal);
                SqlParameter pGracePeriod = new SqlParameter(ProjectConfigurator._GracePeriod, SqlDbType.BigInt);

                SqlParameter pProjectBankName = new SqlParameter(ProjectConfigurator._ProjectBankName, SqlDbType.NVarChar);
                SqlParameter pProjectBranchName = new SqlParameter(ProjectConfigurator._ProjectBranchName, SqlDbType.NVarChar);
                SqlParameter pProjectAccountNo = new SqlParameter(ProjectConfigurator._ProjectAccountNo, SqlDbType.NVarChar);
                SqlParameter pProjectIFSCCode = new SqlParameter(ProjectConfigurator._ProjectIFSCCode, SqlDbType.NVarChar);
                SqlParameter pProjectMICRCode = new SqlParameter(ProjectConfigurator._ProjectMICRCode, SqlDbType.NVarChar);
               
                SqlParameter pCreatedBy = new SqlParameter(ProjectConfigurator._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(ProjectConfigurator._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pPCNo.Value = Entity_PC.PCNo;
                pPCName.Value = Entity_PC.PCName;

                pProjectTypeId.Value = Entity_PC.ProjectTypeId;
                pProjectSubTypeId.Value = Entity_PC.ProjectSubTypeId;
                pAddress.Value = Entity_PC.Address;

                pNOofTowers.Value = Entity_PC.NOofTowers;
                pStampAC.Value = Entity_PC.StampAC;
                pRegistrationAC.Value = Entity_PC.RegistrationAC;

                pVatAC.Value = Entity_PC.VatAC;
                pCollectionAC.Value = Entity_PC.CollectionAC;
                pServiceTaxAC.Value = Entity_PC.ServiceTaxAC;

                pCancelCharge.Value = Entity_PC.CancelCharge;
                pTerraceAreaPer.Value = Entity_PC.TerraceAreaPer;
                pGardenAreaPer.Value = Entity_PC.GardenAreaPer;

                pCreatedBy.Value = Entity_PC.UserId;
                pCreatedDate.Value = Entity_PC.LoginDate;

                pLoading.Value = Entity_PC.Loading;
                pLandArea.Value = Entity_PC.LandArea;
                pSaleableFSI.Value = Entity_PC.SaleableFSI;

                pInterestRate.Value = Entity_PC.InterestRate;
                pGracePeriod.Value = Entity_PC.GracePeriod;

                pProjectBankName.Value = Entity_PC.ProjectBankName;
                pProjectBranchName.Value =Entity_PC.ProjectBranchName ;
                pProjectAccountNo.Value = Entity_PC.ProjectAccountNo;
                pProjectIFSCCode.Value = Entity_PC.ProjectIFSCCode;
                pProjectMICRCode.Value =Entity_PC.ProjectMICRCode;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCNo, pPCName,pProjectTypeId,pProjectSubTypeId,pAddress,pNOofTowers,
                                       pStampAC,pRegistrationAC,pVatAC,pServiceTaxAC,pCollectionAC,pCancelCharge,pTerraceAreaPer,
                                       pGardenAreaPer,pCreatedBy, pCreatedDate,pLoading,pLandArea,pSaleableFSI,pInterestRate,pGracePeriod,
                pProjectBankName,pProjectBranchName,pProjectAccountNo,pProjectIFSCCode,pProjectMICRCode};

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int InsertPCDetail(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);
                SqlParameter pTowerName = new SqlParameter(ProjectConfigurator._TowerName, SqlDbType.NVarChar);
                SqlParameter pFlatNo = new SqlParameter(ProjectConfigurator._FlatNo, SqlDbType.NVarChar);
                SqlParameter pFlatTypeId = new SqlParameter(ProjectConfigurator._FlatTypeId, SqlDbType.BigInt);
                SqlParameter pFloors = new SqlParameter(ProjectConfigurator._Floors, SqlDbType.BigInt);
                SqlParameter pUnits = new SqlParameter(ProjectConfigurator._Units, SqlDbType.BigInt);
                SqlParameter pIsAll = new SqlParameter(ProjectConfigurator._IsAll, SqlDbType.Bit);
                SqlParameter pSqFt = new SqlParameter(ProjectConfigurator._SqFt, SqlDbType.Decimal);
                SqlParameter pSqftAll = new SqlParameter(ProjectConfigurator._SqftAll, SqlDbType.Decimal);
                SqlParameter pSqftEven = new SqlParameter(ProjectConfigurator._SqftEven, SqlDbType.Decimal);
                SqlParameter pSqftOdd = new SqlParameter(ProjectConfigurator._SqftOdd, SqlDbType.Decimal);
                SqlParameter pFloorNo = new SqlParameter(ProjectConfigurator._FloorNo, SqlDbType.BigInt);
                SqlParameter pFacingType = new SqlParameter(ProjectConfigurator._FacingTypeId, SqlDbType.BigInt);
                SqlParameter pTerraceArea = new SqlParameter(ProjectConfigurator._TerraceArea, SqlDbType.Decimal);
                SqlParameter pGardenArea = new SqlParameter(ProjectConfigurator._GardenArea, SqlDbType.Decimal);
                SqlParameter pCarpetArea = new SqlParameter(ProjectConfigurator._CarpetArea, SqlDbType.Decimal);

                SqlParameter pSqftSaleBuiltUp = new SqlParameter(ProjectConfigurator._SqftSaleBuiltUp, SqlDbType.Decimal);
                SqlParameter pTerraceAreaSaleBuiltUp = new SqlParameter(ProjectConfigurator._TerraceAreaSaleBuiltUp, SqlDbType.Decimal);
                SqlParameter pGardenAreaSaleBuiltUp = new SqlParameter(ProjectConfigurator._GardenAreaSaleBuiltUp, SqlDbType.Decimal);
                SqlParameter pSaleableArea = new SqlParameter(ProjectConfigurator._SaleableArea, SqlDbType.Decimal);

                SqlParameter pFlatAgreementCarpet = new SqlParameter(ProjectConfigurator._FlatAgreementCarpet, SqlDbType.Decimal);
                SqlParameter pTerraceAgreementCarpet = new SqlParameter(ProjectConfigurator._TerraceAgreementCarpet, SqlDbType.Decimal);

                SqlParameter pFlatAgreementBuiltUp = new SqlParameter(ProjectConfigurator._FlatAgreementBuiltUp, SqlDbType.Decimal);
                SqlParameter pTerraceAgreementBuiltUp = new SqlParameter(ProjectConfigurator._TerraceAgreementBuiltUp, SqlDbType.Decimal);


                SqlParameter pFlatLayoutPath = new SqlParameter(ProjectConfigurator._FlatLayoutPath, SqlDbType.NVarChar);
                SqlParameter pTerraceAreaPer = new SqlParameter(ProjectConfigurator._TerraceAreaPer, SqlDbType.Decimal);
                SqlParameter pGardenAreaPer = new SqlParameter(ProjectConfigurator._GardenAreaPer, SqlDbType.Decimal);
                
                pAction.Value = 4;
                pPCId.Value = Entity_PC.PCId;
                pTowerName.Value = Entity_PC.TowerName;
                pFlatNo.Value = Entity_PC.FlatNo;
                pFlatTypeId.Value = Entity_PC.FlatTypeId;
                pFloors.Value = Entity_PC.Floors;
                pUnits.Value = Entity_PC.Units;
                pIsAll.Value = Entity_PC.IsAll;
                pSqFt.Value = Entity_PC.Sqft;
                pSqftAll.Value = Entity_PC.SqftAll;
                pSqftEven.Value = Entity_PC.SqftEven;
                pSqftOdd.Value = Entity_PC.SqftOdd;
                pFloorNo.Value = Entity_PC.FloorNo;
                pFacingType.Value = Entity_PC.FacingTypeId;
                pTerraceArea.Value = Entity_PC.TerraceArea;
                pGardenArea.Value = Entity_PC.GardenArea;
                pCarpetArea.Value = Entity_PC.CarpetArea;

                pSqftSaleBuiltUp.Value = Entity_PC.SqftSaleBuiltUp;
                pTerraceAreaSaleBuiltUp.Value = Entity_PC.TerraceAreaSaleBuiltUp;
                pGardenAreaSaleBuiltUp.Value = Entity_PC.GardenAreaSaleBuiltUp;
                pSaleableArea.Value = Entity_PC.SaleableArea;

                pFlatAgreementCarpet.Value = Entity_PC.FlatAgreementCarpet;
                pTerraceAgreementCarpet.Value = Entity_PC.TerraceAgreementCarpet;

                pFlatAgreementBuiltUp.Value = Entity_PC.FlatAgreementBuiltUp;
                pTerraceAgreementBuiltUp.Value = Entity_PC.TerraceAgreementBuiltUp;
                
                pFlatLayoutPath.Value = Entity_PC.FlatLayoutPath;
                pTerraceAreaPer.Value= Entity_PC.TerraceAreaPer;
                pGardenAreaPer.Value = Entity_PC.GardenAreaPer;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCId, pTowerName, pFlatNo, pFlatTypeId, pFloors, 
                    pUnits, pIsAll, pSqFt, pSqftAll, pSqftEven, pSqftOdd,pFloorNo,pFacingType,pTerraceArea,pGardenArea,
                    pCarpetArea,pSaleableArea,pFlatLayoutPath,pTerraceAreaPer,pGardenAreaPer,pSqftSaleBuiltUp,pTerraceAreaSaleBuiltUp,
                pGardenAreaSaleBuiltUp,pFlatAgreementCarpet,pTerraceAgreementCarpet,pFlatAgreementBuiltUp,pTerraceAgreementBuiltUp};

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster1, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }


        public int InsertAmenityDetail(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);
                SqlParameter pAmenityId = new SqlParameter(ProjectConfigurator._AmenityId, SqlDbType.BigInt);
                SqlParameter pTitle = new SqlParameter(ProjectConfigurator._Title, SqlDbType.NVarChar);
                SqlParameter pDetails = new SqlParameter(ProjectConfigurator._Details, SqlDbType.NVarChar);



                pAction.Value = 2;
                pPCId.Value = Entity_PC.PCId;
                pAmenityId.Value = Entity_PC.AmenityId;
                pTitle.Value = Entity_PC.Title;
                pDetails.Value = Entity_PC.Details;


                SqlParameter[] param = new SqlParameter[] { pAction, pPCId, pAmenityId, pTitle, pDetails };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster1, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int InsertProjectImage(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);
                SqlParameter pImagePath = new SqlParameter(ProjectConfigurator._ImagePath, SqlDbType.NVarChar);

                pAction.Value = 5;
                pPCId.Value = Entity_PC.PCId;
                pImagePath.Value = Entity_PC.ImagePath;



                SqlParameter[] param = new SqlParameter[] { pAction, pPCId,pImagePath};

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster1, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int InsertProjectLayout(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);
                SqlParameter pLayoutPath = new SqlParameter(ProjectConfigurator._LayoutPath, SqlDbType.NVarChar);

                pAction.Value = 6;
                pPCId.Value = Entity_PC.PCId;
                pLayoutPath.Value = Entity_PC.LayoutPath;



                SqlParameter[] param = new SqlParameter[] { pAction, pPCId, pLayoutPath };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster1, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int InsertProjectMap(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);
                SqlParameter pMapPath = new SqlParameter(ProjectConfigurator._MapPath, SqlDbType.NVarChar);

                pAction.Value = 8;
                pPCId.Value = Entity_PC.PCId;
                pMapPath.Value = Entity_PC.MapPath;



                SqlParameter[] param = new SqlParameter[] { pAction, pPCId, pMapPath };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster1, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int InsertProjectLogo(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);
                SqlParameter pLogoPath = new SqlParameter(ProjectConfigurator._LogoPath, SqlDbType.NVarChar);

                pAction.Value = 7;
                pPCId.Value = Entity_PC.PCId;
                pLogoPath.Value = Entity_PC.LogoPath;



                SqlParameter[] param = new SqlParameter[] { pAction, pPCId, pLogoPath };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster1, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int InsertProjectVideo(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);
                SqlParameter pVideoPath = new SqlParameter(ProjectConfigurator._VideoPath, SqlDbType.NVarChar);

                pAction.Value = 10;
                pPCId.Value = Entity_PC.PCId;
                pVideoPath.Value = Entity_PC.VideoPath;



                SqlParameter[] param = new SqlParameter[] { pAction, pPCId, pVideoPath };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster1, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int InsertProjectPlan(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);
                SqlParameter pPlanPath = new SqlParameter(ProjectConfigurator._PlanPath, SqlDbType.NVarChar);

                pAction.Value = 9;
                pPCId.Value = Entity_PC.PCId;
                pPlanPath.Value = Entity_PC.PlanPath;



                SqlParameter[] param = new SqlParameter[] { pAction, pPCId, pPlanPath };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster1, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int InsertAmenityImage(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);
                SqlParameter pAmenityPath = new SqlParameter(ProjectConfigurator._AmenityPath, SqlDbType.NVarChar);

                pAction.Value = 3;
                pPCId.Value = Entity_PC.PCId;
                pAmenityPath.Value = Entity_PC.AmenityPath;



                SqlParameter[] param = new SqlParameter[] { pAction, pPCId, pAmenityPath };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster2, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int InsertSpecImage(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);
                SqlParameter pSpecPath = new SqlParameter(ProjectConfigurator._SpecPath, SqlDbType.NVarChar);

                pAction.Value = 4;
                pPCId.Value = Entity_PC.PCId;
                pSpecPath.Value = Entity_PC.SpecPath;



                SqlParameter[] param = new SqlParameter[] { pAction, pPCId, pSpecPath };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster2, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int InsertSpecificDetail(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);
                SqlParameter pSpecificationId = new SqlParameter(ProjectConfigurator._SpecificationId, SqlDbType.BigInt);
                SqlParameter pTitle = new SqlParameter(ProjectConfigurator._Title, SqlDbType.NVarChar);
                SqlParameter pDetails = new SqlParameter(ProjectConfigurator._Details, SqlDbType.NVarChar);



                pAction.Value = 3;
                pPCId.Value = Entity_PC.PCId;
                pSpecificationId.Value = Entity_PC.SpecificationId;
                pTitle.Value = Entity_PC.Title;
                pDetails.Value = Entity_PC.Details;


                SqlParameter[] param = new SqlParameter[] { pAction, pPCId, pSpecificationId, pTitle, pDetails };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster1, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int InsertCompany(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);
                SqlParameter pCompany = new SqlParameter(ProjectConfigurator._Company, SqlDbType.NVarChar);
                SqlParameter pCompanyAddress = new SqlParameter(ProjectConfigurator._CompanyAddress, SqlDbType.NVarChar);
                SqlParameter pLogoImg = new SqlParameter(ProjectConfigurator._LogoImg, SqlDbType.NVarChar);


                pAction.Value = 1;
                pPCId.Value = Entity_PC.PCId;
                pCompany.Value = Entity_PC.Company;
                pCompanyAddress.Value = Entity_PC.CompanyAddress;
                pLogoImg.Value = Entity_PC.LogoImg;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCId, pCompany,pCompanyAddress, pLogoImg };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster1, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int InsertDocumentDetail(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);
                SqlParameter pDocId = new SqlParameter(ProjectConfigurator._DocId, SqlDbType.BigInt);
                SqlParameter pDocPath = new SqlParameter(ProjectConfigurator._DocPath, SqlDbType.NVarChar);
                SqlParameter pIsChecked = new SqlParameter(ProjectConfigurator._IsChecked, SqlDbType.Bit);

                pAction.Value = 11;
                pPCId.Value = Entity_PC.PCId;
                pDocId.Value = Entity_PC.DocId;
                pDocPath.Value = Entity_PC.DocPath;
                pIsChecked.Value = Entity_PC.IsChecked;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCId, pDocId, pDocPath, pIsChecked };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster1, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int UpdateProjectConfi(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);

                SqlParameter pPCNo = new SqlParameter(ProjectConfigurator._PCNo, SqlDbType.NVarChar);
                SqlParameter pPCName = new SqlParameter(ProjectConfigurator._PCName, SqlDbType.NVarChar);
                SqlParameter pProjectTypeId = new SqlParameter(ProjectConfigurator._ProjectTypeId, SqlDbType.BigInt);

                SqlParameter pProjectSubTypeId = new SqlParameter(ProjectConfigurator._ProjectSubTypeId, SqlDbType.BigInt);
                SqlParameter pAddress = new SqlParameter(ProjectConfigurator._Address, SqlDbType.NVarChar);
                SqlParameter pNOofTowers = new SqlParameter(ProjectConfigurator._NOofTowers, SqlDbType.BigInt);

                SqlParameter pStampAC = new SqlParameter(ProjectConfigurator._StampAC, SqlDbType.NVarChar);
                SqlParameter pRegistrationAC = new SqlParameter(ProjectConfigurator._RegistrationAC, SqlDbType.NVarChar);
                SqlParameter pVatAC = new SqlParameter(ProjectConfigurator._VatAC, SqlDbType.NVarChar);

                SqlParameter pServiceTaxAC = new SqlParameter(ProjectConfigurator._ServiceTaxAC, SqlDbType.NVarChar);
                SqlParameter pCollectionAC = new SqlParameter(ProjectConfigurator._CollectionAC, SqlDbType.NVarChar);
                SqlParameter pCancelCharge = new SqlParameter(ProjectConfigurator._CancelCharge, SqlDbType.Decimal);

                SqlParameter pTerraceAreaPer = new SqlParameter(ProjectConfigurator._TerraceAreaPer, SqlDbType.Decimal);
                SqlParameter pGardenAreaPer = new SqlParameter(ProjectConfigurator._GardenAreaPer, SqlDbType.Decimal);
                SqlParameter pFlagBooked = new SqlParameter(ProjectConfigurator._FlagBooked, SqlDbType.Bit);

                SqlParameter pLoading = new SqlParameter(ProjectConfigurator._Loading, SqlDbType.NVarChar);
                SqlParameter pLandArea = new SqlParameter(ProjectConfigurator._LandArea, SqlDbType.Decimal);
                SqlParameter pSaleableFSI = new SqlParameter(ProjectConfigurator._SaleableFSI, SqlDbType.Decimal);

                SqlParameter pInterestRate = new SqlParameter(ProjectConfigurator._InterestRate, SqlDbType.Decimal);
                SqlParameter pGracePeriod= new SqlParameter(ProjectConfigurator._GracePeriod, SqlDbType.BigInt);


                SqlParameter pProjectBankName = new SqlParameter(ProjectConfigurator._ProjectBankName, SqlDbType.NVarChar);
                SqlParameter pProjectBranchName = new SqlParameter(ProjectConfigurator._ProjectBranchName, SqlDbType.NVarChar);
                SqlParameter pProjectAccountNo = new SqlParameter(ProjectConfigurator._ProjectAccountNo, SqlDbType.NVarChar);
                SqlParameter pProjectIFSCCode = new SqlParameter(ProjectConfigurator._ProjectIFSCCode, SqlDbType.NVarChar);
                SqlParameter pProjectMICRCode = new SqlParameter(ProjectConfigurator._ProjectMICRCode, SqlDbType.NVarChar);

                SqlParameter pCreatedBy = new SqlParameter(ProjectConfigurator._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(ProjectConfigurator._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pPCId.Value = Entity_PC.PCId;

                pPCNo.Value = Entity_PC.PCNo;
                pPCName.Value = Entity_PC.PCName;
                pProjectTypeId.Value = Entity_PC.ProjectTypeId;

                pProjectSubTypeId.Value = Entity_PC.ProjectSubTypeId;
                pAddress.Value = Entity_PC.Address;
                pNOofTowers.Value = Entity_PC.NOofTowers;

                pStampAC.Value = Entity_PC.StampAC;
                pRegistrationAC.Value = Entity_PC.RegistrationAC;
                pVatAC.Value = Entity_PC.VatAC;

                pCollectionAC.Value = Entity_PC.CollectionAC;
                pServiceTaxAC.Value = Entity_PC.ServiceTaxAC;
                pCancelCharge.Value = Entity_PC.CancelCharge;

                pTerraceAreaPer.Value = Entity_PC.TerraceAreaPer;
                pGardenAreaPer.Value = Entity_PC.GardenAreaPer;
                pFlagBooked.Value = Entity_PC.FlagBooked;

                pLoading.Value = Entity_PC.Loading;
                pLandArea.Value = Entity_PC.LandArea;
                pSaleableFSI.Value = Entity_PC.SaleableFSI;

                pInterestRate.Value = Entity_PC.InterestRate;
                pGracePeriod.Value = Entity_PC.GracePeriod;

                pCreatedBy.Value = Entity_PC.UserId;
                pCreatedDate.Value = Entity_PC.LoginDate;
                        
                pProjectBankName.Value = Entity_PC.ProjectBankName;
                pProjectBranchName.Value = Entity_PC.ProjectBranchName;
                pProjectAccountNo.Value = Entity_PC.ProjectAccountNo;
                pProjectIFSCCode.Value = Entity_PC.ProjectIFSCCode;
                pProjectMICRCode.Value = Entity_PC.ProjectMICRCode;



                SqlParameter[] param = new SqlParameter[] { pAction,pPCId, pPCNo, pPCName,pProjectTypeId,pProjectSubTypeId,pAddress,pNOofTowers,
                                       pStampAC,pRegistrationAC,pVatAC,pServiceTaxAC,pCollectionAC,pCancelCharge,pTerraceAreaPer,pGardenAreaPer,
                                       pFlagBooked,pCreatedBy, pCreatedDate,pLoading,pLandArea,pSaleableFSI,pInterestRate,pGracePeriod,                
                                       pProjectBankName,pProjectBranchName,pProjectAccountNo,pProjectIFSCCode,pProjectMICRCode};

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public DataSet FillCombo(out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);

                pAction.Value = 4;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster,pAction);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return Ds;
        }

        public DataSet GetPCNO(out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);

                pAction.Value = 5;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster, pAction);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return Ds;
        }

        public DataSet GetProjectConfig(string ReportCond,out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pStrCondition = new SqlParameter(ProjectConfigurator._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 6;
                pStrCondition.Value = ReportCond;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster, pAction, pStrCondition);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return Ds;
        }

        public DataSet GetPCForEdit(int PCId,out string StrError,int Flag)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);
                if(Flag==1)
                pAction.Value = 1;
                else
                pAction.Value = 2;

                pPCId.Value = PCId;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster2, pAction, pPCId);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return Ds;
        }

        public DataSet GetFlatType(int ProjectTypeId, out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pProjectTypeId = new SqlParameter(ProjectConfigurator._ProjectTypeId, SqlDbType.BigInt);

                pAction.Value = 6;
                pProjectTypeId.Value = ProjectTypeId;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster2, pAction, pProjectTypeId);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return Ds;
        }
        public int DeleteProjectConfi(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);
                SqlParameter pUserId = new SqlParameter(ProjectConfigurator._UserId, SqlDbType.BigInt);
                SqlParameter pLoginDate = new SqlParameter(ProjectConfigurator._LoginDate, SqlDbType.DateTime);

                pAction.Value = 3;
                pPCId.Value = Entity_PC.PCId;
                pUserId.Value = Entity_PC.UserId;
                pLoginDate.Value = Entity_PC.LoginDate;


                SqlParameter[] param = new SqlParameter[] { pAction, pPCId, pUserId, pLoginDate };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public string[] GetSuggestRecord(string preFixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(ParkingType._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(ParkingType._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 6;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster, oparamcol);

                if (dr != null && dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        ListItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[0].ToString(),
                            dr[1].ToString());

                        SearchList.Add(ListItem);
                    }

                }
                dr.Close();
            }

            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                Close();
            }

            return SearchList.ToArray();
        }

        public DataSet GetPCForPDF(int PCId, out string StrError, int Flag)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);
               
                pAction.Value = 7;

                pPCId.Value = PCId;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster2, pAction, pPCId);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return Ds;
        }

        public int DeleteFlats(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCDetailId = new SqlParameter(ProjectConfigurator._PCDetailId, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);

                pAction.Value = 8;
                pPCDetailId.Value = Entity_PC.PCDetailId;
                pPCId.Value = Entity_PC.PCId;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCDetailId, pPCId };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster2, param);

                if (iDelete > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iDelete;
        }

        public int UpdateFlats(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCDetailId = new SqlParameter(ProjectConfigurator._PCDetailId, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);

                SqlParameter pSqFt = new SqlParameter(ProjectConfigurator._SqFt, SqlDbType.BigInt);
                SqlParameter pTerraceArea = new SqlParameter(ProjectConfigurator._TerraceArea, SqlDbType.Decimal);
                SqlParameter pCarpetArea = new SqlParameter(ProjectConfigurator._CarpetArea, SqlDbType.Decimal);

                SqlParameter pSqftSaleBuiltUp = new SqlParameter(ProjectConfigurator._SqftSaleBuiltUp, SqlDbType.Decimal);
                SqlParameter pTerraceAreaSaleBuiltUp = new SqlParameter(ProjectConfigurator._TerraceAreaSaleBuiltUp, SqlDbType.Decimal);
                SqlParameter pSaleableArea = new SqlParameter(ProjectConfigurator._SaleableArea, SqlDbType.Decimal);

                SqlParameter pFlatAgreementCarpet = new SqlParameter(ProjectConfigurator._FlatAgreementCarpet, SqlDbType.Decimal);
                SqlParameter pTerraceAgreementCarpet = new SqlParameter(ProjectConfigurator._TerraceAgreementCarpet, SqlDbType.Decimal);

                SqlParameter pFlatAgreementBuiltUp = new SqlParameter(ProjectConfigurator._FlatAgreementBuiltUp, SqlDbType.Decimal);
                SqlParameter pTerraceAgreementBuiltUp = new SqlParameter(ProjectConfigurator._TerraceAgreementBuiltUp, SqlDbType.Decimal);


                pAction.Value = 9;
                pPCDetailId.Value = Entity_PC.PCDetailId;
                pPCId.Value = Entity_PC.PCId;

                pSqFt.Value = Entity_PC.Sqft;
                pSaleableArea.Value = Entity_PC.SaleableArea;

                pTerraceArea.Value = Entity_PC.TerraceArea;
                pCarpetArea.Value = Entity_PC.CarpetArea;

                pSqftSaleBuiltUp.Value = Entity_PC.SqftSaleBuiltUp;
                pTerraceAreaSaleBuiltUp.Value = Entity_PC.TerraceAreaSaleBuiltUp;
                pSaleableArea.Value = Entity_PC.SaleableArea;

                pFlatAgreementCarpet.Value = Entity_PC.FlatAgreementCarpet;
                pTerraceAgreementCarpet.Value = Entity_PC.TerraceAgreementCarpet;

                pFlatAgreementBuiltUp.Value = Entity_PC.FlatAgreementBuiltUp;
                pTerraceAgreementBuiltUp.Value = Entity_PC.TerraceAgreementBuiltUp;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCDetailId, pPCId,pSqFt,pTerraceArea,
                    pCarpetArea,pSqftSaleBuiltUp,pTerraceAreaSaleBuiltUp,pSaleableArea,pFlatAgreementCarpet,pTerraceAgreementCarpet,pFlatAgreementBuiltUp,pTerraceAgreementBuiltUp};

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster2, param);

                if (iDelete > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iDelete;
        }

        public int UpdateTowerWise(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);

               
                SqlParameter pNOofTowers = new SqlParameter(ProjectConfigurator._NOofTowers, SqlDbType.BigInt);
               
                SqlParameter pTerraceAreaPer = new SqlParameter(ProjectConfigurator._TerraceAreaPer, SqlDbType.Decimal);
                SqlParameter pGardenAreaPer = new SqlParameter(ProjectConfigurator._GardenAreaPer, SqlDbType.Decimal);
                //SqlParameter pFlagBooked = new SqlParameter(ProjectConfigurator._FlagBooked, SqlDbType.Bit);

                SqlParameter pLoading = new SqlParameter(ProjectConfigurator._Loading, SqlDbType.NVarChar);
                SqlParameter pLandArea = new SqlParameter(ProjectConfigurator._LandArea, SqlDbType.Decimal);
                SqlParameter pSaleableFSI = new SqlParameter(ProjectConfigurator._SaleableFSI, SqlDbType.Decimal);

                SqlParameter pCreatedBy = new SqlParameter(ProjectConfigurator._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(ProjectConfigurator._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pPCId.Value = Entity_PC.PCId;
           
                pNOofTowers.Value = Entity_PC.NOofTowers;
              
                pTerraceAreaPer.Value = Entity_PC.TerraceAreaPer;
                pGardenAreaPer.Value = Entity_PC.GardenAreaPer;
               // pFlagBooked.Value = Entity_PC.FlagBooked;
                pCreatedBy.Value = Entity_PC.UserId;
                pCreatedDate.Value = Entity_PC.LoginDate;
                pLoading.Value = Entity_PC.Loading;
                pLandArea.Value = Entity_PC.LandArea;
                pSaleableFSI.Value = Entity_PC.SaleableFSI;

                SqlParameter[] param = new SqlParameter[] { pAction,pPCId,pNOofTowers,
                                    pTerraceAreaPer,pGardenAreaPer,pCreatedBy, pCreatedDate,pLoading,pLandArea,pSaleableFSI};
                //pFlagBooked
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster_Part1, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int UpdateFlatsBooked(ref ProjectConfigurator Entity_PC, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);
                SqlParameter pPCDetailId = new SqlParameter(ProjectConfigurator._PCDetailId, SqlDbType.BigInt);

                SqlParameter pTowerName = new SqlParameter(ProjectConfigurator._TowerName, SqlDbType.NVarChar);
                SqlParameter pFlatNo = new SqlParameter(ProjectConfigurator._FlatNo, SqlDbType.NVarChar);
                SqlParameter pSqFt = new SqlParameter(ProjectConfigurator._SqFt, SqlDbType.Decimal);

                SqlParameter pTerraceArea = new SqlParameter(ProjectConfigurator._TerraceArea, SqlDbType.Decimal);
                SqlParameter pGardenArea = new SqlParameter(ProjectConfigurator._GardenArea, SqlDbType.Decimal);
                SqlParameter pCarpetArea = new SqlParameter(ProjectConfigurator._CarpetArea, SqlDbType.Decimal);

                SqlParameter pSqftSaleBuiltUp = new SqlParameter(ProjectConfigurator._SqftSaleBuiltUp, SqlDbType.Decimal);
                SqlParameter pTerraceAreaSaleBuiltUp = new SqlParameter(ProjectConfigurator._TerraceAreaSaleBuiltUp, SqlDbType.Decimal);
                SqlParameter pGardenAreaSaleBuiltUp = new SqlParameter(ProjectConfigurator._GardenAreaSaleBuiltUp, SqlDbType.Decimal);
                SqlParameter pSaleableArea = new SqlParameter(ProjectConfigurator._SaleableArea, SqlDbType.Decimal);

                SqlParameter pFlatAgreementCarpet = new SqlParameter(ProjectConfigurator._FlatAgreementCarpet, SqlDbType.Decimal);
                SqlParameter pTerraceAgreementCarpet = new SqlParameter(ProjectConfigurator._TerraceAgreementCarpet, SqlDbType.Decimal);

                SqlParameter pFlatAgreementBuiltUp = new SqlParameter(ProjectConfigurator._FlatAgreementBuiltUp, SqlDbType.Decimal);
                SqlParameter pTerraceAgreementBuiltUp = new SqlParameter(ProjectConfigurator._TerraceAgreementBuiltUp, SqlDbType.Decimal);

                SqlParameter pFlatTypeId = new SqlParameter(ProjectConfigurator._FlatTypeId, SqlDbType.BigInt);
                SqlParameter pFloors = new SqlParameter(ProjectConfigurator._Floors, SqlDbType.BigInt);
                SqlParameter pUnits = new SqlParameter(ProjectConfigurator._Units, SqlDbType.BigInt);
                SqlParameter pFloorNo = new SqlParameter(ProjectConfigurator._FloorNo, SqlDbType.BigInt);
                SqlParameter pFacingType = new SqlParameter(ProjectConfigurator._FacingTypeId, SqlDbType.BigInt);
                //SqlParameter pIsAll = new SqlParameter(ProjectConfigurator._IsAll, SqlDbType.Bit);           
                //SqlParameter pSqftAll = new SqlParameter(ProjectConfigurator._SqftAll, SqlDbType.Decimal);
                //SqlParameter pSqftEven = new SqlParameter(ProjectConfigurator._SqftEven, SqlDbType.Decimal);
                //SqlParameter pSqftOdd = new SqlParameter(ProjectConfigurator._SqftOdd, SqlDbType.Decimal);                                                  
                SqlParameter pFlatLayoutPath = new SqlParameter(ProjectConfigurator._FlatLayoutPath, SqlDbType.NVarChar);
                SqlParameter pTerraceAreaPer = new SqlParameter(ProjectConfigurator._TerraceAreaPer, SqlDbType.Decimal);
                SqlParameter pGardenAreaPer = new SqlParameter(ProjectConfigurator._GardenAreaPer, SqlDbType.Decimal);

                pAction.Value = 3;
                pPCId.Value = Entity_PC.PCId;
                pPCDetailId.Value = Entity_PC.PCDetailId;

                pTowerName.Value = Entity_PC.TowerName;
                pFlatNo.Value = Entity_PC.FlatNo;
                pSqFt.Value = Entity_PC.Sqft;
                pFlatTypeId.Value = Entity_PC.FlatTypeId;
                pFloors.Value = Entity_PC.Floors;

                pTerraceAreaPer.Value = Entity_PC.TerraceAreaPer;
                pGardenAreaPer.Value = Entity_PC.GardenAreaPer;
                pCarpetArea.Value = Entity_PC.CarpetArea;

                pSqftSaleBuiltUp.Value = Entity_PC.SqftSaleBuiltUp;
                pTerraceAreaSaleBuiltUp.Value = Entity_PC.TerraceAreaSaleBuiltUp;
                pGardenAreaSaleBuiltUp.Value = Entity_PC.GardenAreaSaleBuiltUp;
                pSaleableArea.Value = Entity_PC.SaleableArea;

                pFlatAgreementCarpet.Value = Entity_PC.FlatAgreementCarpet;
                pTerraceAgreementCarpet.Value = Entity_PC.TerraceAgreementCarpet;

                pFlatAgreementBuiltUp.Value = Entity_PC.FlatAgreementBuiltUp;
                pTerraceAgreementBuiltUp.Value = Entity_PC.TerraceAgreementBuiltUp;
                //pUnits.Value = Entity_PC.Units;
                //pIsAll.Value = Entity_PC.IsAll;             
               //pSqftAll.Value = Entity_PC.SqftAll;
                //pSqftEven.Value = Entity_PC.SqftEven;
                //pSqftOdd.Value = Entity_PC.SqftOdd;
                pFloorNo.Value = Entity_PC.FloorNo;
                pFacingType.Value = Entity_PC.FacingTypeId;

                pFlatLayoutPath.Value = Entity_PC.FlatLayoutPath;
                pTerraceArea.Value = Entity_PC.TerraceArea;
                pGardenArea.Value = Entity_PC.GardenArea;
                                               
                
             

                SqlParameter[] param = new SqlParameter[] { pAction, pPCId,pPCDetailId, 
                    pTowerName, pFlatNo,pSqFt, pFlatTypeId, pFloors,pTerraceAreaPer,pGardenAreaPer,pCarpetArea,
                    pSqftSaleBuiltUp,pTerraceAreaSaleBuiltUp,pGardenAreaSaleBuiltUp,pSaleableArea,pFlatAgreementCarpet,pTerraceAgreementCarpet,
                      pFlatAgreementBuiltUp,pTerraceAgreementBuiltUp,pFloorNo,pFacingType,
                     pFlatLayoutPath,pTerraceArea,pGardenArea,                                                                           
                };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ProjectConfiguratorMaster_Part1", param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public DataSet FillcomboBuilding(int PCId, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);

                pAction.Value =2;
                pPCId.Value = PCId;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure,ProjectConfigurator.SP_ProjectConfiguratorMaster_Part1 , pAction, pPCId);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

        public DataSet GetGridDetailsAD(long PCId, out string StrError)
        {
            DataSet DS = new DataSet();
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);

                pAction.Value = 7;
                pPCId.Value = PCId;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster, pAction, pPCId);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return DS;
        }

        public int UpdateIsActive(long PCDetailId,out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCDetailId = new SqlParameter(ProjectConfigurator._PCDetailId, SqlDbType.BigInt);
                SqlParameter pIsactive = new SqlParameter(ProjectConfigurator._IsActive, SqlDbType.Bit);

                pAction.Value = 8;
                pPCDetailId.Value=PCDetailId;
                pIsactive.Value = 1;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCDetailId };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public int UpdateIsDeActive(long PCDetailId, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCDetailId = new SqlParameter(ProjectConfigurator._PCDetailId, SqlDbType.BigInt);
                SqlParameter pIsactive = new SqlParameter(ProjectConfigurator._IsActive, SqlDbType.Bit);

                pAction.Value = 9;
                pPCDetailId.Value = PCDetailId;
                pIsactive.Value = 0;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCDetailId };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster, param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public DataSet ChkNumFloor(long PCDetailId, long PCId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS= new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCDetailId = new SqlParameter(ProjectConfigurator._PCDetailId, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);

                pAction.Value = 11;
                pPCDetailId.Value = PCDetailId;
                pPCId.Value = PCId;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCDetailId,pPCId };
                Open(CONNECTION_STRING);
                BeginTransaction();
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster, param);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }
        public DataSet ChkNumTowerName(long PCDetailId, long PCId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS= new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCDetailId = new SqlParameter(ProjectConfigurator._PCDetailId, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);

                pAction.Value = 12;
                pPCDetailId.Value = PCDetailId;
                pPCId.Value = PCId;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCDetailId,pPCId };
                Open(CONNECTION_STRING);
                BeginTransaction();
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster, param);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public DataSet ChkInBooking(long PCDetailId, long PCId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCDetailId = new SqlParameter(ProjectConfigurator._PCDetailId, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);

                pAction.Value = 13;
                pPCDetailId.Value = PCDetailId;
                pPCId.Value = PCId;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCDetailId, pPCId };
                Open(CONNECTION_STRING);
                BeginTransaction();
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster, param);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }
        public DataSet PrjctName( long PCId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pPCId = new SqlParameter(ProjectConfigurator._PCId, SqlDbType.BigInt);

                pAction.Value = 14;
                pPCId.Value = PCId;

                SqlParameter[] param = new SqlParameter[] { pAction, pPCId };
                Open(CONNECTION_STRING);
                BeginTransaction();
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, ProjectConfigurator.SP_ProjectConfiguratorMaster, param);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public DMProjectConfigurator()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet GetTaxAmt(DateTime EffectiveDate,Int32 TaxId, out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter PAction = new SqlParameter(ProjectConfigurator._Action, SqlDbType.BigInt);
                SqlParameter pEffectiveDate = new SqlParameter("@EffectiveFrom", SqlDbType.DateTime);
                SqlParameter pTaxId = new SqlParameter("@TaxId", SqlDbType.BigInt);

                PAction.Value = 7;
                pEffectiveDate.Value = EffectiveDate;
                pTaxId.Value = TaxId;

                SqlParameter[] param = new SqlParameter[] { PAction, pEffectiveDate, pTaxId };
                Open(Setting.CONNECTION_STRING);

                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_TaxMaster", param);

            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }
    }
}
