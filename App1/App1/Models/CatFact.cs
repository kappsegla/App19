using System.Collections.Generic;

namespace App1.Models
{
    public class CatFact
    {
        public string Text { get; set; }
    }
    public class CatFacts
    {
        public List<CatFact> All { get; set; }
    }
}