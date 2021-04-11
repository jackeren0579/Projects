
// First attempt
// Remove surrounding in order to use code
function remove() {
    // var output = document.getElementById('outputer');
    // var input = document.getElementById('inputer');

    // input.addEventListener('keyup', keyPressed);


    // function keyPressed(e) {
    //     var text = input.value;
    //     var message = 'nothing yet';

    //     if (inputSlightlyOkay(text)) {
    //         if (text.length > 7)
    //             message = 'Close, but no cigar.';
    //         else if (text.length == 7)
    //             message = 'Length is okay';
    //         else if (text.length > 0)
    //             message = 'Okay, but ur cigar too short';
    //         else {
    //             var key;

    //             if (window.event)
    //                 key = window.event.keyCode;
    //             else if (e)
    //                 key = e.keyCode;

    //             if (48 <= key && key <= 90)
    //                 input.value = input.value.substring(0,
    //                     input.value.length - 1);

    //             if (text.length > 1)
    //                 message = 'Error om format';

    //         }
    //         output.innerHTML = message;
    //     }
    // }

    // function inputSlightlyOkay(text) {
    //     return verifyLetters(text, 0, 2) &&
    //         verifyDigits(text, 2, 7);
    // }

    // function verifyLetters(text, start, end) {
    //     for (var i = start; i < end && i < text.length; i++)
    //         if (!('A' <= text[i] && text[i] <= 'Z' || 'a' <= text[i] && text[i] <= 'z'))
    //             return false;

    //     return true;
    // }

    // function verifyDigits(text, start, end) {
    //     for (var i = start; i < end && i < text.length; i++)
    //         if (!('0' <= text[i] && text[i] <= '9'))
    //             return false;

    //     return true;
    // }

    // window.addEventListener('load', changer);
}

function validation() {
    var tf = document.getElementById('textfield').value;
    console.log(tf);
    var resp = document.getElementById('response');

    var reg = tf.length <= 2 ? '[a-z|A-Z]{1,2}$' : '^[a-z|A-Z]{2}[0-9]{1-5}$';
    tf.length == 0 ? resp.innerHTML = '-' : null;

    if (new RegExp(reg).test(tf)) {
        resp.innerHTML = tf.length == 7 ? 'OK' : 'Too fucking short';
    } else {
        document.getElementById('textfield').value = tf.slice(0, -1);
    }
} //addEventListener('input', validation);

$(function () {
    let $input = $('#inputField');

    let $output = $('#outputField');

    $($input).on('input', function () {
        checkInput(this);
    });

    function checkInput(input) {
        let inputContainer = $(input).val()
        let lastLetter = inputContainer.substring(inputContainer.length, inputContainer.length - 1);
        if ((lastLetter.match(/^[A-Za-z]+$/) && inputContainer.length <= 2)) {
            $($output).text("Okay, but too short");
        } else if (lastLetter.match(/^[0-9]+$/) && inputContainer.length < 7 && inputContainer.length >= 2) {
            $($output).text("Okay, but too short"); //Brugt til at 'reset' output hvis man intaster forkert i delen med numre
        } else if (lastLetter.match(/^[0-9]+$/) && inputContainer.length == 7) {
            $($output).text("Okay");
        } else if (inputContainer.length > 7) {
            $($output).text("Okay, but too long");
        } else {
            $input.val(inputContainer.slice(0, -1));
            $($output).text("Error in formatting");
        }
    }
});