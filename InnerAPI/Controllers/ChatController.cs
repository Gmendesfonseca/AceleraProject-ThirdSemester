using InnerAPI.Services;
using InnerAPI.Dtos.Chat;
using InnerAPI.Models.Chat;


namespace InnerAPI.Controllers
{
    public static class ChatController
    {
        public static RouteGroupBuilder MapChatEndpoint(this WebApplication app, SharedService  sharedServices)
        {
            ChatServices chatServices = new ChatServices(sharedServices);
            var group = app.MapGroup("chat").WithParameterValidation();

            //GET /{id}/chats

            //GET /{id}/chats
            group.MapGet("/{id}/chats", (int id) =>
            {
                var chats = chatServices.GetChats().Where(s => s.UserId1 == id || s.UserId2 == id);
                var chatTypes = chats.Select(chat => chatServices.GetChatById(chat.Id));
                return Results.Ok(chatTypes);
                // return Results.Ok(chatServices.GetChats().Where(s => s.UserId1 == id || s.UserId2 == id));
            });


            //group.MapGet("/{id}/chats", (int id) =>
            //{
            //    var chats = chatServices.GetChats().Where(s => s.UserId1 == id || s.UserId2 == id);
            //    var Chat = chats.Select(chat => chatServices.GetChatById(chat.Id));
            //    return Results.Ok(Chat);
            //    //return Results.Ok(chatServices.GetChats().Where(s => s.UserId1 == id || s.UserId2 == id));
            //});

            // GET /chat/{id}
            group.MapGet("/{id}", (int id) =>
            {
                var chat = chatServices.GetChatById(id);
                return chat == null ? Results.NotFound() : Results.Ok(chat);
            });

            //// GET /chat/{id}
            //group.MapGet("/{id}", (int id) =>
            //{
            //    return Results.Ok(chatServices.GetChats().FirstOrDefault(s => s.Id == id));
            //});

            // POST /chat/register
            group.MapPost("/register", (RegisterChatDto newChat) =>
            {
                Chat chat = chatServices.Register(newChat);
                var chatType = chatServices.GetChatById(chat.Id);
                return Results.Created($"/chat/{chat.Id}", chat);
            });

            // PUT /chat/{id}
            group.MapPut("/{id}", (int id, Chat updatedChat) =>
            {

                var result = chatServices.Update(id, updatedChat);
                return result == null ? Results.NotFound() : Results.Ok(result);

                //var result = chatServices.Update(id, updatedChat);
                //if (result == null)
                //{
                //    return Results.NotFound();
                //}
                //return Results.Ok(result);
            });

            // DELETE /chat/{id}
            group.MapDelete("/{id}", (int id) =>
            {
                bool deleted = chatServices.Delete(id);
                return deleted ? Results.NoContent() : Results.NotFound();
                //if (!deleted)
                //{
                //    return Results.NotFound();
                //}
                //return Results.NoContent();
            });

            return group;
        }
    }
}
