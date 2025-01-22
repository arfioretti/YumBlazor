 function ShowConfirmationModal() {
    bootstrap.Modal.getOrCreateInstance(document.getElementById('bsConfirmationModal')).show();
}
function HideConfirmationModal() {
    bootstrap.Modal.getInstance(document.getElementById('bsConfirmationModal')).hide();
}