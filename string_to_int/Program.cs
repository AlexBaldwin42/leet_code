// https://leetcode.com/problems/string-to-integer-atoi

using System.Linq;
Console.WriteLine(myAtoi("21474836460"));

int myAtoi(string s)
{
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
	if(s.Length == 0)return 0;

	bool isPositive = true;
	int start = 0;
	if(s[0] == '-' || s[0] == '+'){
		start =1;
		isPositive = s[0] != '-';
	}

	List<int> listOfInts = new();

	// Start going the string starting at the left 
	for(int i = start;i < s.Length; i++)
	{
		if(charToInt.ContainsKey(s[i])){
			listOfInts.Add(charToInt[s[i]]);
		}else{
			break;
		}
	}

	// Now calculate
	int result = 0;
	int place = 0;
	for(int i = listOfInts.Count - 1; i>=0; i--)
	{
		result += (int)(listOfInts[i] *Math.Pow(10,place));
		place ++;

		if(isPositive && result <0){
			// Overflow 
			result =(int) Math.Pow(2,31)-1;
			break;
		}
		if(!isPositive && result < 0){
			// Overflow
			result = (int)Math.Pow(2,31) *-1;
			break;
		}
	}
	if(!isPositive){
		result = result * -1;

	}
	return result;	
}
