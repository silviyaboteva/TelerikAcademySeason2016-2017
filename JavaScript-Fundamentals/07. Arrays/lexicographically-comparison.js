function solve(args) {

 var input = args[0].split("\n"),
    firstArray = input[0],
    secondArray = input[1];

    if (firstArray > secondArray) {
        console.log('>');
    }
    else if(firstArray < secondArray) {
        console.log('<');
    }
    else {
        console.log('=');
    }
}
solve("hello", "hallo");
