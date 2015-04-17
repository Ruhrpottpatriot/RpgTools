using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTools.Core.Common
{
    public interface ITagsRepository
    {
        IEnumerable<string> Find(Func<object, bool> selector);
    }
}
