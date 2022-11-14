
Console.WriteLine("Passed: " + (true == IsMatch("a","a")).ToString());
Console.WriteLine("----------------------------------------");
Console.WriteLine("Passed: " + (false == IsMatch("aa","a")).ToString());
Console.WriteLine("----------------------------------------");
Console.WriteLine("Passed: " + (false == IsMatch("pppppk","p.k")).ToString());
Console.WriteLine("----------------------------------------");
Console.WriteLine("Passed: "+ (true == IsMatch("pak","p.k")).ToString());
Console.WriteLine("----------------------------------------");
Console.WriteLine("Passed: "+ (true == IsMatch("pppppk","p*k")).ToString());
Console.WriteLine("----------------------------------------");
Console.WriteLine("Passed: "+ (true == IsMatch("pppk","...k")).ToString());
Console.WriteLine("----------------------------------------");
Console.WriteLine("Passed: "+ (false == IsMatch("","...k")).ToString());
Console.WriteLine("----------------------------------------");
Console.WriteLine("Passed: "+ (true == IsMatch("ab",".*")).ToString());
Console.WriteLine("Passed: "+ (true == IsMatch("mississippi","mis*is*p*.")).ToString());

var newbuff = new CircularBuffer<int>();
class CircularBuffer<T>
{
	  Nullable<T>[] buffer;
		int position =0;  
    public CircularBuffer(int capacity)
    {
				buffer =new T?[capacity];
                buffer[0].Value;
    }


    public T Read()
    {
			int output = buffer[position].Value;
				if(position == capacity){
					position = 0;
				}else{
					position++;
				}
				return output.Value; 
    }

    public void Write(T value)
    {
				if(buffer[position].HasValue )
        throw new Exception("buffer full");
    }

    public void Overwrite(T value)
    {
			buffer[position] = (int)value;
    }

    public void Clear()
    {
		
			buffer.ForEach(i=> i = null);			
    }
}

 bool IsMatch(string s, string p)
{
	Console.WriteLine($"Trying {s}, {p}");
	if(!(p.Contains("*") || p.Contains("."))){
		return s == p;
	}
	if(s.Length == 0 && p.Length > 0) return false;

	bool result= true;
	bool inRepeatingPattern = false;
	bool wildcard = false;

	int patternLocation = 0;
	for(int i = 0; i < s.Length; i++){
		Console.Write($"i = {i}, p = {patternLocation}");
		if(p[patternLocation] == '.'){
			// skip pattern
			Console.Write(" skipping pattern");
			wildcard = true;		
			//			if(s.Length -1 > i){
			//			result = false;
			//		Console.WriteLine("breaking  pattern");
			//	break;
			//}
		}else{
			wildcard = false;
			//			Console.Write(" " + p[patternLocation + 1]+ "");
			// Look ahead to check for repeating pattern
		}
		Console.Write($" ploc +1= {patternLocation+1} plength-1 {p.Length -1}");
		if( !(patternLocation+1 > p.Length-1) && p[patternLocation + 1] == '*'){
			Console.Write(" repeat start ");
			inRepeatingPattern = true; 
			// Move ahead
			while(s[i] != p[patternLocation]){
				i++;
			}
			i++;
			patternLocation ++;

		}else{

			Console.Write($" Comp {s[i]} = {p[patternLocation]} wc = {wildcard}");
			if(!wildcard){
				if(s[i] != p[patternLocation]){
					//		if(inRepeatingPattern){
					//			inRepeatingPattern = false;
					//			i--;
					//			patternLocation++;
					//			Console.Write(" End Of Repeating");
					//		}else{
					result = false;
					Console.Write(" non match found ");
					break;
					//	}
				}
			}
			//	if(!inRepeatingPattern){
			//		patternLocation++;
			//		Console.Write($" increment patternLocation {patternLocation}");
			//	}
		}


		//		Console.Write($"fjdkjfkdj");
		patternLocation++;
		Console.WriteLine();
	}
	return result;
}


