using SimpleInjector;

namespace AtlasCopcoMaze
{
  class Program
  {
    //The Maze is working with dummyIntegration 3x3 ... please use maze size 3 to show the output
    // you can change the maze size by changing the dummyIntegartion

    /// <summary>
      /// here we use the dependency Injection to reduce dependency and make it easy to test
      /// </summary>
    private static Container _container;
    static Program()
    {
      _container = new Container();
      _container.Register<IMazeIntegration, DummykMazeIntegration>();
      _container.Register<IRender, ConsoleRender>();
      _container.Register<IInput, ConsoleInput>();
      _container.Register<Game>();
    }
    
    static void Main(string[] args)
    {
      Game game = _container.GetInstance<Game>();
      game.Run();
    }
  }
}
