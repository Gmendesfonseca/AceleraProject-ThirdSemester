using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Post
{
    public record class RegisterPostDto
    (
        [Required] uint id,
        [Required] uint creatorId,
        [Required] string creatorName,
        [Required] string title,
        [Required] string image,
        [Required] string description,
        [Required] uint institutionId
    );
}
