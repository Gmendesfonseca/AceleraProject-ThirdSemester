using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Category
{
    public record CategoryDto
    (
        [Required] uint IdCategory,
        [Required] string NameCategory
    )
    
    {
       public uint IdCategory { get; init; } = IdCategory;
       public string NameCategory { get; init; } = NameCategory;
   }
}

#region antigo
// using System.ComponentModel.DataAnnotations;

// namespace InnerAPI.Dtos.Category
// {
//     public record class CategoryDto
//     (
//         [Required] uint IdCategory,
//         [Required] string NameCategory
//     )
//     {
//         public uint IdCategory { get; init; } = IdCategory;
//         public string NameCategory { get; init; } = NameCategory;
//     }
// }
#endregion antigo