function solve(args) {
    var a = +args[0];
        b = +args[1];
        c = +args[2];
    
    if (a>=b && b>=c) {
        console.log(a + " " + b + " " + c);
    }
    else if (a>=c && c>=b) {
        console.log(a + " " + c + " " + b);
    } 
    else if (c>=a && a>=b){
        console.log(c + " " + a + " " + b);
    } 
    else if (c>=b && b>=a) {
        console.log(c + " " + b + " " + a);
    } 
    else if (b>=a && a>=c) {
        console.log(b + " " + a + " " + c);
    }
    else if(b>=c && c>=a) {
        console.log(b + " " + c + " " + a);
    } 
}

var str = ['8', '1', '9'];
solve(str);