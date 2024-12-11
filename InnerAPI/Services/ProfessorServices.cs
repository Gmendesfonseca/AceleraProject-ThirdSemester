using InnerAPI.Dtos.Login;
using InnerAPI.Dtos.Professor;
using InnerAPI.Models;
using InnerAPI.Utils;

namespace InnerAPI.Services
{
    public class ProfessorServices
    {
        List<Professor> professors;
        List<Student> students;
        List<Branch> branches;
        public ProfessorServices(SharedService _sharedService)
        {
            professors = _sharedService.Professors;
            branches = _sharedService.Branches;
            students = _sharedService.Students;
        }

        public Professor Register(RegisterProfessorDto register)
        {
            var branch = GetBranch(register.Email);
            if (branch == null)
            {
                throw new ArgumentException("Instituição não encontrada.");
            }

            var existingProfessor = professors.Exists(r => r.Registration == register.Matricula || r.Email == register.Email || r.CPF == register.Cpf);
            if (existingProfessor)
            {
                throw new ArgumentException("Este email já está sendo usado por outro usuário.");
            }

            uint id = (uint)professors.Count + 1; 
            string name = register.Name;
            string email = register.Email;
            string password = register.Password;
            string cpf = register.Cpf;
            string image = "caminho/para/imagem.jpg";
            string instituicao = register.Instituicao;
            string matricula = register.Matricula;
            uint institutionId = branch.Id;
            string areaLecionada = register.AreaLecionada;
            string formacao = register.Formacao;

            Professor newProfessor = new Professor(id, register.Name, register.Email, register.Password, register.Cpf, register.Instituicao, register.Matricula, register.IntitutionId, register.AreaLecionada, register.Formacao);
            branch.Professors.Add(newProfessor.Id);
            professors.Add(newProfessor);

            return newProfessor;
        }

        public Professor Login(LoginDto user)
        {
            string email = user.Email;
            string password = user.Password;

            Email Email = new Email();
            if (!Email.IsValid(email))
                throw new ArgumentException("Email inválido.");

            var branch = GetBranch(email);
            if (branch == null)
            {
                throw new ArgumentException("Instituição não encontrada.");
            }

            var professor = professors.FirstOrDefault(p => p.Email == email);

            if (professor == null)
                throw new ArgumentException("Usuário não encontrado.");

            if (professor.Password != password)
                throw new ArgumentException("Senha incorreta.");
            professor.Online = true;

            return professor;
        }

        public Professor Update(int id, RegisterProfessorDto professor)
        {
            var existingProfessor = professors.FirstOrDefault(p => p.Id == id);
            if (existingProfessor == null)
            {
                throw new ArgumentException("Professor não encontrado.");
            }

            existingProfessor.Name = professor.Name;
            existingProfessor.Email = professor.Email;
            existingProfessor.Password = professor.Password;
            existingProfessor.CPF = professor.Cpf;

            return existingProfessor;
        }

        public bool Delete(uint id)
        { 
            branches.SelectMany(i => i.Professors).ToList().RemoveAll(usuario => usuario == id); 
            professors.RemoveAll(p => p.Id == id);
            return true; 
        }

        public Branch GetBranch(string email)
        {
            var domain = email.Split('@')[1];
            var branch = branches.FirstOrDefault(i => i.Domain == domain);
            if(branch == null)
            {
                throw new ArgumentException("Instituição não encontrada.");
            }
            return branch;
        }

        public Branch GetBranch(uint id)
        {
            var branch = branches.FirstOrDefault(i => i.Id == id);
            if(branch == null)
            {
                throw new ArgumentException("Instituição não encontrada.");
            }
            return branch;
        }

        public Professor GetProfessors(uint id)
        {
            var professor = professors.FirstOrDefault(p => p.Id == id);
            if(professor == null)
            {
                throw new ArgumentException("Professor não encontrado.");
            }
            return professor;
        }

        public Stack<Post> Posts(uint id)
        {
            Stack<Post> newPostsList = new Stack<Post>();
            var branch = branches.FirstOrDefault(i => i.Id == id);
            newPostsList = branch.Feed;

            return newPostsList;
        }

        public List<Friend> Friends(uint id)
        {
            List<Friend> newFriendsList = new List<Friend>();
            List<Student> studentsList = students;
            List<Professor> professorsList = professors;

            for(int i = 0; i < studentsList.Count; i++)
            {
                if (studentsList[i].InstitutionId == id)
                {
                    Friend newFriend = new Friend(studentsList[i].Id, studentsList[i].Name, studentsList[i].Email, studentsList[i].Online);
                    newFriendsList.Add(newFriend);
                }
            }   

            for(int i = 0; i < professorsList.Count; i++)
            {
                if (professorsList[i].InstitutionId == id)
                {
                    Friend newFriend = new Friend(professorsList[i].Id, professorsList[i].Name, professorsList[i].Email, professorsList[i].Online);
                    newFriendsList.Add(newFriend);
                }
            }

            return newFriendsList;
        }   

        public void Remover()
        {

        }
    }
}
