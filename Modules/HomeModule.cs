using Nancy;
using System.Collections.Generic;
using TamagotchiList;

namespace TamagotchiList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/Tamagotchis"] = _ => {
        Dictionary<string, Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
        return View["Tamagotchis.cshtml", allTamagotchis];
      };
      Get["/Tamagotchis/new"] = _ =>{
        return View["Tamagotchi_form.cshtml"];
      };
      Post["/Tamagotchis"] = _ =>{
        string word = Request.Form["new-Tamagotchi"];

        Dictionary<string, Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
        if(allTamagotchis.ContainsKey(word)){
          return View["/wrong.cshtml"];
        }
        else{
          Tamagotchi newTamagotchi = new Tamagotchi (word);
          return View["Tamagotchis.cshtml", allTamagotchis];
        }

      };
      Get["/Tamagotchis/{id}"] = parameters => {
        Tamagotchi tamagotchi = Tamagotchi.Find(parameters.id);
        return View["/Tamagotchi.cshtml", tamagotchi];
      };
      Post["/TamagotchiFeed/{name}"] = parameters => {
        Tamagotchi tamagotchi = Tamagotchi.Find(parameters.name);
        tamagotchi.SetHunger();
        return View["/Tamagotchi.cshtml", tamagotchi];
      };
      Post["/TamagotchiSleep/{id}"] = parameters => {
        Tamagotchi tamagotchi = Tamagotchi.Find(parameters.id);
        tamagotchi.SetTiredness();
        return View["/Tamagotchi.cshtml", tamagotchi];
      };
      Post["/TamagotchiPlay/{id}"] = parameters => {
        Tamagotchi tamagotchi = Tamagotchi.Find(parameters.id);
        tamagotchi.SetEntertainment();
        return View["/Tamagotchi.cshtml", tamagotchi];
      };
      Post["/TamagotchiTime"] = parameters => {
        //Tamagotchi tamagotchi = Tamagotchi.Find(parameters.id);
        Dictionary<string, Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
        foreach(var tama in allTamagotchis){
          tama.Value.TimePass();
        }

        return View["/Tamagotchis.cshtml", allTamagotchis];
      };
    }
  }
}
