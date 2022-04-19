using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

//Defining  struct for player information

public struct playerInfo

{

     public String playerName;

     public char playerID;

};


namespace Connect4Game

{

     class Program

     {

          //Defining a main function

          static void Main(string[] args)

          {

              //Creating playerFirst of type playerInfo

              playerInfo playerFirst = new playerInfo();

              //Create playerTwo of type playerInfo

               playerInfo playerSecond = new playerInfo();

              //Define board for game

              char[,] board = new char[9, 10];

              //Declare variables

              int playerdropChoice, win, itsfull, playagain;

              //Display message

              Console.WriteLine("Let's Play Connect 4 Game");

              //Receive user input

Console.WriteLine("First Player please enter your name: ");

              //Store player First's name

              playerFirst.playerName = Console.ReadLine();

              //Set player First's ID as X

              playerFirst.playerID = 'X';

              //Receiving user input

Console.WriteLine("Second Player please enter your name: ");

              //Store player 2 Name

              playerSecond.playerName = Console.ReadLine();

              //Set player 2 ID as O

              playerSecond.playerID = 'O';

              //Declaring variables for this game

              itsfull = 0;

              win = 0;

              playagain = 0;

              //Defining a method for game board

              DisplayBoard( board );

              do

              {

                   //Defining playerdropChoice for playerFirst

playerdropChoice = PlayerDrop( board, playerFirst );

                   //Call CheckBellow()

CheckBellow( board, playerFirst, playerdropChoice );

                   //Call DisplayBoard()

                   DisplayBoard( board );

//Call CheckFour() with board and playerFirst as arguments

                   win = CheckFour( board, playerFirst );

                   //If win equals 1

                   if ( win == 1 )

                   {

                        //Call Win()

                        Win(playerFirst);

//Call restart() with board as arguments

                        playagain = restart(board);

                        //If playagain equals 2

                        if (playagain == 2)

                        {

                             break;

                        }

                   }

                   //Defining playerdropChoice for playerSecond

playerdropChoice = PlayerDrop( board, playerSecond );

                   //Calling CheckBellow

CheckBellow( board, playerSecond, playerdropChoice );

                   //Call DisplayBoard()

                   DisplayBoard( board );

//Call CheckFour() with board and playerSecond as arguments

                   win = CheckFour( board, playerSecond );

                   //If win equals one

                   if ( win == 1 )

                   {

//Call Win() with playerSecond as argument

                        Win(playerSecond);

//Call restart() with board as arguments

                        playagain = restart(board);

                        //If playagain equals to two

                        if (playagain == 2)

                        {

                             break;

                        }

                   }

                   //Call FullBoard() with board as argument

                   itsfull = FullBoard( board );

                   //If itsfull equals 7

                   if ( itsfull == 7 )

                   {

                        //Display message and restart board

Console.WriteLine( "The board is full, it is a draw!" );

                        playagain = restart(board);

                   }

              }

              while ( playagain != 2 );

          }

          //Define a method PlayerDrop()

static int PlayerDrop( char[,] board, playerInfo activePlayer )

          {

              //Declaring variable

              int playerdropChoice;

              //Display message to receive user input

Console.WriteLine(activePlayer.playerName + "'s Turn ");

              do

              {

                   //Receive user input

Console.WriteLine("Please enter a number between 1 and 7: ");

                   //Store value

playerdropChoice = Convert.ToInt32(Console.ReadLine());

              }

             

              //If input is valid

              while (playerdropChoice < 1 || playerdropChoice > 7);

              //If board at given choice if itsfull

while ( board[1 , playerdropChoice] == 'X' || board[1 , playerdropChoice] == 'O' )

              {

                   //Display message to receive input        

Console.WriteLine("That row is full, please enter a new row: ");

                   //Store input value

playerdropChoice = Convert.ToInt32(Console.ReadLine());

              }

              //Return user input value

              return playerdropChoice;

          }

          //Defining a function CheckBellow()

static void CheckBellow ( char[,] board, playerInfo activePlayer, int playerdropChoice )

          {

              //Declaring variables

              int Length, turn;

              Length = 6;

              turn = 0;

              //If board is not filled at given choice

              do

              {

if ( board[Length , playerdropChoice] != 'X' && board[Length , playerdropChoice] != 'O' )

                   {

                        //Set board with value

board[Length , playerdropChoice] = activePlayer.playerID;

                        //Set turn as 1

                        turn = 1;

                   }

                   //If board is filled

                   else

                   //Decrement Length

                   --Length;

              }

              //Loops until turn is not 1

              while ( turn != 1 );

          }

          //Define a method DisplayBoard()

          static void DisplayBoard ( char[,] board )

          {

              //Declare variables

              int lrows = 6, lcolumns = 7, li, lix;

              //Define board structure

              for(li = 1; li <= lrows; li++)

              {

                   //Write pipe symbol on board

                   Console.Write("|");

                   //If board is not filled with value write *

                   for(lix = 1; lix <= lcolumns; lix++)

                   {

                        //If value of board is not X or O

if(board[li , lix] != 'X' && board[li , lix] != 'O')

                        //Write *

                        board[li , lix] = '*';

                        Console.Write( board[li , lix] );

                   }

                   //Display | symbol

                   Console.Write("| \n");

              }

          }

          //Define a method CheckFour()

static int CheckFour ( char[,] board, playerInfo activePlayer )

          {

              //Declare variables

              char XO;

              int win;

              //Set player ID

              XO = activePlayer.playerID;

              win = 0;

              for( int li = 8; li >= 1; --li )

              {

                   for( int lix = 9; lix >= 1; --lix )

                   {

                       

                        //Check whether 4 are connected

                        if( board[li , lix] == XO &&

                        board[li-1 , lix-1] == XO &&

                        board[li-2 , lix-2] == XO &&

                        board[li-3 , lix-3] == XO )

                        {

                             //Set win as 1

                             win = 1;

                        }

                        //Check whether 4 are connected

                        if( board[li , lix] == XO &&

                        board[li , lix-1] == XO &&

                        board[li , lix-2] == XO &&

                        board[li , lix-3] == XO )

                        {

                             //Set win as 1

                        win = 1;

                        }

                        //Check whether 4 are connected      

                        if( board[li , lix] == XO &&

                        board[li-1 , lix] == XO &&

                        board[li-2 , lix] == XO &&

                        board[li-3 , lix] == XO )

                        {   

                             //Set win as 1

                        win = 1;

                        }

                        //Check whether 4 are connected

                        if( board[li , lix] == XO &&

                        board[li-1 , lix+1] == XO &&

                        board[li-2 , lix+2] == XO &&

                        board[li-3 , lix+3] == XO )

                        {

                             //Set win as 1

                             win = 1;

                        }

                        //Check whether 4 are connected      

                        if ( board[li , lix] == XO &&

                        board[li , lix+1] == XO &&

                        board[li , lix+2] == XO &&

                        board[li , lix+3] == XO )

                        {

                             //Set win as 1

                             win = 1;

                        }

                   }

              }

              //Return win

              return win;

          }

          //Define a function FullBoard()

          static int FullBoard( char[,] board )

          {

              //Declare variables

              int itsfull;

              itsfull = 0;

              //Initially board has no * increment itsfull

              for ( int li = 1; li <= 7; ++li )

              {

                   //If first row has no *

                   if ( board[1 , li] != '*' )

                   //Increment lfull

                   ++itsfull;

              }

         

              //Return lfull

              return itsfull;

          }

          //Deifine a method PlayerWin()

          static void Win ( playerInfo activePlayer )

          {

         

              //Display message

Console.WriteLine( activePlayer.playerName + " connected four, you won!" );

          }

          //Define a method restart()

          static int restart ( char[,] board )

          {

              //Declare variables

              int restart;

              //Display message for restart

Console.WriteLine("Would you like to restart? Yes(1) or No(2): ");

              //Store input

              restart = Convert.ToInt32(Console.ReadLine());

              //If value is 1

              if ( restart == 1 )

              {

                   //Restart board by setting values as *

                   for(int li = 1; li <= 6; li++)

                   {

                        for(int lix = 1; lix <= 7; lix++)

                        {

                             //Set board with *s

                             board[li , lix] = '*';

                        }

                   }

              }

         

              //If input is not 1

              else

              //Display message

              Console.WriteLine("Goodbye!");

              //Return value of input

              return restart;

          }

     }

}


