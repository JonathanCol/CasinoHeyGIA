namespace CasinoHeyGIA.Application.Models
{
    public class RuletaApuestaRequest
    {
        public string IdRuleta {  get; set; }
        public string? Numero { get; set; }
        public string? Color { get; set; }
        public decimal Monto { get; set; }
        public string IdUsuario { get; set; }
    }
}
