function solve(args) {
    var a = +args[0];
        b = +args[1];
        perimeter = 2*(a+b);
        area = a*b;
    console.log(area.toFixed(2) + " " + perimeter.toFixed(2));
}