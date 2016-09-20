function solve(args) {
    var array = [],
        numbers = args[0].split('\n'),
        i, j, min;
    
    for (i = 1; i < numbers.length; i += 1) {
    array.push(+numbers[i]);
    }    
        
    for(i = 0; i < array.length - 1; i += 1) {
        for(j = i + 1; j < array.length; j += 1) {
            if(array[i] > array[j]) {
                min = array[i];
                array[i] = array[j];
                array[j] = min;
            }
        }
    }
    console.log(array.join('\n'));
}

solve(['10', '36', '10', '1', '34', '28', '38', '31', '27', '30', '20']);