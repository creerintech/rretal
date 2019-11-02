USE [BuildTimeKariaDevelopers]
GO
/****** Object:  StoredProcedure [dbo].[SP_BookingFormMaster_Part7]    Script Date: 04/17/2014 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_BookingFormMaster_Part7] 

@Action bigint=null,
@BookingId	bigint	=null,
@BookingNo	nvarchar(50)	=null,
@EmpID bigint=null,
@BookingDate	datetime	=null,
@PCId bigint=null,
@Building	nvarchar(100)	=null,
@PCDetailId bigint=null,	
@IsEnquired bit=null,
@CustId bigint	=null,
@Applicant1	nvarchar(250)	=null,
@Applicant2	nvarchar(250)	=null,
@Applicant3	nvarchar(250)	=null,
@Age1	bigint	=null,
@Age2	bigint	=null,
@Age3	bigint	=null,
@CorrAddress	nvarchar(max)	=null,
@Occupation	nvarchar(250)	=null,
@CompanyName	nvarchar(250)	=null,
@PerAddress	nvarchar(250)	=null,
@Email	nvarchar(250)	=null,
@Fax	nvarchar(50)	=null,
@TelO	nvarchar(50)	=null,
@TelR	nvarchar(50)	=null,
@Mobile	nvarchar(50)	=null,
@DOB	datetime	=null,
@DOBSpouse	datetime	=null,
@EarnMoney	decimal(18, 2)	=null,
@Parking	bigint	=null,
@ParkingTypeId bigint	=null,
@PNdetailId bigint	=null,
@NewsTOI bit	=null,
@NewsSakal bit	=null,
@NewsOther bit	=null,
@ModeOfBooking bigint	=null,
@OtherDtls nvarchar(50)=null,
@BrokerId bigint=null,
@ReferenceName  nvarchar(250)=null,
@Exihibition nvarchar(250)=null,
@Hoarding nvarchar(250)=null,
@FriendName nvarchar(250)=null,
@LoanRequired	bigint	=null,
@AmountReq decimal(18,2)=null,
@BankEmailId nvarchar(MAX)=null,
@BankLoanDate datetime	=null,
@ActualBankLoanDate datetime	=null,
@Comments nvarchar(MAX)=null,
@Institute	nvarchar(50)=null,
@CommitedDate	datetime	=null,
@AreaInSqft decimal(18, 2)	=null,
@RateperSqft decimal(18, 5)	=null,
@DevelopmentCharges decimal(18,2)=null,
@TotalFlatAmount decimal(18,2)=null,
@GrandAmount decimal(18,2)=null,
@CancelFlag bit=null,
@UserId bigint=null,
@LoginDate datetime=null,
@IsDeleted bit=null,
@strCond nvarchar(MAX)=null,
@Temp nvarchar(4000)=null,
@EnquiryId bigint=null,
@BrokerAmountCalculateOn decimal(18,2)=null,
@BrokerAmount decimal(18,2)=null,
@OtherCharges  decimal(18,2)=null,
@OpenTerrace  decimal(18,2)=null,
@Garden  decimal(18,2)=null,
@Occupation2 nvarchar(250)=null,
@Schedule nvarchar(250)=null,
@ApplicantPanNo2 nvarchar(250)=null,
@ResidentialStatus bigint=null,
@ActualDateOfAgreement datetime	=null,
@InterestCalculation bigint=null,
@TDSApply bigint=null,
@TDSPercentage decimal(18,2)=null,
@TDSAmount decimal(18,2)=null,
@Mobile2 nvarchar(50)=null,
@EmailId2 nvarchar(250)=null,
@PreferentialAllotmentCharges decimal(18,2)=null,
@IncidentalCharges decimal(18,2)=null,
@Remark nvarchar(MAX)=null,
@Occupation3 nvarchar(MAX)=null,
@Applicant2Mobile nvarchar(50)=null,
@Applicant3Mobile nvarchar(50)=null,
@EmailId3 nvarchar(250)=nulll,
@ApplicantPanNo1 nvarchar(250)=null,
@ApplicantPanNo3 nvarchar(250)=null,
@Applicant2DOB datetime=null,
@Applicant3DOB datetime=null,
@PaymentScheduleId bigint=null,
@StageId bigint=null,
@Percentage decimal(18,2)=null,
@TotalChargeAmount decimal(18,2)=null,
@BeforeTaxAgreementValue decimal(18,2)=null,
@TotalTaxAmount decimal(18,2)=null,
@AgreementValue decimal(18,2)=null,
@PCTemplate bigint=null,
@CollectionFor bigint=null,
@Value decimal(18,2)=null,
@ChargeId bigint=null,
@ChargeAmt decimal(18,2)=null,
@Type bigint=null,
@TaxId bigint=null,
@TaxTypeId bigint=null,
@TaxFormatId bigint=null,
@Amount decimal(18,2)=null,
@IncludeIn bigint=null,
@TaxValue decimal(18,3)=null ,
@TaxDtlId bigint=null,
@SaleableValue decimal(18,2)=null,
@FlatTypeId bigint=null,
@Booking_TaxDtlsId bigint=null

As


If(@Action=1)
Begin
	-----RATE-----
	Select @RateperSqft= RateperSqft --Top(1) 
	from ProjectSaleDetails PSD inner join ProjectSaleMaster PSM 
	on PSD.PSId=PSM.PSId
	where PSM.PCId=@PCId order by PSD.ApplicableDate DESC
	
	-----AREA-----
	Select @AreaInSqft=PCD.SaleableArea,@FlatTypeId=PCD.FlatTypeId From PCDetailMaster PCD
	Inner Join ProjectConfiguratorMaster PCM On PCM.PCId=PCD.PCId
	where PCD.PCDetailId=@PCDetailId
	
	-----SALEABLE VALUE = AREA * RATE-----
	Select @SaleableValue=@AreaInSqft*@RateperSqft
	
	-----CHARGES APPLICABLE IN AGREEMENT VALUE CALCULATION-----
		
	Select CAST (0 As bit) As Charges,CT.ChargeName,CT.Type,
	case CT.Type When 1 Then 'Amount' When 2 Then 'Amount/SqFt' Else 'Percentage' End As Format,
	PCT.Value,
	Cast
	(case CT.Type When 2 Then @AreaInSqft*PCT.Value When 1 Then PCT.Value 
	Else (@AreaInSqft*@RateperSqft*PCT.Value)/100 End As Decimal(18,2))  As ChargeAmount,
	PCT.ChargeId,PCT.CollectionFor,PCT.PCTemplate
	From PCTemplate PCT 
	Inner Join ChargeTypeNew CT On CT.ChargeId=PCT.ChargeId
	Where CT.IsDeleted=0 And PCT.IsDeleted=0 And PCT.CollectionFor=1 
	--And CT.Type in(1,2) 
	And PCT.ProjectId=@PCId and PCT.FlatTypeId=@FlatTypeId
	and convert(smalldatetime,ApplicableDate,106)<=convert(smalldatetime,@BookingDate,106)
	order by ApplicableDate desc
	
	-----TAX APPLICABLE IN AGREEMENT VALUE CALCULATION-----
	--Select *,
	--	 IsNull((select STUFF((select distinct ', ' + Cast (ptt1.ChargeId As Varchar) 
	--							 from ProjectTaxTemplate ptt1
	--							 where  ChargeId > 0 and ptt1.TaxId=T.TaxId
	--							 for xml path('')),1,1,'')) ,0) as [ChargeId],
	--							 	 IsNull((select STUFF((select distinct ', ' + Cast (ptt1.ChargeId As Varchar) 
	--							 from ProjectTaxTemplate ptt1
	--							 where  ChargeId < 0 and ptt1.TaxId=T.TaxId
	--							 for xml path('')),1,1,'')) ,0) as [ChargeId1]
	-- from(
	--select *,(select STUFF((select distinct '+ ' + ptt1.ChargeNameDesc   
	--							 from ProjectTaxTemplate ptt1
	--							 where ptt1.TaxId=a.TaxId
	--							 for xml path('')),1,1,'')) as [ChargeName],CAST (0 As bit)Tax
	--from 
	--(Select distinct ptt.IncludeIn,ptt.ApplicableDate, PTM.TaxName,ptt.TaxTypeId, PTM.TaxId,ptt.TaxAmount, ptt.PCId, Cast(0 As Decimal(18,2)) as TaxAmt,TaxFormatId,TaxFormat
	--from VW_ProjectCharges pct,
	--			 ProjectTaxTemplate ptt,
	--			 TaxTemplateMaster PTM
	--		where ptt.PCId=pct.PCId	
	--		and pct.ChargeId=ptt.ChargeId and pct.FlatTypeId=@FlatTypeId and ptt.TaxId=PTM.TaxId and ptt.IncludeIn=1 
	--		and ptm.PCId=@PCId and ptt.ChargeId >0
	--		and convert(smalldatetime,ptt.ApplicableDate,106)<=convert(smalldatetime,@BookingDate,106)
	--		) a
			
	--		UNION
	--		select *,(select STUFF((select distinct '+ ' + ptt1.ChargeNameDesc   
	--							 from ProjectTaxTemplate ptt1
	--							 where ptt1.TaxId=a.TaxId
	--							 for xml path('')),1,1,'')) as [ChargeName],CAST (0 As bit)Tax
	--from 
	--(Select distinct ptt.IncludeIn,ptt.ApplicableDate, PTM.TaxName,ptt.TaxTypeId, PTM.TaxId,ptt.TaxAmount, ptt.PCId, 0 as TaxAmt,TaxFormatId,TaxFormat
	--from VW_ProjectCharges pct,
	--			 ProjectTaxTemplate ptt,
	--			 TaxTemplateMaster PTM
	--		where ptt.PCId=pct.PCId	
	--		 and pct.FlatTypeId=@FlatTypeId and ptt.TaxId=PTM.TaxId and ptt.IncludeIn=1 
	--		and ptm.PCId=@PCId and ptt.ChargeId <0
	--		and convert(smalldatetime,ptt.ApplicableDate,106)<=convert(smalldatetime,@BookingDate,106)
	--		) a
	--		)T
	--order  by ApplicableDate desc
	
	Select *,
IsNull((select STUFF((select distinct ', ' + Cast (ptt1.ChargeId As Varchar) 
from ProjectTaxTemplate ptt1
where  ChargeId > 0 and ptt1.TaxId=T.TaxId
for xml path('')),1,1,'')) ,0) as [ChargeId],
IsNull((select STUFF((select distinct ', ' + Cast (ptt1.ChargeId As Varchar) 
from ProjectTaxTemplate ptt1
where  ChargeId < 0 and ptt1.TaxId=T.TaxId
for xml path('')),1,1,'')) ,0) as [ChargeId1]
from(
select *,(select STUFF((select distinct '+ ' + ptt1.ChargeNameDesc   
from ProjectTaxTemplate ptt1
where ptt1.TaxId=a.TaxId
for xml path('')),1,1,'')) as [ChargeName],CAST (0 As bit)Tax
from 
(
Select distinct ptt.IncludeIn,ptt.ApplicableDate, PTM.TaxName,ptt.TaxTypeId, PTM.TaxId,ptt.TaxAmount, ptt.PCId, 0 as TaxAmt,TaxFormatId,TaxFormat
from 
ProjectTaxTemplate ptt inner join  TaxTemplateMaster PTM on  ptt.TaxId=PTM.TaxId
left join VW_ProjectCharges pct on  ptt.PCId=pct.PCId	and pct.FlatTypeId=@FlatTypeId			
where			  
ptt.TaxId=PTM.TaxId and ptt.IncludeIn=1 
and ptm.PCId=@PCId and ptt.ChargeId >0
and convert(smalldatetime,ptt.ApplicableDate,106)<=convert(smalldatetime,@BookingDate,106)
) a

UNION
select *,(select STUFF((select distinct '+ ' + ptt1.ChargeNameDesc   
from ProjectTaxTemplate ptt1
where ptt1.TaxId=a.TaxId
for xml path('')),1,1,'')) as [ChargeName],CAST (0 As bit)Tax
from 
(
Select distinct ptt.IncludeIn,ptt.ApplicableDate, PTM.TaxName,ptt.TaxTypeId, PTM.TaxId,ptt.TaxAmount, ptt.PCId, 0 as TaxAmt,TaxFormatId,TaxFormat
from 
ProjectTaxTemplate ptt inner join  TaxTemplateMaster PTM on  ptt.TaxId=PTM.TaxId
left join VW_ProjectCharges pct on  ptt.PCId=pct.PCId	and pct.FlatTypeId=@FlatTypeId			
where			  
ptt.TaxId=PTM.TaxId and ptt.IncludeIn=1 
and ptm.PCId=@PCId and ptt.ChargeId <0
and convert(smalldatetime,ptt.ApplicableDate,106)<=convert(smalldatetime,@BookingDate,106)
) a
)T
order  by ApplicableDate desc
			
	-----CHARGES APPLICABLE AFTER AGREEMENT VALUE CALCULATION-----
		
	Select CAST (0 As bit) As Charges1,CT.ChargeName,CT.Type,
	case CT.Type When 1 Then 'Amount' When 2 Then 'Amount/SqFt' Else 'Percentage' End As Format,
	PCT.Value,
	Cast
	(case CT.Type When 2 Then @AreaInSqft*PCT.Value When 1 Then PCT.Value 
	--Else (@AreaInSqft*@RateperSqft*PCT.Value)/100
	 End As Decimal(18,2))  As ChargeAmount,
	PCT.ChargeId,PCT.CollectionFor,PCT.PCTemplate
	From PCTemplate PCT 
	Inner Join ChargeTypeNew CT On CT.ChargeId=PCT.ChargeId
	Where CT.IsDeleted=0 And PCT.IsDeleted=0 And PCT.CollectionFor=2 
	--And CT.Type in(1,2) 
	And PCT.ProjectId=@PCId and PCT.FlatTypeId=@FlatTypeId
	and convert(smalldatetime,ApplicableDate,106)<=convert(smalldatetime,@BookingDate,106)
	order by ApplicableDate desc
	
		-----TAX APPLICABLE AFTER AGREEMENT VALUE CALCULATION-----
	--	Select *,
	--	 IsNull((select STUFF((select distinct ', ' + Cast (ptt1.ChargeId As Varchar) 
	--							 from ProjectTaxTemplate ptt1
	--							 where  ChargeId > 0 and ptt1.TaxId=T.TaxId
	--							 for xml path('')),1,1,'')) ,0) as [ChargeId],
	--		 IsNull((select STUFF((select distinct ', ' + Cast (ptt1.ChargeId As Varchar) 
	--							 from ProjectTaxTemplate ptt1
	--							 where  ChargeId < 0 and ptt1.TaxId=T.TaxId
	--							 for xml path('')),1,1,'')) ,0) as [ChargeId1]
	--	 From 
	--	(
	--	select *,(select STUFF((select distinct '+ ' + ptt1.ChargeNameDesc   
	--							 from ProjectTaxTemplate ptt1
	--							 where ptt1.TaxId=a.TaxId
	--							 for xml path('')),1,1,'')) as [ChargeName],CAST (0 As bit)Tax1
								
	--from 
	--(
	--Select distinct ptt.IncludeIn,ptt.ApplicableDate, PTM.TaxName,ptt.TaxTypeId, PTM.TaxId,ptt.TaxAmount, ptt.PCId,CAST(0 as Decimal(18,2)) As TaxAmt,TaxFormatId,TaxFormat
	--from VW_ProjectCharges pct,
	--			 ProjectTaxTemplate ptt,
	--			 TaxTemplateMaster PTM
	--		where ptt.PCId=pct.PCId	
	--		and pct.ChargeId=ptt.ChargeId and pct.FlatTypeId=@FlatTypeId and ptt.TaxId=PTM.TaxId and ptt.IncludeIn=2 and  ptt.ChargeId >0
	--		and ptm.PCId=@PCId
	--		and convert(smalldatetime,ptt.ApplicableDate,106)<=convert(smalldatetime,@BookingDate,106)
	--		) a
		
	--	UNION
		
	--select *,(select STUFF((select distinct '+ ' + ptt1.ChargeNameDesc   
	--							 from ProjectTaxTemplate ptt1
	--							 where ptt1.TaxId=a.TaxId
	--							 for xml path('')),1,1,'')) as [ChargeName],CAST (0 As bit)Tax1
								 
	--from 
	--(Select distinct ptt.IncludeIn,ptt.ApplicableDate, PTM.TaxName,ptt.TaxTypeId, PTM.TaxId,ptt.TaxAmount, ptt.PCId, 0 as TaxAmt,TaxFormatId,TaxFormat
	--from VW_ProjectCharges pct,
	--			 ProjectTaxTemplate ptt,
	--			 TaxTemplateMaster PTM
	--		where ptt.PCId=pct.PCId	
	--		and  pct.FlatTypeId=@FlatTypeId and ptt.TaxId=PTM.TaxId and ptt.IncludeIn=2
	--		and ptm.PCId=@PCId and ptt.ChargeId <0
	--		and convert(smalldatetime,ptt.ApplicableDate,106)<=convert(smalldatetime,@BookingDate,106)
	--		) a
	--		)T
	--order  by ApplicableDate desc
	
		Select *,
		 IsNull((select STUFF((select distinct ', ' + Cast (ptt1.ChargeId As Varchar) 
								 from ProjectTaxTemplate ptt1
								 where  ChargeId > 0 and ptt1.TaxId=T.TaxId
								 for xml path('')),1,1,'')) ,0) as [ChargeId],
			 IsNull((select STUFF((select distinct ', ' + Cast (ptt1.ChargeId As Varchar) 
								 from ProjectTaxTemplate ptt1
								 where  ChargeId < 0 and ptt1.TaxId=T.TaxId
								 for xml path('')),1,1,'')) ,0) as [ChargeId1]
		 From 
		(
		select *,(select STUFF((select distinct '+ ' + ptt1.ChargeNameDesc   
								 from ProjectTaxTemplate ptt1
								 where ptt1.TaxId=a.TaxId
								 for xml path('')),1,1,'')) as [ChargeName],CAST (0 As bit)Tax1
								
	from 
	(
	Select distinct ptt.IncludeIn,ptt.ApplicableDate, PTM.TaxName,ptt.TaxTypeId, PTM.TaxId,ptt.TaxAmount, ptt.PCId, 0 as TaxAmt,TaxFormatId,TaxFormat
from 
ProjectTaxTemplate ptt inner join  TaxTemplateMaster PTM on  ptt.TaxId=PTM.TaxId
left join VW_ProjectCharges pct on  ptt.PCId=pct.PCId	and pct.FlatTypeId=@FlatTypeId			
where			  
ptt.TaxId=PTM.TaxId and ptt.IncludeIn=2
and ptm.PCId=@PCId and ptt.ChargeId >0
and convert(smalldatetime,ptt.ApplicableDate,106)<=convert(smalldatetime,@BookingDate,106)
	
			) a
		
		UNION
		
	select *,(select STUFF((select distinct '+ ' + ptt1.ChargeNameDesc   
								 from ProjectTaxTemplate ptt1
								 where ptt1.TaxId=a.TaxId
								 for xml path('')),1,1,'')) as [ChargeName],CAST (0 As bit)Tax1
								 
	from 
	(
	Select distinct ptt.IncludeIn,ptt.ApplicableDate, PTM.TaxName,ptt.TaxTypeId, PTM.TaxId,ptt.TaxAmount, ptt.PCId, 0 as TaxAmt,TaxFormatId,TaxFormat
from 
ProjectTaxTemplate ptt inner join  TaxTemplateMaster PTM on  ptt.TaxId=PTM.TaxId
left join VW_ProjectCharges pct on  ptt.PCId=pct.PCId	and pct.FlatTypeId=@FlatTypeId			
where			  
ptt.TaxId=PTM.TaxId and ptt.IncludeIn=2
and ptm.PCId=@PCId and ptt.ChargeId <0
and convert(smalldatetime,ptt.ApplicableDate,106)<=convert(smalldatetime,@BookingDate,106)
	
	

			) a
			)T
	order  by ApplicableDate desc
	
	-------TAX DETAILS BEFORE AV------------
	select * from ProjectTaxTemplate
		where PCId=@PCId And IncludeIn=1
		and convert(smalldatetime,ApplicableDate,106)<=convert(smalldatetime,@BookingDate,106)
		order by ApplicableDate desc

Return
End



If(@Action=2)---Insert Into Booking_ChargesDetails---
Begin 
Insert Into Booking_ChargesDetails 
(BookingId,PCTemplate,ChargeId,CollectionFor,Value,ChargeAmt,Type)
Values
(@BookingId,@PCTemplate,@ChargeId,@CollectionFor,@Value,@ChargeAmt,@Type)
Return
End

If(@Action=3)---Insert Into BookingTaxDetails---
Begin 
Insert Into BookingTaxDetails 
(BookingId,TaxId,TaxTypeId,TaxFormatId,TaxValue,Amount,IncludeIn,TaxDtlId)
Values
(@BookingId,@TaxId,@TaxTypeId,@TaxFormatId,@TaxValue,@Amount,@IncludeIn,@TaxDtlId)

--update used count in tax templet master
update TaxTemplateDtls 
set UsedCount=UsedCount+1
where TaxId=@TaxId

update TaxTemplateMaster 
set UsedCount=UsedCount+1
where TaxId=@TaxId

Select SCOPE_IDENTITY();
Return
End

If(@Action=4)
Begin
Insert Into BookingTaxChargesDetails 
(Booking_TaxDtlsId,BookingId,ChargeId)
Values
(@Booking_TaxDtlsId,@BookingId,@ChargeId)
Return
End

If(@Action=5)
Begin
select * from ProjectTaxTemplate
where  IncludeIn=1 And PCId=@PCId and TaxId=@TaxId 
and convert(smalldatetime,ApplicableDate,106)<=convert(smalldatetime,@BookingDate,106) 
order by ApplicableDate desc
Return
End

If(@Action=6)
Begin
select * from ProjectTaxTemplate
where  IncludeIn=2 And PCId=@PCId and TaxId=@TaxId 
and convert(smalldatetime,ApplicableDate,106)<=convert(smalldatetime,@BookingDate,106) 
order by ApplicableDate desc
Return
End