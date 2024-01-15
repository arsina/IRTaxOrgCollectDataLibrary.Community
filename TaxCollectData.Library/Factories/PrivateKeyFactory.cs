using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace TaxCollectData.Library.Factories;

public class PrivateKeyFactory
{
    public RSA ReadPrivateKeyFromFile(string privateKeyPath)
    {
        var privateKeyPemReader = new PemReader(File.OpenText(privateKeyPath));
        return DotNetUtilities.ToRSA((RsaPrivateCrtKeyParameters)privateKeyPemReader.ReadObject());
    }

    public RSA ReadPrivateKey(TextReader privateKeyReader)
    {
        var privateKeyPemReader = new PemReader(privateKeyReader);
        return DotNetUtilities.ToRSA((RsaPrivateCrtKeyParameters)privateKeyPemReader.ReadObject());
    }
}