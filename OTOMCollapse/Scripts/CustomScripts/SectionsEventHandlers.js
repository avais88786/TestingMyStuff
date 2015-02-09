$(document).ready(function () {

    InitialPageLoad();

    function InitialPageLoad() {

        //$('.accordion .accordion-section-title').not(':eq(0)').removeClass('active');
        //$('.accordion .accordion-section-content').not(':eq(0)').slideUp(500).removeClass('open');

        $('.accordion  > section').not(':eq(0)').removeClass('active');
        $('.accordion  > section').not(':eq(0)').find('.accordion-section-content').hide();//.slideUp(500).removeClass('open');
        $('.accordion  > section').eq(0).find('.accordion-section-title').addClass('active');


        //$("fieldset > section").not(":eq(0)").hide();

    };

    $('.accordion-section-title').click(function (e) {
        e.preventDefault();
        var accordionSectionIdToShow = $(this).attr('href');
        
        if ($(e.target).is('.active')) {
            return;
        }

        HideSections();
        $(this).addClass('active');

        $('.accordion ' + accordionSectionIdToShow).slideDown(500).addClass('open');

      
    });

    function HideSections(){

        $('.accordion .accordion-section-title').removeClass('active');
        $('.accordion .accordion-section-content').slideUp(500).removeClass('open');

    }


    //$("#sectionDeclarationQuestions").click(function () {

    //    ShowThisTab(this);

    //});
    
    //$("#sectionPropertyQuestions").click(function () {
        
    //    ShowThisTab(this);

    //});

    //function ShowThisTab(tabElement) {
    //    $("fieldset > section").not($(tabElement).next("section")).slideUp(500);
    //    $(tabElement).next().slideDown(500);
    //}

});