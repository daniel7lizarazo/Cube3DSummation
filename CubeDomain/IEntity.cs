using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeDomain
{
    public interface IEntity<TId> where TId : IComparable, IComparable<TId>
    {
        public TId Id { get; set; }
    }
}
