namespace Api.Models
{
    public class ComunidadesModel
    {
        public int ComunidadesId { get; set; }
        public string ComunidadesNome { get; set; } = string.Empty;







        public static implicit operator List<object>(ComunidadesModel v)
        {
            throw new NotImplementedException();
        }
    }
}
