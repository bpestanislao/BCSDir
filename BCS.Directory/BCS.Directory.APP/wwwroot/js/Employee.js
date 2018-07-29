var oTable = null;
var userRoleId = "";
function ValidateRequiredFields() {
    var empty = $('.row').parent().find("input").filter(function () {
        return this.value === "";
    });
    if (empty.length) {
        return "error";
    }
}
var vm = null;
function MapEmployeeVM() {
    vm = {
        Birthdate: $('.txt-bdate').val().trim(),
        Age: $('.txt-age').val().trim(),
        HobbiesAndInterest: $('.txt-hobbies').val().trim(),
        CivilStatus: $('.status-list').val(),
        Gender: $(".gender").val(),
        Address: $('.txt-address').val(),
        Country: $('.txt-country').val(),
        State: $('.txt-state').val(),
        FirstName: $('.txt-fname').val(),
        LastName: $('.txt-lname').val(),
        LanguagesSpoken: $('.txt-language').val(),
        PhoneNumber: $('.txt-phone').val(),
        HireDate: $('.txt-hdate').val(),
        Department: $('.department').val(),
        Id: $('.empId').text(),
        EmployeeSettingsViewModel: {
            Id: $('.empSettingsId').text(),
            IsBirthDatePrivate: $('#chkBday').prop('checked'),
            IsAgePrivate: $('#chkAge').prop('checked'),
            IsHobbiesAndInterestPrivate: $('#chkHobbiesI').prop('checked'),
            IsCivilStatusPrivate: $('#chkCS').prop('checked'),
            IsAddressPrivate: $('#chkAddress').prop('checked'),
        }
    }
}

$(document).ready(function () {
    $('.btn-save-employee').click(function () {
        if (ValidateRequiredFields() == "error") {
            alert("All fields are required!");
        }
        else {
            MapEmployeeVM();
            $.ajax({
                type: "POST",
                data: JSON.stringify(vm),
                url: '/Employee/AddEmployee/',
                contentType: "application/json",
                async: false,
            }).done(function (data) {
                oTable.ajax.reload();
                ResetFields();
                GetUserRole();
                $('.add-employee-div').css("display", "none");
            });
        }
    });

    DtEmployee();

    $('.btn-update-employee').click(function () {
        if (ValidateRequiredFields() == "error") {
            alert("All fields are required!");
        }
        else {
            MapEmployeeVM();
            $.ajax({
                type: "POST",
                data: JSON.stringify(vm),
                url: '/Employee/EditEmployee/',
                contentType: "application/json",
                async: false,
            }).done(function (data) {
                ResetFields();
                oTable.ajax.reload();
                GetUserRole();
            });
        }
    });

    $('.btn-delete-employee').click(function () {
        if (ValidateRequiredFields() == "error") {
            alert("All fields are required!");
        }
        else {
            $.ajax({
                type: "POST",
                url: '/Employee/DeleteEmployeeById/?id=' + $('.empId').text(),
                contentType: "application/json",
                async: false,
            }).done(function (data) {
                oTable.ajax.reload();              
                $('.add-employee-div').css("display", "none");
                ResetFields();
                GetUserRole();  
            });
        }
    });

    $('.btn-update-employee').css("display", "none");
    $('.btn-delete-employee').css("display", "none");

     GetUserRole();
});

function GetUserRole() {
    $.ajax({
        type: "POST",
        url: '/Session/GetUserRoleId/',
        contentType: "application/json",
        async: false,
    }).done(function (data) {
        userRoleId = data.userRoleId;
        if (userRoleId == "1" || userRoleId == "4") { 
            //Admin and Editor
            $('#view-add-employee').text("Add Employee");
            $('.btn-action').css("display", "block");
            $('.add-employee-div').css("display", "block");

            $('.btn-update-employee').css("display", "none");
            $('.btn-delete-employee').css("display", "none");
            $('.btn-save-employee').css("display", "block");
        }
        else if (userRoleId == "2") {
            //Employee
        }
        else if (userRoleId == "3") {
            //Viewer
            $('#view-add-employee').text("Employee Details");
            $('.add-employee-div').css("display", "none");
            $('.btn-action').css("display", "none");
        }
    });
}

function DtEmployee() {
    $('.tableManageOrder').DataTable({
        "paging": false,
        "ordering": false,
        "info": false
    });

    oTable = $('#tbl-employee-view').DataTable({
        "bPaginate": false,
        "bFilter": false,
        "bLengthChange": false,
        "bInfo": false,
        "scrollX": true,
        "ajax": {
            "url": '/Employee/GetAllSaveActiveEmployees',
            "type": "POST",
            "async": "false",
            "complete": function () {

            }
        },
        "columns": [
            {
                "data": "id",
            },
            {
                "data": "firstName",
            },
            {
                "data": "lastName",
            },
            {
                defaultContent:
                    '<button class="btn-view btn btn-primary" style="margin-right: 10px;" type="button">View</button>'
            }

        ],
        columnDefs: [{
            orderable: false,
            className: 'select-checkbox',
            targets: 1,
        }],

        select: {
            style: 'os',
            selector: 'td:first-child'
        },
        order: [[0, 'asc']]
    });

 
}

$('#tbl-employee-view tbody').on('click', '.btn-view', function (e) {
    var data = oTable.row($(this).parents('tr')).data();
    $.ajax({
        type: "POST",
        url: '/Employee/GetEmployeeById/?id=' + data.id,
        contentType: "application/json"
    }).done(function (result) {
        MapEmployeeDetails(result);
        $('#view-add-employee').text("Employee Details");
        $('.add-employee-div').css("display", "block");
        $('.btn-update-employee').css("display", "block");
        $('.btn-delete-employee').css("display", "block");
        $('.btn-save-employee').css("display", "none");
    });
});

function MapEmployeeDetails(result) {
    var response = result.data;
    $('.empId').text(response.id);
    $('.txt-fname').val(response.firstName);
    $('.txt-lname').val(response.lastName);
    $('.txt-bdate').val(response.birthdate);
    $('.txt-age').val(response.age);
    $('.status-list').val(response.civilStatus);
    $('.txt-language').val(response.languagesSpoken);
    $('.txt-country').val(response.country);
    $('.txt-state').val(response.state);
    $('.txt-phone').val(response.phoneNumber);
    $('.txt-hdate').val(response.hireDate);
    $('.department').val(response.department);
    $('.txt-address').val(response.address);
    $(".gender").val(response.gender);
    $(".txt-hobbies").val(response.hobbiesAndInterest);
    $('#chkHobbiesI').prop('checked', response.employeeSettingsViewModel.isHobbiesAndInterestPrivate);
    $('#chkAge').prop('checked', response.employeeSettingsViewModel.isAgePrivate);
    $('#chkBday').prop('checked', response.employeeSettingsViewModel.isBirthDatePrivate);
    $('#chkAddress').prop('checked', response.employeeSettingsViewModel.isAddressPrivate);
    $('#chkCS').prop('checked', response.employeeSettingsViewModel.isCivilStatusPrivate);
    $('.empSettingsId').text(response.employeeSettingsViewModel.id);
}


function ResetFields() {
    $('.empId').text("");
    $('.txt-fname').val("");
    $('.txt-lname').val("");
    $('.txt-bdate').val("");
    $('.txt-age').val("");
    $('.status-list').val("1");
    $('.txt-language').val("");
    $('.txt-country').val("");
    $('.txt-state').val("");
    $('.txt-phone').val("");
    $('.txt-hdate').val("");
    $('.department').val("1");
    $('.txt-address').val("");
    $(".gender").val("1");
    $(".txt-hobbies").val("");
    $('#chkHobbiesI').prop('checked', false);
    $('#chkAge').prop('checked', false);
    $('#chkBday').prop('checked', false);
    $('#chkAddress').prop('checked', false);
    $('#chkCS').prop('checked', false);
    $('.empSettingsId').text("");
}