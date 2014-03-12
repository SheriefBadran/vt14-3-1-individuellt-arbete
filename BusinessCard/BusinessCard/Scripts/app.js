$(document).ready(function () {

    $('#CompanyNameTextBox').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Model/DAL/CompanySearch.asmx/GetCompanyNames",
                data: "{ 'nameFragment': '" + request.term + "'}",
                type: "POST",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Error!');
                }
            });
        }
    });
});