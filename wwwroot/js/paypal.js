export function initPayPalButton(containerId, amount, currency, dotNetObject) {
    if (!window.paypal) {
        console.error("PayPal SDK not loaded");
        dotNetObject.invokeMethodAsync('OnPayPalError', "PayPal SDK not loaded");
        return;
    }

    document.getElementById(containerId).innerHTML = '';

    window.paypal.Buttons({
        createOrder: function(data, actions) {
            return actions.order.create({
                purchase_units: [{
                    amount: {
                        value: amount,
                        currency_code: currency
                    }
                }]
            });
        },
        onApprove: function(data, actions) {
            return actions.order.capture().then(function(details) {
                // Return success to Blazor
                dotNetObject.invokeMethodAsync('OnPayPalSuccess', details.id, details.payer.name.given_name);
            });
        },
        onError: function(err) {
            console.error("PayPal Error:", err);
            dotNetObject.invokeMethodAsync('OnPayPalError', err.toString());
        },
        onCancel: function(data) {
            dotNetObject.invokeMethodAsync('OnPayPalCancel');
        }
    }).render('#' + containerId);
}
