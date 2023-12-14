using System.Text.Json;

namespace Entidades.Archivos
{
    public static class GestorDeArchivos
    {

        private static string basePath;

        static GestorDeArchivos()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            basePath = Path.Combine(desktopPath, "RSP_14122023_DIV2C_Braian");
            ValidaExistenciaDeDirectorio();
        }

        private static void ValidaExistenciaDeDirectorio()
        {
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
        }

        private static void Guardar(string informacion, string path)
        {
            using (StreamWriter archivo = new StreamWriter(path))
            {
                archivo.WriteLine(informacion);
            }
        }

        public static void Serializar<T>(T elemento, string nombreDelArchivo) where T : class
        {
            JsonSerializerOptions configuracionJson = new JsonSerializerOptions();
            configuracionJson.WriteIndented = true;
            string path = Path.Combine(basePath, nombreDelArchivo);
            string json = JsonSerializer.Serialize(elemento, configuracionJson);
            Guardar(json, path);
        }
    }
}
