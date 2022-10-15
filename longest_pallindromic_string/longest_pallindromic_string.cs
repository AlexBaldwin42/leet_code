public class Solution {
 11   public string LongestPalindrome(string s) {
 10      
  9    string canidate = "";
  8     // Pick which a potential candidate
  7     // lets just go through the entire string
  6     // pick a starting position
  5    foreach(int startingPosition = 0; startingPosition < s.Length(); startingsPosition++){
  4     // go through every possible ending position
  3      foreach(int endingposition = s.Length(); endingPosition > startingPosition; endingPosition--){
  2       // Check if this canidate is a pallindrom
            int length = startingPosition - endingPosition;
  1       if(canidate > length && isPallindrome(s.Substring(startingPosition,length))){
13           candidate = s.Substring(startingPosition, length)
  1       }
  2      }
  3       
  4     }
 10   }
 11     
 12   public bool isPallindrome(string canidate){
 13    foreach(int i = 0; i < canidate.Length()/2; i++){
 14     if(canidate.CharAt(i)!= canidate.CharAt(canidate.length()-i-1)){
 15      return false;