using L03_HearthStone.LIB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;


namespace EX01_HearthStone.WPF.Repository
{
    internal class CardRepository
    {
        private static List<CardType> _cardTypes;
        private static List<BaseCard> _cards;

        public static List<CardType> GetCardTypes()
        {
            if (_cardTypes != null)
            {
                return _cardTypes;
            }

            //Read only once
            string json = File.ReadAllText("../../Resources/DataFiles/cardtypes.json");

            _cardTypes = JsonConvert.DeserializeObject<List<CardType>>(json);
            return _cardTypes;
        }

        public static CardType GetCardType(int id)
        {
            if (_cardTypes == null)
            {
                GetCardTypes();
            }

            return _cardTypes.Find(cardType => cardType.Id == id);
        }

        public static List<BaseCard> GetCards()
        {
            if (_cards != null)
            {
                return _cards;
            }

            //Read only once
            string json = File.ReadAllText("../../Resources/DataFiles/cards.json");

            _cards = JToken.Parse(json).SelectToken("cards").ToObject<List<BaseCard>>();
            return _cards;
        }
    }
}
