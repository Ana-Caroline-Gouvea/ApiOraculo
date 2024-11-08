namespace Api.Models
{
    public class PostagemCompleta
    {
        public int PostagemId { get; set; }
        public string PostagemNome { get; set; } = string.Empty;
        public string PostagemImg { get; set; } = string.Empty;
        public int ComunidadesId { get; set; }
        public int CategoriaId { get; set; }
        public int Like { get; set; }
        public int Compartilhamento { get; set; }

        public UsuarioDto? Usuario { get; set; }
    }
}
