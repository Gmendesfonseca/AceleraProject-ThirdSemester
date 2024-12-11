using InnerAPI.Dtos.Courses;
using InnerAPI.Dtos.Post;
using InnerAPI.Services;
using InnerAPI.Utils;
using static System.Net.Mime.MediaTypeNames;
using System.Net;

namespace InnerAPI.Models
{
    public class Branch : Institution
    {
        #region "Declaração de variáveis"
        private SharedService _sharedService;
        private List<CourseDto> courses;
        private List<uint> students;
        private List<uint> professors;
        private Stack<Post> feed;
        private string cnpj1;
        #endregion

        #region "Construtores"
        public Branch() : base()
        {
            Online = false;
            Active = true;
            courses = new List<CourseDto>();
            students = new List<uint>();
            professors = new List<uint>();
            feed = new Stack<Post>();
        }

        public Branch(uint id, string name, string password, string email, string image, string about, string address, DateOnly creationDate, string cnpj, string domain) : base(id, name, password, email, image, about, address, creationDate, cnpj, domain)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Online = false;
            Active = true;
            CNPJ = cnpj;
            courses = new List<CourseDto>();
            students = new List<uint>();
            professors = new List<uint>();
            feed = new Stack<Post>();
        }

        public Branch(uint id, string name, string email, string password, string cnpj)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            CNPJ = cnpj;
            Online = false;
            Active = true;
        }

        public Branch(uint id, string name, string email, string password, string cnpj, DateOnly creationDate, string domain) : base(id, name, email, password, cnpj, domain)
        {
            CreationDate = creationDate;
            Online = false;
            Active = true;
        }
        #endregion

        #region "Métodos Listas"
        public List<CourseDto> Courses
        {
            get { return courses; }
        }

        public List<uint> Professors
        {
            get { return professors; }
        }

        public List<uint> Students
        {
            get { return students; }
        }

        public Stack<Post> Feed
        {
            get
            {
                List<Post> listPosts = new List<Post>();
                for (int i = 0; i < feed.Count; i++)
                {
                    listPosts.Add(feed.Pop());
                }
                return feed;
            }
        }

        public object Type { get; internal set; }

        public void addPost(Post post)
        {
            feed.Push(post);
        }
        public Post updatePost(int id, Post postUpdate)
        {
            Stack<Post> tempStack = new Stack<Post>();
            Post updatedPost = null;

            while (feed.Count > 0)
            {
                Post currentPost = feed.Pop();
                if (currentPost.Id != id)
                {
                    tempStack.Push(currentPost);
                }
                else
                {
                    updatedPost = currentPost;
                }
            }

            while (tempStack.Count > 0)
            {
                feed.Push(tempStack.Pop());
            }

            return updatedPost;
        }
        public void removePost(Post postDelete)
        {
            Stack<Post> tempStack = new Stack<Post>();
            while (feed.Count > 0)
            {
                Post currentPost = feed.Pop();
                if (currentPost != postDelete)
                {
                    tempStack.Push(currentPost);
                }
            }
            while (tempStack.Count > 0)
            {
                feed.Push(tempStack.Pop());
            }
        }
        #endregion
    }
}
