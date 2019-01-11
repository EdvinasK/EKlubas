using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Domain
{
    public class RewardHistory : Entity<long>
    {
        public string UserId { get; set; }
        public EKlubasUser User { get; set; }
        public int Reward { get; set; }
        public DateTime ReceiveTime { get; set; } = DateTime.Now;
    }
}
