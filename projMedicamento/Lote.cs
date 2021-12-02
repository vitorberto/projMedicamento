using System;
using System.Collections.Generic;
using System.Text;

namespace projMedicamento
{
    class Lote
    {
        private int id;
        private int qtde;
        private DateTime venc;

        public int Id { get => id; set => id = value; }
        public int Qtde { get => qtde; set => qtde = value; }
        public DateTime Venc { get => venc; set => venc = value; }

        public Lote()
        {
            Id = 0;
            Qtde = 0;
            Venc = new DateTime();
        }

        public Lote(int id, int qtde, DateTime venc)
        {
            Id = id;
            Qtde = qtde;
            Venc = venc;
        }

        public string toString()
        {
            return Id + "-" + Qtde + "-" + Venc;
        }
    }
}
