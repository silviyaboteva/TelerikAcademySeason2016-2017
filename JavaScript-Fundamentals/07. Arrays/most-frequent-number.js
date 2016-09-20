function solve(args) {
    var array = args[0].split('\n').map(Number),
        counter = 1,
        times = 1,
        bestNum = 1,
        i;
        
        array.sort();
        for(i = 1; i < array.length - 1; i += 1) {
            if(array[i] === array[i+1]) {
                counter+=1;
                if(counter > times) {
                    times = counter;
                    bestNum = array[i];
                }
            } else {
                counter = 1;
            }
        }
    
    console.log(bestNum + " (" + times + " times)");
}

solve(['13', '4', '1', '1', '4', '2', '3', '4', '4', '1', '2', '4', '9', '3']);