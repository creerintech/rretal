<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="Copy of ProjectConfigurator1.aspx.cs" Inherits="Masters_ProjectConfigurator1"
    Title="Project Configurator" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <input type="hidden" id="hiddenbox" runat="server" value="" />
    <input type="hidden" id="endreq" value="0" />
    <input type="hidden" id="bodyy" value="0" />

    <script type="text/javascript" language="javascript">

    function Sqrftcheck() 
    {
        var rb1 = document.getElementById('<%= RBAll.ClientID %>');
          
        if (rb1.checked) 
        {   

                document.getElementById('<%=TrEven.ClientID%>').style.visibility = "hidden";
                document.getElementById('<%=TrOdd.ClientID%>').style.visibility = "hidden";
                document.getElementById('<%=txtSqft.ClientID%>').disabled = false;
                
        }
        else 
        {
  
               document.getElementById('<%=TrEven.ClientID%>').style.visibility = "visible";
                document.getElementById('<%=TrOdd.ClientID%>').style.visibility = "visible";
             
                document.getElementById('<%=txtSqft.ClientID%>').disabled = true;
        }

    }
    
    function UpdateEquipFunction() {

        var value = document.getElementById('<%=txtProjectName.ClientID%>').value;

        if (value == "") {
            document.getElementById('<%= hiddenbox.ClientID%>').value = "1";
        }
        else {
            if (confirm("Would You Want To Upadte The Record ?") == true) {
                document.getElementById('<%= hiddenbox.ClientID%>').value = "0";
                return false;
            }
            else {
                document.getElementById('<%= hiddenbox.ClientID%>').value = "100";

            }
        }
    }  

    function DeleteEquipFunction() {

        var value = document.getElementById('<%=txtProjectName.ClientID%>').value;

        if (value == "") {
            document.getElementById('<%= hiddenbox.ClientID%>').value = "1";
        }
        else {
            if (confirm("Would You Want To Delete This Record ?") == true) {
                document.getElementById('<%= hiddenbox.ClientID%>').value = "0";
                return false;
            }
            else {
                document.getElementById('<%= hiddenbox.ClientID%>').value = "100";

            }
        }
    }
    
    function CalSubTotal() //function for adding textbox value in gridview
    {  

        var _GridPayment = document.getElementById('<%= GridDetails.ClientID %>');  
        var _TxtSubTotal = document.getElementById('<%= txtSubTotal .ClientID %>');  
        var _TxtTerraceAreaPer = document.getElementById('<%= txtTerraceAreaPer .ClientID %>');  
        var _TxtGardenAreaPer = document.getElementById('<%= txtGardenAreaPer .ClientID %>');  
        
        if (_TxtTerraceAreaPer.value== "" || isNaN(_TxtTerraceAreaPer.value))
        {
            _TxtTerraceAreaPer.value=0;           
        }
        if (_TxtGardenAreaPer.value== "" || isNaN(_TxtGardenAreaPer.value))
        {
            _TxtGardenAreaPer.value=0;           
        }
        
        var t3=0,t4=0,t5=0,t6=0,t7=0;
        var NewTerraceArea=0,NewGardenArea=0;
       
          for (i = 0; i <= _GridPayment.rows.length; i++) 
          {
             var  col2 = _GridPayment.rows[i].cells[2];
             var  col3 = _GridPayment.rows[i].cells[3];
             var  col4 = _GridPayment.rows[i].cells[4];
             
             for (j = 0; j < col2.childNodes.length; j++) {
                    if (col2.childNodes[j].type == "text") {
                        if (!isNaN(col2.childNodes[j].value) && col2.childNodes[j].value != "") {
                            t4 = parseInt(col2.childNodes[j].value);
                             if(t4>0)
                            {
                                t3+=t4;
                            }
                            NewTerraceArea=(parseFloat(_TxtTerraceAreaPer.value)*parseFloat(col3.childNodes[j].value))/100;

                            t5 = parseInt(NewTerraceArea);
                            if(t5>0)
                            {
                                t3+=t5;
                            }
                            NewGardenArea=(parseFloat(_TxtGardenAreaPer.value)*parseFloat(col4.childNodes[j].value))/100;    

                            t6 = parseInt(NewGardenArea);
                             if(t6>0)
                            {
                                t3+=t6;
                            }
                           
                        }
                    }
                }
                  
                 _GridPayment.rows[i].cells[5].childNodes[i].value=parseFloat(t3);
              }
        _TxtSubTotal.value=parseFloat(t3);
        
    }  
    </script>

    <script type="text/javascript" language="javascript">

 function CalSubTotalNew() //function for Calculating Saleable Area
    {  

        var _GridPayment = document.getElementById('<%= GridDetails.ClientID %>');  
        var _TxtSubTotal = document.getElementById('<%= txtSubTotal .ClientID %>');  
        var _TxtTerraceAreaPer = document.getElementById('<%= txtTerraceAreaPer .ClientID %>');  
        var _TxtGardenAreaPer = document.getElementById('<%= txtGardenAreaPer .ClientID %>');  
        var TotalSaleable=0;
        if (_TxtTerraceAreaPer.value== "" || isNaN(_TxtTerraceAreaPer.value))
        {
            _TxtTerraceAreaPer.value=0;           
        }
        if (_TxtGardenAreaPer.value== "" || isNaN(_TxtGardenAreaPer.value))
        {
            _TxtGardenAreaPer.value=0;           
        }
        

        for (i = 3; i <= _GridPayment.rows.length-1; i++) 
        {

            var  NewTerraceArea=(parseFloat(_TxtTerraceAreaPer.value)*parseFloat(_GridPayment.rows[i].cells[4].children[0].value))/100;
            var NewGardenArea=(parseFloat(_TxtGardenAreaPer.value)*parseFloat(_GridPayment.rows[i].cells[5].children[0].value))/100;
            var UnitArea=_GridPayment.rows[i].cells[3].children[0].value;
            
            var  NewTerraceAreaSaleBuiltUp=(parseFloat(_TxtTerraceAreaPer.value)*parseFloat(_GridPayment.rows[i].cells[8].children[0].value))/100;
            var NewGardenAreaSaleBuiltUp=(parseFloat(_TxtGardenAreaPer.value)*parseFloat(_GridPayment.rows[i].cells[9].children[0].value))/100;
            var SqftSaleBuiltUp=_GridPayment.rows[i].cells[7].children[0].value;
            
          
            _GridPayment.rows[i].cells[6].children[0].value=parseFloat(UnitArea)+parseFloat(NewTerraceArea)+parseFloat(NewGardenArea);
            
            _GridPayment.rows[i].cells[10].children[0].value=parseFloat(SqftSaleBuiltUp)+parseFloat(NewTerraceAreaSaleBuiltUp)+parseFloat(NewGardenAreaSaleBuiltUp);

           
          
           _GridPayment.rows[i].cells[20].children[0].value=_TxtTerraceAreaPer.value;
            _GridPayment.rows[i].cells[21].children[0].value=_TxtGardenAreaPer.value;
           

            TotalSaleable =(parseFloat(TotalSaleable)+ parseFloat(_GridPayment.rows[i].cells[10].children[0].value));

        }

        _TxtSubTotal.value=parseFloat(TotalSaleable);
        
    }

    function CalNetTotal(obj) //function for adding textbox value in gridview
    {  
        var _GridPayment = document.getElementById('<%= GridDetails.ClientID %>');  
        var _TxtSubTotal = document.getElementById('<%= txtSubTotal .ClientID %>');  
        var _TxtTerraceAreaPer = document.getElementById('<%= txtTerraceAreaPer .ClientID %>');  
        var _TxtGardenAreaPer = document.getElementById('<%= txtGardenAreaPer .ClientID %>');  
       
        var rowindex=obj.parentElement.parentElement.rowIndex;
       
        var UnitArea=_GridPayment.rows[rowindex].cells[3].children[0];
        var TerraceArea=_GridPayment.rows[rowindex].cells[4].children[0];
        var GardenArea=_GridPayment.rows[rowindex].cells[5].children[0];
        var TotalArea=_GridPayment.rows[rowindex].cells[6].children[0];
        
        var SqftSaleBuiltUp=_GridPayment.rows[rowindex].cells[7].children[0];
        var TerraceAreaSaleBuiltUp=_GridPayment.rows[rowindex].cells[8].children[0];
        var GardenAreaSaleBuiltUp=_GridPayment.rows[rowindex].cells[9].children[0];
        var SaleableArea=_GridPayment.rows[rowindex].cells[10].children[0];
        
        var AgreementCarpetFlat=_GridPayment.rows[rowindex].cells[11].children[0];
        var AgreementCarpetTerrace=_GridPayment.rows[rowindex].cells[12].children[0];
        
        var AgreementBuiltUpFlat=_GridPayment.rows[rowindex].cells[13].children[0];
        var AgreementBuiltUpTerrace=_GridPayment.rows[rowindex].cells[14].children[0];
  
        if (UnitArea.value== "" || isNaN(UnitArea.value))
        {
            UnitArea.value=0;           
        }
        if (TerraceArea.value== "" || isNaN(TerraceArea.value))
        {
            TerraceArea.value=0;           
        }
        if (GardenArea.value== "" || isNaN(GardenArea.value))
        {
            GardenArea.value=0;           
        }
        if (_TxtTerraceAreaPer.value== "" || isNaN(_TxtTerraceAreaPer.value))
        {
            _TxtTerraceAreaPer.value=0;           
        }
        if (_TxtGardenAreaPer.value== "" || isNaN(_TxtGardenAreaPer.value))
        {
            _TxtGardenAreaPer.value=0;           
        }
        
        
         
        _GridPayment.rows[rowindex].cells[3].children[1].value=parseFloat(UnitArea.value*0.092903).toFixed(5);
        _GridPayment.rows[rowindex].cells[4].children[1].value=parseFloat(TerraceArea.value*0.092903).toFixed(5);
        _GridPayment.rows[rowindex].cells[5].children[1].value=parseFloat(GardenArea.value*0.092903).toFixed(5);
        
        _GridPayment.rows[rowindex].cells[7].children[1].value=parseFloat(SqftSaleBuiltUp.value*0.092903).toFixed(5);
        _GridPayment.rows[rowindex].cells[8].children[1].value=parseFloat(TerraceAreaSaleBuiltUp.value*0.092903).toFixed(5);
        _GridPayment.rows[rowindex].cells[9].children[1].value=parseFloat(GardenAreaSaleBuiltUp.value*0.092903).toFixed(5);
        
        _GridPayment.rows[rowindex].cells[11].children[1].value=parseFloat(AgreementCarpetFlat.value*0.092903).toFixed(5);
        _GridPayment.rows[rowindex].cells[12].children[1].value=parseFloat(AgreementCarpetTerrace.value*0.092903).toFixed(5);
        _GridPayment.rows[rowindex].cells[13].children[1].value=parseFloat(AgreementBuiltUpFlat.value*0.092903).toFixed(5);
        _GridPayment.rows[rowindex].cells[14].children[1].value=parseFloat(AgreementBuiltUpTerrace.value*0.092903).toFixed(5);
        
     
        var Sqmt=_GridPayment.rows[rowindex].cells[3].children[1];
        
        var NewTerraceArea=0,NewGardenArea=0,NewTerraceAreaSaleBuiltUp=0,NewGardenAreaSaleBuiltUp=0;
        
        NewTerraceArea=(parseFloat(_TxtTerraceAreaPer.value)*parseFloat(TerraceArea.value))/100;
        NewGardenArea=(parseFloat(_TxtGardenAreaPer.value)*parseFloat(GardenArea.value))/100;
        
        NewTerraceAreaSaleBuiltUp=(parseFloat(_TxtTerraceAreaPer.value)*parseFloat(TerraceAreaSaleBuiltUp.value))/100;
        NewGardenAreaSaleBuiltUp=(parseFloat(_TxtGardenAreaPer.value)*parseFloat(GardenAreaSaleBuiltUp.value))/100;
        
        TotalArea.value= (parseFloat(UnitArea.value)+parseFloat(NewTerraceArea)+parseFloat(NewGardenArea)).toFixed(0);
        
        SaleableArea.value= (parseFloat(SqftSaleBuiltUp.value)+parseFloat(NewTerraceAreaSaleBuiltUp)+parseFloat(NewGardenAreaSaleBuiltUp)).toFixed(0);
        
        _GridPayment.rows[rowindex].cells[6].children[1].value=parseFloat(TotalArea.value*0.092903).toFixed(5);
        _GridPayment.rows[rowindex].cells[10].children[1].value=parseFloat(SaleableArea.value*0.092903).toFixed(5);
        
        var total=0;
         for(var i=3;i<_GridPayment.rows.length;i++)
         {   
           total =(parseFloat(total)+ parseFloat(_GridPayment.rows[i].cells[7].children[0].value));
         }
         _TxtSubTotal.value=total;
         
        CalSalebleSqM(obj);
        
}
    </script>

    <script type="text/javascript" language="javascript">
    function CalSaleableFSI() //function for adding textbox value in gridview
    {

        var _GridPayment = document.getElementById('<%= GridMainDetail.ClientID %>');  
        var _txtTotalAll = document.getElementById('<%= txtTotalAll .ClientID %>'); 
        var _txtTotalLand = document.getElementById('<%= txtTotalLand .ClientID %>'); 
        var _txtSaleableFSI = document.getElementById('<%= txtSaleableFSI .ClientID %>'); 
        var total=0;
        
        if (_txtTotalLand.value== "" || isNaN(_txtTotalLand.value))
        {
            _txtTotalLand.value=0;           
        }  
        if (_txtSaleableFSI.value== "" || isNaN(_txtSaleableFSI.value))
        {
            _txtSaleableFSI.value=0;           
        }  
        _txtSaleableFSI.value=parseFloat( parseFloat(_txtTotalAll.value)/parseFloat(_txtTotalLand.value) ).toFixed(2);
    }
    </script>

    <script type="text/javascript" language="javascript">
 function CalSalebleSqM(obj) //function for adding textbox value in gridview
    {  
      var _GridPayment = document.getElementById('<%= GridDetails.ClientID %>');  
        var rowindex=obj.parentElement.parentElement.rowIndex;
       var _TxtSubTotal = document.getElementById('<%= txtSubTotal .ClientID %>');  
        var SaleableArea=_GridPayment.rows[rowindex].cells[10].children[0];
        
          if (SaleableArea.value== "" || isNaN(SaleableArea.value))
        {
            SaleableArea.value=0;           
        }
         var total=0;
         for(var i=3;i<_GridPayment.rows.length;i++)
         {   
          total =(parseFloat(total)+ parseFloat(_GridPayment.rows[i].cells[10].children[0].value));
         }
         
         _TxtSubTotal.value=total;
        _GridPayment.rows[rowindex].cells[10].children[1].value=parseFloat(SaleableArea.value*0.092903).toFixed(4);
    }
    
    function CalSalebleSqMMain(obj) //function for adding textbox value in gridview
    {  
      var _GridPayment = document.getElementById('<%= GridMainDetail.ClientID %>');  
        var rowindex=obj.parentElement.parentElement.rowIndex;
       var _TxtSubTotal = document.getElementById('<%= txtTotalAll .ClientID %>');  
        var SaleableArea=_GridPayment.rows[rowindex].cells[10].children[0];
        
          if (SaleableArea.value== "" || isNaN(SaleableArea.value))
        {
            SaleableArea.value=0;           
        }
         var total=0;
         for(var i=3;i<_GridPayment.rows.length;i++)
         {   
          total =(parseFloat(total)+ parseFloat(_GridPayment.rows[i].cells[10].children[0].value));
          alert(parseFloat(_GridPayment.rows[i].cells[10].children[0].value));
          alert(total);

         }
         
         _TxtSubTotal.value=total;
        _GridPayment.rows[rowindex].cells[10].children[1].value=parseFloat(SaleableArea.value*0.092903).toFixed(4);
    }
    
    </script>

    <script language="javascript" type="text/javascript">

function newDoc(Obj)
  {
    var tbl = $("[id$=GridDocumentList]");
    var rows = tbl.find('tr');
  
      var rowindex=Obj.parentElement.parentElement.rowIndex;
        var row = rows[rowindex];
        var userName = $(row).find("[id*=lblImgPath]").text();
     
        if(userName!="")
        {
        window.open("../PrintReport/PrintReports.aspx?ID="+userName+"&Flag=DocPrint",'_blank');

        }
        else
        {
          alert("Please Select Image First..!");
        }
  }
    </script>

    <script type="text/javascript">
            var prm;
            prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(beginRequestHandler);
            prm.add_endRequest(endRequestHandler);

            $(window).scroll(function() {
                var cend = $("#endreq").val();
                if (cend == "1") {
                    $("#endreq").val("0");
                    var nbodyY = $("#bodyy").val();
                    $(window).scrollTop(nbodyY);
                    //alert(nbodyY);
                 
                }
            });

function beginRequestHandler(sender, event) {
    $("#endreq").val("0");
    $("#bodyy").val($(window).scrollTop());
}

function endRequestHandler(sender, evemt) {
    $("#endreq").val("1");
}
    </script>

    <script type="text/javascript" language="javascript">
    function CalSqftFromSqm(obj) //function for adding textbox value in gridview
    {  
        var _GridPayment = document.getElementById('<%= GridDetails.ClientID %>');  
        var _TxtSubTotal = document.getElementById('<%= txtSubTotal .ClientID %>');  
        var _TxtTerraceAreaPer = document.getElementById('<%= txtTerraceAreaPer .ClientID %>');  
        var _TxtGardenAreaPer = document.getElementById('<%= txtGardenAreaPer .ClientID %>');  
       
        var rowindex=obj.parentElement.parentElement.rowIndex;
       
     
        var AgreementCarpetFlat=_GridPayment.rows[rowindex].cells[11].children[1];
        var AgreementCarpetTerrace=_GridPayment.rows[rowindex].cells[12].children[1];
        
        var AgreementBuiltUpFlat=_GridPayment.rows[rowindex].cells[13].children[1];
        var AgreementBuiltUpTerrace=_GridPayment.rows[rowindex].cells[14].children[1];
  
      
        if (_TxtTerraceAreaPer.value== "" || isNaN(_TxtTerraceAreaPer.value))
        {
            _TxtTerraceAreaPer.value=0;           
        }
        if (_TxtGardenAreaPer.value== "" || isNaN(_TxtGardenAreaPer.value))
        {
            _TxtGardenAreaPer.value=0;           
        }
        
       
        _GridPayment.rows[rowindex].cells[11].children[0].value=parseFloat(AgreementCarpetFlat.value/0.092903).toFixed(4);
        _GridPayment.rows[rowindex].cells[12].children[0].value=parseFloat(AgreementCarpetTerrace.value/0.092903).toFixed(4);
        _GridPayment.rows[rowindex].cells[13].children[0].value=parseFloat(AgreementBuiltUpFlat.value/0.092903).toFixed(4);
        _GridPayment.rows[rowindex].cells[14].children[0].value=parseFloat(AgreementBuiltUpTerrace.value/0.092903).toFixed(4);
        
    }
    </script>

<script type="text/javascript" language="javascript">
 function CalNetTotalMainGrid(obj) //function for adding textbox value in gridview
    {  
        var _GridPayment = document.getElementById('<%= GridMainDetail.ClientID %>');  
        var _TxtSubTotal = document.getElementById('<%= txtTotalAll.ClientID %>');  
        var _TxtTerraceAreaPer = document.getElementById('<%= txtTerraceAreaPer.ClientID %>');  
        var _TxtGardenAreaPer = document.getElementById('<%= txtGardenAreaPer.ClientID %>');  
       
        var rowindex=obj.parentElement.parentElement.rowIndex;
       
        var UnitArea=_GridPayment.rows[rowindex].cells[4].children[0];
        var TerraceArea=_GridPayment.rows[rowindex].cells[5].children[0];
        var GardenArea=_GridPayment.rows[rowindex].cells[6].children[0];
        var TotalArea=_GridPayment.rows[rowindex].cells[7].children[0];
        
        var SqftSaleBuiltUp=_GridPayment.rows[rowindex].cells[8].children[0];
        var TerraceAreaSaleBuiltUp=_GridPayment.rows[rowindex].cells[9].children[0];
        var GardenAreaSaleBuiltUp=_GridPayment.rows[rowindex].cells[10].children[0];
        var SaleableArea=_GridPayment.rows[rowindex].cells[11].children[0];
        
        var AgreementCarpetFlat=_GridPayment.rows[rowindex].cells[12].children[0];
        var AgreementCarpetTerrace=_GridPayment.rows[rowindex].cells[13].children[0];
        
        var AgreementBuiltUpFlat=_GridPayment.rows[rowindex].cells[14].children[0];
        var AgreementBuiltUpTerrace=_GridPayment.rows[rowindex].cells[15].children[0];
  
        if (UnitArea.value== "" || isNaN(UnitArea.value))
        {
            UnitArea.value=0;           
        }
        if (TerraceArea.value== "" || isNaN(TerraceArea.value))
        {
            TerraceArea.value=0;           
        }
        if (GardenArea.value== "" || isNaN(GardenArea.value))
        {
            GardenArea.value=0;           
        }
        if (_TxtTerraceAreaPer.value== "" || isNaN(_TxtTerraceAreaPer.value))
        {
            _TxtTerraceAreaPer.value=0;           
        }
        if (_TxtGardenAreaPer.value== "" || isNaN(_TxtGardenAreaPer.value))
        {
            _TxtGardenAreaPer.value=0;           
        }
        
        
         
        _GridPayment.rows[rowindex].cells[4].children[1].value=parseFloat(UnitArea.value*0.092903).toFixed(5);
        _GridPayment.rows[rowindex].cells[5].children[1].value=parseFloat(TerraceArea.value*0.092903).toFixed(5);
        _GridPayment.rows[rowindex].cells[6].children[1].value=parseFloat(GardenArea.value*0.092903).toFixed(5);
        
        _GridPayment.rows[rowindex].cells[8].children[1].value=parseFloat(SqftSaleBuiltUp.value*0.092903).toFixed(5);
        _GridPayment.rows[rowindex].cells[9].children[1].value=parseFloat(TerraceAreaSaleBuiltUp.value*0.092903).toFixed(5);
        _GridPayment.rows[rowindex].cells[10].children[1].value=parseFloat(GardenAreaSaleBuiltUp.value*0.092903).toFixed(5);
        
        _GridPayment.rows[rowindex].cells[12].children[1].value=parseFloat(AgreementCarpetFlat.value*0.092903).toFixed(5);
        _GridPayment.rows[rowindex].cells[13].children[1].value=parseFloat(AgreementCarpetTerrace.value*0.092903).toFixed(5);
        _GridPayment.rows[rowindex].cells[14].children[1].value=parseFloat(AgreementBuiltUpFlat.value*0.092903).toFixed(5);
        _GridPayment.rows[rowindex].cells[15].children[1].value=parseFloat(AgreementBuiltUpTerrace.value*0.092903).toFixed(5);
        
     
        var Sqmt=_GridPayment.rows[rowindex].cells[4].children[1];
        
        var NewTerraceArea=0,NewGardenArea=0,NewTerraceAreaSaleBuiltUp=0,NewGardenAreaSaleBuiltUp=0;
        
        NewTerraceArea=(parseFloat(_TxtTerraceAreaPer.value)*parseFloat(TerraceArea.value))/100;
        NewGardenArea=(parseFloat(_TxtGardenAreaPer.value)*parseFloat(GardenArea.value))/100;
        
        NewTerraceAreaSaleBuiltUp=(parseFloat(_TxtTerraceAreaPer.value)*parseFloat(TerraceAreaSaleBuiltUp.value))/100;
        NewGardenAreaSaleBuiltUp=(parseFloat(_TxtGardenAreaPer.value)*parseFloat(GardenAreaSaleBuiltUp.value))/100;
        
        TotalArea.value= (parseFloat(UnitArea.value)+parseFloat(NewTerraceArea)+parseFloat(NewGardenArea)).toFixed(0);
        
        SaleableArea.value= (parseFloat(SqftSaleBuiltUp.value)+parseFloat(NewTerraceAreaSaleBuiltUp)+parseFloat(NewGardenAreaSaleBuiltUp)).toFixed(0);
        
        _GridPayment.rows[rowindex].cells[7].children[1].value=parseFloat(TotalArea.value*0.092903).toFixed(5);
        _GridPayment.rows[rowindex].cells[11].children[1].value=parseFloat(SaleableArea.value*0.092903).toFixed(5);
        
        var total=0;
         for(var i=3;i<_GridPayment.rows.length;i++)
         {   
        
           total =(parseFloat(total)+ parseFloat(_GridPayment.rows[i].cells[11].children[0].value));
         
         }
         _TxtSubTotal.value=total.toFixed(2);
         
         

}
</script>

<script type="text/javascript" language="javascript">
function CalSubTotalMain() //function for Calculating Saleable Area
    {  

        var _GridPayment = document.getElementById('<%= GridMainDetail.ClientID %>');  
        var _TxtSubTotal = document.getElementById('<%= txtTotalAll .ClientID %>');  
        var _TxtTerraceAreaPer = document.getElementById('<%= txtTerraceAreaPer .ClientID %>');  
        var _TxtGardenAreaPer = document.getElementById('<%= txtGardenAreaPer .ClientID %>');  
        var TotalSaleable=0;
        if (_TxtTerraceAreaPer.value== "" || isNaN(_TxtTerraceAreaPer.value))
        {
            _TxtTerraceAreaPer.value=0;           
        }
        if (_TxtGardenAreaPer.value== "" || isNaN(_TxtGardenAreaPer.value))
        {
            _TxtGardenAreaPer.value=0;           
        }
        

        for (i = 3; i <= _GridPayment.rows.length-1; i++) 
        {
            TotalSaleable = (parseFloat(TotalSaleable) + parseFloat(_GridPayment.rows[i].cells[11].children[0].value));
           
        }

        _TxtSubTotal.value=parseFloat(TotalSaleable);
        
    }
</script>
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            Search for Project Type :
            <asp:TextBox ID="TxtSearch" runat="server" CssClass="search" ToolTip="Enter The Text"
                Width="292px" AutoPostBack="True" OnTextChanged="TxtSearch_TextChanged">
            </asp:TextBox>
            <div id="divwidth">
            </div>
            <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtSearch"
                CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                ServiceMethod="GetCompletionList" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                CompletionListHighlightedItemCssClass="AutoExtenderHighlight">
            </ajax:AutoCompleteExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    Project Configurator
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <asp:UpdatePanel ID="AjaxPanelUpdateEntry" runat="server">
        <ContentTemplate>
            <table style="width: 100%">
                <tr>
                    <td align="center">
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                            <ProgressTemplate>
                                <div id="progressBackgroundFilter">
                                </div>
                                <div id="processMessage">
                                    <center>
                                        <span class="SubTitle">Loading....!!! </span>
                                    </center>
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icon/updateprogress.gif" />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td>
                        <fieldset id="fieldset" runat="server" class="FieldSet">
                            <table width="100%" cellspacing="6">
                                <tr>
                                    <td class="Label">
                                    </td>
                                    <td align="left" colspan="2">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        PC NO. :
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox ID="txtPCNo" runat="server" CssClass="TextBoxReadOnly"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Project Name
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtProjectName" runat="server" CssClass="TextBox" MaxLength="50"
                                            Width="350px"></asp:TextBox>
                                    </td>
                                    <td class="Label">
                                        Project Type :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProjectType" runat="server" Width="370px" CssClass="ComboBox"
                                            OnSelectedIndexChanged="ddlProjectType_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Req1" runat="server" ControlToValidate="txtProjectName"
                                            Display="None" ErrorMessage="ProjectName Is Required" SetFocusOnError="True"
                                            ValidationGroup="Add">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                            TargetControlID="Req1" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Project Subtype :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlProjectSubtype" runat="server" Width="350px" CssClass="ComboBox">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Project Address :
                                    </td>
                                    <td align="left" colspan="4">
                                        <asp:TextBox ID="txtAddress" runat="server" Width="885px" CssClass="TextBox" TextMode="MultiLine"
                                            Font-Names="Verdana"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-size: small; font-weight: bold; text-align: left;" colspan="2">
                                        Cheques/DD to be made:-
                                    </td>
                                    <td align="left" colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        For Stamp Duty:
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtStampDuty" runat="server" Width="350px" CssClass="TextBox" Font-Names="Verdana"></asp:TextBox>
                                    </td>
                                    <td class="Label">
                                        For Registration:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRegistration" runat="server" Width="350px" CssClass="TextBox"
                                            Font-Names="Verdana"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        For Vat/Service Tax:
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtVat" runat="server" Width="350px" CssClass="TextBox" Font-Names="Verdana"></asp:TextBox>
                                    </td>
                                    <td class="Label">
                                        For Service Tax:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtServiceTax" runat="server" Width="350px" CssClass="TextBox" Font-Names="Verdana"></asp:TextBox>
                                    </td>
                                </tr>
                                <caption>
                                    <tr>
                                        <td class="Label">
                                            Towards Collection of unit:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCollection" runat="server" CssClass="TextBox" Font-Names="Verdana"
                                                Width="350px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Label">
                                            Unit Cancellation Charge:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCancelCharge" runat="server" CssClass="TextBox" Font-Names="Verdana"
                                                Width="350px"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FE1" runat="server" TargetControlID="txtCancelCharge"
                                                FilterType="Custom,Numbers" FilterMode="ValidChars" ValidChars=".">
                                            </ajax:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Label">
                                            Company Name :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCompanyName" runat="server" CssClass="TextBox" Width="350px"></asp:TextBox>
                                        </td>
                                        <td class="Label">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCompanyName"
                                                Display="None" ErrorMessage="Company Name Is Required" SetFocusOnError="True"
                                                ValidationGroup="AddGridComp"></asp:RequiredFieldValidator>
                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender18" runat="server" Enabled="True"
                                                TargetControlID="RequiredFieldValidator9" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                            </ajax:ValidatorCalloutExtender>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Label">
                                            Company Address :
                                        </td>
                                        <td align="left" colspan="4">
                                            <asp:TextBox ID="txtCompanyAddress" runat="server" CssClass="TextBox" Font-Names="Verdana"
                                                TextMode="MultiLine" Width="885px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" width="110px">
                                            Company Logo :
                                        </td>
                                        <td>
                                            <table width="50%">
                                                <tr>
                                                    <td align="left" width="20%">
                                                        <asp:UpdatePanel ID="updatePanel7" runat="server">
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="lnkCompany" />
                                                            </Triggers>
                                                            <ContentTemplate>
                                                                <asp:FileUpload ID="CompanyLogoUpload" runat="server" CssClass="TextBox" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="CompanyLogoUpload"
                                                                    Display="None" ErrorMessage="Upload Image File only" SetFocusOnError="True" ValidationExpression="^.*\.((j|J)(p|P)(e|E)?(g|G)|(g|G)(i|I)(f|F)|(p|P)(n|N)(g|G)|(b|B)(m|M)(p|P))$"
                                                                    ValidationGroup="AddGridComp1"></asp:RegularExpressionValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" TargetControlID="RegularExpressionValidator6"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="CompanyLogoUpload"
                                                                    Display="None" ErrorMessage="Upload File First!" SetFocusOnError="True" ValidationGroup="AddGridComp1"></asp:RequiredFieldValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" TargetControlID="RequiredFieldValidator6"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lnkCompany" runat="server" OnClick="lnkCompany_Click" ValidationGroup="AddGridComp">Upload</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ImgDone" runat="server" CssClass="Imagebutton" Height="16px"
                                                ImageUrl="~/Images/New Icon/DoneChanges.png" ToolTip="Add Grid" Width="16px" />
                                            <asp:ImageButton ID="ImgAddCompany" runat="server" CssClass="Imagebutton" Height="16px"
                                                ImageUrl="~/Images/Icon/Gridadd.png" OnClick="ImgAddCompany_Click" ToolTip="Add Grid"
                                                ValidationGroup="AddGridComp" Width="16px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLogopath" runat="server" Text="Label" Visible="false"></asp:Label>
                                            <asp:Image ID="ImgCompanyLogo" runat="server" Height="30px" Width="40px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div class="scrollableDiv">
                                                <asp:GridView ID="GridCompany" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                                    OnRowCommand="GridCompany_RowCommand" OnRowDeleting="GridCompany_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageGridEdit" runat="server" CommandArgument="<%#((GridViewRow)Container).RowIndex %>"
                                                                    CommandName="SelectGrid" ImageUrl="~/Images/Icon/GridEdit.png" ToolTip="Edit" />
                                                                <asp:ImageButton ID="ImgBtnDelete" runat="server" CommandArgument='<%# Eval("#") %>'
                                                                    CommandName="Delete" ImageUrl="~/Images/Icon/GridDelete.png" ToolTip="Delete"
                                                                    ValidationGroup="Add" />
                                                                <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Would You Like To Delete The Record..!"
                                                                    TargetControlID="ImgBtnDelete">
                                                                </ajax:ConfirmButtonExtender>
                                                            </ItemTemplate>
                                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <HeaderStyle Wrap="False" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Company">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCompany" runat="server" CssClass="Label" Text='<%# Eval("Company") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="30%" />
                                                            <ItemStyle Width="30%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Address">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCompanyAddress" runat="server" CssClass="Label" Text='<%# Eval("CompanyAddress") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="40%" />
                                                            <ItemStyle Width="40%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="LogoImage">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLogoImg" runat="server" CssClass="Label" Text='<%# Eval("LogoImg") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="30%" />
                                                            <ItemStyle Width="30%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Label">
                                            No. of Towers
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtNoofTower" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtNoofTower"
                                                FilterType="Numbers">
                                            </ajax:FilteredTextBoxExtender>
                                        </td>
                                        <td class="Label">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Label">
                                            Tower Name :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtTowerName" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                                        </td>
                                        <td class="Label">
                                            Same As :
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlClone" runat="server" Width="100px">
                                            </asp:DropDownList>
                                            <asp:Button ID="btnClone" runat="server" CssClass="button" OnClick="btnClone_Click"
                                                Text="Clone" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Label">
                                        </td>
                                        <td align="left">
                                            <asp:RadioButtonList ID="RBType" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RBType_SelectedIndexChanged"
                                                AutoPostBack="True">
                                                <asp:ListItem Selected="True" Value="0">Unit Configuration</asp:ListItem>
                                                <asp:ListItem Value="1">Floorwise Unit Configuration</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Label">
                                            No. of Floors :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFloor" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtFloor"
                                                FilterType="Numbers">
                                            </ajax:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr id="TrAll" runat="server" visible="false">
                                        <td class="Label">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:RadioButton ID="RBAll" runat="server" GroupName="RB" onclick="Sqrftcheck();"
                                                Text="All" />
                                            &nbsp;<asp:RadioButton ID="RBEvenOdd" runat="server" GroupName="RB" onclick="Sqrftcheck();"
                                                Text="Even/Odd" />
                                        </td>
                                        <td class="Label">
                                            SqrFt All :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtSqft" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="TrEven" runat="server" visible="false">
                                        <td class="Label">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            &nbsp;
                                        </td>
                                        <td class="Label">
                                            Sqrft Even :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtSqftEven" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="TrOdd" runat="server" visible="false">
                                        <td class="Label">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            &nbsp;
                                        </td>
                                        <td class="Label">
                                            sqrft Odd :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtSqftOdd" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Label">
                                            No. of Units/Floor :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtUnit" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtUnit"
                                                FilterType="Numbers">
                                            </ajax:FilteredTextBoxExtender>
                                            <asp:ImageButton ID="ImgAddGrid" runat="server" CssClass="Imagebutton" Height="16px"
                                                ImageUrl="~/Images/Icon/Gridadd.png" OnClick="ImgAddGrid_Click" ToolTip="Add Grid"
                                                ValidationGroup="AddGrid" Width="16px" />
                                        </td>
                                    </tr>
                                    <tr id="trApply" runat="server">
                                        <td colspan="2">
                                            Apply To All :
                                            <asp:ImageButton ID="ApplyToAll" runat="server" CssClass="Imagebutton" Height="16px"
                                                ImageUrl="~/Images/New Icon/DoneChanges.png" OnClick="ApplyToAll_Click" ToolTip="Apply To All"
                                                ValidationGroup="AddGrid" Width="16px" />
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="lblApply" runat="server" Text="Apply to Even and Odd">
                                            </asp:Label>
                                            <asp:ImageButton ID="ApplyToEvenOdd" runat="server" CssClass="Imagebutton" Height="16px"
                                                ImageUrl="~/Images/New Icon/DoneChanges.png" OnClick="ApplyToEvenOdd_Click" ToolTip="Apply To EvenOdd:"
                                                ValidationGroup="AddGrid" Width="16px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="middle" class="Label2" colspan="4">
                                            Chargable(%) For :-
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Label">
                                            Terrace Area :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtTerraceAreaPer" runat="server" CssClass="TextBox" Width="200px"
                                                onkeyup="CalSubTotalNew();"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtTerraceAreaPer"
                                                FilterType="Custom,Numbers" FilterMode="ValidChars" ValidChars=".">
                                            </ajax:FilteredTextBoxExtender>
                                        </td>
                                        <td class="Label">
                                            Garden Area :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtGardenAreaPer" runat="server" CssClass="TextBox" Width="200px"
                                                onkeyup="CalSubTotalNew();"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtGardenAreaPer"
                                                FilterType="Custom,Numbers" FilterMode="ValidChars" ValidChars=".">
                                            </ajax:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <asp:Label ID="Label2" runat="server" Text="Tower Detail Grid :-" CssClass="Label2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <div class="scrollableDivN" id="DivDetailGrid" runat="server">
                                                <asp:GridView ID="GridDetails" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                                    OnRowDataBound="GridDetails_RowDataBound" OnRowCreated="GridDetails_RowCreated" >
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Upload Layout">
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="updatePanelLay" runat="server">
                                                                    <Triggers>
                                                                        <asp:PostBackTrigger ControlID="lnkUploadLayout" />
                                                                    </Triggers>
                                                                    <ContentTemplate>
                                                                        <asp:FileUpload ID="FuUpload2" runat="server" CssClass="TextBox" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                                <asp:Label ID="lblImgPath" runat="server" Text='<%#Eval("LayoutPath")%>' Width="250px"></asp:Label>
                                                                <asp:LinkButton ID="lnkUploadLayout" runat="server" OnClick="lnkUploadLayout_Click"
                                                                    Text="Upload"></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkCancelDoc" runat="server" Text="Cancel" OnClick="lnkCancelDoc_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="250px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tower Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTowerName" runat="server" CssClass="Label" Text='<%# Eval("TowerName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFlatNo" runat="server" CssClass="Label" Text='<%# Eval("FlatNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Flat Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtSqft" runat="server" CssClass="TextBox" onkeyup="CalNetTotal(this)"
                                                                    Text='<% #Eval("Sqft") %>' Width="70"></asp:TextBox>
                                                                <asp:TextBox ID="txtSqm" runat="server" CssClass="TextBox" Enabled="false" Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Terrace Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTerraceAreaSaleCarpet" runat="server" CssClass="TextBox" onkeyup="CalNetTotal(this)"
                                                                    Text='<% #Eval("TerraceArea") %>' Width="70"></asp:TextBox>
                                                                <asp:TextBox ID="txtTerraceSqmSaleCarpet" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Garden Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtGardenAreaSaleCarpet" runat="server" CssClass="TextBox" onkeyup="CalNetTotal(this)"
                                                                    Text='<% #Eval("GardenArea") %>' Width="70"></asp:TextBox>
                                                                <asp:TextBox ID="txtGardenSqmSaleCarpet" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" CssClass="Display_None" />
                                                            <ItemStyle Width="50px" CssClass="Display_None" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Carpet Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtCarpetAreaSaleCarpet" runat="server" CssClass="TextBox" onkeyup="CalNetTotal(this)"
                                                                    Text='<% #Eval("CarpetArea") %>' Width="70"></asp:TextBox>
                                                                <asp:TextBox ID="txtCarpetSqmSaleCarpet" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Flat Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtSqftSaleBuiltUp" runat="server" CssClass="TextBox" onkeyup="CalNetTotal(this)"
                                                                    Text='<% #Eval("SqftSaleBuiltUp") %>' Width="70"></asp:TextBox>
                                                                <asp:TextBox ID="txtSqmSaleBuiltUp" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Terrace Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTerraceAreaSaleBuiltUp" runat="server" CssClass="TextBox" onkeyup="CalNetTotal(this)"
                                                                    Text='<% #Eval("TerraceAreaSaleBuiltUp") %>' Width="70"></asp:TextBox>
                                                                <asp:TextBox ID="txtTerraceSqmSaleBuiltUp" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Garden Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtGardenAreaSaleBuiltUp" runat="server" CssClass="TextBox" onkeyup="CalNetTotal(this)"
                                                                    Text='<% #Eval("GardenAreaSaleBuiltUp") %>' Width="70"></asp:TextBox>
                                                                <asp:TextBox ID="txtGardenSqmSaleBuiltUp" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" CssClass="Display_None" />
                                                            <ItemStyle Width="50px" CssClass="Display_None" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtSaleableAreaSaleBuiltUp" runat="server" CssClass="TextBox" Text='<% #Eval("SaleableArea") %>'
                                                                    onkeyup="CalSalebleSqM(this);" Width="70"></asp:TextBox>
                                                                <asp:TextBox ID="txtSaleableSqmSaleBuiltUp" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Flat Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtFlatAgreementCarpet" runat="server" CssClass="TextBox" Text='<% #Eval("AgreementCarpetFlat") %>'
                                                                    Width="70" onkeyup="CalNetTotal(this)"></asp:TextBox>
                                                                <asp:TextBox ID="txtSqmAgreementCarpet" runat="server" CssClass="TextBox" onkeyup="CalSqftFromSqm(this)"
                                                                    Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Terrace Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTerraceAgreementCarpet" runat="server" CssClass="TextBox" Text='<% #Eval("AgreementCarpetTerrace") %>'
                                                                    Width="70" onkeyup="CalNetTotal(this)"></asp:TextBox>
                                                                <asp:TextBox ID="txtTerraceSqmAgreementCarpet" runat="server" CssClass="TextBox"
                                                                    onkeyup="CalSqftFromSqm(this)" Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Flat">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtFlatAgreementBuiltUp" runat="server" CssClass="TextBox" Text='<% #Eval("AgreementBuiltUpFlat") %>'
                                                                    Width="70" onkeyup="CalNetTotal(this)"></asp:TextBox>
                                                                <asp:TextBox ID="txtFlatSqmAgreementBuiltUp" runat="server" CssClass="TextBox" onkeyup="CalSqftFromSqm(this)"
                                                                    Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Terrace">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTerraceAgreementBuiltUp" runat="server" CssClass="TextBox" Text='<% #Eval("AgreementBuiltUpTerrace") %>'
                                                                    Width="70" onkeyup="CalNetTotal(this)"></asp:TextBox>
                                                                <asp:TextBox ID="txtTerraceSqmAgreementBuiltUp" runat="server" CssClass="TextBox"
                                                                    onkeyup="CalSqftFromSqm(this)" Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit Type">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlFlatType" runat="server" Width="100px">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RFFlatType" runat="server" ControlToValidate="ddlFlatType"
                                                                    Display="None" ErrorMessage="Flat Type Required" InitialValue="0" ValidationGroup="AddMain"></asp:RequiredFieldValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" TargetControlID="RFFlatType"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                                <asp:Label ID="lblFlatTypeId" runat="server" CssClass="Display_None" Text='<%# Eval("FlatTypeId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Floor">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFloor" runat="server" CssClass="Label" Text='<%# Eval("Floor") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="Display_None" />
                                                            <ItemStyle CssClass="Display_None" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUnit" runat="server" CssClass="Label" Text='<%# Eval("Unit") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="Display_None" />
                                                            <ItemStyle CssClass="Display_None" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Facing">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlFacingType" runat="server" Width="150px">
                                                                    <asp:ListItem Value="0">--Select Facing--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Front</asp:ListItem>
                                                                    <asp:ListItem Value="2">Rear</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <%--  <asp:RequiredFieldValidator ID="RFFacingType" runat="server" 
                                            ControlToValidate="ddlFacingType" Display="None" 
                                            ErrorMessage="Facing Type Required" InitialValue="0" ValidationGroup="AddMain"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="VCEFacingType" runat="server" 
                                            TargetControlID="RFFacingType" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>--%>
                                                                <asp:Label ID="lblFacingTypeId" runat="server" CssClass="Display_None" Text='<%# Eval("FacingTypeId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="30px" CssClass="Display_None" />
                                                            <ItemStyle Width="30px" CssClass="Display_None" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="FloorNo" HeaderText="FloorNo" />
                                                        <asp:TemplateField HeaderText="TerracePer">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTerracePer" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Text='<%# Eval("TerracePer") %>' Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <%-- <HeaderStyle CssClass="Display_None" />
                                                            <ItemStyle CssClass="Display_None" />--%>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="GardenPer">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtGardenPer" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Text='<%# Eval("GardenPer") %>' Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <%-- <HeaderStyle CssClass="Display_None" />
                                                            <ItemStyle CssClass="Display_None" />--%>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="trAddGrid" runat="server">
                                        <td>
                                        </td>
                                        <td class="Label">
                                            Total Sqft. :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSubTotal" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:ImageButton ID="ImgAddMainDetail" runat="server" CssClass="Imagebutton" Height="16px"
                                                ImageUrl="~/Images/Icon/Gridadd.png" OnClick="ImgAddMainDetail_Click" ToolTip="Add Main Grid"
                                                ValidationGroup="AddMain" Width="16px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <asp:Label ID="Label1" runat="server" Text="Main Grid :-" CssClass="Label2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <div class="scrollableDivN1" id="DivMainGrid" runat="server">
                                                <asp:GridView ID="GridMainDetail" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                                    OnDataBound="GridMainDetail_DataBound" OnRowCommand="GridMainDetail_RowCommand"
                                                    OnRowDataBound="GridMainDetail_RowDataBound" OnRowDeleting="GridMainDetail_RowDeleting"
                                                    OnRowCreated="GridMainDetail_RowCreated" DataKeyNames="UsedCount,PCDetailId" >
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgBtnEdit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("TowerName") %>'
                                                                    CommandName="Select" CssClass="Imagebutton" ImageUrl="~/Images/Icon/GridEdit.png"
                                                                    TabIndex="62" ToolTip="Edit Record" />
                                                                <asp:Label ID="lblselect" runat="server" CssClass="Display_None" Text='<%# Eval("TowerName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="10px" />
                                                            <ItemStyle Width="10px" />
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgBtnDeleteRow" runat="server" CausesValidation="False" CommandArgument='<% #Container.DataItemIndex+1 %>'
                                                                    CommandName="Delete" CssClass="Imagebutton" ImageUrl="~/Images/Icon/GridDelete.png"
                                                                    TabIndex="62" ToolTip="Delete Record" />
                                                                   <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Would You Like To Delete This Record?"
                                                                TargetControlID="ImgBtnDeleteRow">
                                                            </ajax:ConfirmButtonExtender>
                                                             <asp:ImageButton ID="ImgBtnUpdate" runat="server" CausesValidation="False" CommandArgument='<% #Container.DataItemIndex+1 %>'
                                                                    CommandName="ChangeRow" CssClass="Imagebutton" ImageUrl="~/Images/Icon/GridUpdate.png"
                                                                    TabIndex="62" ToolTip="Update Record" />
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="10px" />
                                                            <ItemStyle Width="10px" Wrap="false"/>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tower Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTowerName1" runat="server" CssClass="Label" Text='<%# Eval("TowerName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFlatNo1" runat="server" CssClass="Label" Text='<%# Eval("FlatNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Carpet Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtSqft1" runat="server" CssClass="TextBox" Enabled="true" Text='<% #Eval("Sqft") %>'
                                                                    Width="100" onkeyup="CalNetTotalMainGrid(this)"></asp:TextBox>
                                                                <asp:TextBox ID="txtSqm1" runat="server" CssClass="TextBox" Enabled="false" Width="100"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Terrace Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTerraceAreaSaleCarpet1" runat="server" CssClass="TextBox" Enabled="true"
                                                                    Text='<% #Eval("TerraceArea") %>' Width="100" onkeyup="CalNetTotalMainGrid(this)"></asp:TextBox>
                                                                <asp:TextBox ID="txtTerraceSqmSaleCarpet1" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Width="100"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Garden Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtGardenAreaSaleCarpet1" runat="server" CssClass="TextBox" Enabled="true"
                                                                    Text='<% #Eval("GardenArea") %>' Width="100"></asp:TextBox>
                                                                <asp:TextBox ID="txtGardenSqmSaleCarpet1" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Width="100"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" CssClass="Display_None" />
                                                            <ItemStyle Width="50px" CssClass="Display_None" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Carpet Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtCarpetAreaSaleCarpet1" runat="server" CssClass="TextBox" Enabled="true"
                                                                    Text='<% #Eval("CarpetArea") %>' Width="100"></asp:TextBox>
                                                                <asp:TextBox ID="txtCarpetSqmSaleCarpet1" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Width="100"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Flat Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtSqftSaleBuiltUp1" runat="server" CssClass="TextBox" onkeyup="CalNetTotalMainGrid(this)"
                                                                    Text='<% #Eval("SqftSaleBuiltUp") %>' Width="70" Enabled="true"></asp:TextBox>
                                                                <asp:TextBox ID="txtSqmSaleBuiltUp1" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Terrace Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTerraceAreaSaleBuiltUp1" runat="server" CssClass="TextBox" onkeyup="CalNetTotalMainGrid(this)"
                                                                    Text='<% #Eval("TerraceAreaSaleBuiltUp") %>' Width="70" Enabled="true"></asp:TextBox>
                                                                <asp:TextBox ID="txtTerraceSqmSaleBuiltUp1" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Garden Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtGardenAreaSaleBuiltUp1" runat="server" CssClass="TextBox" onkeyup="CalNetTotalMainGrid(this)"
                                                                    Text='<% #Eval("GardenAreaSaleBuiltUp") %>' Width="70" Enabled="true"></asp:TextBox>
                                                                <asp:TextBox ID="txtGardenSqmSaleBuiltUp1" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" CssClass="Display_None" />
                                                            <ItemStyle Width="50px" CssClass="Display_None" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtSaleableAreaSaleBuiltUp1" runat="server" CssClass="TextBox" Text='<% #Eval("SaleableArea") %>'
                                                                    onkeyup="CalSalebleSqM(this);" Width="70" Enabled="true"></asp:TextBox>
                                                                <asp:TextBox ID="txtSaleableSqmSaleBuiltUp1" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Flat Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtFlatAgreementCarpet1" runat="server" CssClass="TextBox" Text='<% #Eval("AgreementCarpetFlat") %>'
                                                                    Width="70" Enabled="true"></asp:TextBox>
                                                                <asp:TextBox ID="txtSqmAgreementCarpet1" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Terrace Area">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTerraceAgreementCarpet1" runat="server" CssClass="TextBox" Text='<% #Eval("AgreementCarpetTerrace") %>'
                                                                    Width="70" Enabled="true"></asp:TextBox>
                                                                <asp:TextBox ID="txtTerraceSqmAgreementCarpet1" runat="server" CssClass="TextBox"
                                                                    Enabled="false" Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Flat">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtFlatAgreementBuiltUp1" runat="server" CssClass="TextBox" Text='<% #Eval("AgreementBuiltUpFlat") %>'
                                                                    Width="70" Enabled="true"></asp:TextBox>
                                                                <asp:TextBox ID="txtFlatSqmAgreementBuiltUp1" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Terrace">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTerraceAgreementBuiltUp1" runat="server" CssClass="TextBox" Text='<% #Eval("AgreementBuiltUpTerrace") %>'
                                                                    Width="70" Enabled="true"></asp:TextBox>
                                                                <asp:TextBox ID="txtTerraceSqmAgreementBuiltUp1" runat="server" CssClass="TextBox"
                                                                    Enabled="false" Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit Type">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlFlatType1" runat="server" Enabled="false" Width="150px">
                                                                </asp:DropDownList>
                                                                <asp:Label ID="lblFlatTypeId1" runat="server" CssClass="Display_None" Text='<%# Eval("FlatTypeId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Floor">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFloor1" runat="server" CssClass="Label" Text='<%# Eval("Floor") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="Display_None" />
                                                            <ItemStyle CssClass="Display_None" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUnit1" runat="server" CssClass="Label" Text='<%# Eval("Unit") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="Display_None" />
                                                            <ItemStyle CssClass="Display_None" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Facing">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlFacingType1" runat="server" Width="150px" Enabled="false">
                                                                    <asp:ListItem Value="0">--Select Facing--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Front</asp:ListItem>
                                                                    <asp:ListItem Value="2">Rear</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="lblFacingTypeId1" runat="server" CssClass="Display_None" Text='<%# Eval("FacingTypeId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="Display_None" />
                                                            <ItemStyle CssClass="Display_None" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="FloorNo" HeaderText="FloorNo" />
                                                        <asp:TemplateField HeaderText="Path">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblImgPath1" runat="server" Text='<%#Eval("LayoutPath")%>'> </asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="30px" />
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="TerracePer">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTerracePer1" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Text='<%# Eval("TerracePer") %>' Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <%-- <HeaderStyle CssClass="Display_None" />
                                                            <ItemStyle CssClass="Display_None" />--%>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="GardenPer">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtGardenPer1" runat="server" CssClass="TextBox" Enabled="false"
                                                                    Text='<%# Eval("GardenPer") %>' Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <%-- <HeaderStyle CssClass="Display_None" />
                                                            <ItemStyle CssClass="Display_None" />--%>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td class="Label">
                                            Total Sqft.(All)
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalAll" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Label">
                                            Loading :
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtLoading" runat="server" Width="665px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Label">
                                            Total Land Area :
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalLand" runat="server" onkeyup="CalSaleableFSI();"></asp:TextBox>
                                            (Sqft)
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtTotalLand"
                                                FilterType="Custom,Numbers" FilterMode="ValidChars" ValidChars=".">
                                            </ajax:FilteredTextBoxExtender>
                                        </td>
                                        <td class="Label">
                                            Saleable FSI:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSaleableFSI" runat="server" Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <ajax:Accordion ID="Accordion1" runat="server" ContentCssClass="accordionContent1"
                                                FadeTransitions="true" FramesPerSecond="30" HeaderCssClass="accordionHeader"
                                                HeaderSelectedCssClass="accordionHeaderSelected" RequireOpenedPane="false" SelectedIndex="1"
                                                SuppressHeaderPostbacks="true" ToolTip="Select Amenities" TransitionDuration="220">
                                                <Panes>
                                                    <ajax:AccordionPane ID="AccordionPane1" runat="server">
                                                        <Header>
                                                            <a class="href" href="#">Select Amenities</a>
                                                        </Header>
                                                        <Content>
                                                            <div>
                                                                <asp:GridView ID="GridAmenities" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                    CssClass="mGrid" DataKeyNames="#" OnDataBound="GridAmenities_DataBound" ShowFooter="True"
                                                                    TabIndex="4" Width="100%">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="#" Visible="False">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="LblEntryId0" runat="server" Width="30px"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="LblEntryId" runat="server" Text='<%# Eval("#") %>' Width="30px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%-- <asp:TemplateField HeaderText="All">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="GrdSelectAllHeader" runat="server" AutoPostBack="true" 
                                            OnCheckedChanged="GrdSelectAllHeader_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="GrdSelectAll" runat="server" AutoPostBack="false" Checked='<%# Convert.ToBoolean(Eval("select").ToString()) %>' />
                                        </ItemTemplate>
                                          <FooterTemplate>
                            <asp:ImageButton ID="img_btn_Add" runat="server" 
                                ImageUrl="~/Images/Icon/Gridadd.png" TabIndex="8" CssClass="Display_None"/>
                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                     </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Sr.No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="LblSrNo" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle CssClass="Display_None" />
                                                                            <ItemStyle CssClass="Display_None" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ControlStyle-Height="23px" ControlStyle-Width="200px" HeaderStyle-HorizontalAlign="Left"
                                                                            HeaderText="Title">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="GrtxtTermCondition_Head" runat="server" CssClass="TextBox" MaxLength="400"
                                                                                    TabIndex="6" Text='<%# Bind("Title") %>' TextMode="MultiLine"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ControlStyle Height="30px" Width="200px" />
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ControlStyle-Height="23px" ControlStyle-Width="200px" HeaderStyle-HorizontalAlign="Left"
                                                                            HeaderText="">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkDetails" runat="server" AutoPostBack="false" Checked='<%# Convert.ToBoolean(Eval("select").ToString()) %>' />
                                                                            </ItemTemplate>
                                                                            <ControlStyle Height="30px" Width="50px" />
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ControlStyle-Height="23px" ControlStyle-Width="200px" HeaderStyle-HorizontalAlign="Left"
                                                                            HeaderText="Description">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="GrtxtDesc" runat="server" CssClass="TextBox" MaxLength="400" TabIndex="6"
                                                                                    Text='<%# Bind("Details") %>' TextMode="MultiLine"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ControlStyle Height="30px" Width="400px" />
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </Content>
                                                    </ajax:AccordionPane>
                                                </Panes>
                                            </ajax:Accordion>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <ajax:Accordion ID="Accordion2" runat="server" ContentCssClass="accordionContent1"
                                                FadeTransitions="true" FramesPerSecond="30" HeaderCssClass="accordionHeader"
                                                HeaderSelectedCssClass="accordionHeaderSelected" RequireOpenedPane="false" SelectedIndex="1"
                                                SuppressHeaderPostbacks="true" ToolTip="Select Specification" TransitionDuration="220">
                                                <Panes>
                                                    <ajax:AccordionPane ID="AccordionPane2" runat="server">
                                                        <Header>
                                                            <a class="href" href="#">Select Specifications</a>
                                                        </Header>
                                                        <Content>
                                                            <div>
                                                                <asp:GridView ID="GridSpecific" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                    CssClass="mGrid" DataKeyNames="#" OnDataBound="GridSpecific_DataBound" ShowFooter="True"
                                                                    TabIndex="4" Width="100%">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="#" Visible="False">
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="LblEntryId0" runat="server" Width="30px"></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="LblEntryId" runat="server" Text='<%# Eval("#") %>' Width="30px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%-- <asp:BoundField DataField="SrNo" HeaderText="SrNo">
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>--%>
                                                                        <%-- <asp:TemplateField HeaderText="All">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="GrdSelectAllHeader1" runat="server" AutoPostBack="true" 
                                               OnCheckedChanged="GrdSelectAllHeader1_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="GrdSelectAll" runat="server" AutoPostBack="false" Checked='<%# Convert.ToBoolean(Eval("select").ToString()) %>' />
                                        </ItemTemplate>
                                          <FooterTemplate>
                            <asp:ImageButton ID="img_btn_Add" runat="server" 
                                ImageUrl="~/Images/Icon/Gridadd.png" TabIndex="8"  CssClass="Display_None"/>
                        </FooterTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                     </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Sr.No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="LblSrNo" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle CssClass="Display_None" />
                                                                            <ItemStyle CssClass="Display_None" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ControlStyle-Height="23px" ControlStyle-Width="200px" HeaderStyle-HorizontalAlign="Left"
                                                                            HeaderText="Title">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="GrtxtTermCondition_Head" runat="server" CssClass="TextBox" MaxLength="400"
                                                                                    TabIndex="6" Text='<%# Bind("Title") %>' TextMode="MultiLine"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ControlStyle Height="30px" Width="200px" />
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ControlStyle-Height="23px" ControlStyle-Width="200px" HeaderStyle-HorizontalAlign="Left"
                                                                            HeaderText="">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkDetails" runat="server" AutoPostBack="false" Checked='<%# Convert.ToBoolean(Eval("select").ToString()) %>' />
                                                                            </ItemTemplate>
                                                                            <ControlStyle Height="30px" Width="50px" />
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ControlStyle-Height="23px" ControlStyle-Width="200px" HeaderStyle-HorizontalAlign="Left"
                                                                            HeaderText="Description">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="GrtxtDesc" runat="server" CssClass="TextBox" MaxLength="400" TabIndex="6"
                                                                                    Text='<%# Bind("Details") %>' TextMode="MultiLine"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ControlStyle Height="30px" Width="480px" />
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </Content>
                                                    </ajax:AccordionPane>
                                                </Panes>
                                            </ajax:Accordion>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <ajax:Accordion ID="Accordion3" runat="server" ContentCssClass="accordionContent1"
                                                FadeTransitions="true" FramesPerSecond="30" HeaderCssClass="accordionHeader"
                                                HeaderSelectedCssClass="accordionHeaderSelected" RequireOpenedPane="false" SelectedIndex="1"
                                                SuppressHeaderPostbacks="true" ToolTip="Select Specification" TransitionDuration="220">
                                                <Panes>
                                                    <ajax:AccordionPane ID="AccordionPane3" runat="server">
                                                        <Header>
                                                            <a class="href" href="#">Upload Document</a>
                                                        </Header>
                                                        <Content>
                                                            <div>
                                                                <asp:GridView ID="GridDocumentList" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                    CssClass="mGrid" DataKeyNames="DocId" TabIndex="4" Width="100%">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="#" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="LblEntryId" runat="server" Text='<%# Eval("DocId") %>' Width="30px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="200px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Document Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDocName" runat="server" Text='<%# Eval("DocName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="250px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Upload Document">
                                                                            <ItemTemplate>
                                                                                <asp:UpdatePanel ID="updatePanelDoc" runat="server">
                                                                                    <Triggers>
                                                                                        <asp:PostBackTrigger ControlID="lnkUploadDoc" />
                                                                                    </Triggers>
                                                                                    <ContentTemplate>
                                                                                        <asp:FileUpload ID="FuUpload1" runat="server" CssClass="TextBox" />
                                                                                        <%--  <asp:RegularExpressionValidator ID="REVDoc" runat="server" 
                                            ControlToValidate="FuUpload1" 
                                            ErrorMessage="Upload Image File only" SetFocusOnError="True" 
                                            ValidationExpression="^.*\.((j|J)(p|P)(e|E)?(g|G)|(g|G)(i|I)(f|F)|(p|P)(n|N)(g|G)|(b|B)(m|M)(p|P))$" 
                                            ValidationGroup="lnkUpload1"></asp:RegularExpressionValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtenderDoc" runat="server" 
                                            TargetControlID="REVDoc" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                        <asp:RequiredFieldValidator ID="RFVDoc" runat="server" 
                                            ControlToValidate="FuUpload1" Display="None" ErrorMessage="Upload File First!" 
                                            SetFocusOnError="True" ValidationGroup="lnkUpload1"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtenderDoc1" runat="server" 
                                            TargetControlID="RFVDoc" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>--%>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                                <asp:Label ID="lblImgPath" runat="server" Text='<%#Eval("DocPath")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="500px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Upload">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkUploadDoc" runat="server" OnClick="lnkUploadDoc_Click" Text="Upload"></asp:LinkButton>
                                                                                <asp:LinkButton ID="lnkCancelDoc" runat="server" Text="Cancel" OnClick="lnkCancelDoc_Click"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Print">
                                                                            <ItemTemplate>
                                                                                <asp:Image ID="ImgBtnPrintDoc" runat="server" ImageUrl="~/Images/Icon/GridPrint.png"
                                                                                    ToolTip="Print Doc" TabIndex="29" onclick="newDoc(this);" />
                                                                                <%--<a href='../PrintReport/PrintReports.aspx?ID=<%# Eval("DocPath")%>&Flag=<%="DocPrint"%>' target="_blank">
                                            <asp:Image ID="ImgBtnPrintDoc" runat="server" ImageUrl="~/Images/Icon/GridPrint.png"
                                            ToolTip="Print Doc" TabIndex="29" onclick="newDoc();"/>
                                           
                                            --%></ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </Content>
                                                    </ajax:AccordionPane>
                                                </Panes>
                                            </ajax:Accordion>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" width="110px">
                                            Upload Pages :
                                        </td>
                                        <td>
                                            <table width="50%">
                                                <tr>
                                                    <td align="left" width="20%">
                                                        <asp:UpdatePanel ID="updatePanelFileUp" runat="server">
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="lnkUpload" />
                                                            </Triggers>
                                                            <ContentTemplate>
                                                                <asp:FileUpload ID="FuUpload" runat="server" CssClass="TextBox" />
                                                                <asp:RegularExpressionValidator ID="RE_V26" runat="server" ControlToValidate="FuUpload"
                                                                    Display="None" ErrorMessage="Upload Image File only" SetFocusOnError="True" ValidationExpression="^.*\.((j|J)(p|P)(e|E)?(g|G)|(g|G)(i|I)(f|F)|(p|P)(n|N)(g|G)|(b|B)(m|M)(p|P))$"
                                                                    ValidationGroup="lnkUpload"></asp:RegularExpressionValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtendernew" runat="server" TargetControlID="RE_V26"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                                <asp:RequiredFieldValidator ID="RF_V4" runat="server" ControlToValidate="FuUpload"
                                                                    Display="None" ErrorMessage="Upload File First!" SetFocusOnError="True" ValidationGroup="lnkUpload"></asp:RequiredFieldValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtendernew1" runat="server" TargetControlID="RF_V4"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lnkUpload" runat="server" OnClick="lnkUpload_Click" ValidationGroup="lnkUpload">Upload</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td align="right" valign="top" width="100px">
                                            Documents :
                                        </td>
                                        <td valign="top">
                                            <table width="50%">
                                                <tr>
                                                    <td align="left" width="35%">
                                                        <asp:UpdatePanel ID="updatePanel4" runat="server">
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="lnkVideo" />
                                                            </Triggers>
                                                            <ContentTemplate>
                                                                <asp:FileUpload ID="FileUploadVideo" runat="server" CssClass="TextBox" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="FileUploadVideo"
                                                                    Display="None" ErrorMessage="Upload Video File only" SetFocusOnError="True" ValidationExpression="^.*\.((j|J)(p|P)(e|E)?(g|G)|(g|G)(i|I)(f|F)|(p|P)(n|N)(g|G)|(b|B)(m|M)(p|P)|(d|D)(o|O)(c|C)|(p|P)(d|D)(f|F))$"
                                                                    ValidationGroup="lnkUpload3"></asp:RegularExpressionValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RegularExpressionValidator3"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUploadVideo"
                                                                    Display="None" ErrorMessage="Upload File First!" SetFocusOnError="True" ValidationGroup="lnkUpload3"></asp:RequiredFieldValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="RequiredFieldValidator3"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lnkVideo" runat="server" OnClick="lnkVideo_Click" ValidationGroup="lnkUpload3">Upload</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="100px">
                                        </td>
                                        <td align="center" valign="top" width="100px">
                                            <asp:GridView ID="GridLayout" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                                Width="100%">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkLayout" runat="server" Checked="True" />
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="LayoutImg" HeaderText="Layout">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                        <td align="left" valign="top" width="100px">
                                        </td>
                                        <td align="center" valign="top" width="100px">
                                            <asp:GridView ID="GridVideo" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                                Width="100%">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkVideo" runat="server" Checked="True" />
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="VideoName" HeaderText="Document">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Print">
                                                        <ItemTemplate>
                                                            <a href='../PrintReport/PrintReports.aspx?ID=<%# Eval("VideoName")%>&Flag=<%="DocPrint"%>'
                                                                target="_blank">
                                                                <asp:Image ID="ImgBtnPrint" runat="server" ImageUrl="~/Images/Icon/GridPrint.png"
                                                                    ToolTip="Print Doc" TabIndex="29" />
                                                            </a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr id="Tr6" runat="server">
                                        <td align="right" valign="top" width="110px">
                                            Upload Logo :
                                        </td>
                                        <td>
                                            <table width="50%">
                                                <tr>
                                                    <td align="left" width="20%">
                                                        <asp:UpdatePanel ID="updatePanel5" runat="server">
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="lnkLogo" />
                                                            </Triggers>
                                                            <ContentTemplate>
                                                                <asp:FileUpload ID="LogoUpload" runat="server" CssClass="TextBox" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="LogoUpload"
                                                                    Display="None" ErrorMessage="Upload Image File only" SetFocusOnError="True" ValidationExpression="^.*\.((j|J)(p|P)(e|E)?(g|G)|(g|G)(i|I)(f|F)|(p|P)(n|N)(g|G)|(b|B)(m|M)(p|P))$"
                                                                    ValidationGroup="LogoUpload"></asp:RegularExpressionValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="RegularExpressionValidator4"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="LogoUpload"
                                                                    Display="None" ErrorMessage="Upload File First!" SetFocusOnError="True" ValidationGroup="LogoUpload"></asp:RequiredFieldValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" TargetControlID="RequiredFieldValidator4"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lnkLogo" runat="server" OnClick="lnkLogo_Click" ValidationGroup="LogoUpload">Upload</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td align="right" valign="top" width="110px" class="Display_None">
                                            Upload Floor Plan :
                                        </td>
                                        <td class="Display_None">
                                            <table width="50%">
                                                <tr>
                                                    <td align="left" width="20%">
                                                        <asp:UpdatePanel ID="updatePanel6" runat="server">
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="lnkPlan" />
                                                            </Triggers>
                                                            <ContentTemplate>
                                                                <asp:FileUpload ID="PlanUpload" runat="server" CssClass="TextBox" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="PlanUpload"
                                                                    Display="None" ErrorMessage="Upload Image File only" SetFocusOnError="True" ValidationExpression="^.*\.((j|J)(p|P)(e|E)?(g|G)|(g|G)(i|I)(f|F)|(p|P)(n|N)(g|G)|(b|B)(m|M)(p|P))$"
                                                                    ValidationGroup="Uploadplan"></asp:RegularExpressionValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" TargetControlID="RegularExpressionValidator5"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="PlanUpload"
                                                                    Display="None" ErrorMessage="Upload File First!" SetFocusOnError="True" ValidationGroup="Uploadplan"></asp:RequiredFieldValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" TargetControlID="RequiredFieldValidator5"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lnkPlan" runat="server" OnClick="lnkPlan_Click" ValidationGroup="Uploadplan">Upload</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="Tr1" runat="server">
                                        <td align="left" valign="top" width="100px">
                                        </td>
                                        <td align="center" valign="top" width="100px">
                                            <asp:GridView ID="GridLogo" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                                Width="100%">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkLogo" runat="server" Checked="True" />
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="LogoImg" HeaderText="Logo">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                        <td align="left" valign="top" width="100px" class="Display_None">
                                        </td>
                                        <td align="center" valign="top" width="100px" class="Display_None">
                                            <asp:GridView ID="GridPlan" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                                Width="100%">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkPlan" runat="server" Checked="True" />
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="PlanImg" HeaderText="Plan">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr id="Tr2" runat="server" class="Display_None">
                                        <td align="right" valign="top" width="100px">
                                            Photos :
                                        </td>
                                        <td>
                                            <table width="50%">
                                                <tr>
                                                    <td align="left" width="35%">
                                                        <asp:UpdatePanel ID="updatePanel2" runat="server">
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="LnkImages" />
                                                            </Triggers>
                                                            <ContentTemplate>
                                                                <asp:FileUpload ID="FileUploadImages" runat="server" CssClass="TextBox" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FileUploadImages"
                                                                    Display="None" ErrorMessage="Upload Image File only" SetFocusOnError="True" ValidationExpression="^.*\.((j|J)(p|P)(e|E)?(g|G)|(g|G)(i|I)(f|F)|(p|P)(n|N)(g|G)|(b|B)(m|M)(p|P))$"
                                                                    ValidationGroup="lnkUpload2"></asp:RegularExpressionValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RegularExpressionValidator2"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUploadImages"
                                                                    Display="None" ErrorMessage="Upload File First!" SetFocusOnError="True" ValidationGroup="lnkUpload2"></asp:RequiredFieldValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator2"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="LnkImages" runat="server" OnClick="LnkImages_Click" ValidationGroup="lnkUpload2">Upload</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td align="right" valign="top" width="110px">
                                            Upload Location Map :
                                        </td>
                                        <td>
                                            <table width="50%">
                                                <tr>
                                                    <td align="left" width="20%">
                                                        <asp:UpdatePanel ID="updatePanel3" runat="server">
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="Lnk_Map" />
                                                            </Triggers>
                                                            <ContentTemplate>
                                                                <asp:FileUpload ID="FileUploadMap" runat="server" CssClass="TextBox" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FileUploadMap"
                                                                    Display="None" ErrorMessage="Upload Image File only" SetFocusOnError="True" ValidationExpression="^.*\.((j|J)(p|P)(e|E)?(g|G)|(g|G)(i|I)(f|F)|(p|P)(n|N)(g|G)|(b|B)(m|M)(p|P))$"
                                                                    ValidationGroup="lnkUpload1"></asp:RegularExpressionValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RegularExpressionValidator1"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUploadMap"
                                                                    Display="None" ErrorMessage="Upload File First!" SetFocusOnError="True" ValidationGroup="lnkUpload1"></asp:RequiredFieldValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator1"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="Lnk_Map" runat="server" OnClick="Lnk_Map_Click" ValidationGroup="lnkUpload1">Upload</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="Tr3" runat="server" class="Display_None">
                                        <td align="left" valign="top" width="100px">
                                        </td>
                                        <td align="center" valign="top" width="100px">
                                            <asp:GridView ID="grdupload" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                                Width="100%">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkUpload" runat="server" Checked="True" />
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ImageName" HeaderText="Photos">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                        <td align="left" valign="top" width="100px">
                                        </td>
                                        <td align="center" valign="top" width="100px">
                                            <asp:GridView ID="GridMap" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                                Width="100%">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkMap" runat="server" Checked="True" />
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="MapImg" HeaderText="Map">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr id="Tr4" runat="server" class="Display_None">
                                        <td align="right" valign="top" width="100px">
                                            Amenities :
                                        </td>
                                        <td>
                                            <table width="50%">
                                                <tr>
                                                    <td align="left" width="35%">
                                                        <asp:UpdatePanel ID="updatePanel8" runat="server">
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="lnkAmenity" />
                                                            </Triggers>
                                                            <ContentTemplate>
                                                                <asp:FileUpload ID="AmenityUpload" runat="server" CssClass="TextBox" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="AmenityUpload"
                                                                    Display="None" ErrorMessage="Upload Image File only" SetFocusOnError="True" ValidationExpression="^.*\.((j|J)(p|P)(e|E)?(g|G)|(g|G)(i|I)(f|F)|(p|P)(n|N)(g|G)|(b|B)(m|M)(p|P))$"
                                                                    ValidationGroup="lnkUploadAm"></asp:RegularExpressionValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="server" TargetControlID="RegularExpressionValidator7"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="AmenityUpload"
                                                                    Display="None" ErrorMessage="Upload File First!" SetFocusOnError="True" ValidationGroup="lnkUploadAm"></asp:RequiredFieldValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" TargetControlID="RequiredFieldValidator7"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lnkAmenity" runat="server" OnClick="lnkAmenity_Click" ValidationGroup="lnkUploadAm">Upload</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td align="right" valign="top" width="100px">
                                            Specification :
                                        </td>
                                        <td valign="top">
                                            <table width="50%">
                                                <tr>
                                                    <td align="left" width="35%">
                                                        <asp:UpdatePanel ID="updatePanel9" runat="server">
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="lnkSpecification" />
                                                            </Triggers>
                                                            <ContentTemplate>
                                                                <asp:FileUpload ID="SpecUpload" runat="server" CssClass="TextBox" />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="SpecUpload"
                                                                    Display="None" ErrorMessage="Upload Video File only" SetFocusOnError="True" ValidationExpression="^.*\.((j|J)(p|P)(e|E)?(g|G)|(g|G)(i|I)(f|F)|(p|P)(n|N)(g|G)|(b|B)(m|M)(p|P))$"
                                                                    ValidationGroup="lnkUploadSpec"></asp:RegularExpressionValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="server" TargetControlID="RegularExpressionValidator8"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="SpecUpload"
                                                                    Display="None" ErrorMessage="Upload File First!" SetFocusOnError="True" ValidationGroup="lnkUploadSpec"></asp:RequiredFieldValidator>
                                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender17" runat="server" TargetControlID="RequiredFieldValidator8"
                                                                    WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                                </ajax:ValidatorCalloutExtender>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lnkSpecification" runat="server" OnClick="lnkSpecification_Click"
                                                            ValidationGroup="lnkUploadSpec">Upload</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="Tr5" runat="server" class="Display_None">
                                        <td align="left" valign="top" width="100px">
                                        </td>
                                        <td align="center" valign="top" width="100px">
                                            <asp:GridView ID="GridAmenityImg" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                                Width="100%">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkAmenity" runat="server" Checked="True" />
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="AmenityImage" HeaderText="Amenity">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                        <td align="left" valign="top" width="100px">
                                        </td>
                                        <td align="center" valign="top" width="100px">
                                            <asp:GridView ID="GridSpecImg" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                                Width="100%">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSpec" runat="server" Checked="True" />
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="SpecImage" HeaderText="Specification">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </caption>
                            </table>
                        </fieldset>
                        <ajax:RoundedCornersExtender ID="RCE2" runat="server" TargetControlID="fieldset"
                            Color="Black" Enabled="True" BorderColor="Black" Radius="10">
                        </ajax:RoundedCornersExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        <fieldset id="fieldset1" runat="server" class="FieldSet">
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <table align="center" width="25%">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="button" ValidationGroup="Add"
                                                        OnClientClick="UpdateEquipFunction();" OnClick="BtnUpdate_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="button" ValidationGroup="Add"
                                                        OnClick="BtnSave_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="button" ValidationGroup="Add"
                                                        OnClientClick="DeleteEquipFunction();" OnClick="BtnDelete_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="False"
                                                        OnClick="BtnCancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <%-- <ajax:AnimationExtender id="MyExtender"
  runat="server" TargetControlID="fieldset1">
  <Animations>
    <OnClick>
      <FadeOut Duration=".5" Fps="20" />
    </OnClick>
     
  </Animations>
  
</ajax:AnimationExtender>--%>
                        <ajax:RoundedCornersExtender ID="RCE" runat="server" TargetControlID="fieldset1"
                            Color="Black" Enabled="True" BorderColor="Black" Radius="10">
                        </ajax:RoundedCornersExtender>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel_GrdReport" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GrdReport" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                                    CssClass="mGrid" GridLines="None" Width="105%" PagerStyle-CssClass="pgr" OnRowCommand="GrdReport_RowCommand"
                                    OnRowDeleting="GrdReport_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgBtnEdit" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                                    CommandArgument='<%# Eval("#") %>' CommandName="Select" ImageUrl="~/Images/Icon/GridEdit.png"
                                                    TabIndex="62" ToolTip="Edit Record" />
                                                <asp:ImageButton ID="ImgBtnDelete" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                                    CommandArgument='<%# Eval("#") %>' CommandName="Delete" ImageUrl="~/Images/Icon/GridDelete.png"
                                                    TabIndex="63" ToolTip="Delete Record" />
                                                <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Would You Like To Delete This Record?"
                                                    TargetControlID="ImgBtnDelete">
                                                </ajax:ConfirmButtonExtender>
                                                <%-- <a href="../Reports/DisplayReport.aspx?ID=<%# Eval("#")%>&Flag=<%=1%>" target="_blank">
                            <asp:Image ID="Image1" runat="server" CssClass="Imagebutton"
                             ImageUrl="~/Images/Icon/PDF.jpg" ToolTip="Generate pdf" Width="20" Height="20" />
                             </a>--%>
                                                <%--  <asp:ImageButton ID="ImgBtnPdf" runat="server" CausesValidation="False" CssClass="Imagebutton"
                            CommandArgument='<%# Eval("#") %>' CommandName="Pdf" 
                            ImageUrl="~/Images/Icon/PDF.jpg" TabIndex="64" ToolTip="Generate Pdf" Width="20" Height="20" />  --%>
                                                <a href="../PrintReport/PrintReports.aspx?ID=<%# Eval("#")%>&Flag=<%="PC"%>" target="_blank">
                                                    <asp:Image ID="ImgBtnPrint" runat="server" CssClass="Imagebutton" ImageUrl="~/Images/Icon/PDF.jpg"
                                                        ToolTip="PDF" Width="20" Height="20" /></a>
                                                        
                                           <a href="../PrintReport/PrintReports.aspx?ID=<%# Eval("#")%>&Flag=<%="PCPrint"%>" target="_blank">
                                                    <asp:Image ID="Image1" runat="server" CssClass="Imagebutton" ImageUrl="~/Images/Icon/Print-Icon.png"
                                                        ToolTip="PDF" Width="20" Height="20" /></a>        
                                                <%--<ajax:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" 
                            ConfirmText="Would You Like To Print The Record..!" 
                            TargetControlID="ImgBtnPrint">
                            </ajax:ConfirmButtonExtender>   --%>
                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" Wrap="false"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sr. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="LblSrNo" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Width="7%" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Project" DataField="Project">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>
                                        <%-- <asp:BoundField HeaderText="Applicant" DataField="Applicant">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                    </asp:BoundField>--%>
                                        <%--  <asp:BoundField HeaderText="ReceivedDate" DataField="ReceivedDate">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                    </asp:BoundField>--%>
                                    </Columns>
                                    <PagerStyle CssClass="pgr" />
                                    <AlternatingRowStyle CssClass="alt" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="GrdReport" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnClone" />
            <asp:PostBackTrigger ControlID="ImgAddGrid" />
            <asp:PostBackTrigger ControlID="BtnUpdate" />
            <asp:PostBackTrigger ControlID="BtnCancel" />
            <asp:PostBackTrigger ControlID="BtnSave" />
            <asp:PostBackTrigger ControlID="ApplyToAll" />
            <asp:PostBackTrigger ControlID="ApplyToEvenOdd" />
            <asp:PostBackTrigger ControlID="ImgAddMainDetail" />
            <asp:PostBackTrigger ControlID="GridDetails" />
            <asp:PostBackTrigger ControlID="ImgAddCompany" />
            <asp:PostBackTrigger ControlID="GridMainDetail" />
            
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
