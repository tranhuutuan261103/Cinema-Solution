// Show model for delete user
function showModelUserDelete(userId) {
    var modalDialogUserId = document.getElementById('modal-dialog-user--id');
    modalDialogUserId.innerHTML = "Comfirm delete " + userId + "?";
    var modalDialogUserFormAction = document.getElementById('modal-dialog-user--form-action');
    modalDialogUserFormAction.action = `/users/${userId}/delete`;
    var modalDialogUserDelete = document.getElementById('modal-dialog-user--delete');
    modalDialogUserDelete.classList.add('modal-dialog--active');
}

// Show model for enable user
function showModelUserEnable(userId) {
    var modalDialogUserId = document.getElementById('modal-dialog-enable-user--id');
    modalDialogUserId.innerHTML = "Comfirm enable " + userId + "?";
    var modalDialogUserFormAction = document.getElementById('modal-dialog-enable-user--form-action');
    modalDialogUserFormAction.action = `/users/${userId}/enable`;
    var modalDialogUserEnable = document.getElementById('modal-dialog-user--enable');
    modalDialogUserEnable.classList.add('modal-dialog--active');
}