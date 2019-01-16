using StartInventaryControl.Data;
using System.Collections.Generic;

namespace StartInventaryControl
{
    public interface IReportCreator
    {
        void Create(string filePath, IList<Variation> variations);
    }
}
