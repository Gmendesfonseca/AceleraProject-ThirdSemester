
 using System.ComponentModel.DataAnnotations;

 namespace InnerAPI.Dtos.Notification
 {
     public record class NotificationDto
     (
         [Required] uint IdNotification,
         [Required] string TitleNotification
     )
     {
         public uint IdNotification { get; init; } = IdNotification;
         public string TitleNotification { get; init; } = TitleNotification;
     }

 }
