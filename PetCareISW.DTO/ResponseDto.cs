using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceApi.Dto
{
    public class ResponseDto<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; }
    }
}
