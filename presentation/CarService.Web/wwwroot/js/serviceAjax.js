function getCostTypesPartial(id) {

    $.post("/Admin/Service/GetCostTypesPartial", { id: id })
        .done(function (data) {
            if (!data) {
                $("#result_get_cost_types_partial").html("");
                getCostPartial(0);
            }
            else {
                getCostPartial(0);
                $("#result_get_cost_types_partial").html(data);                
            }
        }).then(function () {
            var form = $("#add_service");
            form.removeData('validator');
            form.removeData('unobtrusiveValidation');
            $.validator.unobtrusive.parse("form");
        });
}

function getCostPartial(id) {
    if(id === -1) {
        $("#result_get_cost_partial").html("");
    }else {
        $.post("/Admin/Service/GetCostPartial", { id: id })
            .done(function (data) {
                $("#result_get_cost_partial").html(data);
            }).then(function () {
                var form = $("#add_service");
                form.removeData('validator');
                form.removeData('unobtrusiveValidation');
                $.validator.unobtrusive.parse("form");
            });
    }
}

function getParameterPartial(id) {

    $.post("/Admin/Service/GetParameterPartial", { id: id })
        .done(function (data) {
            $("#result_get_parameter_partial").html(data);
        }).then(function () {
            var form = $("#add_service");
            form.removeData('validator');
            form.removeData('unobtrusiveValidation');
            $.validator.unobtrusive.parse("form");
        });
}

