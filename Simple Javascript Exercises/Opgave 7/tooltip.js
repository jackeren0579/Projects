let setUpToolTip = function () {
    let toolTip = '',
        toolTipDiv = document.querySelector('.div-tooltip'),
        toolTipElements = document.getElementsByClassName('hover-show');

    let displayToolTip = function (e, obj) {
        toolTip = obj.dataset.tooltip;
        toolTipDiv.innerHTML = toolTip;
        toolTipDiv.style.top = e.pageY + 'px';
        toolTipDiv.style.left = e.pageX + 'px';
        toolTipDiv.style.opacity = 1;
        // fadeIn(toolTopDiv);
    };

    // let fadeAway = function (element) {
    //     let opa = 1; //initial opacity value
    //     let timer = setInterval(function(){
    //         if(opa <= 0.1){
    //             clearInterval(timer);
    //             element.style.opacity = 0;
    //         }
    //         element.style.opacity = opa
    //         opa -= opa * 0.1;
    //     }, 10);
    // };

    // let fadeIn = function(element) {
    //     let opa = 0.1; //initial opacity value
    //     let timer = setInterval(function(){
    //         if(opa >= 1){
    //             clearInterval(timer);
    //         }
    //         element.style.opacity = opa;
    //         opa += opa * 0.1;
    //     }, 10);
    // };

    for (i = 0; i < toolTipElements.length; i++) {
        toolTipElements[i].addEventListener('mouseenter', function (e) {
            displayToolTip(e, this);
        });
        toolTipElements[i].addEventListener('mouseleave', function (e) {
            toolTipDiv.style.opacity = 0;
            // fadeAway(toolTipDiv);
        });
    };
};

setUpToolTip();