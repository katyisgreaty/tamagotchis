using System.Collections.Generic;

namespace Tamagotchis.Objects
{
  public class Tamagotchi{
    private string _name;
    private int _food;
    private int _attention;
    private int _rest;
    private int _id;
    private static List<Tamagotchi> _instances = new List<Tamagotchi>{};

    public Tamagotchi(string tamagotchiName)
    {
      _name = tamagotchiName;
      _food = 100;
      _attention = 100;
      _rest = 100;
      _instances.Add(this);
      _id = _instances.Count;
    }
// name
    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public int GetFood()
    {
      return _food;
    }

    public int GetAttention()
    {
      return _attention;
    }

    public int GetRest()
    {
      return _rest;
    }

    public int GetId()
    {
      return _id;
    }

// instances

    public static List<Tamagotchi> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Place Find(int searchId)
    {
      return _instances[searchId-1];
    }

  }
}