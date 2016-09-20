function solve(args) {
    var number = +args[0];
    if((number % 5 === 0) && (number % 7 === 0)) {
        var saveNumber = number;
        console.log("true " + saveNumber);
    } else {
        console.log("false " + number);
    } 
}