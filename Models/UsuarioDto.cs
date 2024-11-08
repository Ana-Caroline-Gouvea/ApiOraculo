namespace Api.Models
{
    public class UsuarioDto
    {

        public int UsuarioId { get; set; }

        public string UsuarioNome { get; set; } = string.Empty;

        public string UsuarioEmail { get; set; } = string.Empty;

        public string UsuarioFoto { get; set; } = string.Empty;

        public string UsuarioApelido { get;set; } = string.Empty;
    }
}
