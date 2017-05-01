$(document).ready(function () {
    console.log("PATRYCJA IS READY !!!!");

    $('#projects_table').dataTable({
        'iDisplayLength': 100
    });
    $('#employees_table').dataTable({
        'iDisplayLength': 100
    });
    $('#companies_table').dataTable({
        'iDisplayLength': 100
    });

    $("#project1_id").on('input', function () {
        console.log("ZMIANA");
        $('#project2_percentage').val(0);
        $('#project1_percentage').val(100);
    });
    $("#project2_id").on('input', function () {
        console.log("ZMIANA");
        $('#project2_percentage').val(50);
        $('#project1_percentage').val(50);
    });

    $("#project1_percentage").on('input', function () {
        console.log("ZMIANA");
        $('#project2_percentage').val(100 - $(this).val());
    });
    $("#project2_percentage").on('input', function () {
        console.log("ZMIANA");
        $('#project1_percentage').val(100 - $(this).val());
    });

    $("#gross_salary").change(function () {
        $gross = $('#gross_salary').val();
       //$('#gross_salary').formatCurrency();
    });

    $("#insurance").change(function () {
        $insurance = $('#insurance').val();
     // $('#insurance').formatCurrency();
    });
    $("#pension").change(function () {
             
        $pension = $('#pension').val();
        //$('#pension').formatCurrency();
        console.log("GROSS: " + $gross);
        console.log("INSURANCE: " + $insurance);
        console.log("PENSION: " + $pension);
        

        var j = calculate_annual_gross_salary($gross,$insurance,$pension);
        
        console.log("annaul_gross_salary: " + j);
        $("#gross_annual_salary").val(j);
        //$("#gross_annual_salary").formatCurrency();

        var employee_id = $("#droplista_employee option:selected").attr('value');
        var year = $("#Year option:selected").attr('value');
        var month = $("#Month option:selected").attr('value');
        var project_allocation_id = get_project_allocation_id(employee_id, year, month);
        $("#allocation_id").val(project_allocation_id);
        $("#project1_cost").val(j * get_project1_percentage(project_allocation_id) / 100 / 12);
        $("#project2_cost").val(j * get_project2_percentage(project_allocation_id) / 100 / 12);
    });
    



    $("#droplista_employee").change(function () {
        var employee_id = $("#droplista_employee option:selected").attr('value')
        var year = $("#Year option:selected").attr('value')
        var month = $("#Month option:selected").attr('value')
        console.log("Employee_id =" + employee_id);
        console.log("Year =" + year);
        console.log("Month =" + month);
        
        var project_allocation_id = get_project_allocation_id(employee_id, year, month);
        console.log(project_allocation_id);
        
       

        $("#project1_result").val(get_project1_name(project_allocation_id) +" "+ get_project1_percentage(project_allocation_id) );
        $("#project2_result").val(get_project2_name(project_allocation_id) + " " + get_project2_percentage(project_allocation_id));
        $("#hours_per_week_result").val(get_hours_per_week(employee_id));
        $("#project1_hours").val(get_hours_per_week(employee_id) * (get_project1_percentage(project_allocation_id))/100);
        $("#project2_hours").val(get_hours_per_week(employee_id) * (get_project2_percentage(project_allocation_id))/100);
    });

});

function get_project_allocation_id(employee_id, year, month) {
    $wynik = 0;
    $.ajax({
        type: "GET",
        url: "Staff_Time_Allocation/find_project_allocation_id",
        data: { employee_id: employee_id, year, month },
        async: false,
        contentType: "application/json;charset=utf-8",
        //dataType: "json",
        success: function (result) {
            console.log("Result in ajax:" +result);
            
            $wynik = result;
            
            //debugger;
            //alert(result);
            
        },
        error: function (response) {
            $wynik = "NO PROJECT";
            //debugger;
            //alert('eror');
        }

        
    });

    return $wynik;
    
}

function get_project1_name(project_allocation_id) {
    $wynik = 0;
    $.ajax({
        type: "GET",
        url: "Staff_Time_Allocation/find_project1_name",
        data: { staff_project_allocation_id: project_allocation_id },
        async: false,
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            console.log("Project1_name=" + result);
            $wynik =result;
        },
        error: function (response) {
            $wynik = "";
            //debugger;
            //alert('eror');
        }
    });
    return $wynik;
}

function get_project2_name(project_allocation_id) {
    $wynik = 0;
    $.ajax({
        type: "GET",
        url: "Staff_Time_Allocation/find_project2_name",
        data: { staff_project_allocation_id: project_allocation_id },
        async: false,
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            console.log("Project2_name=" + result);
            $wynik = result;
        },
        error: function (response) {
            $wynik = "";
            //debugger;
            //alert('eror');
        }
    });
    return $wynik;
}

function get_project1_percentage(project_allocation_id) {
    $wynik = 0;
    $.ajax({
        type: "GET",
        url: "Staff_Time_Allocation/find_project1_percentage",
        data: { staff_project_allocation_id: project_allocation_id },
        async: false,
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            console.log("Project1_percentage=" + result);
            $wynik = result;
        },
        error: function (response) {
            $wynik = "NO PROJECT 1";
            //debugger;
            //alert('eror');
        }
    });
    return $wynik;
}

function get_project2_percentage(project_allocation_id) {
    $wynik = 0;
    $.ajax({
        type: "GET",
        url: "Staff_Time_Allocation/find_project2_percentage",
        data: { staff_project_allocation_id: project_allocation_id },
        async: false,
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            console.log("Project2_percentage=" + result);
            $wynik = result;
        },
        error: function (response) {
            $wynik = "NO PROJECT 2";
            //debugger;
            //alert('eror');
        }
    });
    return $wynik;
}

function get_hours_per_week(employee_id) {
    $wynik = 0;
    $.ajax({
        type: "GET",
        url: "Staff_Time_Allocation/find_hours_per_week",
        data: { employee_id: employee_id },
        async: false,
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            console.log("Hours_per_weeek=" + result);
            $wynik = result;
        },
        error: function (response) {
            $wynik = "error";
            //debugger;
            //alert('eror');
        }
    });
    return $wynik;
}

function calculate_annual_gross_salary(gross_salary,insurance,pension) {
    $wynik = 0;
    $.ajax({
        type: "GET",
        url: "Staff_Time_Allocation/calculate_annual_gross_salary",
        data: { gross_salary: gross_salary,insurance,pension },
        async: false,
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            console.log("Gross_salary=" + result);
            $wynik = result;
        },
        error: function (response) {
            $wynik = "error";
            //debugger;
            //alert('eror');
        }
    });
    return $wynik;
}



