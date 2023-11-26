using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class Catalog
{
    public int CatalogId { get; set; }
    public int? ParentCatalogId { get; set; }
    public string? Name { get; set; }

    public List<Catalog>? ChildCatalogs { get; set; }
}
