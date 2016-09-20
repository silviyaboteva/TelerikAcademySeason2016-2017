function solve(args) {
    var array = [],
        min,
        max,
        sum = 0,
        avg;

    for (var i = 0; i < args.length; i += 1) {
        array.push(+args[i]);
    }
    
    min = Math.min.apply(null, array);
    max = Math.max.apply(null, array);
    
    for (var j = 0; j < array.length; j += 1) {
        sum += array[j];
    } 
    
    avg = sum / array.length;
   
    console.log('min='+min.toFixed(2));
    console.log('max='+max.toFixed(2));
    console.log('sum='+sum.toFixed(2));
    console.log('avg='+avg.toFixed(2));
}