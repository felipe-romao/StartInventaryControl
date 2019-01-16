using System;
using System.Collections.Generic;
using System.Linq;
using StartInventaryControl.Data;
using StartInventaryControl.Factory;
using NHibernate.Exceptions;
using NHibernate.Linq;

namespace StartInventaryControl.Repository.NHibernate
{
    public class ProductIssueRepository : IProductIssueRepository
    {
        public void Add(ProductIssue productIssue)
        {
            productIssue.Valid();
            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    var transaction = session.BeginTransaction();

                    session.Save(productIssue);

                    var product = productIssue.Product;
                    foreach (var variation in product.GetVariationUpdatedByProductIssueQuantity(productIssue.ProductIssueItems))
                    {
                        session.Update(variation);
                    }

                    session.Flush();
                    transaction.Commit();
                }
                catch (ConstraintViolationException ex)
                {
                    throw new RepositoryException($"Saida de produto '{productIssue.Code}' já existe.", ex);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível adicionar a saida de produto '{productIssue.Code}': {ex.Message}", ex);
                }
            }
        }

        public void Delete(ProductIssue productIssue)
        {
            productIssue.Valid();
            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    session.Delete(productIssue);
                    session.Flush();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível deletar a saida de produto '{productIssue.Code}': {ex.Message}", ex);
                }
            }
        }

        public IList<ProductIssue> GetAll()
        {
            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    return session.QueryOver<ProductIssue>().List();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível obter todas as saidas de produto: {ex.Message}", ex);
                }
            }
        }

        public ProductIssue GetByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new RepositoryException("Código da saida de produto não pode estar vazia.");
            }

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    return (from w in session.Query<ProductIssue>() where w.Code == code select w).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível obter todas saida de produtos: {ex.Message}", ex);
                }
            }
        }

        public void Update(ProductIssue productIssue)
        {
            productIssue.Valid();
            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    session.Update(productIssue);
                    session.Flush();
                }
                catch (ConstraintViolationException ex)
                {
                    throw new RepositoryException($"Saida de produto '{productIssue.Code}' já existe.", ex);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível atualizar a saida de produto '{productIssue.Code}': {ex.Message}", ex);
                }
            }
        }
    }
}
