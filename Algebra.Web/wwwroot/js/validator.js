/***
 * 
 * TwentyOneYears age validator
 * 
 * ***/


jQuery.validator.addMethod('twentyoneyears',
    function (value, element) {
        var dob = value.split("-"); // YYYY-MM-DD for chrome

        var year = dob[0];
        var month = dob[1];
        var day = dob[2];
        var age = 21;
        console.log("Year : " + year + ", Month : " + month + ", Day : " + day);
        var mydate = new Date();
        mydate.setFullYear(year, month - 1, day);
        console.log("Mydate : " + mydate );
        var currdate = new Date();
        var setDate = new Date();

        setDate.setFullYear(mydate.getFullYear() + age, month - 1, day);
        console.log("SetDate : " + setDate);
        console.log("CurrDate - SetDate : " + (currdate - setDate));
        if ((currdate - setDate) > 0) {
            console.log("Return true");
            return true;
        } else {
            console.log("Return false");
            return false;
        }
    });

jQuery.validator.unobtrusive.adapters.add('twentyoneyears',
    ['year'],
    function (options) {
        var element = $(options.form).find('input#DateOfBirth')[0];
        options.rules['twentyoneyears'] = [element, parseInt(options.params['year'])];
        options.messages['twentyoneyears'] = options.message;
    });



/***
 * 
 * Age between 16 and 21 years validator
 * 
 * ***/

$.validator.addMethod(
    'validateage',
    function (value, element, params) {
        var min = $(element).attr("data-val-min");
        var max = $(element).attr("data-val-max")
        var minumumdate = $(element).attr("minumumdate");
        var maximumdate = $(element).attr("maximumdate");
        //return Date.parse(value) >= Date.parse(params.minumumdate) && Date.parse(value) <= Date.parse(params.maximumdate);
        return Date.parse(value) >= Date.parse(minumumdate) && Date.parse(value) <= Date.parse(maximumdate);
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



//jQuery.validator.unobtrusive.adapters.add('agerange',
//    ['year'],
//    function (options) {
//        var element = $(options.form).find('input#DateOfBirth')[0];
//        options.rules['agerange'] = [element, parseInt(options.params['year'])];
//        options.messages['agerange'] = options.message;
//    });