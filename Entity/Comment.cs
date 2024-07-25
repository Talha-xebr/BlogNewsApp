using System.ComponentModel.DataAnnotations;

namespace BlogNewsApp.Entity
{
	public class Comment
	{
		// Base Attributes
		#region Base Attributes
		[Key]
        public int CommentId { get; set; }
        public string? Text { get; set; }
        public DateTime CommentDate { get; set; }

		#endregion

		// Relations
		#region Relations
		// User
		// We don't need UserId but it won't hurt using it
		public int UserId { get; set; }
        public User user { get; set; } = null!;

        // Post
		// Same thing as UserId
        public int PostId { get; set; }
		public Post post { get; set; } = null!;

		#endregion
	}
}
