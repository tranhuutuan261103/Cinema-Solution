// Show model for delete user
function showModelUserDelete(userId) {
    var modalDialogUserId = document.getElementById('modal-dialog-user--id');
    modalDialogUserId.innerHTML = "Comfirm delete " + userId + "?";
    var modalDialogUserFormAction = document.getElementById('modal-dialog-user--form-action');
    modalDialogUserFormAction.action = `/users/${userId}/delete`;
    var modalDialogUserDelete = document.getElementById('modal-dialog-user--delete');
    modalDialogUserDelete.classList.add('modal-dialog--active');
}