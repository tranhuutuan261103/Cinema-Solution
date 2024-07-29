// Show model for delete movie
function showModelMovieDelete(movieId) {
    var modalDialogMovieId = document.getElementById('modal-dialog-movie--id');
    modalDialogMovieId.innerHTML = "Comfirm delete " + movieId + "?";
    var modalDialogMovieFormAction = document.getElementById('modal-dialog-movie--form-action');
    modalDialogMovieFormAction.action = `/movies/${movieId}/delete`;
    var modalDialogMovieDelete = document.getElementById('modal-dialog-movie--delete');
    modalDialogMovieDelete.classList.add('modal-dialog--active');
}