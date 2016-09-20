function solve(args) {
    var input = +args[0];
    console.log(LastDigitAsWord(input));
        
    function LastDigitAsWord(number) {
        switch(number % 10) {
            case 1: return 'one'; break;
            case 2: return 'two'; break;
            case 3: return 'three'; break;
            case 4: return 'four'; break;
            case 5: return 'five'; break;
            case 6: return 'six'; break;
            case 7: return 'seven'; break;
            case 8: return 'eight'; break;
            case 9: return 'nine'; break;
            default: return 'zero'; break;
        }
    }
}

solve(['42']);