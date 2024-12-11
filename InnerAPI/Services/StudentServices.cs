using InnerAPI.Dtos.Aluno;
using InnerAPI.Dtos.Login;
using InnerAPI.Models;
using InnerAPI.Utils;

namespace InnerAPI.Services
{
    public class StudentServices
    {
        List<Branch> institutions;
        List<Student> students;
        List<Professor> professors;

        public StudentServices(SharedService _sharedService)
        {
            students = _sharedService.Students;
            institutions = _sharedService.Branches;
            professors = _sharedService.Professors;
        }

        public Student Register(RegisterStudentDto register)
        {
            var branch = GetBranch(register.Email);
            
            if (branch == null)
            {
                throw new ArgumentException("Instituição não encontrada.");
            }

            // Verifica se o estudante já existe
            var existingStudent = students.Exists(r => r.Registration == register.Matricula || r.Email == register.Email || r.CPF == register.Cpf);
            if (existingStudent)
            {
                throw new ArgumentException("Este email já está sendo usado por outro usuário.");
            }

            // Cria e adiciona o novo estudante à instituição correta
            uint id = (uint)students.Count + 1; 
            string name = register.Name;
            string email = register.Email;
            string password = register.Password;
            string matricula = register.Matricula;
            string cpf = register.Cpf;
            string image = "caminho/para/imagem.jpg";
            string instituicao = register.Instituicao;
            uint institutionId = branch.Id;
            string curso = register.Curso;
            string periodo = register.Periodo;

            Student newStudent = new Student(id, name, email, password, matricula, cpf, instituicao, institutionId, curso, periodo);
            branch.Students.Add(newStudent.Id);
            students.Add(newStudent);

            return newStudent;
        }

        public Student Login(LoginDto user)
        {
            string email = user.Email;
            string password = user.Password;

            Email Email = new Email();
            if (!Email.IsValid(email))
                throw new ArgumentException("Invalid email.");

            var student = students.FirstOrDefault(s => s.Email == email);

            if (student == null)
                throw new ArgumentException("User not found.");

            if (student.Password != password)
                throw new ArgumentException("Incorrect password.");

            return student;
        }

        public Student Update(int id, Student newStudent)
        {
            Student student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }
            student = newStudent;
            student.Name = newStudent.Name;
            student.Email = newStudent.Email;
            student.Password = newStudent.Password;
            student.Registration = newStudent.Registration;
            student.CPF = newStudent.CPF;
            student.BirthDate = newStudent.BirthDate;
            student.Institution = newStudent.Institution;
            student.Curso = newStudent.Curso;
            student.Periodo = newStudent.Periodo;

            return student;
        }

        public bool Delete(int id)
        {
            foreach (var institution in institutions)
            {
                var student = institution.Students.FirstOrDefault(s => s == id);
            }
            return false;
        }

        public List<uint> GetStudents(uint id)
        {
            Branch institution = institutions.FirstOrDefault(i => i.Id == id);
            if (institution == null)
            {
                throw new ArgumentException("Instituição não encontrada.");
            }
            return institution.Students;
        }

        public Branch GetBranch(string email)
        {
            var domain = email.Split('@')[1];
            return institutions.FirstOrDefault(i => i.Domain == domain);
        }

        public Branch GetBranch(uint id)
        {
            var institution = institutions.FirstOrDefault(i => i.Id == id);
            if (institution == null)
            {
                throw new ArgumentException("Instituição não encontrada.");
            }
            return institution;
        }

        public Stack<Post> Posts(uint id)
        {
            Stack<Post> newPostsList = new Stack<Post>();
            var institution = institutions.FirstOrDefault(i => i.Id == id);
            newPostsList = institution.Feed;

            return newPostsList;
        }

        public List<Friend> Friends(uint id)
        {
            List<Friend> newFriendsList = new List<Friend>();
            List<Student> studentsList = students;
            List<Professor> professorsList = professors;

            for (int i = 0; i < studentsList.Count; i++)
            {
                if (studentsList[i].InstitutionId == id)
                {
                    Friend newFriend = new Friend(studentsList[i].Id, studentsList[i].Name, studentsList[i].Email, studentsList[i].Online);
                    newFriendsList.Add(newFriend);
                }
            }

            for (int i = 0; i < professorsList.Count; i++)
            {
                if (professorsList[i].InstitutionId == id)
                {
                    Friend newFriend = new Friend(professorsList[i].Id, professorsList[i].Name, professorsList[i].Email, professorsList[i].Online);
                    newFriendsList.Add(newFriend);
                }
            }

            return newFriendsList;
        }
    }
}
