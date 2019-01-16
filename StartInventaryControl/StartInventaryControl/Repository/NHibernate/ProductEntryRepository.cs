using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartInventaryControl.Data;
using StartInventaryControl.Factory;
using NHibernate.Exceptions;
using NHibernate.Linq;
using System.Transactions;

namespace StartInventaryControl.Repository.NHibernate
{
    public class ProductEntryRepository : IProductEntryRepository
    {
        public void Add(ProductEntry productEntry)
        {
            productEntry.Valid();
            
            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    var transaction = session.BeginTransaction();
                    
                    session.Save(productEntry);

                    var product = productEntry.Product;
                    foreach(var variation in product.GetVariationUpdatedByProductEntryQuantity(productEntry.ProductEntryItems))
                    {
                        session.Update(variation);
                    }

                    session.Flush();
                    transaction.Commit();
                }
                catch (ConstraintViolationException ex)
                {
                    throw new RepositoryException($"Entrada de produto '{productEntry.Code}' já existe.", ex);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível adicionar a entrada de produto '{productEntry.Code}': {ex.Message}", ex);
                }
            }

        }

        public void Delete(ProductEntry productEntry)
        {
            productEntry.Valid();

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    session.Delete(productEntry);
                    session.Flush();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível deletar a entrada de produto '{productEntry.Code}': {ex.Message}", ex);
                }
            }
        }

        public IList<ProductEntry> GetAll()
        {
            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    return session.QueryOver<ProductEntry>().List();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível obter todas as entradas de produto: {ex.Message}", ex);
                }
            }
        }

        public ProductEntry GetByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new RepositoryException("Código da entrada de produto não pode estar vazia.");
            }

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    return (from w in session.Query<ProductEntry>() where w.Code == code select w).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível obter todas as ordens de serviços: {ex.Message}", ex);
                }
            }
        }

        public void Update(ProductEntry productEntry)
        {
            productEntry.Valid();

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    session.Update(productEntry);
                    session.Flush();
                }
                catch (ConstraintViolationException ex)
                {
                    throw new RepositoryException($"Entrada de produto '{productEntry.Code}' já existe.", ex);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível adicionar a entrada de produto '{productEntry.Code}': {ex.Message}", ex);
                }
            }
        }
    }
}
