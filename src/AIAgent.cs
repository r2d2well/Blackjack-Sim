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
}
