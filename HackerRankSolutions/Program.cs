// See https://aka.ms/new-console-template for more information

using System.Globalization;

Console.WriteLine("Hello, World!");

#region DiagonalDifference
  int DiagonalDifference(List<List<int>> arr)
  {
    int leftToRightDiagonal=0;
    int rightToLeftDiagonal=0;
        
    int arrCount=arr[0].Count;
        
    for(int i = 0;i<arrCount;i++){
      leftToRightDiagonal += arr[i][0+i]; // [0][0], [1][1] , [2][2]
      rightToLeftDiagonal+=arr[i][arrCount-i-1];
      // arrCount = 3 , arr[i].Count = 3 so we need to minus i and 1 because of Count
    }
       

    return Math.Abs(leftToRightDiagonal-rightToLeftDiagonal);
  }

// var arr = new List<List<int>>();
// arr.Add(new List<int>{1,2,3});
// arr.Add(new List<int>{4,5,6});
// arr.Add(new List<int>{9,8,9});

// Console.WriteLine(DiagonalDifference(arr));

#endregion

#region ComparasionSorting

  List<int> CountingSort(List<int> arr)
{
  var result= new int[100];
        
  foreach(var element in arr){
    result[element]++;
  }
  
  return result.ToList();
}

// var arr = new List<int> { 1, 2, 3, 4,2,3,3,4,4,4,4 };
//
// Console.WriteLine(CountingSort(arr));


#endregion

#region PangramOrNotPangram

// if string parameter has every letter in english alphabet, return "pangram". if not return "not pangram";
  string Pangrams(string s)
  {
    var charHashSet = new HashSet<char>();
    // foreach (char c in s.ToLower())
    // {
    //   if (char.IsLetter(c))
    //   {
    //     charHashSet.Add(c);
    //   }
    // }
    
    foreach (var c in s.ToLower().Where(char.IsLetter))
    {
      charHashSet.Add(c);
    }
    

    return charHashSet.Count == 26 ? "pangram" : "not pangram";
  }
// Console.WriteLine(Pangrams("We promptly judged antique ivory buckles for the next prize"));
#endregion

// In plus minus question, only type conversions is important. if you do smth like int / int does not return you a double value.

#region MiniMaxSum
void MiniMaxSum(List<int> arr)
{
  long minVal = long.MaxValue;
  long maxVal = long.MinValue;

  foreach (var t in arr)
  {
    if(maxVal<t) maxVal=t;
    
    if (minVal>t) minVal=t;
  }

  long sum= arr.Aggregate<int, long>(0, (current, t) => current + t);

  Console.WriteLine($"{sum-maxVal} {sum-minVal}");
}
// MiniMaxSum(new List<int>{1,2,3,4,5});
#endregion

