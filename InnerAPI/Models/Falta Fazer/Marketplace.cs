namespace InnerAPI.Models
{
    public class Marketplace
    {

        #region "Declaração de variáveis"

        private uint _idMarketplace;
        private string _nameMarketplace;
        private string _descriptionMarketplace;
        private uint _idUser;
        private uint _idNotification;
        private uint _idPost;

        #endregion

        #region "Propriedades"

        public uint IdMarketplace
        {
            get { return _idMarketplace; }
            set { _idMarketplace = value; }
        }

        public string NameMarketplace
        { 
            get { return _nameMarketplace; } 
            set { _nameMarketplace = value; } 
        }

        public string DescriptionMarketplace
        {
            get { return _descriptionMarketplace; }
            set { _descriptionMarketplace = value; }
        }

        public uint IdUser
        {
            get { return _idUser; }
            set { _idUser = value;}
        }

        public uint IdNotification
        {
            get { return _idNotification;}
            set { _idNotification = value;}
        }

        public uint IdPost
        {
            get { return _idPost; }
            set { _idPost = value;}
        }
        #endregion

        #region "Metodos"

        //Futuramente arrumar nomeclatura dos métoodos
        public void ReceberPostagem()
        {

        }

        public void SerDeletado()
        {

        }

        public void SerCompartilhado()
        {

        }

        public void ReceberComentarios()
        {

        }
        #endregion

    }
}
