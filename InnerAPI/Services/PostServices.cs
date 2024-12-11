using InnerAPI.Dtos.Post;
using InnerAPI.Models;

namespace InnerAPI.Services
{
    public class PostServices
    {
        Stack<Post> posts;
        List<Branch> institutions;
        List<Student> students;
        List<Professor> professors;
        public PostServices(SharedService sharedService)
        {
            institutions = sharedService.Branches;
            students = sharedService.Students;
            professors = sharedService.Professors;
        }

        public Stack<Post> GetPosts(int id)
        {
            var institution = institutions.Find(inst => inst.Id == id);
            if (institution == null)
            {
                throw new InvalidOperationException("Instituição não encontrada.");
            }
            Stack<Post> posts = institution.Feed;
            return posts;
        }

        public void Register(string type, RegisterPostDto postDto)
        {
            if(type == "student")
            {
                var student = students.FirstOrDefault((i) => i.Id == postDto.creatorId);
            }
            else if (type == "professor")
            {
                var professor = professors.FirstOrDefault((i) => i.Id == postDto.creatorId);
            }
            
            Post newPost = new Post(
                postDto.id,
                postDto.creatorId,
                postDto.creatorName,
                postDto.title,
                postDto.image,
                postDto.description
            );

            var institution = institutions.Find(inst => inst.Id == postDto.institutionId);
            if (institution != null)
            {
                institution.Feed.Push(newPost);
            }
        }

        public Post Update(int id, UpdatePostDto updatedPost)
        {
            Stack<Post> posts = institutions.Find(institution => institution.Id == updatedPost.InstitutionId).Feed;
            Post postToUpdate = posts.FirstOrDefault(p => p.Id == id);
            if (postToUpdate == null)
            {
                return null;
            }
            
            postToUpdate.Title = updatedPost.TitlePost;

            
            return postToUpdate;
        }

        public bool Delete(int id) //Bucar e remover todos os posts com o ID
        {
            //PostServices postServices = new PostServices(new SharedService());
            //foreach (var institution in institutions)
            //{
            //    Stack<Post> posts = institution.Feed;
            //    Post post = posts.FirstOrDefault(p => p.IdPost == id);
            //    if (post != null)
            //    {
            //        post.RemoveContent(post);
            //        return true;
            //    }
            //}
            return true;
        }
    }
}
