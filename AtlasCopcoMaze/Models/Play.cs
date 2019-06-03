using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasCopcoMaze.Models
{
  public class Play
  {
    public Play()
    {
      this.HP = 3;
      this.Steps = 0;
      this.MazeSize = 0;
      this.CurrentRoom = 0;
      this.CurrentRoomDescription = "";
      this.VisitedRooms = new List<Room>();
    }
    public int HP { set; get; }
    public int Steps { set; get; }
    public int MazeSize { set; get; }
    public int CurrentRoom { set; get; }
    public string CurrentRoomDescription { set; get; }
    public List<Room> VisitedRooms { get; }
    
  }
}
