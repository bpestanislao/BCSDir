var oTable = null;

$(document).ready(function () {
    $('.btn-save-employee').click(function () {
        var empty = $('.row').parent().find("input").filter(function () {
            return this.value === "";
        });
        if (empty.length) {
            //At least one input is empty
            alert("empty!");
        }
        else {
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
                UserType: $('.user-type-list').val(),
                HireDate: $('.txt-hdate').val(),
                Department: $('.department').val()
            }

            $.ajax({
                type: "POST",
                data: JSON.stringify(vm),
                url: '/Employee/AddEmployee/',
                contentType: "application/json",
                async: false,
            }).done(function (data) {
                $.ajax({
                    type: "POST",
                    data: JSON.stringify(vm),
                    url: '/Employee/GetActiveEmployees/',
                    contentType: "application/json",
                    async: false,
                }).done(function (data) {
                    //oTable.ajax.reload();
                    //GetTotalInRefresh();
                });
            });
        }

    });

    DtEmployee();

});


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
    alert(data.id);
    $.ajax({
        type: "POST",
        url: '/Employee/GetEmployeeById/?id=' + data.id,
        contentType: "application/json"
    }).done(function (result) {
        alert(result.data.age);
        $('.txt-age').val(result.data.age);
                //Age: $('.txt-age').val().trim(),
                //HobbiesAndInterest: $('.txt-hobbies').val().trim(),
                //CivilStatus: $('.status-list').val(),
                //Gender: $(".gender").val(),
                //Address: $('.txt-address').val(),
                //Country: $('.txt-country').val(),
                //State: $('.txt-state').val(),
                //FirstName: $('.txt-fname').val(),
                //LastName: $('.txt-lname').val(),
                //LanguagesSpoken: $('.txt-language').val(),
                //PhoneNumber: $('.txt-phone').val(),
                //UserType: $('.user-type-list').val(),
                //HireDate: $('.txt-hdate').val(),
                //Department: $('.department').val()
    });
});
