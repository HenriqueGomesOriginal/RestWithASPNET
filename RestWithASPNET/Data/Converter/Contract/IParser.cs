using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Data.Converter.Contract
{
    // D -> Destination
    // SRC -> For sure is source
    public interface IParser<SRC, D>
    {
        D Parse(SRC source);

        List<D> Parse(List<SRC> source);
    }
}
