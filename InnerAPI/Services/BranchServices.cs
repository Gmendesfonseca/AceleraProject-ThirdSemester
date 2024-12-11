using InnerAPI.Dtos;
using InnerAPI.Dtos.Branch;
using InnerAPI.Dtos.Courses;
using InnerAPI.Dtos.Login;
using InnerAPI.Models;
using InnerAPI.Utils;

namespace InnerAPI.Services
{
    public class BranchServices
    {
        List<Branch> branches;
        List<Professor> globalProfessorsList;
        List<Student> globalStudentsList;

        public BranchServices(SharedService _sharedService)
        {
            branches = _sharedService.Branches;
            globalProfessorsList = _sharedService.Professors;
            globalStudentsList = _sharedService.Students;
        }

        public Branch Register(RegisterBranchDto register)
        {
            uint id = (uint)branches.Count + 1;
            string name = register.Name;
            string email = register.Email;
            string password = register.Password;
            string cnpj = register.Cnpj;
            string image = "caminho/para/imagem.jpg";
            string about = register.About;
            string address = register.Address;
            DateOnly creationDate = DateOnly.FromDateTime(DateTime.Now); 
            string domain = email.Split('@')[1];

            Email Email = new Email();
            if (!Email.IsValid(email))
                throw new ArgumentException("Email inválido.");

            var existingUser = branches.Exists(r => r.Name == register.Name || r.Email == register.Email || r.CNPJ == register.Cnpj);
            if (existingUser)
            {
                throw new ArgumentException("Este email já está sendo usado por outro usuário.");
            }

            Branch newBranch = new Branch(id, name, email, password,  image, about, address, creationDate, cnpj, domain);

            branches.Add(newBranch);

            return newBranch;
        }


        public Branch Login(LoginDto user)
        {
            string email = user.Email;
            string password = user.Password;

            Branch branch = branches.FirstOrDefault(i => i.Email == user.Email);

            Email Email = new Email();
            if (!Email.IsValid(email))
                throw new ArgumentException("Email inválido.");

            if (branch == null)
                throw new ArgumentException("Usuário não encontrado.");

            if (branch.Password != password)
                throw new ArgumentException("Senha incorreta.");

            return branch;
        }

        public Branch Update(int id, RegisterBranchDto register)
        {
            Branch Branch = branches.FirstOrDefault(i => i.Id == id);

            if (Branch == null)
                throw new ArgumentException("Usuário não encontrado.");

            Branch.Name = register.Name;
            Branch.Email = register.Email;
            Branch.Password = register.Password;
            Branch.Domain = register.Domain;
            Branch.CNPJ = register.Cnpj;

            return Branch;
        }

        public List<Student> Students(uint id)
        {

            List<Student> newStudentsList = new List<Student>();
            var branch = branches.FirstOrDefault(i => i.Id == id);
            if (branch == null) return newStudentsList; 

            List<uint> branchStudents = branch.Students;

            foreach (uint studentId in branchStudents)
            {
                var student = globalStudentsList.FirstOrDefault(i => i.Id == studentId);
                if (student != null)
                    newStudentsList.Add(student);
            }

            return newStudentsList;

        }

        public List<Professor> Professors(uint id) // Alterado o nome do parâmetro para evitar conflito
        {
            List<Professor> newProfessorsList = new List<Professor>();
            var branch = branches.FirstOrDefault(i => i.Id == id);
            if (branch == null) return newProfessorsList;

            List<uint> branchProfessor = branch.Professors;

            foreach (uint studentId in branchProfessor)
            {
                var student = globalProfessorsList.FirstOrDefault(i => i.Id == studentId);
                if (student != null)
                    newProfessorsList.Add(student);
            }

            return newProfessorsList;
        }

        public List<CourseDto> GetCourses(int id)
        {
            var Branch = branches.FirstOrDefault(i => i.Id == id);
            return Branch.Courses;
        }

        public bool Delete(int id)
        { branches.RemoveAll(usuario => usuario.Id == id); return true; }

        public void SuspenderAcesso()
        {

        }

        public void CriarGrupo()
        {

        }
    }
}
