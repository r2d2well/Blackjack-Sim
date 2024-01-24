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
        public static void DealerMove(Stack<Card> deck, List<Card> dealer)
        {
            byte total = GetDealerTotal(dealer);
            if (total < 17)
            {
                dealer.Add(deck.Pop());
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
                        case "A":
                            total += 11;
                            break;

                        case "J":
                        case "Q":
                        case "K":
                            total += 10;
                            break;
                    }
                }
            }
            return total;
        }
    }
}
