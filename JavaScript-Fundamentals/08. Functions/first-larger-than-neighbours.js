function solve(args) {
    var input = args[0].split('\n'),
        numbersLength = input[0],
        numbers = input[1].split(' ').map(Number);
        
        console.log(IndexOfFirstLargerNeighbour(numbers, numbersLength));
        
    function IndexOfFirstLargerNeighbour(array, arrayLength) {
        var index = 0,
            i;
            
            for(i = 1; i < arrayLength; i += 1) {
                if(array[i] > array[i-1] && array[i] > array[i+1]) {
                    index = i;
                    break;
                } else {
                    index = -1;
                }
            }
        return index;
    }
}

solve(['6\n-26 -25 -28 31 2 27'])