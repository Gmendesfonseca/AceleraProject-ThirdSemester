using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Post
{
    public record class UpdatePostDto
    (
        [Required] uint IdPost,
        uint InstitutionId, 
        string TitlePost = null, 
        List<string> Comments = null, 
        List<string> ContentPost = null,
        uint? NumLikes = null
    )
    {
        public uint IdPost { get; init; } = IdPost;
        public string TitlePost { get; init; } = TitlePost;
        public List<string> Comments { get; init; } = Comments ?? new List<string>();
        public List<string> ContentPosts { get; init; } = ContentPost ?? new List<string>();
        public uint InstitutionId { get; init; } = InstitutionId;

    }
}
