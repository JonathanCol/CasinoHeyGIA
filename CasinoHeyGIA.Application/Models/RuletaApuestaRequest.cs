namespace CasinoHeyGIA.Application.Models
{
    public class RuletaApuestaRequest
    {
        public string Id_Ruleta {  get; set; }
        public int Numero { get; set; }
        public string Color { get; set; }
        public decimal Monto { get; set; }
        public string IdUsuario { get; set; }
    }
}
