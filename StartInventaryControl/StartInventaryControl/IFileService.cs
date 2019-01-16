using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl
{
    public interface IFileService
    {
        byte[] ReadAllBytes(string filePath);

        void WriteAllBytes(byte[] bytes, string TargetFilePath);
    }
}
