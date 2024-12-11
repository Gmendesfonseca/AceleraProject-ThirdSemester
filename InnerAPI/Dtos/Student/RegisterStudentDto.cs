using InnerAPI.Dtos.Groups;
using InnerAPI.Dtos.Notification;
using InnerAPI.Dtos.Post;
using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Aluno
{
    public record class RegisterStudentDto
    (
        [Required] int Id,
        [Required][StringLength(100)] string Name,
        [Required][EmailAddress][StringLength(60)] string Email,
        [Required][MinLength(8)][MaxLength(20)] string Password,
        [Required][StringLength(11)] string Cpf,
        [Required][StringLength(100)] string Curso,
        [Required][StringLength(50)] string Periodo,
        [Required] uint Pontuacao,
        [Required][StringLength(20)] string Matricula,
        [Required] DateOnly BirthDate,
        [Required][StringLength(100)] string Instituicao,
        [Required] uint InstitutionId
    )
    {
        public bool Status { get; init; }
        public Stack<NotificationDto> Notifications { get; init; } = new Stack<NotificationDto>();
        public Stack<PostDto> Postagens { get; init; } = new Stack<PostDto>();
        public List<GroupsDto> Grupos { get; init; } = new List<GroupsDto>();
    }
}

