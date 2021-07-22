using Blog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Shared.Entities.Abstract
{
   public abstract class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; }
        public string Message { get; set; }
    }
}
