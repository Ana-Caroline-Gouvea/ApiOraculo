namespace Api.Models
{
    public class PostagemModel

    {
        public int PostagemId { get; set; }
        public string PostagemNome { get; set; } = string.Empty;
        public string PostagemImg { get; set; } = string.Empty;
        public int ComunidadesId { get; set; }
        public int CategoriaId { get; set; }
        public int Like { get; set; }
        public int Compartilhamento { get; set; }


        public static implicit operator List<object>(PostagemModel v)
        {
            throw new NotImplementedException();
        }
    }
}
