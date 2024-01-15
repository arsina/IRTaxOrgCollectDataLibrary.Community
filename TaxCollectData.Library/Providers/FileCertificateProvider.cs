using TaxCollectData.Library.Abstraction.Providers;

namespace TaxCollectData.Library.Providers
{
    public class FileCertificateProvider : ICertificateProvider
    {
        private readonly string _certificateFilePath;
        private readonly string _privateKeyFilePath;

        public FileCertificateProvider(string certificateFilePath, string privateKeyFilePath)
        {
            _certificateFilePath = certificateFilePath;
            _privateKeyFilePath = privateKeyFilePath;
        }

        public TextReader GetCertificateReader()
        {
            return File.OpenText(_certificateFilePath);
        }

        public TextReader GetPrivateKeyReader()
        {
            return File.OpenText(_privateKeyFilePath);
        }
    }
}
