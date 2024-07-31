// Show model for delete Cinema
function showModelCinemaDelete(cinemaId) {
    var modalDialogCinemaId = document.getElementById('modal-dialog-cinema--id');
    modalDialogCinemaId.innerHTML = "Comfirm delete " + cinemaId + "?";
    var modalDialogCinemaFormAction = document.getElementById('modal-dialog-cinema--form-action');
    modalDialogCinemaFormAction.action = `/cinemas/${cinemaId}/delete`;
    var modalDialogCinemaDelete = document.getElementById('modal-dialog-cinema--delete');
    modalDialogCinemaDelete.classList.add('modal-dialog--active');
}

function updateSelection(provinceId) {
    var provinceSelectionInput = document.getElementById('cinema-province');
    provinceSelectionInput.value = provinceId;
}