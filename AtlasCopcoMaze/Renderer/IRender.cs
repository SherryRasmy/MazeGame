using AtlasCopcoMaze.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasCopcoMaze
{
  public interface IRender
  {
    /// <summary>
    /// This Interface mission is to Render On Console.
    /// </summary>
    void GameDescription();
    void Congratulations(Play play);
    void GameOver(Play play);
    void Moves( Play play);
    void Message(MessageTypes messageType);
    void EntranceRoom(int entranceRoom);
    void RenderMaze( Play play);
  }
}
