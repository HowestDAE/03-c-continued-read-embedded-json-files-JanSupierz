using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03_HearthStone.LIB
{
    public class CardType
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Class { get; set; }

        [JsonIgnore]
        public Type ActualType
        {
            get 
            {
                if(Slug == "minion")
                {
                    return typeof(MinionCard);
                }
                else if(Slug == "hero")
                {
                    return typeof(HeroCard);
                }
                else if(Slug == "spell")
                {
                    return typeof(SpellCard);
                }
                else if(Slug == "weapon")
                {
                    return typeof(WeaponCard);
                }
                else
                {
                    throw new InvalidOperationException($"Unknown card type slug '{Slug}'");
                }

            }
        }
    }
}
