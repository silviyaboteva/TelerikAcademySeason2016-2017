function solve(args) {
    var input = args[0].split('\n'),
        numbersLength = input[0],
        numbers = input[1].split(' ').map(Number);
        
    console.log(CountLargerThanNeighbours(numbers, numbersLength));
        
    function CountLargerThanNeighbours(array, arrayLength) {
        var counter = 0,
            i;
            
        for(i = 1; i < arrayLength; i += 1) {
            if(array[i] > array[i-1] && array[i] > array[i+1]) {
                counter += 1;
            }
        }
        return counter;
    }
}

solve(['6',
'-26 -25 -28 31 2 27'
])