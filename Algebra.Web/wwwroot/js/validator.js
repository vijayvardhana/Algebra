/***
 * 
 * TwentyOneYears age validator
 * 
 * ***/


jQuery.validator.addMethod('twentyoneyears',
    function (value, element) {
        var from = value.split("-"); // YYYY-MM-DD for chrome

        var year = from[0];
        var month = from[1];
        var day = from[2];
        var age = 21;

        var mydate = new Date();
        mydate.setFullYear(year, month - 1, day);

        var currdate = new Date();
        var setDate = new Date();

        setDate.setFullYear(mydate.getFullYear() + age, month - 1, day);

        if ((currdate - setDate) > 0) {
            return true;
        } else {
            return false;
        }
    });

jQuery.validator.unobtrusive.adapters.add('twentyoneyears',
    ['year'],
    function (options) {
        var element = $(options.form).find('input#M_DateOfBirth')[0];
        options.rules['twentyoneyears'] = [element, parseInt(options.params['year'])];
        options.messages['twentyoneyears'] = options.message;
    });



/***
 * 
 * Age between 16 and 21 years validator
 * 
 * ***/