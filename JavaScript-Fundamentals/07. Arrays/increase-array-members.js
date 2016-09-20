function solve(args) {
    var n = +args[0],
        array = [],
        index = 0;
        
        for (index = 0; index < n; index+=1) {
            array[index] = index*5;
            console.log(array[index]);
        }
}

solve('5');