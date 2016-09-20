function solve(args) {
    var numbers = args[0].split(' ').map(Number);
        number1 = numbers[0],
        number2 = numbers[1],
        number3 = numbers[2],
        maxNum = 0;
        
    function GetMax(a, b) {
        if(a>=b) {
            return a;
        } else {
            return b;
        }
    }
    maxNum = GetMax(number1, GetMax(number2, number3));
    console.log(maxNum);
}

solve(['8 9 5']);