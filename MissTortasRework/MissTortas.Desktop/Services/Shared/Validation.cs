namespace MissTortas.Desktop.Services.Shared
{
    public class Validation
    {
        public static string ValidateAndSanitize(string str, int lo, int hi, string fieldName)
        {
            if (str == null || str.Length < lo || str.Length > hi)
            {
                throw new FormatException($"Entrada de '{fieldName}': {str} no es valida. Debe tener un largo entre {lo} y {hi}.");
            }
            return str.Trim();
        }
    }
}
