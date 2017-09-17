using Repository;
using Repository.EntityFramework;
using System;
namespace ConsoleAppTest.Context
{
    public class RepoUoWContext : EFUnitOfWork, IDisposable, IUnitOfWork
    {
        public RepoUoWContext(bool autoDetectChangesEnabled = false, bool proxyCreationEnabled = false)
            : base(new FakeContext(), autoDetectChangesEnabled, proxyCreationEnabled)
        {
        }
    }
}
