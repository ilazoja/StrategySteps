using System;

static class Program
{
	static int Player1 = 0;
	static int Player2 = 0;
	static int Player3 = 0;
	static int Player4 = 0;
	
	// Player types	
	static string Player1Type, Player2Type, Player3Type, Player4Type;
	
	// A random number generator for use by AI players.
	static Random rGen = new Random();
	
	static void Main()
	{
		int currentNumber1 = 0;
		int currentNumber2 = 0;
		int currentNumber3 = 0;
		int currentNumber4 = 0;
		string unique1, unique2, unique3, unique4;
		
		Console.WriteLine();
		Console.WriteLine("Welcome to Strategy Steps");
		
		WriteBoard();
		
		Player1Type = GetPlayerType( "1" );
		Player2Type = GetPlayerType( "2" );
		Player3Type = GetPlayerType( "3" );
		Player4Type = GetPlayerType( "4" );
		
		while ( ! IsWin() )
		{
			if (Player1Type == "human") currentNumber1 = HumanNumberSelection("1");
			if (Player1Type == "ai") currentNumber1 = AiNumberSelection();
			if (Player2Type == "human") currentNumber2 = HumanNumberSelection("2");
			if (Player2Type == "ai") currentNumber2 = AiNumberSelection();
			if (Player3Type == "human") currentNumber3 = HumanNumberSelection("3");
			if (Player3Type == "ai") currentNumber3 = AiNumberSelection();
			if (Player4Type == "human") currentNumber4 = HumanNumberSelection("4");
			if (Player4Type == "ai") currentNumber4 = AiNumberSelection();
			
			unique1 = Compare(currentNumber1, currentNumber2, currentNumber3, currentNumber4);
			unique2 = Compare(currentNumber2, currentNumber1, currentNumber3, currentNumber4);
			unique3 = Compare(currentNumber3, currentNumber1, currentNumber2, currentNumber4);
			unique4 = Compare(currentNumber4, currentNumber1, currentNumber2, currentNumber3);
			Console.WriteLine ("Player 1 chose {0} which is {1}", currentNumber1, unique1);
			Console.WriteLine ("Player 2 chose {0} which is {1}", currentNumber2, unique2);
			Console.WriteLine ("Player 3 chose {0} which is {1}", currentNumber3, unique3);
			Console.WriteLine ("Player 4 chose {0} which is {1}", currentNumber4, unique4);
			
			if (unique1 == "Unique")
			{
				Player1 = Player1 + currentNumber1;
			}
			if (unique2 == "Unique")
			{
				Player2 = Player2 + currentNumber2;
			}
			if (unique3 == "Unique")
			{
				Player3 = Player3 + currentNumber3;
			}
			if (unique4 == "Unique")
			{
				Player4 = Player4 + currentNumber4;
			}
			WriteBoard();
			Console.WriteLine("   {0} {1} {2} {3}", Player1, Player2, Player3, Player4);
			
		}
		Console.WriteLine();
		if(Player1 >= 12)
		{
			Console.WriteLine( "Player 1 wins!");
		}
		if(Player2 >= 12)
		{
			Console.WriteLine( "Player 2 wins!");
		}
		if(Player3 >= 12)
		{
			Console.WriteLine( "Player 3 wins!");
		}
		if(Player4 >= 12)
		{
			Console.WriteLine( "Player 4 wins!");
		}		
	}
	static int HumanNumberSelection(string playerNumber)
	{
		int selectedNumber = 0;
		bool inputCorrect = false;
		while (!inputCorrect)
		{
			Console.Write("Would Player {0} like to traverse 1, 3 or 5 steps?", playerNumber);
			selectedNumber = int.Parse(Console.ReadLine());
			if (selectedNumber == 1 || selectedNumber == 3 || selectedNumber == 5)
			{
				inputCorrect = true;
			}
			else
			{
				Console.WriteLine("You did not pick a valid number");
			}
		}
		Console.Clear();
		return selectedNumber;
	}
	static int AiNumberSelection()
	{
		switch (rGen.Next(1,4))
		{
			case 1:
				return 1;
			case 2:
				return 3;
			case 3:
				return 5;
			default:
				return 0;
		}
	}
	static string Compare(int currentNumberA, int currentNumberB, int currentNumberC, int currentNumberD)
	{
		if (currentNumberA != currentNumberB && currentNumberA != currentNumberC && currentNumberA != currentNumberD)
		{
			return "Unique";
		}
		else
		{
			return "Not Unique";
		}
	}
	static void WriteBoard()
	{
		string [] Player1Display = new string[12];
		string [] Player2Display = new string[12];
		string [] Player3Display = new string[12];
		string [] Player4Display = new string[12];
		for (int i = 0; i < 12; i++)
		{
			if (i < Player1)
			{
				Player1Display[i] = "-";
			}
			else if (i >= Player1)
			{
				Player1Display[i] = " ";
			}
			
		}
		for (int i = 0; i < 12; i++)
		{
			if (i < Player2)
			{
				Player2Display[i] = "-";
			}
			else if (i >= Player2)
			{
				Player2Display[i] = " ";
			}
			
		}
		for (int i = 0; i < 12; i++)
		{
			if (i < Player3)
			{
				Player3Display[i] = "-";
			}
			else if (i >= Player3)
			{
				Player3Display[i] = " ";
			}			
		}
		for (int i = 0; i < 12; i++)
		{
			if (i < Player4)
			{
				Player4Display[i] = "-";
			}
			else if (i >= Player4)
			{
				Player4Display[i] = " ";
			}			
		}
		Console.WriteLine();
		Console.WriteLine( "12 {0} {1} {2} {3}", Player1Display[11], Player2Display[11], Player3Display[11], Player4Display[11]);
		Console.WriteLine( "11 {0} {1} {2} {3}", Player1Display[10], Player2Display[10], Player3Display[10], Player4Display[10]);
		Console.WriteLine( "10 {0} {1} {2} {3}", Player1Display[9], Player2Display[9], Player3Display[9], Player4Display[9]);
		Console.WriteLine( "9  {0} {1} {2} {3}", Player1Display[8], Player2Display[8], Player3Display[8], Player4Display[8]);
		Console.WriteLine( "8  {0} {1} {2} {3}", Player1Display[7], Player2Display[7], Player3Display[7], Player4Display[7]);
		Console.WriteLine( "7  {0} {1} {2} {3}", Player1Display[6], Player2Display[6], Player3Display[6], Player4Display[6]);
		Console.WriteLine( "6  {0} {1} {2} {3}", Player1Display[5], Player2Display[5], Player3Display[5], Player4Display[5]);
		Console.WriteLine( "5  {0} {1} {2} {3}", Player1Display[4], Player2Display[4], Player3Display[4], Player4Display[4]);
		Console.WriteLine( "4  {0} {1} {2} {3}", Player1Display[3], Player2Display[3], Player3Display[3], Player4Display[3]);
		Console.WriteLine( "3  {0} {1} {2} {3}", Player1Display[2], Player2Display[2], Player3Display[2], Player4Display[2]);
		Console.WriteLine( "2  {0} {1} {2} {3}", Player1Display[1], Player2Display[1], Player3Display[1], Player4Display[1]);
		Console.WriteLine( "1  {0} {1} {2} {3}", Player1Display[0], Player2Display[0], Player3Display[0], Player4Display[0]);
		
	}
	static string GetPlayerType (string player)
	{
		Console.WriteLine();
		string playerType = "a";
		bool inputCorrect = false;
		while (!inputCorrect)
		{
			Console.Write("Enter the player type for {0}, human or ai: ", player );
			playerType = Console.ReadLine().ToLower();
			if (playerType == "human" || playerType == "ai")
			{
				inputCorrect = true;
			}
			else
			{
				Console.WriteLine ("You must choose 'human' or 'ai'");
			}
		}
		return playerType;
	}
	static bool IsWin()
	{
		if(Player1 >= 12 || Player2 >= 12 || Player3 >= 12 || Player4 >= 12)
		{
			return true;
		}
		else
		{
			return false;
		}

	}
	
}