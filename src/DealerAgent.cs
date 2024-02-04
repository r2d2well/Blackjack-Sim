using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_Simulator
{
    internal static class DealerAgent
    {
        public static bool DealerMove(List<Card> dealer)
        {
            byte total = GetDealerTotal(dealer);
            if (total < 17)
            {
                return true;
                //If the dealerTotal is under 17 then hit
            }
            else
            {
                return false;
                //If the dealerTotal is equal to or greater than 17 then stay
            }
        }

        public static byte GetDealerTotal(List<Card> dealer)
        {
            byte total = 0;
            foreach (Card x in dealer)
            {
                try
                {
                    total += Byte.Parse(x.value);
                }
                catch (Exception e)
                {
                    switch (x.value)
                    {
                        case "ace":
                            total += 11;
                            break;
                            //Aces must count as 11

                        case "jack":
                        case "queen":
                        case "king":
                            total += 10;
                            break;
                    }
                    //If value is not a number then adds value manually though switch case
                }
            }
            return total;
        }
    }
}
