using System;
using System.Collections.Generic;
using InnerAPI.Dtos.Comment;

namespace InnerAPI.Models
{
    public class Post
    {
        #region "Declaração de variáveis"

        private List<string> _comments;
        private List<string> _contentPost;
        private uint id;
        private uint creatorId;
        private uint _numLikes;
        private string creatorName;
        private string creatorImage;
        private string title;
        private string image;
        private string description;
        private List<CommentDto> comments;


        #endregion

        #region "Construtores"

        public Post()
        {
            _comments = new List<string>();
            _contentPost = new List<string>();
        }

        public Post(uint idPost, string titlePost, uint numLikes, List<string> comments, List<string> contentPost, DateOnly datePost, uint institutionId)
        {
            id = idPost;
            title = titlePost;
            _numLikes = numLikes;
            _comments = comments ?? new List<string>();
            _contentPost = contentPost ?? new List<string>();
            _comments = new List<string>();
            _contentPost = new List<string>();
        }

        public Post(uint id, uint creatorId, string creatorName, string title, string image, string description)
        {
            this.id = id;
            this.creatorId = creatorId;
            this.creatorName = creatorName;
            this.title = title;
            this.image = image;
            this.description = description;
            comments = new List<CommentDto>();

        }

        #endregion

        #region "Propriedades"

        public uint Id
        {
            get { return id; }
            set { id = value; }
        }

        public uint CreatorId
        {
            get { return creatorId; }
            set { creatorId = value; }
        }

        public string CreatorName
        {
            get { return creatorName; }
            set { creatorName = value; }
        }

        public string CreatorImage
        {
            get { return creatorImage; }
            set { creatorImage = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public uint NumLikes
        {
            get { return _numLikes; }
            set { _numLikes = value; }
        }

        public List<string> Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public List<string> ContentPost
        {
            get { return _contentPost; }
            set { _contentPost = value; }
        }
        #endregion

        #region "Métodos"

        public void ReceberCurtida()
        {
            _numLikes++;
        }

        public void ReceberComentario(string comment)
        {
            _comments.Add(comment);
        }

        public void AddContent(string content)
        {
            _contentPost.Add(content);
        }

        public void RemoveContent(string content)
        {
            _contentPost.Remove(content);
        }

        #endregion
    }
}
