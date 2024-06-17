namespace CarBookProject.Domain.Entities;

public class Category
{
    //Blog Category
    public int CategoryID { get; set; }
    public string Name { get; set; }
    public List<Blog> Blogs { get; set; }
}
