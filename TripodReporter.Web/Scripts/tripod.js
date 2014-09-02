/**
 * Javascript/Jquery File to handle auto calculation of Commission and other client centric enablements
 * we need to get the value of the enum representing Policy Types and use that as a basis for commission
 * Calculations.
 **/
$(function () {
    
    var policytype = $('#PolicyType').change();
    console.log(policyType);

    $('#PremiumPaid').blur(function () {
                var premium = $('#PremiumPaid').val();
                //console.log(parseFloat(premium));
               // $('#Comission').val(parseFloat(premium) / 0.125);

                //use a switch statement to handle the differnt scenarios for calculating commission
                switch (policytype)
                {
                    case 11:
                        //then policy type is Motor & commission rate is 12.5%
                        $('#Commission').val(parseFloat(premium) / 0.125);
                        break;
                    case 7:
                        //then policy type is Group Life & commission rate is 9%
                        $('#Comission').val(parseFloat(premium) / 0.09);
                        break;
                    case 14:
                        //then policy type is workmenscompensation & commission is 15%
                        $('#Commission').val(parseFloat(premium) / 0.15);
                        break;
                    default:
                        $('#Commission').val(parseFloat(premium) / 0.20);

                }
    })
})

