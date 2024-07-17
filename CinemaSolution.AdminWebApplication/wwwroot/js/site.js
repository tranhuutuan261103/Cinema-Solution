// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var userDropdownBtn = document.getElementById('user-dropdown');
var userDropdown = document.getElementById('user-menu-content');

userDropdownBtn.addEventListener('click', function () {
    if (!userDropdown.classList.contains('user-menu-show')) {
        userDropdown.classList.add('user-menu-show');
    }
    else {
        userDropdown.classList.remove('user-menu-show');
    }
});