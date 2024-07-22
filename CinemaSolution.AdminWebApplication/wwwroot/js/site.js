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

// Get all elements with class "collapsible"
var collapsibleElements = document.querySelectorAll('.collapsible');

// Create arrays to store the child elements
var dropdownBtnElements = [];
var navCollapsibleBtnElements = [];

// Loop through each collapsible parent element
collapsibleElements.forEach(function (collapsible) {
    // Get all dropdown elements of the current collapsible parent
    var dropdownBtn = collapsible.querySelectorAll('.dropdown-btn');

    // Convert the NodeList to an array and add it to the dropdownBtnElements array
    Array.from(dropdownBtn).forEach(function (btn) {
        dropdownBtnElements.push(btn);
    });

    // Get all navCollapsible elements of the current collapsible parent
    var navCollapsibleBtn = collapsible.querySelectorAll('.nav');

    // Convert the NodeList to an array and add it to the navCollapsibleBtnElements array
    Array.from(navCollapsibleBtn).forEach(function (btn) {
        navCollapsibleBtnElements.push(btn);
    });
});

// Now, dropdownBtnElements and navCollapsibleBtnElements contain the elements with parent class "collapsible"
// console.log(dropdownBtnElements);
// console.log(navCollapsibleBtnElements);

dropdownBtnElements.forEach(function (item) {
    item.addEventListener('click', function () {
        var correspondingNavCollapsible = item.nextElementSibling; // Assuming it's a sibling
        if (!correspondingNavCollapsible) return; // Stop if there is no sibling
        else if (correspondingNavCollapsible.classList.contains('nav-show')) {
            correspondingNavCollapsible.classList.remove('nav-show');
        }
        else {
            // Remove the "nav-show" class from all navCollapsibleBtnElements
            navCollapsibleBtnElements.forEach(function (btn) {
                btn.classList.remove('nav-show');
            });

            // Add the "nav-show" class to the corresponding navCollapsible element
            if (correspondingNavCollapsible.classList.contains('nav')) {
                correspondingNavCollapsible.classList.add('nav-show');
            }
        }
    });
});