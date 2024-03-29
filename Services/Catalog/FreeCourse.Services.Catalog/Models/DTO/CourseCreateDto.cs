﻿namespace FreeCourse.Services.Catalog.Models.DTO
{
    public class CourseCreateDto
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public FeatureDto Feature { get; set; }
       
        public string Description { get; set; }
    }
}
