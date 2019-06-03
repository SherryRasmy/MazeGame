using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;
using Colorful;
using Alba.CsConsoleFormat;
using AtlasCopcoMaze.Models;

namespace AtlasCopcoMaze
{
  public class ConsoleRender : IRender
  {
    public ConsoleRender()
    {
      Console.OutputEncoding = Encoding.UTF8;

    }
    public void GameDescription()
    {
      Console.WriteLine("         ");
      Console.WriteLine("++++++++++++++++++++++++++++++++++ How to play ++++++++++++++++++++++++++++++++++++++", Color.DarkKhaki);
      Console.WriteLine("         ");
      Console.WriteLine("your Maze is a squared shape , you should reach the Treasure Room and avoid falling in Traps Rooms ", Color.DarkKhaki);
      Console.WriteLine("with the smallest number of moves . ", Color.DarkKhaki);
      Console.WriteLine("you have only 3 Health Points (hp) , so use them well :)", Color.DarkKhaki);
      Console.WriteLine("you can use the arrows buttoms to make a move", Color.DarkKhaki);
      Console.WriteLine("         ");
      Console.WriteLine("++++++++++++++++++++++++++++++++++ Good Luck ++++++++++++++++++++++++++++++++++++++++++++++", Color.DarkKhaki);
      Console.WriteLine("         ");
      Console.WriteLine("please enter your maze size to start.", Color.DarkGoldenrod);
    }
    public void Congratulations(Play play)
    {
      
      int DA = 34;
      int V = 139;
      int ID = 34;
      Console.WriteAscii("      Congratulations       ", Color.FromArgb(DA, V, ID));
      Console.WriteLine("   ");
      Console.WriteLine("     ");
      string s = "You Wins the game with Only " + play.Steps + " Steps and " + play.HP + " Hp.";
      Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
      Console.WriteLine(s, Color.FromArgb(DA, V, ID));
      RenderMaze(play);
      Console.WriteLine("   ");
      Message(MessageTypes.NewGame);
      
    }
    public void GameOver(Play play)
    {
      
      int DA = 255;
      int V = 0;
      int ID = 0;
      Console.WriteAscii("       Game Over       ", Color.FromArgb(DA, V, ID));
      Console.WriteLine("   ");
      Console.WriteLine("     ");
      string s = "You lost the game with " + play.Steps + " Steps and " + play.HP + " Hp.";
      Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
      Console.WriteLine(s, Color.FromArgb(DA, V, ID));
      RenderMaze(play);
      Console.WriteLine("   ");
      Message(MessageTypes.NewGame);
      
    }
    public void Message(MessageTypes MessageType)
    {
      if (MessageType == MessageTypes.WelcomeMessage)
      {
        int DA = 195;
        int V = 176;
        int ID = 145;
        Console.WriteAscii("      Welcome        ", Color.FromArgb(DA, V, ID));
        Console.WriteLine("   ");
        Console.WriteLine("     ");
        string welcome = "Welcome to the great maze game .... To start Press {0}, to exit Press {1}";
        Formatter[] choices = new Formatter[]
              {new Formatter("1", Color.DarkGoldenrod),
               new Formatter("ESC", Color.DarkGoldenrod)
              };
        Console.SetCursorPosition((Console.WindowWidth - welcome.Length) / 2, Console.CursorTop);
        Console.WriteLine("  ");
        Console.WriteLineFormatted(welcome, Color.Khaki, choices);
        return;
      }
      if (MessageType == MessageTypes.InvalidInput)
      {
        Console.WriteLine("please enter valid number ", Color.DarkRed);
        Console.WriteLine("         ");
        return;
      }
      if (MessageType == MessageTypes.Instruction)
      {
        Console.WriteLine("Start using the arrows to play ");
        Console.WriteLine("         ");
        return;
      }
      if (MessageType == MessageTypes.outsideMaze)
      {
        Console.WriteLine(" you are now outside the maze borders , please choose another step", Color.DarkOrange);
      }
      if(MessageType == MessageTypes.NewGame)
      {
        string welcome = "Have fun and start new game! .... To start Press {0}, to exit Press {1}";
        Formatter[] choices = new Formatter[]
              {new Formatter("1", Color.DarkGoldenrod),
               new Formatter("ESC", Color.DarkGoldenrod)
              };
        Console.SetCursorPosition((Console.WindowWidth - welcome.Length) / 2, Console.CursorTop);
        Console.WriteLine("  ");
        Console.WriteLineFormatted(welcome, Color.Khaki, choices);
        
        return;
      }
    }
    public void EntranceRoom(int entranceRoom)
    {
      Console.WriteLine(" ");
      Console.WriteLine($"Your entrance is room {entranceRoom}");
      Console.WriteLine(" ");
    }
    public void Moves(Play play)
    {
      Console.WriteLine("----------------------------------------- Your Moves ------------------------------------------", Color.Khaki);
      if (play.VisitedRooms.Count > 0)
      {
        Console.WriteLine("You have already visited these rooms :", Color.DarkKhaki);
        foreach (var x in play.VisitedRooms)
        {
          if(x.HasTrap)
          {
            Console.WriteLine("room " + x.RoomId + " : " + x.Description, Color.Red);
          }
          else
          {
            Console.WriteLine("room " + x.RoomId + " : " + x.Description, Color.Gold);
          }
          
        }
      }
      Console.WriteLine("you used " + play.Steps + " moves", Color.DarkKhaki);
      Console.WriteLine("you have " + play.HP + " hp left", Color.DarkKhaki);
      Console.WriteLine("you are now in Room " + play.CurrentRoom + " : " + play.CurrentRoomDescription, Color.LightGreen);
      Console.WriteLine("-----------------------------------------------------------------------------------------------", Color.Khaki);
      Console.WriteLine("  ");

      RenderMaze(play);
    }
    public void RenderMaze(Play play)
    {
      var headerThickness = new LineThickness(LineWidth.Single, LineWidth.Single);
      List<Cell> cells = new List<Cell>();
      for (int i = 0; i < play.MazeSize * play.MazeSize; i++)
      {
        Cell c = new Cell(i.ToString());
        if (play.VisitedRooms.FindAll(x => x.RoomId == i).Count() > 0)
        {
          c.Color = ConsoleColor.Green;
        }
        cells.Add(c);
      }
      var doc = new Document(
      //new Span("Steps: " + play.Steps) { Color = ConsoleColor.Yellow }, new Br(),
      //new Span("HP: " + play.HP) { Color = ConsoleColor.Yellow }, new Br(),
      //new Span("Current Room: " + play.CurrentRoom) { Color = ConsoleColor.Yellow }, new Br(),
      //new Span("Current Room Description: " + play.CurrentRoomDescription) { Color = ConsoleColor.Yellow },
      new Grid(cells)
      {
        Columns = { Enumerable.Repeat(GridLength.Star(1), play.MazeSize) }
      });
      doc.Padding = new Thickness(3);
      ConsoleRenderer.RenderDocument(doc);
    }
  }
}
