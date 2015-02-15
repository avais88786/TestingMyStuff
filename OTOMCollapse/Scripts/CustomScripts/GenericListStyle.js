$(document).ready(function () {

    $('#subsidiaryRepeatGroup').click(function () {

        var g = $('#gg');
        var x = $('#gg').first().data('container');
        var y = $('#gg').first().data('property');
        
        var t = $('form').serialize();
        var tt = JSON.stringify($('form').html());
        var datas = $('form').serialize() + "&container=" + x + "&property="  + y;
        $('.placeholder').last().load("PropertyOwners/avais", datas, function () {
            
        });


        //$.post("PropertyOwners/avais", { viewModel: t,container: x, property: y }, function (data) {
           
        //});

        //$.ajax({
        //    type: "POST",
        //    url: 'PropertyOwners/avais',
        //    data: {viewModel : $('form').serialize(),container:x,property:y},
        //    success: function (data, textStatus) {
        //    }
        //});

    });


    $("body").on("click",":button[data-hiddenforelementid]",function () {
        //$(":button").click(function () {

        var clickedButton = $(this);
        var hiddenElementId = $(this).data("hiddenforelementid");
        
        var container = $(hiddenElementId).data('container');
        var property = $(hiddenElementId).data('property');
        var maxPossibleValue = $(hiddenElementId).data('maxpossiblevalue');
        var currentDisplayedRepeatingGroups = $(hiddenElementId).data('currentdisplayedrepeatinggroupsonpage');
        var currentRepeatingGroupIndex = $(hiddenElementId).data('currentindex');
        var nextIndex = currentRepeatingGroupIndex + 1;
        var htmlTemplateFieldPrefix = $(hiddenElementId).data('htmlfieldprefix');

        if (currentDisplayedRepeatingGroups >= maxPossibleValue) {
            return;
        }
        
        var placeHolderId = $(this).data('placeholderelementid');

        var placeHolder = $(placeHolderId);

        var datas = "container=" + container + "&property=" + property + "&nextIndex=" + nextIndex + "&htmlTemplateFieldPrefix=" + htmlTemplateFieldPrefix;

        //var placeHolderDiv = $("[data-placeholderelementid=" + placeHolderId + "]").last();
        //var existingHtml = placeHolderDiv.html();
        ////$("[data-placeholderelementid=" + placeHolderId + "]").load("PropertyOwners/avais", datas, function () {
        //placeHolderDiv.load("PropertyOwners/avais", datas, function () {
        //    //$(this).prepend(existingHtml);
        //});

        $.get("PropertyOwners/avais", datas, function (result) {
            currentDisplayedRepeatingGroups = currentDisplayedRepeatingGroups + 1;
            $(hiddenElementId).data('currentdisplayedrepeatinggroupsonpage', currentDisplayedRepeatingGroups);
            $(hiddenElementId).attr('data-currentdisplayedrepeatinggroupsonpage', currentDisplayedRepeatingGroups);

            $(hiddenElementId).data('currentindex', nextIndex);
            $(hiddenElementId).attr('data-currentindex', nextIndex);

            placeHolder.append(result);

            if (currentDisplayedRepeatingGroups >= maxPossibleValue) {
                clickedButton.fadeOut(500);
            }

        });

    });

    $("body").on("click", ":button[data-placeholderelementidtoremove]", function () {
        var divId = $(this).data('placeholderelementidtoremove');
        $("div [data-placeholderelementid=" + divId + "]").fadeOut(500);
        
        var x = $(this).parent();
        var y = $(this).parent().parent('section');
        $(this).parent().parent('section').siblings(':button[data-hiddenforelementid]').first().slideDown(300);
        var hiddenElement = $(this).parent().parent('section').siblings(':hidden[data-currentdisplayedrepeatinggroupsonpage]').first();//.slideDown(300);

        var currentDisplayedRepeatingGroups = hiddenElement.data('currentdisplayedrepeatinggroupsonpage');
        currentDisplayedRepeatingGroups = --currentDisplayedRepeatingGroups;
        hiddenElement.data('currentdisplayedrepeatinggroupsonpage', currentDisplayedRepeatingGroups);
        hiddenElement.attr('data-currentdisplayedrepeatinggroupsonpage', currentDisplayedRepeatingGroups);

        //var addButtonId = $(this).data('mappedaddelementid');
        //$(addButtonId).slideDown(1000);
    });

});