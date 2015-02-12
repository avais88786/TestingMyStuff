$(document).ready(function () {

    $(".dropDownList").change(function (event) {

        var selectedtext = $(this).find(" :selected").text();
        var abiCodeList = $(this).val();

        $('#dropDownValueSelector').text(selectedtext + "    " + abiCodeList);

        //$.post('DisplayCodeListSelectedValue', { id: $(this).val(), selectedText: selectedtext }, function (data) {

        //    $('#dropDownValueSelector').text(data);

        //});

        var x = 5;
    })



});