#region DiagonalDifference

using System.Globalization;

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

#region LonelyInteger
int LonelyIntegerSolutionOne(List<int> a)
{
    // Bu örnekte Bitwise Exclusive XOR çalışıyor.
    /*
     1. iterasyonda 0 ve 1 arasından 1'i seçiyor
     2. iterasyonda 1 ve 2 arasından 3 toplamını elde ediyor.
     3. iterasyonda 3 ve 3 arasından 0 değerini elde ediyor.
     4. iterasyonda 0 ve 4 arasından 4 değerini elde ediyor.
     5. iterasyonda 4 ve 3 arasından 7 değerini elde ediyor.
     6. iterasyonda 7 ve 2 arasından 5 değerini elde ediyor.
     7. iterasyonda 5 ve 1 arasından 4 değerini elde ediyor.
     */

    var result = 0;
    foreach (var i in a)
    {
        result ^= i;
    }

    return result;
}
int LonelyIntegerSolutionTwo(List<int> a)
{
  var arr = new List<int>(a);
  
  for (int i = 0; i < a.Count; i++)
  {
    for (int j = a.Count-1; j > i; j--)
    {
      if (a[i]==a[j])
      {
        arr.Remove(a[i]);
        arr.Remove(a[j]);
        break;
      }
    }
  }

  return arr.First();

}

// Console.WriteLine(LonelyInteger(new List<int>{1,2,3,4,5,1,2,3,4}));


#endregion

#region FlippingTheMatrix
int FlippingMatrix(List<List<int>> arr)
{
  int row = arr.Count - 1;
  int col = arr[0].Count - 1;
  int total = 0;
  for(int i = 0; i < row; i++)
  { 
    // 112 42 83 119
    // 56 125 56 49
    // 15 78 101 43
    // 62 98 114 108
    for(int j = 0; j < col; j++)
    {
      int max = arr[i][j]; // 112 
      max = Math.Max(max, arr[i][col]); // 119
      max = Math.Max(max, arr[row][j]); // 62
      max = Math.Max(max, arr[row][col]); // 108
      total += max;
      col--;
    }
    col = arr[0].Count - 1; // reset column
    row--;
  }
  return total;
}

Console.WriteLine(FlippingMatrix(new List<List<int>>{new List<int>{112,42,83,119},new List<int>{56,125,56,49},new List<int>{15,78,101,43},new List<int>{62,98,114,108}}));


#endregion

#region FindMinimumPrice
static long findMinimumPrice(List<int> price, int discountCouponNumber)
{
    long sum = 0;

    if (discountCouponNumber == 0)
    {
        for (int i = 0; i < price.Count; i++)
        {
            sum += price[i];
        }

        return sum;

    }

    var count = price.Count;

    var discountPrice = price[count - 1];

    price[count - 1] = discountPrice / Convert.ToInt32(Math.Pow(2, discountCouponNumber));

    for (int i = 0; i < price.Count; i++)
    {
        sum += price[i];
    }

    return sum;

}
#endregion

#region GetMaximumEvenSum
static long getMaximumEvenSum(List<int> val)
{
    List<int> positiveNumbers = new();
    List<int> negativeNumbers = new();

    for (int i = 0; i < val.Count; i++)
    {
        if (val[i] > 0)
        {
            positiveNumbers.Add(val[i]);
        }
    }
    long positiveSum = positiveNumbers.Sum();
    if (positiveSum % 2 == 0) return positiveSum;

    var negativeSum = 0;
    for (int i = 0; i < val.Count; i++)
    {
        if (val[i] < 0)
        {
            negativeNumbers.Add(val[i]);
            var negMax = negativeNumbers.Max();
            if ((positiveNumbers.Sum() + negMax) % 2 == 0)
            {
                negativeSum = positiveNumbers.Sum() + negMax;
            }
        }
    }
    return negativeSum;


}
#endregion

#region ReturnHour
string returnHour(string s)
{
    var dt = DateTime.ParseExact(s, "hh:mm:sstt", CultureInfo.InvariantCulture);

    return $"{dt:HH:mm:ss}";
}
#endregion

#region MatchingStrings

List<int> matchingStrings(List<string> strings, List<string> queries)
{
    var count = queries.Count;
    int[] array = new int[count];
    for (int i = 0; i < count; i++)
    {
        for (int j = 0; j < strings.Count; j++)
        {
            if (queries[i] == strings[j])
            {
                array[i]++;
            }
        }
    }
    return array.ToList();
}

//Console.WriteLine(matchingStrings(new List<string>() { "ab", "ab", "abc" }, new List<string>() { "ab", "abc", "bc" }));

#endregion

#region IsTheNumberPresent
List<string> IsTheNumberPresent(List<int> num)
{
    var numberPresent=new List<string>{"",""};

    for (int i = 0; i < num.Count; i++)
    {
        bool occurLater = false;
        bool occurEarlier = false;

        for (int j = num.Count-1; j > i; j--)
        {
            if (num[i] == num[j])
                occurLater = true;
        }

        if (i!=0 || i!=num.Count-1)
        {
            for (int k = i; k >=0; k--)
            {
                if (num[i] == num[k])
                    occurEarlier = true;
            }
        }


        if (occurEarlier) numberPresent[0] += "1";
        else numberPresent[0] += "0";

        if (occurLater) numberPresent[1]+= "1";
        else numberPresent[1]+= "0";


    }
    return numberPresent;
}

#endregion