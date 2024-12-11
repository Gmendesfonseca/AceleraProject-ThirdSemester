

namespace InnerAPI.Models
{

    public abstract class Institution : User

    {
        #region "Declaração de variáveis"
        private string _address;
        private DateOnly _creationDate;
        public string _cnpj;
        public string _domain;
        #endregion

        #region "Construtores"
        public Institution() : base()
        {
            _creationDate = new DateOnly();
            _address = _cnpj = _domain = "";
        }

        public Institution(uint id, string name, string password, string email, string cnpj, string domain) : base(id, name, password, email)
        {
            _cnpj = cnpj;
            _domain = domain;
        }

        public Institution(uint id, string name, string password, string email, string image, string about, string address, DateOnly creationDate, string cnpj, string domain) : base(id, name, password, email, image, about)
        {
            _address = address;
            _creationDate = creationDate;
            _cnpj = cnpj;
            _domain = domain;
        }
        #endregion

        #region "Propriedades"
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public DateOnly CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }

        public string CNPJ
        {
            get { return _cnpj; }
            set { _cnpj = value; }
        }

        public string Domain
        {
            get { return _domain; }
            set { _domain = value; }
        }
        #endregion
    }
}
