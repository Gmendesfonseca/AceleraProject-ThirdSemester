using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Groups
{
    public record class CreateGroupsDto
    (
        [Required] string NameGroup,
        [Required] DateOnly DateCreationGroup,
        [Required] uint NumMembers,
        [Required] uint NumAdmins,
        [Required] uint NumPosts,
        [Required] uint NumNotifications
    );
}
