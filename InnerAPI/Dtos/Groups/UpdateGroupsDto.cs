using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Groups
{
    public record class UpdateGroupDto
    (
        [Required] uint IdGroup,
        string NameGroup,
        DateOnly? DateCreationGroup,
        uint? NumMembers,
        uint? NumAdmins,
        uint? NumPosts,
        uint? NumNotifications
    );
}