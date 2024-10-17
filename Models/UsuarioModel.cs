namespace Api.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }

        public string UsuarioNome { get; set; } = string.Empty;

        public string UsuarioEmail { get; set; } = string.Empty;

        public string UsuarioApelido { get; set; } = string.Empty;

        public DateTime UsuarioNascimento { get; set; }

        public string UsuarioFoto { get; set; } = string.Empty;

        public string UsuarioSenha { get; set; } = string.Empty;

        public string UsuarioConfirmarSenha { get; set; } = string.Empty;

        public static implicit operator List<object>(UsuarioModel v)
        {
            throw new NotImplementedException();
        }
    }
}
