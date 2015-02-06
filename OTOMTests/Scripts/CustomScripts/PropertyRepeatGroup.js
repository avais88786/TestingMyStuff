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

        //var maxProperties = $("#MaxPropertyRepeatValue").val();

        //for (var i = 2; i <= maxProperties; i++) {
        //   // $("#repeatGroupTab_" + i).hide();
        //    $("#tabBody_" + i).hide();
        //    $("#tabHeader_" + i).hide();
        //}
    
        $("#tabHeader_0").css("cursor", "pointer");
        $("#tabHeaderSelector_0").css("background-color", "lightgreen");
        TabDelegateClickHandler(0, $("#tabBody_0"));

        $("#RepeatGroupContainer_Tabs > div:not([id$='0'],.tabAdd)").hide();
        $(".nestedRepeatGroupContainer > div:not([id$='0'],.tabAdd)").hide();

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
            //repeatGroup.append()
        }

    });


    $("#tabAdd").click(function () {
        var currentId = $("#currentPropertyRepeatGroupId_Tab").val();
        var selectedId = $("#selectedPropertyRepeatGroupId_Tab").val();
        currentId = ++currentId;
        var repeatGroup = $("#tabBody_" + currentId);

        if (repeatGroup.length) {
            $("#tabBody_" + selectedId).slideToggle();
            $("#tabHeaderSelector_" + selectedId).css("background-color", "gray");


            $("#tabHeader_" + currentId).fadeIn(500);
            $("#tabHeader_" + currentId).css("cursor", "pointer");
            $("#tabHeaderSelector_" + currentId).css("background-color", "lightgreen");
            

            repeatGroup.slideToggle(500);
            $("#currentPropertyRepeatGroupId_Tab").val(currentId);
            $("#selectedPropertyRepeatGroupId_Tab").val(currentId);

            TabDelegateClickHandler(currentId, repeatGroup);
            var removeLabelId = "removeProperty" + currentId;
            repeatGroup.append('<Label id="' + removeLabelId + '" class="removeTab">Remove Property</Label>')

            //$(document).delegate("#tabHeader_" + currentId, "click", function () {
            //    var oldId = $("#selectedPropertyRepeatGroupId_Tab").val();
            //    if (oldId != currentId)
            //    {
            //        $("#tabBody_" + oldId).slideToggle();
            //        repeatGroup.slideToggle(500);
            //        $("#selectedPropertyRepeatGroupId_Tab").val(currentId);
            //    }
            //});
            
            RemoveTabDelegateClickHandler(currentId);

        }

    });
    
    function TabDelegateClickHandler(currentId, repeatGroup) {
        $(document).delegate("#tabHeader_" + currentId, "click", function () {
            var oldId = $("#selectedPropertyRepeatGroupId_Tab").val();
            if (oldId != currentId) {
                $("#tabBody_" + oldId).slideToggle();
                $("#tabHeaderSelector_" + oldId).css("background-color", "gray");

                repeatGroup.slideToggle(500);
                $("#tabHeaderSelector_" + currentId).css("background-color", "lightgreen");

                $("#selectedPropertyRepeatGroupId_Tab").val(currentId);
            }
        });
    };

    function RemoveTabDelegateClickHandler(selectedId) {
        $(document).delegate("#removeProperty"+selectedId, "click", function () {
            $("#tabBody_" + selectedId).remove();
            $("#tabHeader_" + selectedId).remove();
            selectedId = --selectedId;

            for (var i = selectedId; i >= 0; i--) {
                var element = $("#tabHeader_" + i);

                if (element.length) {
                    element.trigger("click");
                    $("#selectedPropertyRepeatGroupId_Tab").val(i);
                    break;
                }

            }

        });
    }

});