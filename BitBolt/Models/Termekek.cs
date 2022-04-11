namespace BitBolt.Models
{
    public class Termekek
    {
        public int Id { get; set; }
        public string Megnevezés { get; set; }
        public string Gyáró { get; set; }
        public string Típus { get; set; }
        public float BeszerzésiÁr { get; set; }

        public Termekek()
        {

        }
    }
}
