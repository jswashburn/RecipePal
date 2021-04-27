
namespace RecipePal.Models
{
    public class Comment : SocialElement
    {
        public int UserId { get; set; }
        public int CookbookId { get; set; }
        public string Text { get; set; }

        public RPUser User { get; set; }
    }
}
