using System.Linq;
{
    
}
// See https://aka.ms/new-console-template for more information
Console.WriteLine(myAtoi("   -12334"));



int myAtoi(string s){
	Dictionary<char, int> charToInt = new();
	charToInt.Add('0',0);
	charToInt.Add('1',1);
	charToInt.Add('2',2);
	charToInt.Add('3',3);
	charToInt.Add('4',4);
	charToInt.Add('5',5);
	charToInt.Add('6',6);
	charToInt.Add('7',7);
	charToInt.Add('8',8);
	charToInt.Add('9',9);
	s = s.Trim();
	//
		//get the sign if there is one if not assume that it is positive
	bool isPositive = true;
	int start = 0;
	if(s[0] == '-' || s[0] == '+'){
		start =1;
		isPositive = s[0] != '-';
	}
	
	List<int> listOfInts = new();

	// Start going the string starting at the left 
	for(int i = start;i < s.Length; i++){

		if(charToInt.ContainsKey(s[i])){
			listOfInts.Add(charToInt[s[i]]);
		}else{
			break;
		}
	}

	//listOfInts.ForEach (i=> Console.WriteLine(i));

	int result = 0;
	// now calculate
	int place = 0;
	for(int i = listOfInts.Count - 1; i>=0; i--){
		
		result += listOfInts[i] *(int)Math.Pow(10,place) ;
		place ++;
	}
	if(!isPositive){
		result = result * -1;

	}
	// if it is an int save it to the list
	// if it is a character stop
	//
	// go through the built array starting at the right and building the number 
	// timsing it by it's place
	return result;	
}
