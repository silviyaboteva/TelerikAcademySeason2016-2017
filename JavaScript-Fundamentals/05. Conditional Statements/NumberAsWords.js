function solve(args) {
    function capitalizeFirstLetter(string) {
            var str = string + '',
                strToRetun = str[0].toUpperCase() + str.substr(1, str.length);
            console.log(strToRetun);
        }
        
    var wholeNumber = +args,
        numbersToWordsOnes = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"],
        fromElevenToNineteen = ["eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"],
        numbersToWordsTens = ["ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"],
        numbersToWordsHundreds = ["one hundred", "two hundred", "three hundred", "four hundred", "five hundred", "six hundred", "seven hundred", "eight hundred", "nine hundred"],
        ones,
        tens,
        hundreds,
        number;

    number = wholeNumber;
    ones = number % 10;
    number /= 10;
    tens = Math.floor(number) % 10;
    number /= 10;
    hundreds = Math.floor(number) % 10;


    if (hundreds === 0 && tens === 0)
    {
        console.logcapitalizeFirstLetter(numbersToWordsOnes[ones]);
    }
    else if (wholeNumber > 10 && wholeNumber < 20) 
    {
        console.log(capitalizeFirstLetter(fromElevenToNineteen[ones - 1]));
    }
    else if (hundreds === 0 && tens !== 0 && ones === 0)
    {
        console.log(capitalizeFirstLetter(numbersToWordsTens[tens - 1]));
    }
    else if (hundreds !== 0 && tens === 0 && ones === 0)
    {
        console.log(capitalizeFirstLetter(numbersToWordsHundreds[hundreds - 1]));
    }
    else if (hundreds === 0 && tens > 1 && ones !== 0) 
    {
        console.log(capitalizeFirstLetter(numbersToWordsTens[tens - 1] + " " + numbersToWordsOnes[ones]));
    }
    else if (hundreds > 0 && tens !== 0 && ones === 0)
    {
        console.log(capitalizeFirstLetter(numbersToWordsHundreds[hundreds - 1] + " and " + numbersToWordsTens[tens - 1]));
    }
    else if (hundreds !== 0 && tens === 1 && ones !== 0)
    {
        console.log(capitalizeFirstLetter(numbersToWordsHundreds[hundreds - 1] + " and " + fromElevenToNineteen[ones - 1]));
    }
    else if (hundreds !== 0 && tens > 1 && ones !== 0)
    {
        console.log(capitalizeFirstLetter(numbersToWordsHundreds[hundreds - 1] + " and " + numbersToWordsTens[tens - 1] + " " + numbersToWordsOnes[ones]));
    }
    else if (hundreds !== 0 && tens === 0 && ones !== 0)
    {
        console.log(capitalizeFirstLetter(numbersToWordsHundreds[hundreds - 1] + " and " + numbersToWordsOnes[ones]));
    }
}

var str = ["987"];
solve(str);