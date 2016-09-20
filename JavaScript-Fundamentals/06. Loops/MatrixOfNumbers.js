function solve(args) {
    var number = +args[0],
        row,
        col,
        matrix = '';
    for (row = 0; row < number; row+=1) {
        for (col = row + 1; col <= +args[0] + row; col += 1) {
			matrix += col + ' ';
		}
		matrix += '\n';
    }
    console.log(matrix);
}

solve('3')