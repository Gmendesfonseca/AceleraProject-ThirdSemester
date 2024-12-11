using InnerAPI.Dtos.Branch;
using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.HeadOffice
{
    public record class HeadOfficeDto
    (
        [Required] uint Id,
        [Required] string Name,
        [Required] string Email,
        [Required] string Address,
        [Required] DateOnly CreationDate,
        [Required] string CNPJ,
        [Required] string Domain,
        List<BranchDto> Branches
    )
    {
        public uint Id { get; init; } = Id;
        public string Name { get; init; } = Name;
        public string Email { get; init; } = Email;
        public string Address { get; init; } = Address;
        public DateOnly CreationDate { get; init; } = CreationDate;
        public string CNPJ { get; init; } = CNPJ;  
        public string Domain { get; init; } = Domain;
        public List<BranchDto> Branches { get; init; } = Branches ?? new List<BranchDto>();
    }
}
