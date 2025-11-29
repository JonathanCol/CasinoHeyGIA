namespace CasinoHeyGIA.Application.Models
{
    public class ApuestaRequest
    {
        public string Id_Ruleta {  get; set; }
        public int Numero { get; set; }
        public decimal Apuesta { get; set; }
        public string IdUsuario { get; set; }
    }
}
