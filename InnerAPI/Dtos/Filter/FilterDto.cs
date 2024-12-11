using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Filter
{
    public record class FilterDto
    (
        [Required] uint IdFilter,
        [Required] string NameFilter
    )
    {
        public uint IdFilter { get; init; } = IdFilter;
        public string NameFilter { get; init; } = NameFilter;
    }
}
