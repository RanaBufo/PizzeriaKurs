﻿using Pizzeria.Models;

namespace Pizzeria.Services
{
    public class PizzaService
    {
        private readonly ApplicationDbContext _db;
        public PizzaService(ApplicationDbContext db) { _db = db; }
        public string FindIdPizza()
        {
            List<Pizza> pizas = _db.Pizzas.ToList();
            string maxId;
            if (pizas.Count > 0)
            {
                maxId = "Piz" + (int.Parse(pizas[^1].IDPizza.Substring(3)) + 1).ToString();
            }
            else maxId = "WR1";
            return maxId;
        } 
        public void AddPizza(PizzaAddModel ppizzaAddModel, List<string> SlectedFillings, List<string> SSouse)
        {
            if(ppizzaAddModel.PizzaName == null)
            {
                ppizzaAddModel.PizzaName = "New PIZZA";
            }
            string? id = null;
            string str = "";
            foreach (var filling in SlectedFillings)
            {
                var _filling = _db.Fillings.FirstOrDefault(f => f.NameFilling == filling);
                if (str != "")
                {
                    str += ", " + filling;
                }
                else str = filling;

                ppizzaAddModel.PizzaPrice += _filling.PriceFilling;
            }
            foreach (var filling in SSouse)
            {
                var _filling = _db.Sauces.FirstOrDefault(f => f.NameSauce == filling);
                str += ", " + filling;
                ppizzaAddModel.PizzaPrice += _filling.PriceSause;
                id = _filling.IDSauce;
                break;
            }
            if (ppizzaAddModel.PizzaImage == null)
            {
                ppizzaAddModel.PizzaImage = "1.png";
            }
            var newpizza = new Pizza
            {
                IDPizza = FindIdPizza(),
                PizzaName = ppizzaAddModel.PizzaName,
                PizzaImage = ppizzaAddModel.PizzaImage,
                PizzaPrice = ppizzaAddModel.PizzaPrice,
                Description = str,
                IDSauce = id

            };
            _db.Pizzas.Add(newpizza);
            _db.SaveChanges();
        }
    }
}
