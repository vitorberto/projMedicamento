using System;
using System.Collections.Generic;
using System.Text;

namespace projMedicamento
{
    class Medicamentos
    {
        private List<Medicamento> listaMedicamentos = new List<Medicamento>();

        public Medicamentos() { }

        public void Adicionar(Medicamento medicamento)
        {
            listaMedicamentos.Add(medicamento);
        }

        public bool Deletar(int id)
        {
            Medicamento medicamento = listaMedicamentos.Find(medicamento => medicamento.Id == id);
            if (medicamento != null)
            {
                if (medicamento.QtdeDisponivel() > 0)
                {
                    listaMedicamentos.Remove(medicamento);
                }
            }
            return false;
        }

        public Medicamento Pesquisar(int id)
        {
            Medicamento medicamento = listaMedicamentos.Find(medicamento => medicamento.Id == id);

            if (medicamento != null)
                return medicamento;

            return new Medicamento();
        }

        public int QuantidadeMedicamentos()
        {
            return listaMedicamentos.Count;
        }

        public void Listar()
        {
            Console.Clear();
            Console.WriteLine("Listagem de medicamentos: ");
            foreach (Medicamento medicamento in listaMedicamentos)
            {
                Console.WriteLine(medicamento.toString());
            }
        }
    }
}
