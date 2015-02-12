$(document).ready(function () {

    InitialPageLoad();

    $('.tabs .tabHeader a').click('click', function (e) {

        var currentAttrValue = $(this).attr('href');
        $('.tabBodyContainer > section').slideUp(300);
        $(currentAttrValue).slideDown(300);

        $(this).parent('li').siblings().children('a').removeClass('active');
        $(this).addClass('active');

        //$(this).parent('li').siblings().children('a').css("background-color", "black");
        //$(this).css("background-color", "lightgreen");
        
        e.preventDefault();

    });


   

    function InitialPageLoad() {

        //Not used yet!
        //$('.accordion  > section').not(':eq(0)').removeClass('active');
        //$('.accordion  > section').not(':eq(0)').find('.accordion-section-content').hide();//.slideUp(500).removeClass('open');
        //$('.accordion  > section').eq(0).find('.accordion-section-title').addClass('active');

        $('.tabBodyContainer > section').not(' :eq(0)').hide();
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


   

});