namespace InnerAPI.Models
{
    public class Group
    {
        #region "Declaração de variáveis"

        private uint _idGroup;
        private string _nameGroup;
        private DateOnly _dateCreationGroup;
        private uint _numMembers; //Talvez alterar para tipo ushort        
        private uint _numAdmins; //Talvez alterar para o tipo ushort
        private uint _numPosts; //Talvez alterar para tipo ushort                   
        private uint _numNotifications; //Talvez alterar para tipo ushort                                   

        #endregion

        #region "Propriedaedes"

        public uint IdGroup
        {
            get { return _idGroup; }
            set { _idGroup = value; }
        }

        public string NameGroup
        {
            get { return _nameGroup; }
            set { _nameGroup = value; }
        }

        public DateOnly DateCreationGroup
        {
            get { return _dateCreationGroup; }
            set { _dateCreationGroup = value; }
        }

        public uint NumMembers
        {
            get { return _numMembers; }
            set { _numMembers = value; }
        }

        public uint NumAdmins
        {
            get { return _numAdmins; }
            set { _numAdmins = value; }
        }

        public uint NumPosts
        {
            get { return _numPosts; }
            set { _numPosts = value; }
        }

        public uint NumNotifications
        {
            get { return _numNotifications; }
            set { _numNotifications = value; }
        }

        #endregion

        #region "Métodos"

        public void AdicionarPostagem()
        {

        }

        public void EditarPostagem()
        {

        } //Revisar Método

        public void RemoverPostagem()
        {

        }

        #endregion
    }
}
