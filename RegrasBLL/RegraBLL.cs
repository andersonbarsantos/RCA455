using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using RCA455_Conexao;

namespace RegrasBLL
{
    public class RegraBLL
    {
        public List<Regra> ConsultaInicial() 
        {
            RepRegra rep = new RepRegra();

            return rep.Find();
        }

        public List<Regra> ConsultarTodos() 
        {
            RepRegra rep = new RepRegra();

            return rep.FindAll();
        }

        public List<Regra> ConsultarSemClassif()
        {
            RepRegra rep = new RepRegra();

            return rep.FindNull();
        }

        public List<Regra> ConsultarComClassif()
        {
            RepRegra rep = new RepRegra();

            return rep.FindNotNull();
        }

        public Regra ConsultarId(int regra_id)
        {
            RepRegra rep = new RepRegra();

            return rep.FindById(regra_id);
        }

        public void InserirRegra(Regra r)
        {
            RepRegra rep = new RepRegra();

            rep.Insert(r);
        }

        public void AtualizarRegra(Regra r)
        {
            
            RepRegra rep = new RepRegra();

            rep.Update(r);
        }

        public void ExcluirRegra(int regra_id) 
        {
            RepRegra rep = new RepRegra();

            if (rep.FindById(regra_id) != null) 
            {
                rep.Delete(regra_id);
            }
        }

        
    }
}
