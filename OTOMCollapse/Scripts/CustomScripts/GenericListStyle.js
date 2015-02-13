$(document).ready(function () {

    $('#subsidiaryRepeatGroup').click(function () {

        var g = $('#gg');
        var x = $('#gg').first().data('container');
        var y = $('#gg').first().data('property');
        
        var t = $('form').serialize();

        $('.placeholder').last().load("avais", { container: x, property: y, viewModel: t }, function () {
            alert('hiiiii');
        });
        //$.post("PropertyOwners/avais", { container: x, property: y }, function (data) {
           
        //});

    });

    

});