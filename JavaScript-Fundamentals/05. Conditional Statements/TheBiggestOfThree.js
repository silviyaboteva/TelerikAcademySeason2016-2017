function solve(args) {
    var a = +args[0];
        b = +args[1];
        c = +args[2];
    
    console.log(Math.max(a, Math.max(b,c)));
}

var str = ['8', '2', '1'];
solve(str);