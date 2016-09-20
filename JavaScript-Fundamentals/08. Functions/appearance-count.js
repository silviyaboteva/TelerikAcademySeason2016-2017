function solve(args) {
    var n = args[0].split('\n'),
        numbersLength = n[0],
        numbers = n[1].split(' ').map(Number),
        x = n[2];
        
        console.log(CountAppearance(numbers, numbersLength, x));
        
        function CountAppearance(numbers, length, x) {
            var counter = 0,
                i;
            
            for(i = 0; i < length; i += 1) {
                if(numbers[i] == x) {
                    counter +=1;
                }
            }
            return counter;
        }
}

solve(['8',
    '28 6 21 6 -7856 73 73 -56',
    '73'
])