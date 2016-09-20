function solve(args) {
    var a = +args[0];
        b = +args[1];
    if(a>b) {
        console.log(b + " " + a);
    }
    else {
        console.log(a + " " + b);
    }
}

var str = ["100", "63"];
solve(str);