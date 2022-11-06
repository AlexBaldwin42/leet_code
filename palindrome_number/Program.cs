
Console.WriteLine(IsPalindrome(636));
Console.WriteLine(IsPalindrome(6636));

Console.WriteLine(IsPalindrome(640000046));
Console.WriteLine(IsPalindrome(6400046));
Console.WriteLine(IsPalindrome(6400146));
Console.WriteLine(IsPalindrome(66));
bool IsPalindrome(int x){
	string input = x.ToString();
	if(input.Length < 2) return true;

	for(int i = 0; i < input.Length/2; i ++){
		if(input[i] != input[input.Length -1 - i]){
			return false;
		}
	}
	return true;

}
