namespace InnerAPI.Models
{
    public class Story
    {
        #region "Declaração de variáveis"

        private uint _idStory;
        private uint _idUser;
        private DateOnly _datePost;

        #endregion

        #region "Propriedades"

        public uint IdStory 
        { 
            get { return _idStory;} 
            set { _idStory = value; }
        }

        public uint IdUser
        { 
            get { return _idUser;}
            set { _idUser = value;}
        }

        public DateOnly DatePost
        {
            get { return _datePost;}
            set { _datePost = value;}
        }

        #endregion

        #region "Metodos"

        public void PublicarStrory()
        {

        }

        public void CurtirStory()
        {

        }

        public void DeletarStory()
        {

        }

        #endregion
    }
}
