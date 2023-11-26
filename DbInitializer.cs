using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public static class DbInitializer
    {
        public static void Initialize(CatalogDbContext context)
        {
            if (context.Catalogs.Any())
                return;

            var catalogs = new List<Catalog>
            {
                new Catalog
                {
                    CatalogId = 1,
                    ParentCatalogId = null,
                    Name = "CreatingDigitalImages",
                    ChildCatalogs = new List<Catalog>
                    {
                        new Catalog
                        {
                            CatalogId = 2,
                            ParentCatalogId = 1,
                            Name = "Resources",
                            ChildCatalogs = new List<Catalog>
                            {
                                new Catalog
                                {
                                    CatalogId = 5,
                                    ParentCatalogId = 2,
                                    Name = "PrimarySources"
                                },
                                new Catalog
                                {
                                    CatalogId = 6,
                                    ParentCatalogId = 2,
                                    Name = "SecondarySources"
                                }
                            }
                        },
                        new Catalog
                        {
                            CatalogId = 3,
                            ParentCatalogId = 1,
                            Name = "Evidence",
                        },
                        new Catalog
                        {
                            CatalogId = 4,
                            ParentCatalogId = 1,
                            Name = "GraphicsProducts",
                            ChildCatalogs = new List<Catalog>
                            {
                                new Catalog
                                {
                                    CatalogId = 7,
                                    ParentCatalogId = 4,
                                    Name = "Process"
                                },
                                new Catalog
                                {
                                    CatalogId = 8,
                                    ParentCatalogId = 4,
                                    Name = "FinalProduct"
                                }
                            }
                        }
                    }
                }
            };

            foreach (var catalog in catalogs)
            {
                context.Catalogs.Add(catalog);
            }

            context.SaveChanges();
        }
    }

