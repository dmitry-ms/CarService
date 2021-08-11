function addServiceToBasket(serviceId) {
    let carId = $('#carId').text();
    $.post("/Client/Service/AddServiceToBasket", { serviceId: serviceId, carId : carId })
        .done(function (data) {
            if (data) {
                let amount = data.amount;
                let serviceId = data.serviceId;
                $('#' + serviceId).text('Удалить из корзины')
                    .attr("onclick", "removeServiceFromBasket('" + data.serviceId + "')")
                    .removeClass('btn-success').addClass('btn-danger');
                $('#order_counter').text(amount).removeClass('visually-hidden');
                $('#submitOrder').prop('aria-disabled', false);
                $('#submitOrder').removeClass('disabled');
            }
        });
}

function removeServiceFromBasket(serviceId) {
    let carId = $('#carId').text();
    $.post("/Client/Service/RemoveServiceFromBasket", { serviceId: serviceId, carId: carId })
        .done(function (data) {
            if (data) {
                let amount = data.amount;
                let serviceId = data.serviceId;
                $('#' + serviceId).text('Добавить в корзину').attr("onclick", "addServiceToBasket('" + data.serviceId + "')")
                    .removeClass('btn-danger').addClass('btn-success');
                $('#order_counter').text(amount);
                if (amount < 1) {
                    $('#order_counter').addClass('visually-hidden');
                    $('#submitOrder').prop('aria-disabled', true);
                    $('#submitOrder').addClass('disabled');
                }
            }
        });
}

function getBasket(carId) {
    $.post("/Client/Service/Basket", { carId: carId })
        .done(function (data) {
            $('#basketContent').html(data);
        });
}
