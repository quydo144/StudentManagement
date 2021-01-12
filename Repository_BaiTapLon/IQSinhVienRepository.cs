using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_BaiTapLon
{
   public interface IQSinhVienRepository<T>:IRepositoryBase<T>
    {
       T GetById(object id);
        
    }
}
