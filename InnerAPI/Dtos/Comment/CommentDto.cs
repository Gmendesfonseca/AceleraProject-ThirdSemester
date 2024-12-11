using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Comment
{
  public record class CommentDto
  (
      [Required] string username,
      [Required] string content,
      [Required] DateTime CreatedAt,
      [Required] DateTime? UpdatedAt
  );
}
