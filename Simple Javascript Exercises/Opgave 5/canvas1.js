//Program code --> https://www.youtube.com/watch?v=EO6OkltgudE&list=PLpPnRKq7eNW3We9VdCfx9fprhqXHwTPXL&index=3
//JS OOP --> https://www.youtube.com/watch?v=vDJpGenyHaA&t=32s

var canvas = document.querySelector('canvas');

canvas.width = window.innerWidth;
canvas.height = window.innerHeight;

var cnxt = canvas.getContext('2d');

//Random firkanter
// cnxt.fillStyle = 'blue';
// cnxt.fillRect(100, 100, 100, 100);
// cnxt.fillRect(400, 100, 100, 100);
// cnxt.fillStyle = 'pink';
// cnxt.fillRect(300, 300, 100, 100);

//Random linjer
// cnxt.beginPath();
// cnxt.moveTo(50, 350);
// cnxt.lineTo(400, 100);
// cnxt.lineTo(300, 500);
// cnxt.strokeStyle = 'yellow';
// cnxt.stroke();

//Random cirkler
// cnxt.beginPath();
// cnxt.arc(300, 300, 30, 0, Math.PI * 2, false);
// cnxt.strokeStyle = 'green';
// cnxt.stroke();
// for (var i = 0; i <= 50; i++) {
//     var x = Math.random() * window.innerWidth;
//     var y = Math.random() * window.innerHeight;

//     cnxt.beginPath();
//     cnxt.arc(y, x, 30, 0, Math.PI * 2, false);
//     cnxt.strokeStyle = 'green';
//     cnxt.stroke();
// }

var mouse = {
    x: undefined,
    y: undefined
}

maxRadius = 40;
// minRadius = 4;

var colorArray = [
    '#2C3E50',
    '#E74C3C',
    '#ECF0F1',
    '#3498DB',
    '#2980B9'
];

window.addEventListener('mousemove', function (event) {
    mouse.x = event.x;
    mouse.y = event.y;
});

window.addEventListener('resize', function () {
    canvas.width = window.innerWidth;
    canvas.height = window.innerHeight;

    init();
})

function Circle(x, y, dx, dy, radius) {
    this.x = x;
    this.y = y;
    this.dx = dx;
    this.dy = dy;
    this.radius = radius;
    this.minRadius = radius;
    this.color = colorArray[Math.floor(Math.random() * colorArray.length)];

    this.draw = function () {
        cnxt.beginPath();
        cnxt.arc(this.x, this.y, this.radius, 0, Math.PI * 2, false);
        cnxt.fillStyle = this.color;
        cnxt.fill();
    }

    this.update = function () {
        if (this.x + this.radius > innerWidth ||
            this.x - this.radius < 0) {
            this.dx = -this.dx;
        }

        if (this.y + this.radius > innerHeight ||
            this.y - this.radius < 0) {
            this.dy = -this.dy;
        }
        this.x += this.dx;
        this.y += this.dy;

        //Interactivity
        if (mouse.x - this.x < 50 && mouse.x - this.x > -50 &&
            mouse.y - this.y < 50 && mouse.y - this.y > -50) {

            if (this.radius < maxRadius) {
                this.radius += 1;
            }

        } else if (this.radius > this.minRadius) {
            this.radius -= 1;
        }

        this.draw();
    }
}

var circleArray = [];

function init() {
    circleArray = [];

    for (var i = 0; i < 500; i++) {
        var radius = Math.random() * 7 + 1;
        var x = Math.random() * (innerWidth - radius * 2) + radius;
        var y = Math.random() * (innerHeight - radius * 2) + radius;
        var dx = (Math.random() - 0.5) * 3;
        var dy = (Math.random() - 0.5) * 3;

        circleArray.push(new Circle(x, y, dx, dy, radius));
    }
}

function animate() {
    requestAnimationFrame(animate);
    cnxt.clearRect(0, 0, innerWidth, innerHeight);

    for (var i = 0; i < circleArray.length; i++) {
        circleArray[i].update();
    }
}

init();
animate();