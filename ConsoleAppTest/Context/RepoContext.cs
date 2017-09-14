using System;

namespace ConsoleAppTest.Context
{
    public class RepoContext : Repository.EntityFramework.Repository, IDisposable
    {
        public RepoContext(bool autoDetectChangesEnabled = false, bool proxyCreationEnabled = false)
            :base(new FakeContext(),autoDetectChangesEnabled,proxyCreationEnabled)
        {

        }
    }
}
