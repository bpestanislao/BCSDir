
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
            UserType: $('.user-type-list').val()
        }

        $.ajax({
            type: "POST",
            data: JSON.stringify(vm),
            url: '/Employee/AddEmployee',
            contentType: "application/json",
            async: false,
        }).done(function (data) {
            //oTable.ajax.reload();
            //GetTotalInRefresh();
        });
    }
    //if ($('#ListProduct').val() != null && $('#ListProduct').val() != ""
    //    && $('.txt-price').val().trim() != "" && $('.txt-price').val().trim() != "0" && parseInt($('.txt-price').val()) > 0
    //    && $('.txt-qty').val().trim() != "" && $('.txt-qty').val().trim() != "0" && parseInt($('.txt-qty').val()) > 0) {
    //    ComputeTotalPerOrder($('.txt-qty').val(), $('.txt-price').val());
    //    vm = {
    //        ProductId: parseInt($('#ListProduct').val()),
    //        QTY: $('.txt-qty').val().trim(),
    //        Price: $('.txt-price').val().trim(),
    //        TotalPerOrder: $('.txt-total').text(),
    //        Remarks: $("#txt-area-note").val()
    //    }
    //    $.ajax({
    //        type: "POST",
    //        data: JSON.stringify(vm),
    //        url: '/Employee/AddEmployee',
    //        contentType: "application/json",
    //        async: false,
    //    }).done(function (data) {
    //        oTable.ajax.reload();
    //        GetTotalInRefresh();
    //    });
    //}

});
