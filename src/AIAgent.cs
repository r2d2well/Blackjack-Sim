using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

public static class AIAgent
{
    public static bool DetermineMove(byte player, byte dealer)
    {
        if (player < 12)
        {
            return true;
            //If playertotal is under 12 no risk to not hitting
        }
        if (dealer > player)
        {
            return true;
            //If dealer has higher total then player then player must hit to win regardless of player total
        }
        if (player < 17)
        {
            return true;
            //If player is under 17 total then it should hit
        }

        return false;
        //Otherwise return false
    }

    public static byte GetPlayerTotal(List<Card> list)
    {
        byte total = 0;
        foreach (Card x in list)
        {
            try
            {
                total += byte.Parse(x.value);
            }
            catch (Exception e)
            {
                switch (x.value)
                {
                    case "ace":
                        total += 11;
                        break;
                        //Aces count as 11 here

                    case "jack":
                    case "queen":
                    case "king":
                        total += 10;
                        break;
                }
                //If value is not a number then adds value manually though switch case
            }
        }
        if (total > 21)
        {
            //If player total is over 21 then calculate the total again
            //but this time do so with aces counting as 1 instead of 11
            total = 0;
            foreach (Card x in list)
            {
                try
                {
                    total += byte.Parse(x.value);
                }
                catch (Exception e)
                {
                    switch (x.value)
                    {
                        case "ace":
                            total++;
                            break;

                        case "jack":
                        case "queen":
                        case "king":
                            total += 10;
                            break;
                    }
                }
            }
        }
        return total;
    }
}
