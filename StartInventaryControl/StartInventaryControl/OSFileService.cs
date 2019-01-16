using System;
using System.IO;

namespace StartInventaryControl
{
    public class OSFileService : IFileService
    {
        public byte[] ReadAllBytes(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("Arquivo não pode ser nulo um vazio.");
            }
            try
            {
                return File.ReadAllBytes(filePath);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void WriteAllBytes(byte[] bytes, string TargetFilePath)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("Dados para inserir no arquivo não pode ser nulo um vazio.");
            }
            try
            {
                File.WriteAllBytes(TargetFilePath, bytes);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
