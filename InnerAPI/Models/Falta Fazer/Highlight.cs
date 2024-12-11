namespace InnerAPI.Models
{
    public class Destaque
    {
        #region "Declaração de variáveis"
        
        private uint _idHighlights;
        private string _nameHighlights; //Revisar variável

        #endregion

        #region "Propriedades"

        public uint IdHighlights
        {
            get { return _idHighlights; }
            set { _idHighlights = value; }
        }

        public string NameHighlights
        {
            get { return _nameHighlights; } 
            set { _nameHighlights = value; } 
        }

        #endregion

        #region "Metodos"

        //Revisar métodos e aplicar polimorfismo
        public void AdicionarDestaque()
        {

        }

        public void RemoverDestaque()
        {

        }
        #endregion
    }
}
