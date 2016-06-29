using System.Collections.Generic;

namespace TamagotchiList
{
  public class Tamagotchi
  {
    private string _name;
    private int _hunger;
    private int _entertainment;
    private int _tiredness;
    private int _id;
    private bool _dead;
    private static Dictionary<string, Tamagotchi> _tamagotchis = new Dictionary<string, Tamagotchi>(){};
    // private static List<Tamagotchi> _tamagotchis = new List<Tamagotchi> {};

    public Tamagotchi (string name)
    {
      _name = name;
      _hunger = 1;
      _entertainment = 1;
      _tiredness = 1;
      _dead = false;
      _tamagotchis.Add(this._name, this);
      _id = _tamagotchis.Count;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public bool GetDead()
    {
      return _dead;
    }
    public void SetDead(bool newDead)
    {
      _dead = newDead;
    }
    public int GetHunger()
    {
      return _hunger;
    }
    public void SetHunger()
    {
      _hunger += 5;
    }
    public int GetEntertainment()
    {
      return _entertainment;
    }
    public void SetEntertainment()
    {
      _entertainment +=5;
    }
    public int GetTiredness()
    {
      return _tiredness;
    }
    public void SetTiredness()
    {
      _tiredness +=5;
    }
    public int GetId()
    {
      return _id;
    }
    public static Dictionary<string, Tamagotchi> GetAll()
    {
      return _tamagotchis;
    }
    // public static Tamagotchi Find(int searchId){
    //   return _tamagotchis[searchId-1];
    // }
    public static Tamagotchi Find(string tama){
      return _tamagotchis[tama];
    }
    public static void ClearAll()
    {
      _tamagotchis.Clear();
    }
    public void TimePass(){
      if(_hunger <= 0 || _entertainment <= 0 || _tiredness <= 0){
        _dead = true;
      }
      else{
        _hunger -= 1;
        _entertainment -= 1;
        _tiredness -= 1;
      }
    }
  }
}
