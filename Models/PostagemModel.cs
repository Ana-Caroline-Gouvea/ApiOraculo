namespace Api.Models
{
    public class PostagemModel

    {
        public int PostagemId { get; set; }

        public int UsuarioId { get; set; }

        public DateTime PostagemData { get; set; }

        public int PostagemLike { get; set; }
        public int PostagemCompartilhamento { get; set; }


        public static implicit operator List<object>(PostagemModel v)
        {
            throw new NotImplementedException();
        }
    }
}
