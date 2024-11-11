namespace EventFlow.Utils
{
    public class StringFormatter
    {
        public static string FormatarTelefone(string telefone)
        {
            if (string.IsNullOrEmpty(telefone) || telefone.Length != 11)
                return telefone;

            return $"({telefone.Substring(0, 2)}) {telefone.Substring(2, 5)}-{telefone.Substring(7, 4)}";
        }

        public static string FormatarCEP(string cep)
        {
            if (string.IsNullOrEmpty(cep) || cep.Length != 8)
                return cep;

            return $"{cep.Substring(0, 5)}-{cep.Substring(5, 3)}";
        }
    }
}
