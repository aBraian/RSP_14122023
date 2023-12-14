using Entidades.Enumerados;

namespace Entidades.MetodosDeExtension
{
    public static class EmergenciaExtension
    {
        public static bool ValidaEmergencia(this List<EEmergencia> lista, EEmergencia eEmergencia)
        {
            return lista.Any((item) => item == eEmergencia);
        }

        public static double SegundosTranscurridos(this DateTime inicio)
        {
            TimeSpan segundos = DateTime.Now - inicio;
            return segundos.TotalSeconds;
        }
    }
}
