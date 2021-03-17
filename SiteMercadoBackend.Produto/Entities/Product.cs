using System;
namespace SiteMercadoBackend.Produto.Entities {
    public class Product : Entity
    {
        public Product(string name, decimal price, string imagePath)
        {
            Name = name;
            Price = price;
            ImagePath = imagePath;
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string ImagePath { get; private set; }

        public void UpdateName(string name){
            Name = name;
        }
        public void UpdatePrice(decimal price){
            Price = price;
        }
        public void UpdateImagePath(string imagePath){
            ImagePath = imagePath;
        }
        
    }

}