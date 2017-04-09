//*********************


//*************************
//
(function () {
    "use strict";

    $(function () { // will trigger when the document is ready
        $('.datepicker').datetimepicker({ locale: 'en-GB' }); //Initialise any date pickers
        $('.datepicker').removeAttr("data-val-date");// this should fix on chrome.



    });
})();