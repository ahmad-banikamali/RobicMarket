using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BaseDto
{
    public class  Request <T> 
    {
        public Request( T data )
        {
            Data = data;
        }
        public T Data { get; }
    }
 

}
