// Show model for delete product
function showModelProductComboDelete(productId) {
    var modalDialogProductId = document.getElementById('modal-dialog-product--id');
    modalDialogProductId.innerHTML = "Comfirm delete " + productId + "?";
    var modalDialogProductFormAction = document.getElementById('modal-dialog-product--form-action');
    modalDialogProductFormAction.action = `/productcombos/${productId}/delete`;
    var modalDialogProductDelete = document.getElementById('modal-dialog-product--delete');
    modalDialogProductDelete.classList.add('modal-dialog--active');
}