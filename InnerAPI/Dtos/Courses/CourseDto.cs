using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Courses
{
    public record class CourseDto
    (
        [Required] int Id,
        [Required] string Name,
        string Description,
        [Required] string Workload,
        [Required] string Period
    )
    {
        public int Id { get; init; } = Id;
        public string Name { get; init; } = Name;
        public string Description { get; init; } = Description;
        public string Workload { get; init; } = Workload;
        public string Period { get; init; } = Period;

    }
}
