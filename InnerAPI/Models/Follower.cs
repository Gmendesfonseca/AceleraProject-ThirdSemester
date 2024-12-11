using System.Collections.Generic;
namespace InnerAPI.Models
{
    public class Follower
    {
        #region "Declaração de variáveis"
        
        private uint _idFollower; //Criar Lista de Seguidores
        private string? _nameFollower;
        private List<Follower> _followers;//lista de Seguidores
        private List<Follower> _pendingRequests; 

        #endregion

        #region "Construtores"

        public Follower()
        {
            _followers = new List<Follower>();
            _pendingRequests = new List<Follower>();
        }

        public Follower(uint idFollower, string nameFollower)
        {
            _idFollower = idFollower;
            _nameFollower = nameFollower;
            _followers = new List<Follower>();
            _pendingRequests = new List<Follower>();
        }

        #endregion

        #region "Propriedades"
        public uint IdFollower
        { 
            get { return _idFollower; }
            set { _idFollower = value;}
        }

        public string NameFollower
        {
            get { return _nameFollower ?? string.Empty; }
            set { _nameFollower = value;}
        }

          public List<Follower> Followers
        {
            get { return _followers; }
            private set { _followers = value; }
        }

        public List<Follower> PendingRequests
        {
            get { return _pendingRequests; }
            private set { _pendingRequests = value; }
        }

        #endregion

        #region "Metodos"

    
        public void EnviarSolicitacao(Follower follower)
        {
         if (follower != null && !follower._pendingRequests.Contains(this))
            {
                follower._pendingRequests.Add(this);
                
        }
        }


        public void ReceberSolicitacao(Follower follower)
        {
            if (follower != null && _pendingRequests.Contains(follower))
            {
                _followers.Add(follower);
                _pendingRequests.Remove(follower);
               
            }
        }
        #endregion
   
}
}