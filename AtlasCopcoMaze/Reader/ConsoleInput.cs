using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasCopcoMaze
{
  public class ConsoleInput : IInput
  {
    public ConsoleKey ReadInput()
    {
      return Console.ReadKey().Key;
    }
    public bool IsEscape(ConsoleKey key)
    {
      if (key == ConsoleKey.Escape)
      { return true; }
      return false;
    }
    public bool IsOne(ConsoleKey key)
    {
      if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
      { return true; }
      return false;
    }
    public bool IsArrow(ConsoleKey key)
    {
      return
        IsUpArrow(key) || IsDownArrow(key) || IsLeftArrow(key) || IsRightArrow(key);
    }
    public bool IsUpArrow(ConsoleKey key)
    {
      if (key == ConsoleKey.UpArrow)
        return true;
      return false;
    }
    public bool IsDownArrow(ConsoleKey key)
    {
      if (key == ConsoleKey.DownArrow)
        return true;
      return false;
    }
    public bool IsLeftArrow(ConsoleKey key)
    {
      if (key == ConsoleKey.LeftArrow)
        return true;
      return false;
    }
    public bool IsRightArrow(ConsoleKey key)
    {
      if (key == ConsoleKey.RightArrow)
        return true;
      return false;
    }

    public void clearInput()
    {
      Console.Clear();
    }

    public int? ToNumber(ConsoleKey key)
    {
      int keyValue = (int)key;
      if(keyValue <= 105 && keyValue >=96)
      {
        return keyValue - 96;
      }

      if(keyValue <=56  && keyValue >=48)
      {
        return keyValue - 48;
      }

      return null;
    }
  }
}
