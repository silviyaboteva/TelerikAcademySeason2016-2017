function solve(args) {
    var number = +args[0];
        thirdDigit = parseInt((number / 100) % 10) ;
    if(thirdDigit === 7){
        console.log("true");
    } else {
        console.log("false " + thirdDigit);
    }
}