using System.IO;
using System.Linq;
//var file = File.Open("Doubles.csv", File.ReadLines());
var file = File.ReadAllLines("Doubles.csv");

class lineOfDoubles{
    public string first;
    public string second;
    public string combined;
}

List<lineOfDoubles> list = new();
foreach(var i in file){
    if(i.Split(',').Count() <2){continue;}
    list.Add(new lineOfDoubles(){
        first = i.Split(',')[0],
        second = i.Split(',')[1],
        combined = i.Split(',')[0] + i.Split(',')[1]
        }
    ); 
}

Console.WriteLine(list.Count());
var doubled = list.GroupBy(i=> i.combined).Where(i=> i.Count() > 1).Select(i=> i.Key).ToList();
//doubled.ForEach(i=> Console.WriteLine(i));
list = list.Where(i=> doubled.Contains(i.combined)).ToList();

list.ForEach(i=> Console.WriteLine($"{i.first},{i.second}"));
//Console.WriteLine(doubled.Count());
