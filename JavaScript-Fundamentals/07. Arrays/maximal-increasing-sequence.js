function solve(args) {
      var array = args[0].split('\n').map(Number),
            currentSequence = 1,
            bestSequence = 1,
            length = array.length,
            i;
            
      for(i = 0; i < length; i += 1) {
          if(array[i-1] < array[i]) {
              currentSequence += 1;
          } else {
              if(currentSequence > bestSequence) {
                  bestSequence = currentSequence;
              }
              
              currentSequence = 1;
          } 
      }
      console.log(bestSequence);
}

solve(['8', '7', '3', '2', '3', '4', '2', '2', '4']);