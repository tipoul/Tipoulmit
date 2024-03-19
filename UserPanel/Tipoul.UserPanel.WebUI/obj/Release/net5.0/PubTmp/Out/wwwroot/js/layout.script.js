$(document).ready(function () {
    //   datepicker
    if (jQuery.fn.datepicker)
        jQuery('.date-picker').each(function () {
            var input = jQuery(this);
            var pd = input.pDatepicker({
                format: 'YYYY/MM/DD',
                autoClose: true,
                initialValue: input.prop("required"),
                initialValueType: 'persian',
                onSelect: function () {
                }
            });

            setTimeout(function () {
                if (input.data("value")) {
                    var dateParts = input.data("value").split('-');
                    pd.setDate(new persianDate([parseInt(dateParts[0]), parseInt(dateParts[1]), parseInt(dateParts[2])]));
                }
            }, 300);

            input.parents("form").submit(function () {
                var value = input.val();
                value = ToEnglishNumbers(value);
                var dateParts = value.split('/');
                var date = new persianDate([parseInt(dateParts[0]), parseInt(dateParts[1]), parseInt(dateParts[2])]).toDate();
                input.val(date.toLocaleString());
            });
        });

    if (jQuery.fn.dropzone)
        jQuery("div[data-drop-zone=true]").each(function () {
            var actionUrl = jQuery(this).data("action-url");

            if (actionUrl)
                jQuery(this).dropzone({ url: jQuery(this).data("action-url") });
            else
                console.error('action-url not specified', jQuery(this));
        });

    if (jQuery.fn.wickedpicker)
        $(".time-picker").wickedpicker({
            showSeconds: false,
            title: '',
            twentyFour: true
        });

    $("input[data-max-length]").keyup(function () {
        var maxLength = parseInt($(this).data("max-length"));
        if (maxLength != -1) {
            var value = $(this).val();
            if (value.length > maxLength)
                $(this).val(value.substring(0, maxLength));
        }
    });

    jQuery(".numeric").keydown(function (e) {
        if (IsCommonKey(e))
            return true;

        switch (e.key) {
            case "1":
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
            case "0":
                return true;
            default:
                return false;
        }
    });

    jQuery(".persian-text").keypress(function (event) {
        if (IsCommonKey(event))
            return true;

        var isValid = " آابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی".indexOf(event.key) != -1;

        if (isValid)
            jQuery(this).parent().find(".en-error").remove();
        else if (jQuery(this).parent().find(".en-error").length == 0)
            jQuery(this).parent().append("<span class='text-danger en-error'>لطفا کیبورد خود را فارسی کنید</span>");


        return isValid;
    });

    function IsCommonKey(e) {
        switch (e.key) {
            case "Tab":
            case "Control":
            case "v":
            case "Delete":
            case "Backspace":
            case "Home":
            case "End":
            case "ArrowLeft":
            case "ArrowUp":
            case "ArrowDown":
            case "ArrowRight":
            case "Insert":
            case "NumLock":
            case "Enter":
            case "Shift":
            case "CapsLock":
                return true;
            default:
                return false;
        }
    }

    function ToEnglishNumbers(value) {

        for (var i = 0; i < value.length; i++) {
            value = value
                .replace("۰", "0")
                .replace("۱", "1")
                .replace("۲", "2")
                .replace("۳", "3")
                .replace("۴", "4")
                .replace("۵", "5")
                .replace("۶", "6")
                .replace("۷", "7")
                .replace("۸", "8")
                .replace("۹", "9");
        }

        return value;
    }
});