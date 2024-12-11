using InnerAPI.Dtos.Login;

namespace InnerAPI.Models
{
    public class HeadOffice : Institution
    {
        #region "Declaração de variáveis"
        List<uint> branches;
        #endregion

        #region "Construtores"
        public HeadOffice() : base()
        {
            branches = new List<uint>();
        }

        public HeadOffice(uint id, string name, string password, string email, string image, string about, string address, DateOnly creationDate, string cnpj, string domain) : base(id, name, password, email, image, about, address, creationDate, cnpj, domain)
        {
            branches = new List<uint>();
        }   

        public HeadOffice(uint id, string name, string email, string password, string cnpj, string domain) : base(id, name, email, password, cnpj, domain)
        {
            Online = false;
            Active = true;
            branches = new List<uint>();
        }
        #endregion

        #region "Métodos Listas"

        public bool Login(LoginDto login)
        {
            // Verifica se o e-mail e a senha correspondem às credenciais do head office
            return Email == login.Email && Password == login.Password;
        }

        public List<uint> Branches { get { return branches; } }
        public void addBranch(uint branch)
        {
            branches.Add(branch);
        }
        public void removeBranch(uint branch)
        {
            branches.Remove(branch);
        }
        #endregion
    }
}
