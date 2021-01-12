using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Interface_BaiTapLon
{
   public interface IBaseService<T>where T:class

    {
        IEnumerable<T> GetAll();
        T getById(object id);
    }
}
