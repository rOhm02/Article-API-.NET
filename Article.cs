namespace SimpleApi
{
    public class Article
    {
        public int id { get; set; }
        public string ueberschrift { get; set; }
        public string autor { get; set; }
        public string datum { get; set; }
        public string anriss { get; set; }
        public string text { get; set; }
        public string[] tags { get; set; }
        public string bild { get; set; }

        public Article(int id, string ueberschrift, string autor, string datum, string anriss, string text, string[] tags, string bild = "")
        {
            this.id = id;
            this.ueberschrift = ueberschrift;
            this.autor = autor;
            this.datum = datum;
            this.anriss = anriss;
            this.text = text;
            this.tags = tags;
            this.bild = bild;
        }
    }
}
