namespace Api.Models
{
    public class NovidadeModel
    {
        public int NovidadeId { get; set; }

        public string NovidadeTexto { get; set; } = string.Empty;

        public string NovidadeFoto { get; set; } = string.Empty;



        public static implicit operator List<object>(NovidadeModel v)
        {
            throw new NotImplementedException();
        }
    }
}
