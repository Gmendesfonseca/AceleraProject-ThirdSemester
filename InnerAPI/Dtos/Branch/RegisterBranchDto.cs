using InnerAPI.Dtos.Courses;
using InnerAPI.Dtos.Groups;
using InnerAPI.Dtos.Notification;
using InnerAPI.Dtos.Post;
using InnerAPI.Dtos.Student;
using InnerAPI.Dtos.Professor;
using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Branch
{
    public record class RegisterBranchDto
    (
        [Required] uint Id,
        [Required][StringLength(100)] string Name,
        [Required][StringLength(60)][EmailAddress] string Email,
        [Required][MinLength(8)][MaxLength(20)] string Password,
        [Required][StringLength(50)] string Domain,
        [Required][StringLength(14)] string Cnpj,
        [StringLength(100)] string? HeadOfficeId,
        [StringLength(100)] string? Address = null,
        [StringLength(200)] string? About = null,
        DateOnly? DataCriacao = null,
        List<CourseDto>? Courses = null,
        List<StudentDto>? Students = null,
        List<ProfessorDto>? Professors = null
    )
    {
        public bool Status { get; init; }
        public Stack<NotificationDto> Notifications { get; init; } = new Stack<NotificationDto>();
        public Stack<PostDto> Postagens { get; init; } = new Stack<PostDto>();
        public List<GroupsDto> Grupos { get; init; } = new List<GroupsDto>();
    }
}
