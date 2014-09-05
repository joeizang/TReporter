/**
 * Javascript/Jquery File to handle auto calculation of Commission and other client centric enablements
 * we need to get the value of the enum representing Policy Types and use that as a basis for commission
 * Calculations.
 **/


$(function () {
    
    $('#PolicyType').change(function () {
        var pt = $(this).val();
        $('#PremiumPaid').blur(function () {
            var pr = $(this).val();

            var comsn = $('#Comission');
            switch (pt) {
                case 11:
                    comsn.val(parseFloat(pr) * 0.125);
                    break;
                case 7:
                    comsn.val(parseFloat(pr) * 0.09);
                    break;
                case 14:
                    comsn.val(parseFloat(pr) * 0.15);
                default:
                    comsn.val(parseFloat(pr) * 0.20);
            }
        })
    });
    //Include JqueryUI for date picking etc
    
    
});

