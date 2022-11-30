//	if(log)	Console.WriteLine($"found {tokensString} tokens");
Console.WriteLine("Passed: " + (true == IsMatch("aab","c*a*b")).ToString());
Console.WriteLine("----------------------------------------");
Console.WriteLine("Passed: " + (true == IsMatch("a","a")).ToString());
Console.WriteLine("----------------------------------------");
Console.WriteLine("Passed: " + (false == IsMatch("aa","a")).ToString());
Console.WriteLine("----------------------------------------");
Console.WriteLine("Passed: " + (false == IsMatch("pppppk","p.k")).ToString());
Console.WriteLine("----------------------------------------");
Console.WriteLine("Passed: "+ (true == IsMatch("pak","p.k")).ToString());
//Console.WriteLine("----------------------------------------");
Console.WriteLine("Passed: "+ (true == IsMatch("pppppk","p*k")).ToString());
Console.WriteLine("----------------------------------------");
Console.WriteLine("Passed: "+ (true == IsMatch("pppk","...k")).ToString());
Console.WriteLine("----------------------------------------");
Console.WriteLine("Passed: "+ (false == IsMatch("","...k")).ToString());
Console.WriteLine("----------------------------------------");
Console.WriteLine("Passed: "+ (true == IsMatch("ab",".*")).ToString());
Console.WriteLine("Passed: "+ (false == IsMatch("mississippi","mis*is*p*.")).ToString());
//

bool IsMatch(string s, string p)
{



	bool log = true;

	Console.WriteLine($"Trying {s}, {p}");
	if(!(p.Contains("*") || p.Contains("."))){
		return s == p;
	}
	if(s.Length == 0 && p.Length > 0) return false;


	int NumOfTokens =  p.Length - p.Split('*').Count()+1;
	var splitTokens = p.Split('*');
	bool hasAsterisk = true;
	if(!(p.Contains("*"))){
		hasAsterisk = false;
	}
	//	var tokens = new[NumOfTokens] (char modifier, char token);
	//(char modifier, char token)[] tokens =  new(char? modifier, char token)[NumOfTokens]; 
	var tokens =  new(char? modifier, char token)[NumOfTokens]; 
	if(log)	Console.WriteLine($"found {NumOfTokens} tokens");

	int tokenPosition = 0;
	// Build Tokens	
	for(int i= 0; i < p.Length; i++)
	{
		if(p[i] == '*'){
			tokens[tokenPosition-1] = ('*', tokens[tokenPosition-1].token);
		}else{

			tokens[tokenPosition++] = (null, p[i]);
		}

	}

	string tokensString = string.Join(", ",tokens);
	if(log)	Console.WriteLine($"found {tokensString} tokens");
	int sLocation = 0;
	// Check Tokens
	//foreach(var token in tokens)
	for(int i = 0; i <tokens.Length; i++){
		var token = tokens[i];
		if(sLocation > s.Length)
		{
			Console.WriteLine("Quitting because length");
			return false;
		}
		Console.WriteLine($"{token.modifier} {token.token} string {s[sLocation]}  sloc={sLocation} sLength {s.Length}");
		if(token.modifier == null)
		{
			if(!(s[sLocation] == token.token || token.token == '.')){
				if(log)Console.WriteLine($"returning false  sloc = token {s[sLocation] == token.token} token = . {token.token == '.'} token = {token.token}");
				Console.WriteLine("jggjgjgjgjfjdkjjFK");
				return false;
			}else{
				sLocation++;
			}
		}else
		{
			// multiple find next character that isn't this 

			if(log)Console.WriteLine($"starting while");
			if(s[sLocation] == token.token ){

				while(sLocation < s.Length && s[sLocation] == token.token )
				{
					if(log)Console.WriteLine($"in while {sLocation}");
					sLocation ++;
				}
			}else{

				if(log)Console.WriteLine($"skippingwhile no char found");
				if(i+1 < tokens.Length &&tokens[i+1])
					// need to check ahead here somehow and not create infinite loop how it is now
			}
			if(log)Console.WriteLine($"out ofwhile {sLocation}");
		}

	}
	Console.WriteLine("made it");
	return true;
	// tokenize

}


