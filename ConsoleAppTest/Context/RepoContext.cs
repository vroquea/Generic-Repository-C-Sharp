using System;

namespace ConsoleAppTest.Context
{
    public class RepoContext : Repository.EntityFramework.EFRepository, IDisposable
    {
        public RepoContext(bool autoDetectChangesEnabled = false, bool proxyCreationEnabled = false)
            :base(new FakeContext(),autoDetectChangesEnabled,proxyCreationEnabled)
        {

        }
    }
}
