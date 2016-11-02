# Generic Repository C sharp

Example to use:

You need to create a class inside your business logic layer, for example Repository.cs like this:

```javascript

public class BL_Repository: Repository.EntityFramework.Repository, IDisposable
{
    public BL_Repository(bool autoDetectChangesEnabled = false, bool proxyCreationEnabled = false)
        :base(new NWContext(),autoDetectChangesEnabled,proxyCreationEnabled)
    {

    }
}

```

And then in another class for example BL_Product.cs:

```javascript

namespace Repository.NWBusiness
{
    public class BL_Product
    {
        IRepository repo = new BL_Repository();

        public IEnumerable<Product> GetAll()
        {
            return repo.GetAll<Product>(p => true);
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await repo.GetAllAsync<Product>(p => true);
        }

        public async Task<IEnumerable<Product>> GetAllWithRelationAsync()
        {
            return await repo.GetAllAsync<Product>(p => true, "Category");
        }
    }
}

```

If you need relations

```javascript

public async Task<IEnumerable<Product>> GetAllWithRelationAsync()
{
    return await repo.GetAllAsync<Product>(p => true, "Category");
}

```

Async methods

```javascript

public async Task<IEnumerable<Product>> GetAllAsync()
{
    return await repo.GetAllAsync<Product>(p => true);
}

public async Task<IEnumerable<Product>> GetAllWithRelationAsync()
{
    return await repo.GetAllAsync<Product>(p => true, "Category");
}

```
