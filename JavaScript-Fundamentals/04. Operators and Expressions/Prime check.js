 function solve(args) {
     var number = +args[0];
         isPrime = true;
         if(number > 1 && number <= 100) {
            for (var i = 2; i <= Math.sqrt(number); i+=1)
            {
                if (number % i === 0)
                {
                    isPrime = false;
                    break;
                }
            }
            console.log(isPrime);
         } else {
             console.log("false");
         }
 }