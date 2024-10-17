namespace Api.Models
{
    public class MaisComentadosModel
    {
        public int MaisComentadosId { get; set; }
        public int PostagemId { get; set; }

        public static implicit operator List<object>(MaisComentadosModel v)
        {
            throw new NotImplementedException();
        }
    }
}
