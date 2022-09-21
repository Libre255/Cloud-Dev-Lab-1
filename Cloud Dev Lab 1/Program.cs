using System.Numerics;
using static System.Console;

//Loop only Numbers 
//Search first duplicate number
//and mark all the numbers in between including the searching number
//Then output all the numbers with the marked numbers

//if during searching a number the loop finds anything other than a number
//Then stop searching with that number and start searching with the next number

// Dont print the loops that didnt find:
//Duplicate numbers Or were canseled because of a letter (or other than a number)

char[] Approved_Numbers = { '1','2','3','4','5','6','7','8','9','0'};

string testInput = "29535123p48723487597645723645";


void SearchSecondaryNumber(string Input)
{
    List<List<int>> ListOfAllTheMarkedNrsIndex = new();
    
    //Looping Input
    for(int ST = 0; ST < Input.Length; ST++)
    {
        char SearchTarget = Input[ST];
        //Checked if SearchTarget is a number
        if (Approved_Numbers.Contains(SearchTarget))
        {
            //Begin searching equal number starting after SearchTarget
            for(int ET = (ST+1); ET < Input.Length; ET++)
            {
                char EqualTarget = Input[ET];
                //Check if EqualTarget is a number if not then finish loop
                if (Approved_Numbers.Contains(EqualTarget))
                {
                    //If i find the second number equal to SearchTarget
                    if (SearchTarget == EqualTarget)
                    {
                        //Creat a list for all numbers inbetween (and including) SearchTarget and EqualTarget 
                        List<int> ListOfIndexMarkedNrs = new();
                        for(int IndexOfMarkedNr = ST; IndexOfMarkedNr <= ET; IndexOfMarkedNr++)
                        {
                            ListOfIndexMarkedNrs.Add(IndexOfMarkedNr);
                        }
                        //Add marked numbers to ListOfMatchedNumbers
                        ListOfAllTheMarkedNrsIndex.Add(ListOfIndexMarkedNrs);
                        ET = Input.Length;
                    }
                }
                else
                {
                    ET = Input.Length;
                }

            }
        }
    }

    WriteLine("[ Marked Numbers ]");
    foreach (List<int> ListOfMarkedNrs_Index in ListOfAllTheMarkedNrsIndex)
    {
        WriteLine(" ");
        for(int i = 0; i < Input.Length; i++)
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
    }
    ForegroundColor = ConsoleColor.White;
    
    WriteLine("  ");
    WriteLine("  ");
    WriteLine("[ Total Sum ] ");
    IEnumerable<BigInteger> ConvertAllIndexInto_InputValues_IntFormat = ListOfAllTheMarkedNrsIndex
                        .Select(IndexOfMakredNrs => 
                                    BigInteger.Parse(new string(IndexOfMakredNrs
                                                            .Select(Inputindex => Input[Inputindex])
                                                            .ToArray() ) ) );
    BigInteger TotalSum = 0;
    foreach(BigInteger MarkedNumbers in ConvertAllIndexInto_InputValues_IntFormat)
    {
        TotalSum += MarkedNumbers;
    }
    WriteLine(TotalSum);
}

SearchSecondaryNumber(testInput);
