using System;
using System.Collections.Generic;

namespace EgitimPortali.API.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // --- İLİŞKİLER (Navigation Properties) ---

        // Her kursun bir kategorisi olmalı (Zorunlu)
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Eğitmen bağlantısı (Nullable yaptık: Hata almamak için ?)
        // Bu sayede kurs eklerken eğitmen atamak zorunda kalmıyoruz
        public string? InstructorId { get; set; }
        public AppUser? Instructor { get; set; }

        // Bir kursun birden fazla dersi olabilir
        public ICollection<Lesson> Lessons { get; set; }

        // Bir kursa birden fazla öğrenci kayıt olabilir
        public ICollection<Enrollment> Enrollments { get; set; }

        // Bir kursa birden fazla yorum ve puan verilebilir
        public ICollection<Review> Reviews { get; set; }

        // Bir kursun satış kayıtları (Finansal işlemler)
        public ICollection<Transaction> Transactions { get; set; }
    }
}