using la_mia_pizzeria_razor_layout.Models.Form;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.Metrics;

namespace la_mia_pizzeria_razor_layout.Models.Repositories
{
    public class InMemoryPizzaRepository : IDbPizzaRepository
    {
        public static List<Pizza> Pizzas = new List<Pizza>();

        public static List<Category> Categories = new List<Category>();

        public static List<Tag> Tags = new List<Tag>();
        private static int counter = 1;



        public InMemoryPizzaRepository()
        {
            
        }

        //ritorna gli oggetti presenti nella lista
        public List<Pizza> All()
        {
            return Pizzas;
        }

        public List<Category> AllCategory()
        {
            return Categories;
        }

        public List<Tag> AllTag()
        {
            return Tags;
        }


 

        public void Create(Pizza pizza, List<int> selectedTags)
        {
            
            pizza.Id = counter;
            counter++;

            pizza.Category = GetByIdCategory(pizza.CategoryId);

            
            pizza.Tags = new List<Tag>();

            foreach (int tagId in selectedTags)
            {
                pizza.Tags.Add(GetByIdTag(tagId));
            }


            Pizzas.Add(pizza);
        }

        public void Delete(Pizza pizza)
        {
            Pizzas.Remove(pizza);
        }

        public void DeleteCategory(Category categories)
        {
            Categories.Remove(categories);
        }

        public void DeleteTag(Tag tag)
        {
            Tags.Remove(tag);
        }

        public Pizza GetById(int id)
        {
            Pizza pizza = Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

            pizza.Category = GetByIdCategory(pizza.CategoryId);




            return pizza;
        }

        public Category GetByIdCategory(int id)
        {
            Category category = Categories.Where(C => C.Id == id).FirstOrDefault();

           

            return category;
        }

        public Tag GetByIdTag(int id)
        {
            Tag tag = Tags.Where(t => t.Id == id).FirstOrDefault();



            return tag;
        }


        public void Update(Pizza pizza, Pizza pizzaData, List<int>? selectedTags)
        {
            pizza = pizzaData;
            pizza.Category = pizzaData.Category;

            pizza.Tags = new List<Tag>();



           

            foreach (int tagId in selectedTags)
            {
                pizza.Tags.Add(GetByIdTag(tagId));
            }



        }

        public void AddCategory(Category category)
        {
            //Random rnd = new Random();
            category.Id = counter;
            counter++;

            category.Pizza = new List<Pizza>();

            Categories.Add(category);

        }

        public void AddTag(Tag tag)
        {
            tag.Id = counter;
            counter++;

            tag.Pizzas = new List<Pizza>();

            Tags.Add(tag);

        }

        public List<Pizza> SearchByTitle(string? Name)
        {
            if (Name == null)
                return Pizzas.ToList();

            return Pizzas.Where(pizza => pizza.Name.ToLower().Contains(Name.ToLower())).ToList();
        }






    }



}

