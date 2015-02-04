$(document).ready(function () {

    
    HideProperties();

    function HideProperties() {
        
        $("#RepeatGroupContainer > div").hide();
        $("#PropertyRepeatGroup_0").show();
        //var maxProperties = $("#MaxPropertyRepeatValue").val();

        //for (var i = 1; i < maxProperties; i++) {
        //    $("#PropertyRepeatGroup_" + i).hide();
        //}

        //$("#RepeatGroupContainer_Tabs > div > div").hide();

        var maxProperties = $("#MaxPropertyRepeatValue").val();

        for (var i = 2; i <= maxProperties; i++) {
            $("#repeatGroupTab_" + i).hide();
            $("#tabBody_" + i).hide();
        }


    };


    $("#addProperty").click(function () {

        var maxProperties = $("#MaxPropertyRepeatValue").val();
        var currentId = $("#currentPropertyRepeatGroupId").val();
        currentId = ++currentId;
        var repeatGroup = $("#PropertyRepeatGroup_" + currentId);//.show(500);//.slideDown();

        if (repeatGroup.length) //if element exists
        {
            repeatGroup.show(500);
            $("#currentPropertyRepeatGroupId").val(currentId);
            $("#removeProperty").removeAttr("hidden");
        }
        
        if (currentId >= maxProperties-1)
            $(this).hide();
        

    });


    $("#removeProperty").click(function () {

        var currentId = $("#currentPropertyRepeatGroupId").val();
        var repeatGroup = $("#PropertyRepeatGroup_" + currentId);//.hide(500);//.slideDown();

        if (repeatGroup.length) {
            repeatGroup.hide(500);
            currentId = --currentId;
            $("#currentPropertyRepeatGroupId").val(currentId);
            
        }
        
        if (currentId == 0)
            $(this).attr("hidden", "hidden");
        else
        {
            $("#addProperty").show();
        }

    });


    $("#addProperty_Tab").click(function () {
        var currentId = $("#currentPropertyRepeatGroupId_Tab").val();
        $("#tabBody_" + currentId).hide();
        currentId = ++currentId;
        var repeatGroup = $("#tabBody_" + currentId);

        if (repeatGroup.length) {
            $("#repeatGroupTab_" + currentId).show(500);
            repeatGroup.show(500);
            $("#currentPropertyRepeatGroupId_Tab").val(currentId);
            repeatGroup.append()
        }

    });


});