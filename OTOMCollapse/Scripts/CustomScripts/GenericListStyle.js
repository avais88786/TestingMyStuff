$(document).ready(function () {

    HideElements();

    function HideElements() {
        $(':input[type="hidden"][data-currentdisplayedrepeatinggroupsonpage]').each(function (index, element) {

            var currentDisplayedRepeatingGroups = $(this).data('currentdisplayedrepeatinggroupsonpage');

            if (currentDisplayedRepeatingGroups <= 1) {
                var thisID = $(this).attr('id');
                var z = $(':button[data-hiddenelementid="#' + thisID + '"]');
                $(':button[data-hiddenelementid="#' + thisID + '"]').hide();
            }

        });
    };


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
        
        var xx = $(this).prevAll('section');
        var placeHolder = $(this).siblings('div').last();
        var isAccordion = placeHolder.has('.accordion-section');


        var datas = "property=" + property + "&nextIndex=" + nextIndex + "&htmlTemplateFieldPrefix=" + htmlTemplateFieldPrefix + "&container=" + container;

        $.ajax({
            url: "PropertyOwners/avais",
            data: datas,
            beforeSend: function(){
                clickedButton.attr("disabled", true);
                },
            success: function (result) {
                currentDisplayedRepeatingGroups = currentDisplayedRepeatingGroups + 1;
                $(hiddenElementId).data('currentdisplayedrepeatinggroupsonpage', currentDisplayedRepeatingGroups);
                $(hiddenElementId).attr('data-currentdisplayedrepeatinggroupsonpage', currentDisplayedRepeatingGroups);

                $(hiddenElementId).data('currentindex', nextIndex);
                $(hiddenElementId).attr('data-currentindex', nextIndex);

                if (isAccordion.length > 0) {
                    HideSections();
                }
                

                placeHolder.append(result);

                if (currentDisplayedRepeatingGroups >= maxPossibleValue) {
                    clickedButton.fadeOut(500);
                }

                $(':button[data-hiddenelementid="' + hiddenElementId + '"]').slideDown();
                HideElements();
                clickedButton.removeAttr("disabled");
            },
            error: function () {
                alert('failed');
                clickedButton.removeAttr("disabled");
            }
        });
    });

    $("body").on("click", ":button[data-placeholderelementidtoremove]", function () {
        
        
        var similarElementsName = $(this).data('mappedsimilarelements');
        //$(this).parent().siblings(':button[data-hiddenforelementid]').first().slideDown(300);
        //var hiddenElement = $(this).parent().siblings(':hidden[data-currentdisplayedrepeatinggroupsonpage]').first();//.slideDown(300);
        var hiddenElementId = $(this).data('hiddenelementid');
        var hiddenElement = $(hiddenElementId);

        hiddenElement.next(':button').slideDown(300);

        var currentDisplayedRepeatingGroups = hiddenElement.data('currentdisplayedrepeatinggroupsonpage');
        currentDisplayedRepeatingGroups = --currentDisplayedRepeatingGroups;
        hiddenElement.data('currentdisplayedrepeatinggroupsonpage', currentDisplayedRepeatingGroups);
        hiddenElement.attr('data-currentdisplayedrepeatinggroupsonpage', currentDisplayedRepeatingGroups);

        $(this).parent('section').last().fadeOut(500, function () {

                if (currentDisplayedRepeatingGroups == 1) {
                    $(':button[data-mappedsimilarelements="' + similarElementsName + '"]').hide();
                }

               
                if ($(this).parent().parent('.accordion-section').last().length > 0) {
                    $(this).parent().parent('.accordion-section').last().remove();
                    HideSections();
                }

                $(this).remove();
            });
    });

    InitialPageLoad();

    function InitialPageLoad() {
        $('.accordion-section-title').eq(0).addClass('active');
        $('.accordion-section-content').not(':eq(0)').hide();
        $('.accordion-section-title').not(':eq(0)').removeClass('active');

    }
    $("body").on("click", ".accordion-section-title", function (e) {

        e.preventDefault();
        var accordionSectionIdToShow = $(this).attr('href');

        if ($(e.target).is('.active')) {
            return;
        }

        HideSections();
        $(this).addClass('active');

        $(accordionSectionIdToShow).slideDown(500).addClass('open');


    });

    function HideSections() {

        $('.accordion-section-title').removeClass('active');
        $('.accordion-section-content').slideUp(500).removeClass('open');

    }


});