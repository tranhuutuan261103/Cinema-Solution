var dropdownContainers = document.querySelectorAll(".dropdown");

if (dropdownContainers) {
    dropdownContainers.forEach(function (dropdownContainer) {
        try {
            dropdownContainer.addEventListener('click', function () {
                if (dropdownContainer.classList.contains('dropdown-content-show')) {
                    dropdownContainer.classList.remove('dropdown-content-show');
                }
                else {
                    dropdownContainer.classList.add('dropdown-content-show');
                }
            }
            );

            const dropdownSelected = dropdownContainer.querySelector('.selected');

            const dropdownItems = dropdownContainer.querySelectorAll('.dropdown-content .dropdown-item');

            dropdownItems.forEach(function (dropdownItem) {
                dropdownItem.addEventListener('click', function () {
                    // Lấy nội dung của mục đã chọn
                    const selectedId = dropdownItem.getAttribute("data-id");
                    const selectedValue = dropdownItem.getAttribute("data-value");

                    // Cập nhật nội dung trong thẻ có class "selected"
                    dropdownSelected.setAttribute("data-id", selectedId);
                    dropdownSelected.textContent = selectedValue;
                });
            });
        } catch (error) {
            console.log(error);
        }
    });
}

// Dialog event
var dialog = document.getElementsByClassName("modal-dialog");

var dialogCancelBtn = document.querySelectorAll(".cancel-btn");

if (dialogCancelBtn) {
    dialogCancelBtn.forEach(function (item) {
        try {
            item.addEventListener('click', function () {
                var dialog = item.closest('.modal-dialog');
                dialog.classList.remove('modal-dialog--active');
            }
            );
        } catch (error) {
            console.log(error);
        }
    });
}