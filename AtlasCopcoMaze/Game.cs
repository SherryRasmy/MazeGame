using AtlasCopcoMaze.Models;
using System;
using System.Collections.Generic;


namespace AtlasCopcoMaze
{
  public class Game
  {
    #region Variables

    private State _currentState { set; get; }
    private Play _play;
    private IMazeIntegration _mazeIntegration;
    private IRender _render;
    private IInput _input;

    #endregion

    public Game(IMazeIntegration mazeIntegration, IRender render, IInput input)
    {
      _mazeIntegration = mazeIntegration;
      _render = render;
      _input = input;
      _play = new Play();
      _currentState = State.Start;
    }

    #region Pubic interface
    public void Run()
    {
      var key = ConsoleKey.NoName;
      _render.Message(MessageTypes.WelcomeMessage);
      while (!_input.IsEscape(key))
      {
        switch (_currentState)
        {
          case State.Start:
            StartState(key);
            break;
          case State.GameDescription:
            GameDescriptionState();
            break;
          case State.NewGame:
            NewGameState(key);
            break;
          case State.InProgress:
            InProgressState(key);
            break;
          default:
            break;
        }
        key = _input.ReadInput();
      }
    }
    #endregion

    #region private methods 
    private void StartState(ConsoleKey key)
    {
      if (_input.IsOne(key))
      {
        _currentState = State.GameDescription;
      }
    }
    private void GameDescriptionState()
    {
      _input.clearInput();
      _render.GameDescription();
      _currentState = State.NewGame;
    }
    private void NewGameState(ConsoleKey key)
    {
      _input.clearInput();
      var mazeSize = _input.ToNumber(key);
      if (mazeSize == null)
      {
        _render.Message(MessageTypes.InvalidInput);
      }
      else if(mazeSize<=1){ _render.Message(MessageTypes.InvalidInput); }
      else
      {
        _play = new Play();
        _play.MazeSize = mazeSize.Value;
        _mazeIntegration.BuildMaze(_play.MazeSize);
        _play.CurrentRoom = _mazeIntegration.GetEntranceRoom();
        string desc = _mazeIntegration.GetDescription(_play.CurrentRoom);
        _play.VisitedRooms.Add(new Room()
        {
          Description = desc,
          HasTrap = false,
          HasTreasure = false,
          RoomId = _play.CurrentRoom
        });
       
        _render.EntranceRoom(_play.CurrentRoom);
        _render.Message(MessageTypes.Instruction);
        _render.Moves(_play);
        _currentState = State.InProgress;
      }
    }
    private void InProgressState(ConsoleKey key)
    {
      if (_input.IsArrow(key))
      {
        char direction = ' ';
        if (_input.IsUpArrow(key))
        {
          direction = 'N';
        }
        if (_input.IsDownArrow(key))
        {
          direction = 'S';
        }
        if (_input.IsRightArrow(key))
        {
          direction = 'E';
        }
        if (_input.IsLeftArrow(key))
        {
          direction = 'W';
        }

        int? nextRoom = _mazeIntegration.GetRoom(_play.CurrentRoom, direction);
        if (nextRoom == null)
        {
          _render.Message(MessageTypes.outsideMaze);
        }
        else
        {
          _input.clearInput();
          _play.CurrentRoom = nextRoom.Value;
          GetRoomInfo(_play.CurrentRoom);

        }
      }
      else
      {
        _render.Message(MessageTypes.Instruction);
      }
    }
    private void CongratulationsState()
    {
      _render.Congratulations(_play);
      _currentState = State.Start;
    }
    private void GameOverState()
    {
      _render.GameOver(_play);
      _currentState = State.Start;
    }
    private void GetRoomInfo(int roomId)
    {
      _play.Steps = _play.Steps + 1;
      bool hasTrap = false;
      bool hasTreasure = false;

      _play.CurrentRoomDescription = _mazeIntegration.GetDescription(roomId);
      if (_mazeIntegration.CausesInjury(roomId))
      {
        hasTrap = true;
        _play.HP = _play.HP - 1;
        if (_play.HP <= 0)
        {
          GameOverState();
          return;
        }
      }
      if (_mazeIntegration.HasTreasure(roomId))
      {
        hasTreasure = true;
        CongratulationsState();
        return;
      }
      AddToVisitedRooms(roomId, _play.CurrentRoomDescription, hasTrap, hasTreasure);
      _render.Moves(_play);
    }
    private void AddToVisitedRooms(int roomId,string desc,bool hasTrap, bool hasTreasure)
    {
      Room room = new Room();
      room.RoomId = roomId;
      room.Description = desc;
      room.HasTrap = hasTrap;
      room.HasTreasure = hasTreasure;
      _play.VisitedRooms.Add(room);
    }
    #endregion

  }
}
