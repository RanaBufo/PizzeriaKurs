using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Models
{
    public class Pizza
    {
        [Key]
        public string IDPizza { get; set; }
        public string PizzaName { get; set; }
        public double PizzaPrice { get; set; }
        public string PizzaImage { get; set; }
        public string IDSauce { get; set; }
        public bool Mozzarella { get; set; }
        public bool Parmesan { get; set; }
        public bool Door_blue { get; set; }
        public bool Brynza { get; }
    }
}
