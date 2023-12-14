using Entidades.Modelos;

namespace Entidades.Delegados
{
    public delegate string DelegadoEmergenciaMensaje(string mensaje);

    public delegate Emergencia DelegadoEmergenciaEnCurso(Emergencia emergencia);

    public delegate double DelegadoEstadoEmergenciaEnCurso(double estado);
}