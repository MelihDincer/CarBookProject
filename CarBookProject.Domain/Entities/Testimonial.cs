namespace CarBookProject.Domain.Entities;

public class Testimonial
{
    public int TestimonialID { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }

    public Testimonial()
    {

    }

    public Testimonial(string name, string title, string comment, string imageUrl)
    {
        Name = name;
        Title = title;
        Comment = comment;
        ImageUrl = imageUrl;
    }
}
