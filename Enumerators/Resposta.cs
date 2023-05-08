using System.Text.Json.Serialization;

namespace ListaConvidados.Enumerators
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Resposta
    {
        Nao = 0,
        Sim = 1
    }
}
