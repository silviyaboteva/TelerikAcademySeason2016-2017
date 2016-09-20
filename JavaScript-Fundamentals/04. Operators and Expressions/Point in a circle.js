 function solve(args) {
    var x = +args[0];
        y = +args[1];
        distance = Math.sqrt(Math.pow(x, 2) + Math.pow(y, 2));
    if(x <= 2 && x >= -2 && y <= 2 && y >= -2) {
        console.log("yes " + distance.toFixed(2));
    } else {
        console.log("no " + distance.toFixed(2));
    }
}