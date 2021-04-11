

//Fjern metoden hvis koden skal bruges. Metoden er der kun for at kunne lukke den sammen.
function removeSometime() {
    //Attempt 1
    // function addButton(){
    //     let tfs = document.getElementById('opgave2');

    //     if(tfs.childElementCount < 5) {
    //         let div = document.createElement('div');
    //         let input = document.createElement('input');
    //         input.setAttribute('type', 'text');

    //         div.appendChild(input);
    //         tfs.appendChild(div);
    //     }

    //     function removeButton(){
    //         let tfs = document.getElementById('opgave2');

    //         if(tfs.childElementCount > 0) {
    //             tfs.lastElementChild.remove();
    //         }
    //     }
    // }


    //Attempt 2
    // let divID = document.getElementById('opgave2');
    // let divElements = divID.getElementsByTagName('input');
    // let lessButton = document.getElementById('less');
    // let moreButton = document.getElementById('more');

    // function addMore(){
    //     if(divElements.length < 5) {
    //         let inputDiv = document.createElement('div');
    //         let input = document.createElement('input');
    //         input.type = 'text';
    //         inputDiv.appendChild(input);
    //         inputDiv.appendChild(document.createElement('p'));
    //         divID.appendChild(inputDiv);
    //     }
    // }

    // function makeLess(){
    //     if(divElements > 0) {
    //         var gamer = divElements.length;
    //         divID.removeChild(divElements[gamer-1]);
    //     }
    // }

    // moreButton.addEventListener('click', addMore);
    // lessButton.addEventListener('click', makeLess);
}


//jQuery attempt

$(function () {
    let inputAmount;

    $('#more').click(function () {
        inputAmount = $('#opgave2 input');
        console.log(inputAmount);

        if (inputAmount.length < 5) {
            $('#opgave2').append('<br>').append('<input>').append('<br>');
        }
    });

    $('#less').click(function(){
        inputAmount = $('#opgave2 input');
        console.log(inputAmount);

        if(inputAmount.length > 0){
            $('#opgave2 br:last').remove();
            $('#opgave2 input:last').remove();
            $('#opgave2 br:last').remove();
        }
    });
});