

// Multistep form navigation
function Step1() {
    $(".step").addClass("d-none");
    $("#step1").removeClass("d-none");
    $(".progressbar li").removeClass("active");
    $(".progressbar li").eq(0).addClass("active");
    scrolltotop();
}
function Step2() {
    $(".step").addClass("d-none");
    $("#step2").removeClass("d-none");
    $(".progressbar li").removeClass("active");
    $(".progressbar li").eq(0).addClass("active");
    $(".progressbar li").eq(1).addClass("active");
    scrolltotop();
}
function Step3() {
    $(".step").addClass("d-none");
    $("#step3").removeClass("d-none");
    $(".progressbar li").removeClass("active");
    $(".progressbar li").eq(0).addClass("active");
    $(".progressbar li").eq(1).addClass("active");
    $(".progressbar li").eq(2).addClass("active");
    scrolltotop();
    calculateFinancialAllItems();
}
function Step4() {
    $(".step").addClass("d-none");
    $("#step4").removeClass("d-none");
    $(".progressbar li").addClass("active");
    scrolltotop();
    $("#step4Date").text(new Date().toString());
}
//script for grouping items
var count = 1;
$(".group-item").click(function () {
    if (!$(this).children().hasClass('fa-check-circle-o')) {
        $(this).parent().parent().toggleClass("table-info");
        $(this).children().toggleClass("fa-minus-circle");
        $("#numitemsselected").text($(".fa-minus-circle").length);
    }
    if ($(".fa-minus-circle").length > 0){
        //Run Calculations
        $("#btnNewItemGroup").prop('disabled', false);
        $("#btnStep3").prop('disabled', false);
        $("#btnCostingAnalysis").prop('disabled', false);
    }
   

});
function displaycosting() {
    $("#PriceUpdateCalc").prop('hidden', false);
    $("#btnCostingAnalysis").hide();
    document.getElementById('PriceUpdateCalc').scrollIntoView();
}
function scrolltotop() {
    $(window).scrollTop(0);
}
function togglepnltable() {
    $("#pnltable").slideToggle();
}
function AddNewGroup() {
    var groupname = $("#new-itemgroup-name").val().toString();
    var numofitems = $(".fa-minus-circle").length;
    var newitemgroup = '<a class="dropdown-item" href="#?" onclick="warningSave()"><button class="btn btn-sm btn-danger mr-2" onclick="warningDelete()"><i class="fa fa-trash text-white m-0"></i></button>' + groupname + ' <span class="badge badge-primary badge-pill ml-3" style="position: static;">' + numofitems +'</span> </a> '
    $("#sel-itemgroups").append(newitemgroup);
    count++;
    $("#new-itemgroup-name").val("MIDEL Group 2");
    $(".fa-minus-circle").parent().removeAttr("href");
    $(".fa-minus-circle").parent().parent().parent().removeClass('table-info');
    $(".fa-minus-circle").parent().parent().parent().addClass('table-secondary');
    $(".fa-minus-circle").toggleClass("fa-check-circle-o");
    $(".fa-minus-circle").toggleClass("fa-minus-circle");
    $("#numitemsselected").text($(".fa-minus-circle").length);

    scrolltotop();
    $("#PriceUpdateCalc").prop('hidden', true);
    $("#btnCostingAnalysis").show();
    $("#btnCostingAnalysis").prop('disabled', true);
}

function warningSave() {
    $("#modalWarningSave").modal('toggle');
}
function warningDelete() {
    $("#modalDeleteGroup").modal('toggle');
    $("#modalWarningSave").modal('toggle');
}
$("#btn-FinancialAllItems").click(function () {
    $("#div-FinancialAllItems").removeClass("d-none");
    $("#div-FinancialAffectedItems").addClass("d-none");
    $("#btn-FinancialAllItems").addClass("active");
    $("#btn-FinancialAffectedItems").removeClass("active");
});
$("#btn-FinancialAffectedItems").click(function () {
    $("#div-FinancialAllItems").addClass("d-none");
    $("#div-FinancialAffectedItems").removeClass("d-none");
    $("#btn-FinancialAllItems").removeClass("active");
    $("#btn-FinancialAffectedItems").addClass("active");
});
function calculateCostingAllItems() {
    var currentpurchasepricepercase = parseFloat($("#data-currentpurchasepricepercase"));
    var proposedpurchasepricepercase = parseFloat($("#input-proposedpurchasepricepercase"));
    var exchangerate = parseFloat($("#dataExchangeRate"));
    var purchasepriceCAD = proposedpurchasepricepercase * exchangerate;
    var duty = purchasepriceCAD * parseFloat($("#data-duty")) / 100;
    var freightcosting = parseFloat($("#data-freightcosting"));
    var currentlandingcost;
    var proposedlandingcost = purchasepriceCAD + duty + freightcosting;
    var currentdealaccruals = parseFloat($("#data-freightcosting"));
    var proposeddealaccruals;


    //DSD
    var dsdcurrentpricepercase;
    var dsdcproposedpricepercase;
}



function calculateFinancialAllItems() {
    //CASES
    var L12affectedCases = parseInt($("#val-L12affectedcases").text());
    var N12affectedCases = parseInt($("#input-N12affectedCases").val());
    var L12unaffectedCases = parseInt($("#val-L12unaffectedcases").text());
    var N12unaffectedCases = parseInt($("#input-N12unaffectedCases").val());
    var L12totalcases = L12affectedCases + L12unaffectedCases;
    var N12totalcases = N12affectedCases + N12unaffectedCases;
    var Changetotalcases = N12totalcases - L12totalcases;
        //update
    $("#val-L12totalcases").text(L12totalcases.toString());
    $("#val-N12totalcases").text(N12totalcases.toString());
    $("#val-Changetotalcases").text(Changetotalcases.toString());
    //AVERAGE PRICE / CASE
    var L12affectedappc = parseFloat($("#val-L12affectedappc").text());
    var N12affectedappc = parseFloat($("#val-N12affectedappc").text());
    var L12unaffectedappc = parseFloat($("#val-L12unaffectedappc").text());
    var N12unaffectedappc = parseFloat($("#val-N12unaffectedappc").text());
    var L12totalappc = (L12affectedappc * L12affectedCases / L12totalcases) + (L12unaffectedappc * L12unaffectedCases / L12totalcases);
    var N12totalappc = (N12affectedappc * N12affectedCases / N12totalcases) + (N12unaffectedappc * N12unaffectedCases / N12totalcases);
    var Changeappc = N12totalappc - L12totalappc;
    //update
    $("#val-L12appc").text(L12totalappc.toFixed(2).toString());
    $("#val-N12appc").text(N12totalappc.toFixed(2).toString());
    $("#val-Changeappc").text(Changeappc.toFixed(2).toString());
    //GROSS SALES
    var L12affectedgrosssales = parseFloat($("#val-L12affectedgrosssales").text());
    var N12affectedgrosssales = N12affectedCases * N12affectedappc;
    var L12unaffectedgrosssales = parseFloat($("#val-L12unaffectedgrosssales").text());
    var N12unaffectedgrosssales = N12unaffectedCases * N12unaffectedappc;
    var L12totalgrosssales = L12affectedgrosssales + L12unaffectedgrosssales;
    var N12totalgrosssales = N12affectedgrosssales + N12unaffectedgrosssales;
    var Changegrosssales = N12totalgrosssales - L12totalgrosssales;
    //update
    $("#val-N12affectedgrosssales").text(N12affectedgrosssales.toFixed(2).toString());
    $("#val-N12unaffectedgrosssales").text(N12unaffectedgrosssales.toFixed(2).toString());
    $("#val-L12totalgrosssales").text(L12totalgrosssales.toFixed(2).toString());
    $("#val-N12totalgrosssales").text(N12totalgrosssales.toFixed(2).toString());
    $("#val-Changegrosssales").text(Changegrosssales.toFixed(2).toString());
    //SALES DEDUCTIONS
    var L12affecteddeductions = parseFloat($("#val-L12affecteddeductions").text());
    var N12affecteddeductions = parseFloat($("#val-N12affecteddeductions").text());
    var L12unaffecteddeductions = parseFloat($("#val-L12unaffecteddeductions").text());
    var N12unaffecteddeductions = parseFloat($("#val-N12unaffecteddeductions").text());
    var L12totaldeductions = L12affecteddeductions + L12unaffecteddeductions;
    var N12totaldeductions = N12affecteddeductions + N12unaffecteddeductions;
    var Changedeductions = N12totaldeductions - L12totaldeductions;
    //update
    $("#val-L12totaldeductions").text(L12totaldeductions.toFixed(2).toString());
    $("#val-N12totaldeductions").text(N12totaldeductions.toFixed(2).toString());
    $("#val-Changedeductions").text(Changedeductions.toFixed(2).toString());
    //NET SALES
    var L12affectednetsales = L12affectedgrosssales - L12affecteddeductions;
    var N12affectednetsales = N12affectedgrosssales - N12affecteddeductions;
    var L12unaffectednetsales = L12unaffectedgrosssales - L12unaffecteddeductions;
    var N12unaffectednetsales = N12unaffectedgrosssales - N12unaffecteddeductions;
    var L12totalnetsales = L12totalgrosssales - L12totaldeductions;
    var N12totalnetsales = N12totalgrosssales - N12totaldeductions;
    var Changenetsales = Changegrosssales - Changedeductions;
    //update
    $("#val-L12affectednetsales").text(L12affectednetsales.toFixed(2).toString());
    $("#val-N12affectednetsales").text(N12affectednetsales.toFixed(2).toString());
    $("#val-L12unaffectednetsales").text(L12unaffectednetsales.toFixed(2).toString());
    $("#val-N12unaffectednetsales").text(N12unaffectednetsales.toFixed(2).toString());
    $("#val-L12totalnetsales").text(L12totalnetsales.toFixed(2).toString());
    $("#val-N12totalnetsales").text(N12totalnetsales.toFixed(2).toString());
    $("#val-Changenetsales").text(Changenetsales.toFixed(2).toString());
    //COGS
    var L12affectedcogs = parseFloat($("#val-L12affectedcogs").text());
    var N12affectedcogs = L12affectedcogs / L12affectedgrosssales * N12affectedgrosssales;
    var L12unaffectedcogs = parseFloat($("#val-L12unaffectedcogs").text());
    var N12unaffectedcogs = L12unaffectedcogs / L12unaffectedgrosssales * N12unaffectedgrosssales;
    var L12totalcogs = L12affectedcogs + L12unaffectedcogs;
    var N12totalcogs = N12affectedcogs + N12unaffectedcogs;
    var Changecogs = N12totalcogs - L12totalcogs;
    //update
    $("#val-N12affectedcogs").text(N12affectedcogs.toFixed(2).toString());
    $("#val-N12unaffectedcogs").text(N12unaffectedcogs.toFixed(2).toString());
    $("#val-L12totalcogs").text(L12totalcogs.toFixed(2).toString());
    $("#val-L12totalcogs").text(L12totalcogs.toFixed(2).toString());
    $("#val-N12totalcogs").text(N12totalcogs.toFixed(2).toString());
    $("#val-Changecogs").text(Changecogs.toFixed(2).toString());
    //GROSS MARGIN
    var L12affectedgrossmargin = L12affectednetsales - L12affectedcogs;
    var N12affectedgrossmargin = N12affectednetsales - N12affectedcogs;
    var L12unaffectedgrossmargin = L12unaffectednetsales - L12unaffectedcogs;
    var N12unaffectedgrossmargin = N12unaffectednetsales - N12unaffectedcogs;
    var L12totalgrossmargin = L12affectedgrossmargin + L12unaffectedgrossmargin;
    var N12totalgrossmargin = N12affectedgrossmargin + N12unaffectedgrossmargin;
    var Changegrossmargin = N12totalgrossmargin - L12totalgrossmargin;
    //update
    $("#val-L12affectedgrossmargin").text(L12affectedgrossmargin.toFixed(2).toString());
    $("#val-N12affectedgrossmargin").text(N12affectedgrossmargin.toFixed(2).toString());
    $("#val-L12unaffectedgrossmargin").text(L12unaffectedgrossmargin.toFixed(2).toString());
    $("#val-N12unaffectedgrossmargin").text(N12unaffectedgrossmargin.toFixed(2).toString());
    $("#val-L12totalgrossmargin").text(L12totalgrossmargin.toFixed(2).toString());
    $("#val-N12totalgrossmargin").text(N12totalgrossmargin.toFixed(2).toString());
    $("#val-Changegrossmargin").text(Changegrossmargin.toFixed(2).toString());
    //GROSS MARGIN
    var L12affectedgrossmargincase = L12affectedgrossmargin / L12affectedCases;
    var N12affectedgrossmargincase = N12affectedgrossmargin / N12affectedCases;
    var L12unaffectedgrossmargincase = L12unaffectedgrossmargin / L12unaffectedCases;
    var N12unaffectedgrossmargincase = N12unaffectedgrossmargin / N12unaffectedCases;
    var L12totalgrossmargincase = L12totalgrossmargin / L12totalcases;
    var N12totalgrossmargincase = N12totalgrossmargin / N12totalcases;
    var Changegrossmargincase = N12totalgrossmargincase - L12totalgrossmargincase;
    //update
    $("#val-L12affectedgrossmargincase").text(L12affectedgrossmargincase.toFixed(2).toString());
    $("#val-N12affectedgrossmargincase").text(N12affectedgrossmargincase.toFixed(2).toString());
    $("#val-L12unaffectedgrossmargincase").text(L12unaffectedgrossmargincase.toFixed(2).toString());
    $("#val-N12unaffectedgrossmargincase").text(N12unaffectedgrossmargincase.toFixed(2).toString());
    $("#val-L12totalgrossmargincase").text(L12totalgrossmargincase.toFixed(2).toString());
    $("#val-N12totalgrossmargincase").text(N12totalgrossmargincase.toFixed(2).toString());
    $("#val-Changegrossmargincase").text(Changegrossmargincase.toFixed(2).toString());
    //VAR OPEX
    var L12affectedvaropex = 1.47 * L12affectedCases;
    var N12affectedvaropex = 1.47 * N12affectedCases;
    var L12unaffectedvaropex = 1.47 * L12unaffectedCases;
    var N12unaffectedvaropex = 1.47 * N12unaffectedCases;
    var L12totalvaropex = L12affectedvaropex + L12unaffectedvaropex;
    var N12totalvaropex = N12affectedvaropex + N12unaffectedvaropex;
    var Changevaropex = N12totalvaropex - L12totalvaropex;
    //update
    $("#val-L12affectedvaropex").text(L12affectedvaropex.toFixed(2).toString());
    $("#val-N12affectedvaropex").text(N12affectedvaropex.toFixed(2).toString());
    $("#val-L12unaffectedvaropex").text(L12unaffectedvaropex.toFixed(2).toString());
    $("#val-N12unaffectedvaropex").text(N12unaffectedvaropex.toFixed(2).toString());
    $("#val-L12totalvaropex").text(L12totalvaropex.toFixed(2).toString());
    $("#val-N12totalvaropex").text(N12totalvaropex.toFixed(2).toString());
    $("#val-Changevaropex").text(Changevaropex.toFixed(2).toString());
    //CONTRIBUTION MARGIN
    var L12affectedconmargin = L12affectedgrossmargin - L12affectedvaropex;
    var N12affectedconmargin = N12affectedgrossmargin - N12affectedvaropex;
    var L12unaffectedconmargin = L12unaffectedgrossmargin - L12unaffectedvaropex;
    var N12unaffectedconmargin = N12unaffectedgrossmargin - N12unaffectedvaropex;
    var L12totalconmargin = L12affectedconmargin + L12unaffectedconmargin;
    var N12totalconmargin = N12affectedconmargin + N12unaffectedconmargin;
    var Changeconmargin = N12totalconmargin - L12totalconmargin;
    //update
    $("#val-L12affectedconmargin").text(L12affectedconmargin.toFixed(2).toString());
    $("#val-N12affectedconmargin").text(N12affectedconmargin.toFixed(2).toString());
    $("#val-L12unaffectedconmargin").text(L12unaffectedconmargin.toFixed(2).toString());
    $("#val-N12unaffectedconmargin").text(N12unaffectedconmargin .toFixed(2).toString());
    $("#val-L12totalconmargin").text(L12totalconmargin.toFixed(2).toString());
    $("#val-N12totalconmargin").text(N12totalconmargin.toFixed(2).toString());
    $("#val-Changeconmargin").text(Changeconmargin.toFixed(2).toString());
    //CONTRIBUTION MARGIN / CASE
    var L12affectedconmargincase = L12affectedconmargin / L12affectedCases;
    var N12affectedconmargincase = N12affectedconmargin / N12affectedCases;
    var L12unaffectedconmargincase = L12unaffectedconmargin / L12unaffectedCases;
    var N12unaffectedconmargincase = N12unaffectedconmargin / N12unaffectedCases;
    var L12totalconmargincase = L12totalconmargin / L12totalcases;
    var N12totalconmargincase = N12totalconmargin / N12totalcases;
    var Changeconmargincase = N12totalconmargincase - L12totalconmargincase;
    //update
    $("#val-L12affectedconmargincase").text(L12affectedconmargincase.toFixed(2).toString());
    $("#val-N12affectedconmargincase").text(N12affectedconmargincase.toFixed(2).toString());
    $("#val-L12unaffectedconmargincase").text(L12unaffectedconmargincase.toFixed(2).toString());
    $("#val-N12unaffectedconmargincase").text(N12unaffectedconmargincase.toFixed(2).toString());
    $("#val-L12totalconmargincase").text(L12totalconmargincase.toFixed(2).toString());
    $("#val-N12totalconmargincase").text(N12totalconmargincase.toFixed(2).toString());
    $("#val-Changeconmargincase").text(Changeconmargincase.toFixed(2).toString());
    //DIRECT OPEX
    var L12totaldirectopex = parseFloat($("#val-L12totaldirectopex").text());
    var N12totaldirectopex = parseFloat($("#val-N12totaldirectopex").text());
    var Changedirectopex = parseFloat($("#val-Changedirectopex").text());
    //CONTRIBUTION AFTER OPEX MARGIN

    var L12totalconmarginA = L12totalconmargin - L12totaldirectopex;
    var N12totalconmarginA = N12totalconmargin - N12totaldirectopex;
    var ChangeconmarginA = N12totalconmarginA - L12totalconmarginA
    //update
    $("#val-L12totalconmarginA").text(L12totalconmarginA.toFixed(2).toString());
    $("#val-N12totalconmarginA").text(N12totalconmarginA.toFixed(2).toString());
    $("#val-ChangeconmarginA").text(ChangeconmarginA.toFixed(2).toString());
    //CONTRIBUTION AFTER OPEX MARGIN / CASE
    var L12totalconmarginAcase = L12totalconmarginA / L12totalcases;
    var N12totalconmarginAcase = N12totalconmarginA / N12totalcases;
    var ChangeconmarginAcase = N12totalconmarginAcase - L12totalconmarginAcase;
    //update
    $("#val-L12totalconmarginAcase").text(L12totalconmarginAcase.toFixed(2).toString());
    $("#val-N12totalconmarginAcase").text(N12totalconmarginAcase.toFixed(2).toString());
    $("#val-ChangeconmarginAcase").text(ChangeconmarginAcase.toFixed(2).toString());

    //Change Color
    changecolor();
}
function changecolor() {
    $(".changenum").each(function () {
        if (parseFloat($(this).text()) > 0) {
            $(this).removeClass('text-danger');
            $(this).addClass('text-success');
        }
        else if (parseFloat($(this).text()) < 0) {
            $(this).removeClass('text-success');
            $(this).addClass('text-danger');
        }
    });
}