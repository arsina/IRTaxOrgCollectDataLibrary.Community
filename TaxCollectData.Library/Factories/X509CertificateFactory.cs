using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TaxCollectData.Library.Factories;

public class X509CertificateFactory
{
    public X509Certificate ReadCertificateFromFile(string certificatePath)
    {
        return new X509Certificate(File.ReadAllBytes(certificatePath));
    }

    public X509Certificate ReadCertificate(TextReader certificateReader)
    {
        return new X509Certificate(Encoding.UTF8.GetBytes(certificateReader.ReadToEnd()));
    }
}