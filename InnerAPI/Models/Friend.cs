namespace InnerAPI.Models
{
    public class Friend
    {
        #region 
        private uint id;
        private string name;
        private string email;
        private string online;
        #endregion

        #region "Construtores"
        public Friend()
        {
            id = 0;
            name = email = "";
            online = "false";
        }

        public Friend(uint id, string name, string email, Boolean online)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            if (online)
            {
                this.online = "Online";
            } else
            {
                this.online = "Offline";
            }
        }

        #endregion

        #region "Propriedades"

        public uint Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        

        #endregion

    }
}
