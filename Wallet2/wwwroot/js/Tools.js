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
function printDiv(printBtn,title, element) {
	$(printBtn).prop("disabled", true);
	var mywindow = window.open('', "PRINT", "toolbar=yes,scrollbars=yes,resizable=yes,top=100,left=500,width=700,height=600");
	mywindow.document.write('<html><head><title>' + title + '</title>');
	mywindow.document.write('<link rel="stylesheet" href="../css/style.bundle.rtl.css">');
	mywindow.document.write('</head><body dir=\'rtl\'>');
	mywindow.document.write('<h1>' + title + '</h1>');
	mywindow.document.write($(element).html());
	mywindow.document.write('</body></html>');
	mywindow.document.close(); // necessary for IE >= 10
	mywindow.focus(); // necessary for IE >= 10*/
	mywindow.print();
	mywindow.close();
	$(printBtn).prop("disabled", false);
	return true;
}
