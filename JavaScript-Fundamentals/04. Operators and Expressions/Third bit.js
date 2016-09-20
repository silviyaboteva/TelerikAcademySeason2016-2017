function solve(args) {
    
    var a = +args[0];

var b = (a >>> 3).toString(2) + "";
console.log(b[b.length - 1]);
}