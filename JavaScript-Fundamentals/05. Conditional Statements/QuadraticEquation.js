function solve(args) {
    var a = +args[0];
        b = +args[1];
        c = +args[2];
        d = Math.pow(b, 2) - 4*a*c;
        x1 = 0;
        x2 = 0;
   if(d>0) {
     x1 = (-b - Math.sqrt(d))/(2*a);
     x2 = (-b + Math.sqrt(d))/(2*a);
     console.log("x1=" + x1.toFixed(2) + '; ' + "x2=" + x2.toFixed(2))  
   }
   else if (d===0) {
       x2 = (-b)/(2*a);
       x1 = x2;
        console.log("x1=x2=" + x1.toFixed(2));
   }
   else {
       console.log("no real roots");
   }
}

var str = ['8', '2', '1'];
solve(str);