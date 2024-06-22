﻿namespace CarBookProject.Application.Features.Mediator.Results.BlogResults;

public class GetBlogByIdWithAuthorQueryResult
{
    public int BlogID { get; set; }
    public string AuthorDescription { get; set; }
    public string AuthorImageUrl { get; set; }
    public string AuthorName { get; set; }
}