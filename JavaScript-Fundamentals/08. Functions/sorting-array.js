function solve(args) {
    var  arrayLength = +args[0],
       array = args[1].split(' ').map(Number),
       sortedArray;
       
   sortedArray = array.sort(function (x, y) {
        if(x > y) {
            return 1;
        } else {
            return -1;
        } 
    });
    
    return sortedArray.join(' ');
}

console.log(solve(['6\n3 4 1 5 2 6']));