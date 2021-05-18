using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projet_pizza
{
    class PizzaPersonnalisee : Pizza
    {
        static int nbPizzasPersonnalisee = 0;

        public PizzaPersonnalisee() : base("Personnalisée", 5f, null, false)
        {
            nbPizzasPersonnalisee++;
            nom = $"Personnalisée {nbPizzasPersonnalisee}";


            ingredients = new List<string>();
            

            while (true)
            {
                Console.Write($"Rentrez un ingrédient pour la pizza personnalisée {nbPizzasPersonnalisee} (ENTER pour terminer) : ");
                var ingredient = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ingredient))
                {
                    break;
                }
                if (ingredients.Contains(ingredient))
                {
                    Console.WriteLine("ERREUR : Cet ingrédient est déjà dans la liste");
                }
                else
                {
                    ingredients.Add(ingredient);
                    Console.WriteLine(string.Join(", ", ingredients));
                }
                
                
                Console.WriteLine();
            }
            prix = 5 + ingredients.Count * 1.5f;
        }
        
    }
    class Pizza
    {

        protected string nom;
        public float prix { get; protected set; }
        public bool vegetarienne { get; private set; }
        public List<string> ingredients { get; protected set; }


        public Pizza(string nom, float prix, List<string> ingredients, bool vegetarienne = false)
        {
            this.nom = nom;
            this.prix = prix;
            this.vegetarienne = vegetarienne;
            this.ingredients = ingredients;
        }


        public void Afficher()
        {
            string badgeVegetarienne = vegetarienne ? "(V)" : "";

            string nomAfficher = FormatPremiereLettreMajuscules(nom);


            var ingredientAfficher = ingredients.Select(i => FormatPremiereLettreMajuscules(i)).ToList();

            Console.WriteLine($"{nomAfficher} {badgeVegetarienne} - {prix}€");
            Console.WriteLine($"{string.Join(", ", ingredientAfficher)}");
            Console.WriteLine();
            
        }

        private static string FormatPremiereLettreMajuscules(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            

            string minuscules = s.ToLower();
            string majuscules = s.ToUpper();

            string resultat = majuscules[0] + minuscules.Substring(1);

            return resultat;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            

            var pizzas = new List<Pizza>
            {
                new Pizza("hawaienne",10.5f, new List<string>() {"parmesan rapé", "poivre du moulin", "tomate", "curry", "paprika", "farine", "poulet", "ananas" }),
                new Pizza("napolitaine",11.5f, new List<string>() { "sel", "poivre", "huile d'olive", "tomate", "anchois", "oignons" }),
                new Pizza("4 saisons",11.5f, new List<string>() { "parmesan", "chorizo", "tomate", "aubergine", "champignon", "jambon" }, true),
                new Pizza("oriental",12.5f, new List<string>() { "basilic", "sucre", "tomate", "ail", "oignon", "huile d'olive" }),
                new Pizza("jambon",10.5f, new List<string>() { "chorizo", "origan", "tomate", "jambon", "mozzarella" }),
                new Pizza("thon",8.5f, new List<string>() { "origan", "herbes de provence", "sel", "câpres égouttées", "thon", "sauce tomates", "fromage blanc 0%" }, true),
                new PizzaPersonnalisee(),
                new PizzaPersonnalisee()
            };


            //var pizzasVegetarienne = pizzas.Where(p => p.vegetarienne).ToList();

            /*pizzas = pizzas.Where(p => p.ingredients.Where(i => i.ToLower().Contains("tomate")).ToList().Count > 0).ToList();

            bool contientTomate = "sauce tomate".Contains("tomate");*/
            

            foreach(var pizza in pizzas)
            {
                pizza.Afficher();
            }

            //var ingredients = new List<string>() { "origan", "herbes de provence", "sel", "câpres égouttées", "thon", "tomates", "fromage blanc 0%" };




        }
    }
}
