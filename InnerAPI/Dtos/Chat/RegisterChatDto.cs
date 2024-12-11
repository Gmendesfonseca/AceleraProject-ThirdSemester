using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Chat
{
    public record class RegisterChatDto
    (
        [Required] uint IdUser1,
        [Required] uint IdUser2
    );
}
