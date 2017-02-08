using Nancy;
using Tamagotchis.Objects;
using System.Collections.Generic;


namespace Tamagotchis
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
        return View["index.cshtml", allTamagotchis];
      };

      Get["/tamagotchis/new"] = _ => {
      return View["new_pet.cshtml"];
      };

      Get["/tamagotchis/{id}"] = parameters => {
       Tamagotchi tamagotchi = Tamagotchi.Find(parameters.id);
       return View["tamagotchi.cshtml", tamagotchi];
     };

      Post["/tamagotchis/food/{id}"] = parameters => {
        Tamagotchi tamagotchi = Tamagotchi.Find(parameters.id);
        tamagotchi.AddFood();
        return View["tamagotchi.cshtml", tamagotchi];
      };

      Post["/tamagotchis/attention/{id}"] = parameters => {
        Tamagotchi tamagotchi = Tamagotchi.Find(parameters.id);
        tamagotchi.AddAttention();
        return View["tamagotchi.cshtml", tamagotchi];
      };

      Post["/tamagotchis/rest/{id}"] = parameters => {
        Tamagotchi tamagotchi = Tamagotchi.Find(parameters.id);
        tamagotchi.AddRest();
        return View["tamagotchi.cshtml", tamagotchi];
      };

      Post["/"] = _ => {
        Tamagotchi newTamagotchi = new Tamagotchi(Request.Form["new-pet"]);
        List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
        return View["index.cshtml", allTamagotchis];
      };

      Post["/tamagotchis_cleared"] = _ => {
        Tamagotchi.ClearAll();
        return View["tamagotchis_cleared.cshtml"];
      };

    }
  }
}
