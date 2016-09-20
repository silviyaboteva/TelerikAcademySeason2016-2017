function solve(args) {
    var a = +args[0];
        b = +args[1];
        c = +args[2];
        d = +args[3];
        e = +args[4];
        
   return Math.max(a, Math.max(b, Math.max(c, Math.max(d, e))));
}

var str = ['8', '2', '1', "15", "35"];
solve(str);