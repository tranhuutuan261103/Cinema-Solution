// Show model for delete category
function showModelCategoryDelete(categoryId) {
    var modalDialogCategoryId = document.getElementById('modal-dialog-category--id');
    modalDialogCategoryId.innerHTML = "Comfirm delete " + categoryId + "?";
    var modalDialogCategoryHref = document.getElementById('modal-dialog-category--href');
    modalDialogCategoryHref.href = `/categories/${categoryId}/delete`;
    var modalDialogCategoryDelete = document.getElementById('modal-dialog-category--delete');
    modalDialogCategoryDelete.classList.add('modal-dialog--active');
}