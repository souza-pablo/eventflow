namespace EventFlow.Utils
{
    public class TelefoneFormatter
    {
        public static string FormatarTelefone(string telefone)
        {
            if (string.IsNullOrEmpty(telefone) || telefone.Length != 11)
                return telefone;

            return $"({telefone.Substring(0, 2)}) {telefone.Substring(2, 5)}-{telefone.Substring(7, 4)}";
        }
    }
}
