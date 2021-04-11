var numberOfMoves = 0;


function start_game() {
    numberOfMoves = 0;

    var position = new Array();
    while (position.length < 9) {
        var positionN = Math.round(Math.random() * 100);
        if ((positionN == 11) || (positionN == 12) || (positionN == 13) || (positionN == 21) || (positionN == 22) || (positionN == 23) || (positionN == 31) || (positionN == 32) || (positionN == 33)) {
            if (!position.includes(positionN)) {

                position[position.length] = positionN;
            }
        }
    }

    document.getElementById('p11').textContent = position[0];
    document.getElementById('p11').style.background = 'url(' + position[0] + '.jpg)';

    document.getElementById('p12').textContent = position[1];
    document.getElementById('p12').style.background = 'url(' + position[1] + '.jpg)';

    document.getElementById('p13').textContent = position[2];
    document.getElementById('p13').style.background = 'url(' + position[2] + '.jpg)';

    document.getElementById('p21').textContent = position[3];
    document.getElementById('p21').style.background = 'url(' + position[3] + '.jpg)';

    document.getElementById('p22').textContent = position[4];
    document.getElementById('p22').style.background = 'url(' + position[4] + '.jpg)';

    document.getElementById('p23').textContent = position[5];
    document.getElementById('p23').style.background = 'url(' + position[5] + '.jpg)';

    document.getElementById('p31').textContent = position[6];
    document.getElementById('p31').style.background = 'url(' + position[6] + '.jpg)';

    document.getElementById('p32').textContent = position[7];
    document.getElementById('p32').style.background = 'url(' + position[7] + '.jpg)';

    document.getElementById('p33').textContent = position[8];
    document.getElementById('p33').style.background = 'url(' + position[8] + '.jpg)';

    document.getElementById('gamer_grid').style.visibility = 'visible';
    document.getElementById('moves').textContent = 'Moves: 0';
    document.getElementById('launch').textContent = 'Restart Game'
}

function pictureTrigger(firstCheck, secondCheck) {
    var tempValue = document.getElementById(firstCheck).textContent;
    document.getElementById(firstCheck).textContent = document.getElementById(secondCheck).textContent;
    document.getElementById(secondCheck).textContent = tempValue;

    document.getElementById(secondCheck).style.background = 'url(' + document.getElementById(secondCheck).textContent + '.jpg)';
    document.getElementById(firstCheck).style.background = 'url(' + document.getElementById(firstCheck).textContent + '.jpg)';
    numberOfMoves++;
    document.getElementById('moves').textContent = "Moves: " + numberOfMoves;
}

function winnerCheck() {
    var cell1 = document.getElementById('p11').textContent;
    var cell2 = document.getElementById('p12').textContent;
    var cell3 = document.getElementById('p13').textContent;
    var cell4 = document.getElementById('p21').textContent;
    var cell5 = document.getElementById('p22').textContent;
    var cell6 = document.getElementById('p23').textContent;
    var cell7 = document.getElementById('p31').textContent;
    var cell8 = document.getElementById('p32').textContent;
    var cell9 = document.getElementById('p33').textContent;

    if (cell1 == '11' && cell2 == '12' && cell3 == '13' && cell4 == '21' && cell5 == '22' && cell6 == '23' && cell7 == '31' && cell8 == '32' && cell9 == '33') {
        
        return true;
    } else return false;
}

function resetImages(){
    document.getElementById('p11').style.visibility = 'visible';
    document.getElementById('p12').style.visibility = 'visible';
    document.getElementById('p13').style.visibility = 'visible';
    document.getElementById('p21').style.visibility = 'visible';
    document.getElementById('p22').style.visibility = 'visible';
    document.getElementById('p23').style.visibility = 'visible';
    document.getElementById('p31').style.visibility = 'visible';
    document.getElementById('p32').style.visibility = 'visible';
    document.getElementById('p33').style.visibility = 'visible';

    document.getElementById('launch').textContent = 'Start Game';
}

function backToNormal() {
    document.getElementById('gamer_grid').style.background = 'url("winnerpic.jpg")';

    setTimeout(resetImages, 5000);
}

function switching(cell) {
    if (document.getElementById(cell).textContent != '11') {
        switch (cell) {
            case 'p11':
                if (document.getElementById('p12').textContent == '11') {
                    pictureTrigger('p12', 'p11');
                }
                if (document.getElementById('p21').textContent == '11') {
                    pictureTrigger('p21', 'p11');
                }

                if (winnerCheck()) {
                    setTimeout(function () {
                        document.getElementById('p11').style.visibility = 'hidden';
                        document.getElementById('p12').style.visibility = 'hidden';
                        document.getElementById('p13').style.visibility = 'hidden';
                        document.getElementById('p21').style.visibility = 'hidden';
                        document.getElementById('p22').style.visibility = 'hidden';
                        document.getElementById('p23').style.visibility = 'hidden';
                        document.getElementById('p31').style.visibility = 'hidden';
                        document.getElementById('p32').style.visibility = 'hidden';
                        document.getElementById('p33').style.visibility = 'hidden';
                        document.getElementById('gamer_grid').style.background = 'url("winnergifer.gif")';

                        alert('Congratulations, you have managed to win this extremely hard slider puzzle, only using ' + numberOfMoves + ' moves!');

                        setTimeout(backToNormal, 5000);
                    }, 500)
                }
                break;
            case 'p12':
                if (document.getElementById('p11').textContent == '11') {
                    pictureTrigger('p11', 'p12');
                }
                if (document.getElementById('p22').textContent == '11') {
                    pictureTrigger('p22', 'p12');
                }
                if (document.getElementById('p13').textContent == '11') {
                    pictureTrigger('p13', 'p12');
                }
                break;
            case 'p13':
                if (document.getElementById('p12').textContent == '11') {
                    pictureTrigger('p12', 'p13');
                }
                if (document.getElementById('p23').textContent == '11') {
                    pictureTrigger('p23', 'p13');
                }
                break;
            case 'p21':
                if (document.getElementById('p11').textContent == '11') {
                    pictureTrigger('p11', 'p21');
                }
                if (document.getElementById('p22').textContent == '11') {
                    pictureTrigger('p22', 'p21');
                }
                if (document.getElementById('p31').textContent == '11') {
                    pictureTrigger('p31', 'p21');
                }
                break;
            case 'p22':
                if (document.getElementById('p12').textContent == '11') {
                    pictureTrigger('p12', 'p22');
                }
                if (document.getElementById('p23').textContent == '11') {
                    pictureTrigger('p23', 'p22');
                }
                if (document.getElementById('p32').textContent == '11') {
                    pictureTrigger('p32', 'p22');
                }
                break;
            case 'p23':
                if (document.getElementById('p13').textContent == '11') {
                    pictureTrigger('p13', 'p23');
                }
                if (document.getElementById('p22').textContent == '11') {
                    pictureTrigger('p22', 'p23');
                }
                if (document.getElementById('p33').textContent == '11') {
                    pictureTrigger('p33', 'p23');
                }
                break;
            case 'p31':
                if (document.getElementById('p21').textContent == '11') {
                    pictureTrigger('p21', 'p31');
                }
                if (document.getElementById('p32').textContent == '11') {
                    pictureTrigger('p32', 'p31');
                }
                break;
            case 'p32':
                if (document.getElementById('p31').textContent == '11') {
                    pictureTrigger('p31', 'p32');
                }
                if (document.getElementById('p22').textContent == '11') {
                    pictureTrigger('p22', 'p32');
                }
                if (document.getElementById('p33').textContent == '11') {
                    pictureTrigger('p33', 'p32');
                }
                break;
            case 'p33':
                if (document.getElementById('p32').textContent == '11') {
                    pictureTrigger('p32', 'p33');
                }
                if (document.getElementById('p23').textContent == '11') {
                    pictureTrigger('p23', 'p33');
                }
                break;

        }
    }
}