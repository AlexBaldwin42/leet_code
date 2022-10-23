// See https://aka.ms/new-console-template for more information
using System;
//Console.WriteLine("Hello, World!");

string s = "PAYPALISHIRING";
//s = "PAYPALISHIRINGdjdjdjjdjdjd";
int numRows = 3;
string output = "";

int lengthOfArrays = s.Length;

char[,] array = new char[numRows,lengthOfArrays];

for(int i = 0; i < numRows; i++){
	for(int j= 0; j< lengthOfArrays; j ++){
		array[i,j]= ' ';
	}}
List<List<char>> lists = new List<List<char>>();
for(int i= 0; i < numRows; i++){
	lists.Add(new List<char>());
}

for(int i =0 ; i < s.Length; i++){
	//int moddedi = i%(numRows+2);
	int periodLength = numRows*2-2;
	int moddedi = i%periodLength;
	int row = 0;
	int col = 0;
	if (moddedi < numRows){
		row = moddedi;
	}else{
		//row = (int)Math.Floor((decimal)i/(decimal)rows);
		row = (numRows - (moddedi%(numRows-1))-1);
	//	Console.WriteLine($"{numRows} - ({moddedi} % {numRows} - 1))-1 ");
	}
	int cycleNumber = (int)Math.Floor((double)i/(double)periodLength);

	if(i%(periodLength)< numRows)
	{
		col =	cycleNumber*numRows-cycleNumber;
	}else{
		//
		int iModPeriod = i%periodLength;
		int dcol = i % periodLength;
		int fcol = numRows - dcol%(numRows-1)-1;
		int ocol = numRows-fcol-1;
		int end = numRows -(numRows - (i % periodLength)%(numRows-1)-1)-1;
//		int end =ocol;
		col = (cycleNumber *numRows-cycleNumber)+ end;
//		Console.WriteLine($"start{cycleNumber*rnumRowsows-cycleNumber} imodperido{iModPeriod} end{end}");
	//	Console.WriteLine($"dcol{dcol} fcold{fcol} ocol{ocol} end{end}");
	}
	
	array[row,col]= s[i];
	if(i%periodLength == 0){Console.WriteLine("---------------");}
	//Console.WriteLine($"i= {i:00} Row{row:00} col{col:00} "); 

}

for(int i = 0; i < numRows; i++){
	for(int j= 0; j< lengthOfArrays; j ++){
		if(array[i,j] ==null) {
			array[i,j] = '_';
	//	Console.Write("nullll");
		}
		Console.Write(array[i,j]);
		if(array[i,j]!= ' '){
			output+= array[i,j];
		}
	}
	Console.Write("\n");
}

Console.WriteLine(output);

