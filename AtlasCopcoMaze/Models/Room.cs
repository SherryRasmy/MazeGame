using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasCopcoMaze.Models
{
  public class Room
  {
    public int RoomId { get; set; }
    public bool HasTreasure { get; set; }
    public bool HasTrap { get; set; }
    public string Description { get; set; }
  }
}
