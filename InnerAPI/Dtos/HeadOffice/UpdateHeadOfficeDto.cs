using InnerAPI.Dtos.Branch;
using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos
{
    public record class UpdateHeadOfficeDto
    (
        [Required] uint Id,
        [Required] string Name,
        [Required][EmailAddress] string Email,
        [Required] string Address,
        [Required] string CNPJ,
        [Required] string Domain,
        [Required] string Password,
        List<BranchDto>? Branches = null,
        [StringLength(500)] string? About = null
    )
    {
        public uint Id { get; init; } = Id;
        public string Name { get; init; } = Name;
        public string Email { get; init; } = Email;
        public string Address { get; init; } = Address;
        public string CNPJ { get; init; } = CNPJ;
        public string Domain { get; init; } = Domain;
        public string Password { get; init; } = Password;
        public List<BranchDto>? Branches { get; init; } = Branches ?? new List<BranchDto>();
    }
}
