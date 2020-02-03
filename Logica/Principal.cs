using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Logica
{
    public class Principal : IPrincipal, IProgramas
    {
        string DirectorioEntrada;
        string DirectorioSalida;
        public Programas Programs { get; set; }

        public Principal()
        {
            this.Programs = new Programas();
            this.DirectorioEntrada = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        public List<string> CargarProgramasDesk()
        {
            var Programs = new List<string>();
            string fn;
            string[] files = Directory.GetFiles(DirectorioEntrada);
            for (int iFile = 0; iFile < files.Length; iFile++)
            {
                fn = new FileInfo(files[iFile]).Name;
                Programs.Add(fn);
            }              
                
            string[] folders = Directory.GetDirectories(DirectorioEntrada);
            for (int ifolder = 0; ifolder < folders.Length; ifolder++)
            {
                fn = new FileInfo(folders[ifolder]).Name;
                Programs.Add(fn);
            }


            
            return Programs;
        }

        public void SetDirectorySalida(string salida)
        {
            this.DirectorioSalida = salida;
        }

        public string GetDirectorySalida()
        {
            return this.DirectorioSalida;
        }

        public void AgregarProgramas(List<string> programs)
        {
            this.Programs.AgregarProgramas(programs);
        }

        public void AceptarPrograma(string program)
        {
            this.Programs.AceptarPrograma(program);
        }

        public void DenegarPrograma(string program)
        {
            this.Programs.DenegarPrograma(program);
        }

        public List<Programm> TraerLista()
        {
            return this.Programs.TraerLista();
        }

        public List<Programm> TraerAceptados()
        {
            return this.Programs.TraerAceptados();
        }
    }
}
