using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCollectData.Library.Abstraction.Providers
{
    /// <summary>
    /// An interface to facilitate loading certificates from different sources.
    /// </summary>
    public interface ICertificateProvider
    {
        TextReader GetCertificateReader();
        TextReader GetPrivateKeyReader();
    }
}
