function getModels(brand) {

    $.post("/Client/Home/GetModels", { brand: brand })
        .done(function (data) {
            if (data) {
                var s = '<option selected disabled></option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option>' + data[i] + '</option>';
                }
                $("#modelSelect").html(s);
                $("#engineSelect").html('<option selected disabled></option>');
            }
            else {
                $("#modelSelect").html('<option selected disabled></option>');
            }
        }).then(function () {
            var form = $("#add_ClientCar");
            form.removeData('validator');
            form.removeData('unobtrusiveValidation');
            $.validator.unobtrusive.parse("form");
        });
}

function getEngines(model) {
    let brand = $("#modelBrand :selected").text();
    console.log(brand);
    $.post("/Client/Home/GetEngines", { brand: brand, model: model })
        .done(function (data) {
            console.log(data);
            if (data) {
                var s = '<option selected disabled></option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].item2 + '">' + data[i].item1 + '</option>';
                }
                $("#engineSelect").html(s);
                console.log(s);
            }
            else {
                $("#engineSelect").html('<option selected disabled></option>');
            }
        }).then(function () {
            var form = $("#add_ClientCar");
            form.removeData('validator');
            form.removeData('unobtrusiveValidation');
            $.validator.unobtrusive.parse("form");
        });
}