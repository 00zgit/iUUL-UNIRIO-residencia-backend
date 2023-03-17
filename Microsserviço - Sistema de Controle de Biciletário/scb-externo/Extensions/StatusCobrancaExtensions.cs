using scb_externo.Models.Enum;

namespace scb_externo.Extensions
{
    public static class StatusCobrancaExtensions
    {
        private static Dictionary<string, StatusCobranca> Mapa = new()
        {
                { "PAGA", StatusCobranca.PAGA },
                { "PENDENTE", StatusCobranca.PENDENTE },
                { "FALHA", StatusCobranca.FALHA },
                { "CANCELADA", StatusCobranca.CANCELADA },
                { "OCUPADA", StatusCobranca.OCUPADA }
        };

        public static string ParaString(this StatusCobranca status)
        {
            return Mapa.First(s => s.Value == status).Key;
        }

        public static StatusCobranca ParaValor(this string status)
        {
            return Mapa.First(s => s.Key == status).Value;
        }
    }
}
