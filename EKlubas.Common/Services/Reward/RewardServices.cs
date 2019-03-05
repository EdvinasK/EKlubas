using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Common.Services
{
    public class RewardServices
    {
        private static decimal Bonus = 1.15M;

        public static int CalculateCoinReward(int markPercentage, int passMark, int baseReward, bool isNew)
        {
            if (markPercentage < passMark)
                return 0;

            var bonusModifier = (markPercentage - passMark) / 10;
            var reward = baseReward;
            var baseBonus = Bonus;

            while(bonusModifier > 0)
            {
                Bonus = Bonus * baseBonus;
                bonusModifier--;
            }

            if (isNew)
                Bonus *= 1.1m;

            reward = Convert.ToInt32(Math.Round(reward * Bonus));

            return reward;
        }
    }
}
