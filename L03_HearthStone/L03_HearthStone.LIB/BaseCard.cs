using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03_HearthStone.LIB
{
    public class BaseCard
    {
        [JsonProperty("name")]
        public string DisplayName { get; set; }
        public string ArtistName { get; set; }
        public string Text { get; set; }
        public int ManaCost { get; set; }
    }
}
