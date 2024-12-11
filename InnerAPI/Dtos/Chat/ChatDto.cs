using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Chat
{
    public record class ChatDto
    (
        [Required] uint IdChat,
        [Required] uint IdUser1,
        [Required] uint IdUser2,
        [Required] DateOnly DateCreation
    );
//     {
//         public uint IdChat { get; init; } = IdChat;
//         public uint IdUser1 { get; init;} = IdUser1;
//         public uint IdUser2 { get; init; } = IdUser2; 
//         public DateOnly DateCreation { get; init; } = DateCreation;
//     }
 }
