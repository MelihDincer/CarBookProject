namespace CarBookProject.Application.Features.Mediator.Results.BlogResults;

public class GetLast3BlogsWithAuthorQueryResult
{
    public int BlogID { get; set; }
    public string Title { get; set; }
    public string AuthorName { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
}
