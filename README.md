# Generic Repository C#

Example to use:

You need to create a class inside your business logic layer, for example Repository.cs like this:

```javascript

public class Repository : EFRepository, IDisposable
{
    public Repository(bool autoDetectChangesEnabled = false, bool proxyCreationEnabled = false) : base(new AlmacenContext(), autoDetectChangesEnabled, proxyCreationEnabled)
    {
    }
}

```

And then in another class for example ProdutBL.cs:

```javascript

IRepository repo = new Business.Repository();

public IEnumerable<Product> GetAll()
{
    return repo.GetAll<Product>(c=>true);
}

```

If you need relations

```javascript

IRepository repo = new Business.Repository();

public IEnumerable<Product> GetAll()
{
    return repo.GetAll<Product>(c=>true, "Category");
}

```

or

```javascript

IRepository repo = new Business.Repository();

public IEnumerable<Product> GetAll()
{
    return repo.GetAll<Product>(c=>true, c=>c.Category);
}

```
