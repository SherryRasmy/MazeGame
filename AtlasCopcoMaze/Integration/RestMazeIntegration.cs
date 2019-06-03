using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AtlasCopcoMaze
{
  public class RestMazeIntegration : IMazeIntegration
  {
    private string _baseUrl;
    public RestMazeIntegration(string baseUrl)
    {
      _baseUrl = baseUrl;
    }
    public void BuildMaze(int size)
    {
      HttpClient client = new HttpClient();
      client.PostAsync($"{_baseUrl}/BuildMaze?size={size}",new StringContent("")).Wait();
    }

    public bool CausesInjury(int roomId)
    {
      HttpClient client = new HttpClient();
      var result = client.GetAsync($"{_baseUrl}/CausesInjury?room={roomId}").Result;
      return bool.Parse(result.Content.ReadAsStringAsync().Result);
    }

    public string GetDescription(int roomId)
    {
      HttpClient client = new HttpClient();
      var result = client.GetAsync($"{_baseUrl}/GetDescription?room={roomId}").Result;
      return result.Content.ReadAsStringAsync().Result;
    }

    public int GetEntranceRoom()
    {
      HttpClient client = new HttpClient();
      var result = client.GetAsync($"{_baseUrl}/GetEntranceRoom").Result;
      return int.Parse(result.Content.ReadAsStringAsync().Result);
    }

    public int? GetRoom(int roomId, char direction)
    {
      HttpClient client = new HttpClient();
      var result = client.GetAsync($"{_baseUrl}/GetRoom?roomid={roomId}&dir={direction}").Result;
      return int.Parse(result.Content.ReadAsStringAsync().Result);
    }

    public bool HasTreasure(int roomId)
    {
      HttpClient client = new HttpClient();
      var result = client.GetAsync($"{_baseUrl}/HasTreasure?roomid={roomId}").Result;
      return bool.Parse(result.Content.ReadAsStringAsync().Result);
    }
  }
}
