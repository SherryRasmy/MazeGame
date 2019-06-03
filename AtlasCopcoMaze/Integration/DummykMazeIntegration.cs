using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasCopcoMaze
{
  public class DummykMazeIntegration : IMazeIntegration
  {
    /// <summary> To Change MazeSize in the dummy Integration
    /// Just Change these:
    /// 1-the maze structure in BuildMaze()
    /// 2- the private mazesize value
    /// </summary>
    private int _mazesize = 3;
    private int[] _maze;
    /// <summary>
    /// Rooms values will be :
    /// 0  empty
    /// -1 trap
    /// 1  treasure
    /// 2  entrance
    /// </summary>
    /// <param name="size"></param>
    public void BuildMaze(int size)
    {
     int mazesize = size;
      _maze = new int[]
      {
          0, -1, 0 ,
         -1,  0, 1 ,
          0,  0, 2 ,
         
          
      };
    }

    public int GetEntranceRoom()
    {
      //the entrance room is the room value = 2 
      return Array.FindIndex(this._maze, i => i == 2);
    }

    /// <summary>
    /// if the maze is 3x3
    /// Go Nourth (upwords) we will subtract 3 rooms
    /// Go South (downwords) we will add 3 rooms
    /// Go West (to the left) :
    /// if it is the edge : It will be either roum position (0,3,6) so we can make it more generic (roomId % mazesize)
    /// else just subtract a room
    /// Go East(to the right):
    /// if it's the edge : It will be just the oppsoit of the left one ( (roomId-mazesize) % mazesize==(mazesize -1) )
    /// else just add a room
    /// </summary>
    public int? GetRoom(int roomId, char direction)
    {
      int? nextRoom = null;
      switch (direction)
      {
        case 'N':
        case 'n':
            nextRoom = roomId - _mazesize;
          if (nextRoom < 0)
            nextRoom = null;
          break;
        case 'S':
        case 's':
          nextRoom = roomId + _mazesize;
          if((_mazesize * _mazesize) -1 < nextRoom)
            nextRoom = null;
          break;
        case 'W':
        case 'w':
          if (roomId % _mazesize == 0)
            nextRoom = null;
          else
            nextRoom = roomId - 1;
          break;
        case 'E':
        case 'e':
          if ((roomId - _mazesize) % _mazesize == (_mazesize - 1))
            nextRoom = null;
          else nextRoom = roomId + 1;
          break;
        default:
          break;
      }

      return nextRoom;
    }

    public string GetDescription(int roomId)
    {
      if (CausesInjury(roomId))
      {
        return $" opps, Room {roomId} is a trap";
      }
      if (HasTreasure(roomId))
      {
        return $" Wooooow room {roomId}  has the treasure , Congrats";
      }
      //the entrance room is the room value = 2 
      if (Array.FindIndex(this._maze, i => i == 2) == roomId)
      {
        return $" Room {roomId} is the entrance room ";
      }
      return $" Room {roomId} is a normal room without traps or treasures ";
    }

    public bool CausesInjury(int roomId)
    {
      BuildMaze(_mazesize);
      return this._maze[roomId] == -1;
    }

    public bool HasTreasure(int roomId)
    {
      BuildMaze(_mazesize);
      return this._maze[roomId] == 1;
    }
  }
}
