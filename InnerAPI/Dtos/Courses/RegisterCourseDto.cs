using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Courses
{
    public record class RegisterCourseDto
    (
      [Required] string Name,
      string Description,
      [Required] string Workload,
      [Required] string Period
    )
    {
        public string Name { get; init; } = Name;
        public string Description { get; init; } = Description;
        public string Workload { get; init; } = Workload;
        public string Period { get; init; } = Period;
    }
}
