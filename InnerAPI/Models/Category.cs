 namespace InnerAPI.Models
 {
     public class Categoria
     {
         #region "Declaração de variáveis"
        
         private uint _idCategory;
         private string _nameCategory;

         #endregion

         #region "Propriedades"

         public Categoria(string nameCategory)
        {
             _nameCategory = nameCategory ?? throw new ArgumentNullException(nameof(nameCategory));
        }

         public uint IdCategory
         { 
             get { return _idCategory; }
             set { _idCategory = value; }
         }

         public string NameCategory
         { 
             get { return _nameCategory; } 
             set { _nameCategory = value; }
         }

         #endregion

         #region "Metodos"

        //  Revisar Metodos - Repetição com as outras classes
        //  Solução - Implementar o polimorfismo para evitar repetição
         public void CriarCategoria()
         {

         }

         public void DeletarCategoria()
         {

         }

         #endregion
     }
 }
#region 
//  namespace InnerAPI.Models
//  {
//      public class Category
//      {
//          public uint IdCategory { get; set; }
//          public string NameCategory { get; set; }
//      }
//  }
#endregion