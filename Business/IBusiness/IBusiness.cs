
using System;
using System.Collections.Generic;

namespace Business

{
    public interface IBusiness
    {
         IList<String> GetList( );

         IBusiness Get();
    }
}