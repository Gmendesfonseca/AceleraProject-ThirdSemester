using InnerAPI.Dtos.Login;
using InnerAPI.Models;
using System.Collections.Generic;

namespace InnerAPI.Services
{
    public class AuthenticationServices
    {
        private readonly Dictionary<string, Branch> _headOffices ;
        private readonly Dictionary<string, Branch> _branches ;

       // public object UserType { get; }

        // Adicione outros dicionários para professores, alunos, etc., se necessário

        public AuthenticationServices()
        {
            _headOffices = new Dictionary<string, Branch>();
            _branches = new Dictionary<string, Branch>();

            // Exemplo: Inicializar alguns usuários para fins de demonstração
            //_headOffices.Add("admin@example.com", new Branch(1, "Admin", "admin@example.com", "admin123", "00000000000000"));
            //_branches.Add("branch@example.com", new Branch(2, "Branch", "branch@example.com", "branch123", "11111111111111"));
        }

        public Branch LoginHeadOffice(LoginDto login)
        {
            // Implemente aqui a lógica de autenticação para o login do head office (administrador)
            if (_headOffices.TryGetValue(login.Email, out var institution) && institution.Password == login.Password)
            {
                return institution;
            }
            return null;
        }

        public Branch LoginBranch(LoginDto login)
        {
            // Implemente aqui a lógica de autenticação para o login da branch (filial)
            if (_branches.TryGetValue(login.Email, out var institution) && institution.Password == login.Password)
            {
                return institution;
            }
            return null;
        }

        // Implemente métodos semelhantes para login de professor e aluno, se necessário
    }
}
