using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BaseDto
{

    public class Response<T>
    {
        public T? Data { get; set; }
        public List<string> Message { get; set; } = new List<string>();
        public bool IsSuccess { get; set; } = true;

    }


    public class Response
    {
        public List<string> Message { get; set; } = new List<string>();
        public bool IsSuccess { get; set; } = true;
    }


}