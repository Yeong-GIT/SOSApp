using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSApp
{
    public class MasterDetailPageSOSFlyoutMenuItem
    {
        public MasterDetailPageSOSFlyoutMenuItem()
        {
            TargetType = typeof(MasterDetailPageSOSFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}