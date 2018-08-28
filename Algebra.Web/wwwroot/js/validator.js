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