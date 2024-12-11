using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Profile
{
    public record class ProfileDto
    (
        [Required] uint IdProfile,
        [Required] string Name,
        [Required] string Email,
        [Required] DateOnly DateCreation,
        string? ProfileImage //Não sei se ta certo, considerei que seria o caminho da imagem 
    )
    {
        public uint IdProfile { get; init; } = IdProfile;
        public string Name { get; init; } = Name;
        public string Email { get; init; } = Email;
        public DateOnly DateCreation { get; init; } = DateCreation;
        public string ProfileImage { get; init; } = ProfileImage;
    }
}
