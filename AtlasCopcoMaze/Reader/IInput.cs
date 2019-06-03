using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasCopcoMaze
{
 public interface IInput
  {
    ConsoleKey ReadInput();
    bool IsEscape(ConsoleKey key);
    bool IsOne(ConsoleKey key);
    bool IsArrow(ConsoleKey key);
    bool IsUpArrow(ConsoleKey key);
    bool IsDownArrow(ConsoleKey key);
    bool IsLeftArrow(ConsoleKey key);
    bool IsRightArrow(ConsoleKey key);
    void clearInput();
    int? ToNumber(ConsoleKey key);
  }
}
