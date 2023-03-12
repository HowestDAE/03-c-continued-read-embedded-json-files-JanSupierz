using L03_HearthStone.LIB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EX01_HearthStone.WPF.Repository
{
    internal class CardRepository
    {
        private static List<CardType> _cardTypes;

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
            if(_cardTypes == null)
            {
                GetCardTypes();
            }

            return _cardTypes.Find(cardType => cardType.Id == id);
       }
    }
}
