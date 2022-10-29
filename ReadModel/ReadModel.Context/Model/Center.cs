using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModel.Context.Model
{
    public partial class Center
    {
        public Center()
        {
            Parts = new HashSet<Part>();
        }
        public Guid Id { get; set; }
        public string CenterName { get; set; }
        public int CenterID { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
