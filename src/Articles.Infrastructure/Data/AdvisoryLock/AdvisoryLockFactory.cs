using Articles.Application.Common.Data.AdvisoryLock;
using System.Security.Cryptography;
using System.Text;

namespace Articles.Infrastructure.Data.AdvisoryLock;

internal sealed class AdvisoryLockFactory(AppDbContext dbContext) : IAdvisoryLockFactory
{
    private readonly Encoding _encoding = new UTF8Encoding(false);
    private readonly HashAlgorithm _hashAlgorithm = MD5.Create();

    public IAdvisoryLock Create(string name)
    {
        var id = BitConverter.ToInt64(_hashAlgorithm.ComputeHash(_encoding.GetBytes(name)));
        return new AdvisoryLock(dbContext, id);
    }
}