namespace Api.Models
{
    public class EventoModel
    {
        public int EventoId { get; set; }

        public string EventoNome { get; set; } = string.Empty;

        public string EventoFoto { get; set; } = string.Empty;







        public static implicit operator List<object>(EventoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
