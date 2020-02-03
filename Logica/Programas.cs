using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public class Programas :IProgramas
    {
        public List<Programm> ProgramasAgregados { get; set; }
        public List<Programm> ListaProgramas { get; set; }

        public Programas()
        {
            this.ListaProgramas = new List<Programm>();
            this.ProgramasAgregados = new List<Programm>();
        }

        public void AgregarProgramas(List<string> programs)
        {
            for (int i = 0; i < programs.Count; i++)
            {
                this.ListaProgramas.Add(new Programm { Nombre = programs[i] });
            }
           
        }
        public void AceptarPrograma(string program)
        {
            this.ProgramasAgregados.Add(new Programm() { Nombre = program });
            this.ListaProgramas.Remove(this.ListaProgramas.Find(x => x.Nombre == program));
        }        
        

        public List<Programm> TraerLista()
        {
            return this.ListaProgramas;
        }

        public void DenegarPrograma(string program)
        {
            this.ListaProgramas.Add(new Programm() { Nombre = program });
            this.ProgramasAgregados.Remove(this.ListaProgramas.Find(x => x.Nombre == program));
        }

        public List<Programm> TraerAceptados()
        {
            return this.ProgramasAgregados;
        }
    }
}
