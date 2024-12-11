using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Post
{
    public record class PostDto
    (
        [Required] uint IdPost,
        [Required] string TitlePost,
        [Required] uint NumLikes,
        [Required] List<string> Comments,  
        [Required] string ContentPost,
        [Required] DateOnly DatePost,
        [Required] uint CreatorId,
        [Required] uint InstitutionId

    )
    {
        public string TitlePost { get; init; } = TitlePost;
        public List<string> Comments { get; init; } = Comments; 
        public string ContentPosts { get; init; } = ContentPost; 
        public DateOnly DatePost { get; init; } = DatePost;
        public uint CreatorId { get; init;} = CreatorId;
        public uint InstitutionId { get; init; } = InstitutionId;
        public uint IdPost { get; init; } = IdPost;

    }
}