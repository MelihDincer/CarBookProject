﻿namespace CarBookProject.Dto.BlogDtos;

public class ResultBlogByIdDto
{
    public int BlogID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverImageUrl { get; set; }
    public string AuthorName { get; set; }
    public string AuthorDescription { get; set; }
    public string AuthorImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
}
