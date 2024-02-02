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
        }
        if (dealer > player)
        {
            return true;
        }
        if (player < 17)
        {
            return true;
        }

        return false;
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

                    case "jack":
                    case "queen":
                    case "king":
                        total += 10;
                        break;
                }
            }
        }
        if (total > 21)
        {
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
