using System.ComponentModel.DataAnnotations;

namespace BlogNewsApp.Entity
{
    public class Post
    {
		// Base Attributes
		#region Base Attributes
		[Key]
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Url { get; set; }
        public DateTime PostDate { get; set; }
        public bool isActive { get; set; }
        #endregion

        // Relations
        #region Relations
        public int UserId { get; set; }
        public User user { get; set; } = null!;

        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
        #endregion
    }
}