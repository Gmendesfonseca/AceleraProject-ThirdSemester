using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace InnerAPI.Models
{
    public class Ranking
    {
        #region "Declaração de variáveis"

        private uint _idRanking;
        private string? _name;
        private List<RankingItem> _items;

        #endregion

        #region "Construtores"

        public Ranking()
        {
            _items = new List<RankingItem>();
        }

        public Ranking(uint idRanking, string name)
        {
            _idRanking = idRanking;
            _name = name;
            _items = new List<RankingItem>();
        }

        #endregion

        #region "Propriedades"

        public uint IdRanking
        {
            get { return _idRanking; }
            set { _idRanking = value; }
        }

        public string Name
        {
            get { return _name  ?? string.Empty; }
            set { _name = value; }
        }

        public List<RankingItem> Items
        {
            get { return _items; }
            private set { _items = value; }
        }

        #endregion

        #region "Metodos"

        public void ExibirRanking()
        {
            Console.WriteLine($"Ranking: {Name}");
            foreach (var item in _items)
            {
                Console.WriteLine($"{item.Position}. {item.Name} - {item.Score}");
            }
        }

        public void AtualizarRanking(RankingItem item)
        {
            var existingItem = _items.Find(i => i.Name == item.Name);
            if (existingItem != null)
            {
                existingItem.Score = item.Score;
            }
            else
            {
                _items.Add(item);
            }

            // Ordena os itens por pontuação de forma decrescente
            _items.Sort((x, y) => y.Score.CompareTo(x.Score));

            // Atualiza a posição dos itens
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].Position = (uint)(i + 1);
            }
        }

        public void AdicionarItem(RankingItem item)
        {
            _items.Add(item);
            AtualizarRanking(item);
        }

        public void RemoverItem(string itemName)
        {
            var item = _items.Find(i => i.Name == itemName);
            if (item != null)
            {
                _items.Remove(item);
                // Atualiza as posições após a remoção
                for (int i = 0; i < _items.Count; i++) 
                {
                    _items[i].Position = (uint)(i + 1);
                }
            }
        }

        #endregion
    }
        public class RankingItem
        {
            public uint Position { get; set; }
            public string Name { get; set; }
            public int Score { get; set; }

            public RankingItem(string name, int score)
            {
                Name = name;
                Score = score;
            }
        }
}

