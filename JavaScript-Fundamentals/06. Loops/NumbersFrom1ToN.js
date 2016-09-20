function solve(args) {
    var number = +args;
        output = '';
    
    for (var i = 1; i <= number; i+=1) {
       output+= i + ' ';
    }
    console.log(output);
}