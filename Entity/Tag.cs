using System.ComponentModel.DataAnnotations;

namespace BlogNewsApp.Entity
{
	public class Tag
	{
        // Base Attributes
        #region Base Attributes
        [Key]
        public int TagId { get; set; }
        public string? TagName { get; set; }
        public string? Url { get; set; }

        // Tag Color ????

        #endregion

        // Relations
        #region Relations
        public List<Post> Posts { get; set; } = new List<Post>();

        #endregion
    }
}
