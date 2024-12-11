using InnerAPI.Dtos.Chat;
using InnerAPI.Models;
using InnerAPI.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InnerAPI.Services
{
    public class ChatServices
    {
        private readonly Dictionary<int, Chat> _chats = new();
        private readonly Dictionary<int, List<MessageType>> _messages = new();
        private int _nextChatId = 1;
        private int _nextMessageId = 1;

        public SharedService sharedServices { get; }

        public ChatServices(SharedService sharedServices)
        {
            this.sharedServices = sharedServices;
        }

        public IEnumerable<Chat> GetChats() => _chats.Values;

        public Chat? GetChatById(int id) => _chats.TryGetValue(id, out var chat) ? chat : null;

        public Chat Register(RegisterChatDto newChat)
        {
            var chat = new Chat
            {
                Id = _nextChatId++,
                UserId1 = newChat.IdUser1,
                UserId2 = newChat.IdUser2,
                DateCreation = DateTime.Now
            };
            _chats[chat.Id] = chat;
            _messages[chat.Id] = new List<MessageType>();
            return chat;
        }

        public Chat? Update(int id, Chat updatedChat)
        {
            if (!_chats.ContainsKey(id)) return null;

            _chats[id] = updatedChat;
            return updatedChat;
        }

        public bool Delete(int id)
        {
            if (!_chats.Remove(id)) return false;

            _messages.Remove(id);
            return true;
        }

        //public void SendMessage(int chatId, int senderId, string text)
        //{
        //    if (!_chats.ContainsKey(chatId)) return;

        //    var user = sharedServices.GetUserById(senderId);
        //    if (user == null) return; // Adicione um tratamento de erro adequado aqui

        //    var message = new MessageType
        //    {
        //        Id = _nextMessageId++,
        //        ChatId = (int)someChatId, // Converta `uint` para `int` explicitamente se necessário
        //        SenderId = someSenderId,
        //        Text = "Your message text",
        //        CreatorName = "Creator name",
        //        CreatorImage = "Image URL",
        //        CreatorAccountType = AccountType.STUDENT, // ou qualquer tipo apropriado
        //        CreatedAt = DateTime.Now,
        //        Timestamp = DateTime.Now
        //    };

        //    if (!_messages.ContainsKey(chatId))
        //    {
        //        _messages[chatId] = new List<MessageType>();
        //    }
        //    _messages[chatId].Add(message);
        //}

        public IEnumerable<MessageType> GetMessages(int chatId)
        {
            return _messages.TryGetValue(chatId, out var messages) ? messages : Enumerable.Empty<MessageType>();
        }

        //public Chat? GetChatDetailsById(int id)
        //{
        //    if (!_chats.TryGetValue(id, out var chat)) return null;

        //    //var user1 = sharedServices.GetUserById((int)chat.UserId1);
        //    //var user2 = sharedServices.GetUserById((int)chat.UserId2);

        //    //if (user1 == null || user2 == null) return null; // Adicione um tratamento de erro adequado aqui

        //    //var lastMessage = _messages.TryGetValue(chat.Id, out var messages) ? messages.LastOrDefault() : null;

        //    //return new Chat
        //    //{
        //    //    Id = chat.Id,
        //    //    UserId1 = user1,
        //    //    UserId2 = user2,
        //    //    Name = user1.Id == chat.UserId1 ? user2.Name : user1.Name,
        //    //    Description = lastMessage?.Text ?? string.Empty,
        //    //    Messages = messages ?? new List<MessageType>(),
        //    //    Image = user1.Id == chat.UserId1 ? user2.Image : user1.Image,
        //    //    UpdatedAt = lastMessage?.CreatedAt ?? chat.DateCreation
        //    //};
        //}
    }
}
