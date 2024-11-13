window.sweetAlert = function (type, message) {
    if (type == "success") {
        Swal.fire({
            title: "The Internet?",
            text: message,
            icon: "success"
        });
    }
    if (type == "error") {
        Swal.fire({
            title: "The Internet?",
            text: message,
            icon: "error"
        });
    }
}
window.showToastr = function (type, message) {
    if (type == "success") {
        toastr.success(message);
    }
    if (type == "error") {
        toastr.error(message);
    }
}
