﻿namespace InnerAPI.Models
{
    public class Notification
    {
        #region "Declaração de variáveis"
        
        private uint _idNotification;
        private string _titleNotification;

        #endregion

        #region "Propriedades"

        public uint IdNotification
        {
            get { return _idNotification; }
            set { _idNotification = value;}
        }

        public string TitleNotification
        {
            get { return _titleNotification; }
            set { _titleNotification = value; }
        }

        #endregion

        #region "Metodos"

        public void Alertar()
        {

        }

        #endregion
    }
}