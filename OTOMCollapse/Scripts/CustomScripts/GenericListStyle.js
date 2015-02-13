$(document).ready(function () {

    $('#subsidiaryRepeatGroup').click(function () {

        var g = $('#gg');
        var x = $('#gg').first().data('container');
        var y = $('#gg').first().data('property');
        
        $('.placeholder').last().load("PropertyOwners/avais", { container: x, property: y }, function () {
            alert('hiiiii');
        });
        //$.post("PropertyOwners/avais", { container: x, property: y }, function (data) {
           
        //});

    });

    //function GiveMe(model){

    //    va
    //};

});