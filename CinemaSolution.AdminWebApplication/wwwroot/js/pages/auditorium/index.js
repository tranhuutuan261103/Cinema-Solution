// Show model for delete auditorium
function showModelAuditoriumDelete(cinemaId, auditoriumId) {
    var modalDialogAuditoriumId = document.getElementById('modal-dialog-auditorium--id');
    modalDialogAuditoriumId.innerHTML = "Comfirm delete " + auditoriumId + "?";
    var modalDialogAuditoriumFormAction = document.getElementById('modal-dialog-auditorium--form-action');
    modalDialogAuditoriumFormAction.action = `/cinemas/${cinemaId}/auditoriums/${auditoriumId}/delete`;
    var modalDialogAuditoriumDelete = document.getElementById('modal-dialog-auditorium--delete');
    modalDialogAuditoriumDelete.classList.add('modal-dialog--active');
}