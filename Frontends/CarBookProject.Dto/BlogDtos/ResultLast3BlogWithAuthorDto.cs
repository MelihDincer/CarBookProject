namespace CarBookProject.Dto.BlogDtos;

public class ResultLast3BlogWithAuthorDto
{
    public int BlogID { get; set; }
    public string Title { get; set; }
    public string AuthorName { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CategoryName { get; set; }
}
