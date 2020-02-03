using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public interface IProgramas
    {
        void AgregarProgramas(List<string> programs);
        void AceptarPrograma(string program);
        void DenegarPrograma(string program);
        List<Programm> TraerLista();
        List<Programm> TraerAceptados();
    }
}
