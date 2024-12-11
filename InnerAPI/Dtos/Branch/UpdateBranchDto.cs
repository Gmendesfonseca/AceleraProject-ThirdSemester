using InnerAPI.Dtos.Courses;
using InnerAPI.Dtos.Groups;
using InnerAPI.Dtos.Notification;
using InnerAPI.Dtos.Post;
using InnerAPI.Dtos.Professor;
using InnerAPI.Dtos.Student;
using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Branch
{
    public record class UpdateBranchDto
    (
        [Required][StringLength(100)] string Name,
        [Required][StringLength(60)][EmailAddress] string Email,
        [Required][MinLength(8)][MaxLength(20)] string Password,
        [Required][StringLength(50)] string Domain,
        [Required][StringLength(14)] string Cnpj,
        [StringLength(100)] string Address,
        DateOnly CreationDate,
        List<CourseDto>? Courses,
        List<StudentDto>? Students,
        List<ProfessorDto>? Professors,
        [StringLength(500)] string? About = null

    )
    {
        public bool Status { get; init; }
        public Stack<NotificationDto> Notifications { get; init; } = new Stack<NotificationDto>();
        public Stack<PostDto> Postagens { get; init; } = new Stack<PostDto>();
        public List<GroupsDto> Grupos { get; init; } = new List<GroupsDto>();
        public string About { get; init; } = About;

    }
}
