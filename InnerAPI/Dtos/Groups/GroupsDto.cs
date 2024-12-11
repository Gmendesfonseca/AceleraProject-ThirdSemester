using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Groups
{
    public record class GroupsDto
    (
        [Required] uint IdGroup,
        [Required] string NameGroup,
        [Required] DateOnly DateCreationGroup,
        [Required] uint NumMembers,
        [Required] uint NumAdmins,
        [Required] uint NumPosts,
        [Required] uint NumNotifications
    )
    {
        public uint IdGroup { get; init; } = IdGroup;
        public string NameGroup { get; init; } = NameGroup;
        public DateOnly DateCreationGroup { get; init; } = DateCreationGroup;
        public uint NumMembers { get; init; } = NumMembers;
        public uint NumAdmins { get; init; } = NumAdmins;
        public uint NumPosts { get; init; } = NumPosts;
        public uint NumNotifications { get; init; } = NumNotifications;
    }
}
