namespace CarBookProject.Dto.CommentDtos;

public class ResultCommentDto
{
    public int CommentID { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public string BlogTitle { get; set; }
    public string AuthorName { get; set; }
    public string AuthorImageUrl { get; set; }
    public string CategoryName { get; set; }

    public string NameInitials
    {
        get
        {
            if (string.IsNullOrWhiteSpace(Name))
                return "";

            var parts = Name.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return string.Join("", parts.Select(x => x[0])).Substring(0, Math.Min(2, parts.Count())).ToUpper();
        }
    }
}
