using TaxCollectData.Library.Abstraction.Cryptography;
using TaxCollectData.Library.Abstraction.Providers;
using TaxCollectData.Library.Providers;

namespace TaxCollectData.Library.Factories;

public class Pkcs8SignatoryFactory
{
    private readonly SignatoryFactory _signatoryFactory;
    private readonly X509CertificateFactory _x509CertificateFactory;
    private readonly PrivateKeyFactory _privateKeyFactory;

    public Pkcs8SignatoryFactory()
    {
        var currentDateProvider = new CurrentDateProvider();
        _signatoryFactory = new SignatoryFactory(currentDateProvider);
        _x509CertificateFactory = new X509CertificateFactory();
        _privateKeyFactory = new PrivateKeyFactory();
    }

    public ISignatory Create(string privateKeyPath, string certificatePath)
    {
        var privateKey = _privateKeyFactory.ReadPrivateKeyFromFile(privateKeyPath);
        var x509Certificate = _x509CertificateFactory.ReadCertificateFromFile(certificatePath);
        return _signatoryFactory.Create(privateKey, x509Certificate);
    }

    /// <summary>
    /// Creates and instance of Pkcs8Signatory initialized with provided Certificate and Privatekey
    /// </summary>
    /// <param name="certificateProvider"></param>
    /// <returns></returns>
    public ISignatory Create(ICertificateProvider certificateProvider)
    {
        var privateKey = _privateKeyFactory.ReadPrivateKey(certificateProvider.GetPrivateKeyReader());
        var x509Certificate = _x509CertificateFactory.ReadCertificate(certificateProvider.GetCertificateReader());
        return _signatoryFactory.Create(privateKey, x509Certificate);
    }
}