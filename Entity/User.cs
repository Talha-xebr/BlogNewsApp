using System.ComponentModel.DataAnnotations;

namespace BlogNewsApp.Entity
{
	public class User
	{
		// Base Attributes
		#region Base Attributes
		[Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Image { get; set; }
        public string? AboutMe { get; set; }
        public bool isAdmin { get; set; }

        #endregion

        // Relations

        #region Relations
        public List<Post> Posts { get; set; } = new List<Post>();

        public List<Comment> Comments { get; set; } = new List<Comment>();
        #endregion
    }
}
