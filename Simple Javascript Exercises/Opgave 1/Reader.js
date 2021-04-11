function main() {
    // opgave1();
}

// function opgave1() {
//     const divById = document.getElementById('opgave1');
//     var listItems = divById.getElementsByTagName('li');

//     for (var item of listItems) {
//         var itemContent = item.innerHTML;

//         if (itemContent.startsWith('http://')) {
//             item.innerHTML = '<a href="' + itemContent + '">' + itemContent + '</a>';
//         }
//     }
// }

//Opgave 1 med jQuery

//Svar 1
$(function () {
    $("#targets li:contains('http://')").html(function (i, text) {
        return '<a href="' + text + '">' + text + '</a>';
    });
});

//Svar 2
$(function () {
    $('#targets li:contains("http://")').wrapInner(function () {
        return '<a href="' + this.innerText + '"></a>';
    });
});

// $(function () {

//     var elements = $('#targets').children();

//     for (var i = 0; i < elements.length; i++) {
//         var contents = elements[i].innerHTML;
//         console.log(contents)

//         if (contents.startsWith('http://')) {
//             $("ul li:contains('https://')").html().replaceWith('<a href="' + contents + '">' + contents + '</a>');
//         }
//     }
// });

