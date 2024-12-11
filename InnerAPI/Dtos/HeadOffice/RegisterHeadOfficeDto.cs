using InnerAPI.Dtos.Branch;
using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.HeadOffice
{
    public record class RegisterHeadOfficeDto
    (
        [Required] string Name,
        [Required] string Email,
        [Required] [MinLength(8)] string Password,
        [Required] string Address,
        [Required] string About,
        [Required] DateOnly CreationDate,
        [Required] string CNPJ,
        [Required] string Domain
    )
    {
        public string Name { get; init; } = Name;
        public string Email { get; init; } = Email;
        public string Password { get; init; } = Password;
        public string Address { get; init; } = Address;
        public DateOnly CreationDate { get; init; } = CreationDate;
        public string CNPJ { get; init; } = CNPJ;
        public string Domain { get; init; } = Domain;
    }
}
