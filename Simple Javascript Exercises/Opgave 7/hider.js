function setHider() {
    elementsToHide = document.getElementsByClassName('hover-hide');
    elementsToHide[0].style.opacity = 0.01;

    for (i = 0; i < elementsToHide.length; i++) {
        elementsToHide[i].addEventListener('mouseenter', function (e) {
            this.style.opacity = 1;
        });
        elementsToHide[i].addEventListener('mouseleave', function (e) {
            this.style.opacity = 0.01;

        });
    };
};
setHider();

// $(function (){
//     $('.hover-hide').mouseenter(function(){
//         $(this).style.opacity = 1;
//     });
//     $('.hover-hide').mouseleave(function(){
//         $(this).style.opacity = 0.01;
//     });
// });