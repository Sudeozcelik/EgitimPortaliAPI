namespace EgitimPortali.API.DTOs
{
    public class CourseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; } // Hata buradaydı, bunu ekledik
        public string InstructorId { get; set; } // Bunu da ekledik
    }
}