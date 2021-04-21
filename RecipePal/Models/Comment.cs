
namespace RecipePal.Models
{
    public class Comment : BaseEntity, ISocialElement
    {
        public int UserId { get; set; }
        public int CookbookId { get; set; }
        public string Text { get; set; }

        public User User { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}
