using Entidades.Enumerados;
using Entidades.Interfaces;

namespace Entidades.Modelos
{
    public class Paramedico : IServidorPublico
    {
        private static List<EEmergencia> emergenciasAtendibles;

        static Paramedico()
        {
            Paramedico.emergenciasAtendibles = new List<EEmergencia>() { EEmergencia.Accidentes_De_Trafico, EEmergencia.Desastres_Naturales, EEmergencia.Emergencias_Medicas };
        }

        public string Imagen => $"./assets/{this.GetType().Name}.gif";

        public void Atender(Emergencia emergencia)
        {

        }
    }
}
