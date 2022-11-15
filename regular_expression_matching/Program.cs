
Console.WriteLine("Passed: " + (false == IsMatch("aab","c*a*b")).ToString());
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Passed: " + (true == IsMatch("a","a")).ToString());
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Passed: " + (false == IsMatch("aa","a")).ToString());
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Passed: " + (false == IsMatch("pppppk","p.k")).ToString());
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Passed: "+ (true == IsMatch("pak","p.k")).ToString());
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Passed: "+ (true == IsMatch("pppppk","p*k")).ToString());
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Passed: "+ (true == IsMatch("pppk","...k")).ToString());
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Passed: "+ (false == IsMatch("","...k")).ToString());
//Console.WriteLine("----------------------------------------");
//Console.WriteLine("Passed: "+ (true == IsMatch("ab",".*")).ToString());
//Console.WriteLine("Passed: "+ (false == IsMatch("mississippi","mis*is*p*.")).ToString());


 bool IsMatch(string s, string p)
{
// bool log = false;
	Console.WriteLine($"Trying {s}, {p}");
	if(!(p.Contains("*") || p.Contains("."))){
		return s == p;
	}
	if(s.Length == 0 && p.Length > 0) return false;


	int sLocation =0;
	for(int i = 0; i < p.Length; i++){
		// going through the pattern
		bool hasNext = i + 1 < p.Length;

//		if(log) Console.WriteLine($"i: {i} p: {p[i]} sLoc:{sLocation} s: {s[sLocation]}");

		bool nextIsRepeating =false; 
		if(hasNext){
			nextIsRepeating = p[i+1] == '*';
		}

		bool matchAny = p[i] == '.';
		
		if(matchAny || s[sLocation] == p[i]){
			// Found a match 
			char currentMatch = s[sLocation];
			if(nextIsRepeating){
				// Find next one non match character
				for(int j = sLocation + 1 ; j < s.Length; j++){
					if(s[j] != currentMatch){
						// End of match
						sLocation = j;
						break;
					}
				}
				i++;
			}else{
				sLocation ++;
			}
		}else{
			return false;
		}

	}
	return true;

}


