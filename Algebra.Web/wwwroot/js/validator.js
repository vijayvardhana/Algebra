/***
 * 
 * TwentyOneYears age validator
 * And
 * Age between 16 and 21 years validator
 * 
 * ***/

$.validator.addMethod(
    'validateage',
    function (value, element, params) {

        //this hac is just for chrome need to find better solution
        var dateAr = value.split('-');
        var newDate = dateAr[1] + '/' + dateAr[2] + '/' + dateAr[0];
        console.log(newDate);
        var minumumdate = $(element).attr("minumumdate");
        var maximumdate = $(element).attr("maximumdate");
        return Date.parse(newDate) >= Date.parse(minumumdate)
            && Date.parse(newDate) <= Date.parse(maximumdate);
    });

$.validator.unobtrusive.adapters.add(
    'validateage', ['minumumdate', 'maximumdate'], function (options) {
        var params = {
            minumumdate: options.params.minumumdate,
            maximumdate: options.params.maximumdate
        };
        options.rules['validateage'] = params;
        options.messages['validateage'] = options.message;
    });
