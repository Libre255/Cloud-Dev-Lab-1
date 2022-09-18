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

string testInput = "29535123";


void SearchSecondaryNumber(string Input)
{
    List<List<char>> ListOfMatchedNumbers = new();
  
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

                //If i find the second number equal to SearchTarget
                if (SearchTarget == EqualTarget)
                {
                    //Creat a list for all numbers inbetween (and including) SearchTarget and EqualTarget 
                    List<char> MarkedNumbers = new();
                    for(int x = ST; x <= ET; x++)
                    {
                        char MarkedNr = Input[x];
                        MarkedNumbers.Add(MarkedNr);
                    }
                    //Add marked numbers to ListOfMatchedNumbers
                    ListOfMatchedNumbers.Add(MarkedNumbers);
                }
            }
        }
    }

    WriteLine("Marked Numbers");
    foreach(List<char> MarkedNrs in ListOfMatchedNumbers)
    {
        WriteLine(" ");
        foreach(char Nrs in MarkedNrs)
        {
            Write(Nrs);
        }
    }
}

SearchSecondaryNumber(testInput);
