using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Follower
{
    public record class FollowerDto
    (
        [Required] uint IdFollower,
        [Required] string NameFollower, 
         List<FollowerDto> Followers
    )
    {
        public List<FollowerDto> Followers { get; set; } = Followers ?? new List<FollowerDto>();
    }
}