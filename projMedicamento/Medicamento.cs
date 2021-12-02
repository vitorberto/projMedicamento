using System;
using System.Collections.Generic;
using System.Text;

namespace projMedicamento
{
    class Medicamento
    {
        private int id;
        private string nome;
        private string laboratorio;
        private Queue<Lote> lotes = new Queue<Lote>();

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Laboratorio { get => laboratorio; set => laboratorio = value; }
        public Queue<Lote> Lotes { get => lotes; set => lotes = value; }

        public Medicamento()
        {
            Id = 0;
            Nome = "";
            Laboratorio = "";
        }

        public Medicamento(int id, string nome, string laboratorio)
        {
            this.Id = id;
            this.Nome = nome;
            this.Laboratorio = laboratorio;
        }

        public int QtdeDisponivel()
        {
            int disponivel = 0;
            foreach (Lote lote in Lotes)
            {
                disponivel += lote.Qtde;
            }

            return disponivel;
        }

        public void Comprar(Lote lote)
        {
            Lotes.Enqueue(lote);
        }

        public bool vender (int qtde)
        {
            if (QtdeDisponivel() >= qtde)
            {
                while (qtde > 0)
                {
                    Lote lote = Lotes.Peek();
                    int qtdeLote = lote.Qtde;
                    lote.Qtde -= qtde;
                    if (lote.Qtde <= 0)
                        Lotes.Dequeue();
                    qtde -= qtdeLote;
                }
                return true;
            } else
            {
                return false;
            }
        }

        public string toString()
        {
            return Id + "-" + Nome + "-" + Laboratorio + "-" + QtdeDisponivel();
        }

        public override bool Equals(Object obj)
        {
            return this == obj;
        }
    }
}
