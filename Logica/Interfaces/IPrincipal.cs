using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public interface IPrincipal
    {
        List<string> CargarProgramasDesk();
        void SetDirectorySalida(string salida);
        string GetDirectorySalida();

    }
}
