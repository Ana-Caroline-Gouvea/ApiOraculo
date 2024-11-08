namespace Api.Models
{
    public class ComunidadeUsuarioModel
    {
        public int ComunidadeUsuarioId { get; set; }
        public int UsuarioId { get; set; }
        public int ComunidadesId { get; set; }

        public static implicit operator List<object>(ComunidadeUsuarioModel v)
        {
            throw new NotImplementedException();
        }
    }
}
