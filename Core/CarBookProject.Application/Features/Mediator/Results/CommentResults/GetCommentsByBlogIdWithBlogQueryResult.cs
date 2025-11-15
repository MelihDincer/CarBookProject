namespace CarBookProject.Application.Features.Mediator.Results.CommentResults;

public class GetCommentsByBlogIdWithBlogQueryResult
{
    public int CommentID { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public string BlogTitle { get; set; }
    public string AuthorName { get; set; }
    public string CategoryName { get; set; }
}
