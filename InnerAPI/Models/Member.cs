using InnerAPI.Dtos.Chat;
using InnerAPI.Utils;
using System.Xml.Linq;

namespace InnerAPI.Models
{
    public abstract class Member : User
    {
        #region "Declaração de variáveis"
        private string _registration;
        private uint _institutionId;
        private string _cpf;
        public DateOnly _birthDate;
        private string _institution;
        private List<Post> _postList;
        private List<ChatDto> _chatList;
        private List<Friend> _friendList;

        #endregion

        #region "Construtores"
        public Member() : base()
        {
            _registration = _cpf = _institution = "";
            _birthDate = new DateOnly();
        }

        public Member(uint id, string name, string password, string email, string image, string about, string registration, string cpf, DateOnly birthDate, string institution) : base(id, name, password, email, image, about)
        {
            _registration = registration;
            _cpf = cpf;
            _birthDate = birthDate;
            _institution = institution;
            _postList = new List<Post>();
            _chatList = new List<ChatDto>();
            _friendList = new List<Friend>();
        }

        public Member(uint id, string name, string password, string email, string registration, string cpf, DateOnly birthDate, string institution, uint institutionId) : base(id, name, password, email)
        {
            _registration = registration;
            _cpf = cpf;
            _birthDate = birthDate;
            _institution = institution;
            _institutionId = institutionId;
            _postList = new List<Post>();
            _chatList = new List<ChatDto>();
            _friendList = new List<Friend>();
        }
        public Member(uint id, string name, string password, string email, string registration, string cpf, string institution, uint institutionId):base(id, name, password, email)
        {
            _registration = registration;
            _cpf = cpf;
            _institution = institution;
            _institutionId = institutionId;
        }
        #endregion
        #region "Propriedades"

        public string Registration
        {
            get { return _registration; }
            set { _registration = value; }
        }

        public string CPF
        {
            get { return _cpf; }
            set { _cpf = value; }
        }

        public DateOnly BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public string Institution
        {
            get { return _institution; }
            set { _institution = value; }
        }

        public uint InstitutionId
        {
            get { return _institutionId; }
            set { _institutionId = value; }
        }

        public List<Post> Posts
        {
            get { return _postList; }
        }

        public List<ChatDto> Chats
        {
            get { return _chatList; }
        }

        public List<Friend> Friends
        {
            get { return _friendList; }
        }
        #endregion
    }
}
