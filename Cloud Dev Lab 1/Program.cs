using System.Numerics;
using static System.Console;

char[] Approved_Numbers = { '1','2','3','4','5','6','7','8','9','0'};

string testInput = "29535123p48723487597645723645";

List<List<int>> SearchAllTheIndexOfTheMarkedNumbers(string Input)
{
    List<List<int>> AllTheListsOfMarkedNumbersIndexes = new();
    
    for(int STIndex = 0; STIndex < Input.Length; STIndex++)
    {
        char SearchTarget = Input[STIndex];
        if (Approved_Numbers.Contains(SearchTarget))
        {
            for(int ETIndex = (STIndex+1); ETIndex < Input.Length; ETIndex++)
            {
                char EqualTarget = Input[ETIndex];
                if (Approved_Numbers.Contains(EqualTarget))
                {
                    if (SearchTarget == EqualTarget)
                    {
                        List<int> ListOfIndexMarkedNrs = new();
                        for(int IndexOfMarkedNr = STIndex; IndexOfMarkedNr <= ETIndex; IndexOfMarkedNr++)
                        {
                            ListOfIndexMarkedNrs.Add(IndexOfMarkedNr);
                        }
                        AllTheListsOfMarkedNumbersIndexes.Add(ListOfIndexMarkedNrs);
                        ETIndex = Input.Length;
                    }
                }
                else { 
                    ETIndex = Input.Length;
                }
            }
        }
    }

    return AllTheListsOfMarkedNumbersIndexes;
}

void PrintAllTheMarkedNumbersWithColorGreen(string Input, List<List<int>> AllTheListOfMarkedNrsIndexes)
{
    foreach (List<int> ListOfMarkedNrs_Index in AllTheListOfMarkedNrsIndexes)
    {
        for (int i = 0; i < Input.Length; i++)
        {
            if (ListOfMarkedNrs_Index.Contains(i))
            {
                ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                ForegroundColor = ConsoleColor.White;
            }
            Write(Input[i]);
        }
        WriteLine(" ");

    }
    ForegroundColor = ConsoleColor.White;
}

BigInteger SumTheTotalOfAllTheMarkedNumbers(string Input, List<List<int>> AllTheListOfMarkedNrsIndexes)
{
    IEnumerable<BigInteger> ConvertAllIndexInto_InputValues_IntFormat = AllTheListOfMarkedNrsIndexes
                        .Select(IndexOfMakredNrs =>
                                    BigInteger.Parse(new string(IndexOfMakredNrs
                                                            .Select(Inputindex => Input[Inputindex])
                                                            .ToArray())));
    BigInteger TotalSum = 0;
    foreach (BigInteger MarkedNumbers in ConvertAllIndexInto_InputValues_IntFormat)
    {
        TotalSum += MarkedNumbers;
    }
    return TotalSum;
}

WriteLine("Insert your input:");
string UserInput = ReadLine();
List<List<int>> ResultOfMarkedNrsIndex = SearchAllTheIndexOfTheMarkedNumbers(UserInput);
WriteLine("\n[ Marked Numbers ]");
PrintAllTheMarkedNumbersWithColorGreen(UserInput, ResultOfMarkedNrsIndex);
BigInteger TheSumOfAllTheMarkedNrs = SumTheTotalOfAllTheMarkedNumbers(UserInput, ResultOfMarkedNrsIndex);
WriteLine("\n[ Total Sum ] ");
WriteLine(TheSumOfAllTheMarkedNrs);
