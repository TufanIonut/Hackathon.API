namespace Hackathon.API.Entities
{
    public class Parteners
    {
        public int IdPartener { get; set; }
        public string namePartener { get; set; }
        public Parteners(int IdPartener, string namePartener) {
            this.IdPartener = IdPartener;
            this.namePartener = namePartener;
        }  

    }
}