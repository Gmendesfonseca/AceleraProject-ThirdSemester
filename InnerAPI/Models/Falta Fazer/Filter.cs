namespace InnerAPI.Models
{
    public class Filtro
    {
        #region "Declaração de variáveis"
        
        private uint _idFilter;
        private string _nameFilter;

        #endregion

        #region "Propriedades"

        public uint IdFilter
        {
            get { return _idFilter; }
            set { _idFilter = value; }
        }

        public string NameFilter
        { 
            get { return _nameFilter; } 
            set { _nameFilter = value; }
        }

        #endregion

        #region "Metodos"

        public void Filtrar()
        {

        }


        //Revisar o que os métodos abaixo fazem

        public void Permitir()
        { 

        }

        public void Negar() 
        {

        }
        #endregion
    }
}
