function showToast(type, title, message) {
    toastr.options =
    {
        "debug": false,
        "positionClass": 'toast-center-center',
        "onclick": null,
        "fadeIn": 100,
        "fadeOut": 100,
        "timeOut": 2000,

    }
    toastr[type](message, title);
    console.log(toastr);
}