using System.Collections.Generic;

namespace RecipePal.Models
{
    public class Cookbook : BaseEntity, ISocialElement
    {
        public int UserId { get; set; }

        public string Title { get; set; }
        public string CuisineType { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public User User { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}
