using System.Collections.Generic;

namespace RecipePal.Models
{
    public class Recipe : BaseEntity, ISocialElement
    {
        public int CookbookId { get; set; }

        public string Title { get; set; }

        public ICollection<Note> Notes { get; set; }
        public Cookbook Cookbook { get; set; }

        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
