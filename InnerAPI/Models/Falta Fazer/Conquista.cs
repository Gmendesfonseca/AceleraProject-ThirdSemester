namespace InnerAPI.Models
{
    public class Conquista
    {
        #region "Declaração de variáveis"
        
        private uint _idAchievement;
        private string _nameAchievement;
        private DateTime _dateTimeAchievement; //Revisar Nome da variável
        private uint _idUser;

        #endregion

        #region "Propriedades"

        public uint IdAchievement
        {
            get { return _idAchievement; }
            set { _idAchievement = value; }
        }

        public string NameAchievement
        { 
            get { return _nameAchievement; } 
            set { _nameAchievement = value; } 
        }

        public DateTime DateTimeAchievement
        { 
            get { return _dateTimeAchievement; } 
            set { _dateTimeAchievement = value; } 
        }

        public uint IdUser
        {
            get { return _idUser; }
            set { _idUser = value;}
        }

        #endregion

        #region "Metodos"

        public void ReceberConquista()
        {

        }

        public void ExbirConquista()
        {

        }

        public void ExcluirConquista()
        {

        }
        #endregion
    }
}
