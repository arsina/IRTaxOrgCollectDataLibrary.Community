using TaxCollectData.Library.Abstraction.Providers;

namespace TaxCollectData.Library.Providers
{
    public class StringCertificateProvider : ICertificateProvider
    {
        private readonly string _certificateContent;
        private readonly string _privateKeyContnet;

        public StringCertificateProvider(string certificateContent, string privateKeyContent)
        {
            _certificateContent = certificateContent;
            _privateKeyContnet = privateKeyContent;
        }

        public TextReader GetCertificateReader()
        {
            return new StringReader(_certificateContent);
        }

        public TextReader GetPrivateKeyReader()
        {
            return new StringReader(_privateKeyContnet);
        }
    }
}
