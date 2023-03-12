using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;


namespace L03_HearthStone.LIB
{
    public abstract class BaseCard
    {
        private string _text;

        public string  Text
        {
            get 
            {
                return Regex.Replace(_text, "<.*?>", string.Empty);
            }
            set { _text = value; }
        }


        [JsonProperty("name")]
        public string DisplayName { get; set; }
        public string ArtistName { get; set; }

        public int ManaCost { get; set; }

        public abstract BitmapImage Image { get; }
    }

    interface IHasLifeSpan
    {
        int LifesLeft { get; }
    }


    public class MinionCard : BaseCard, IHasLifeSpan
    {
        public int Attack { get; set; }

        public int Health { get; set; }

        public override BitmapImage Image
        {
            get
            {
                return new BitmapImage(
                new Uri($"pack://application:,,,/Resources/DataFiles/cardtypes/card minion.png", UriKind.Absolute));
            }
        }

        public int LifesLeft
        {
            get { return Health; }
        }
    }

    public class HeroCard : BaseCard, IHasLifeSpan
    {
        public int Health { get; set; }

        public override BitmapImage Image
        {
            get
            {
                return new BitmapImage(
                new Uri($"pack://application:,,,/Resources/DataFiles/cardtypes/herocard.png", UriKind.Absolute));

            }
        }

        public int LifesLeft
        {
            get { return Health; }
        }
    }

    public class SpellCard : BaseCard
    {
        public override BitmapImage Image
        {
            get
            {
                return new BitmapImage(
                new Uri($"pack://application:,,,/Resources/DataFiles/cardtypes/spell.png", UriKind.Absolute));
            }
        }
    }

    public class WeaponCard : BaseCard, IHasLifeSpan
    {
        int Durability { get; set; }

        public override BitmapImage Image
        {
            get
            {
                return new BitmapImage(
                new Uri($"pack://application:,,,/Resources/DataFiles/cardtypes/weaponcard.png", UriKind.Absolute));
            }
        }

        public int LifesLeft
        {
            get { return Durability; }
        }
    }

}
