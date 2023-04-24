using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exMedicamentos.Compartilhado
{
    public class Repositorio
    {
        public ArrayList Lista { get; protected set; }

        public Repositorio()
        {
            this.Lista = new ArrayList();
        }

        public void InserirRegistro(Entidade entidade)
        {
            Lista.Add(entidade);
        }

        public void EditarRegistro(
            Entidade entidadeAtualizada, int id
        )
        {
            EncontrarRegistro(id).Atualizar(entidadeAtualizada);
        }

        public Entidade EncontrarRegistro(int id, ArrayList lista)
        {
            foreach (Entidade entidade in lista)
            {
                if (entidade.Id == id)
                {
                    return entidade;
                }
            }

            return null;
        }

        public Entidade EncontrarRegistro(int id)
        {
            foreach (Entidade entidade in Lista)
            {
                if (entidade.Id == id)
                {
                    return entidade;
                }
            }

            return null;
        }

        public void RemoverRegistro(Entidade entidade)
        {
            Lista.Remove(entidade);
        }
    }
}
