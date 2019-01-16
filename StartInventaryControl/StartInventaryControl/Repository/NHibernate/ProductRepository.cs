using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartInventaryControl.Data;
using StartInventaryControl.Factory;
using NHibernate.Exceptions;
using System.Transactions;
using NHibernate.Linq;

namespace StartInventaryControl.Repository.NHibernate
{
    public class ProductRepository : IProductRepository
    {
        public void Add(Product product)
        {
            if (product == null)
            {
                throw new RepositoryException($"O produto não pode estar nulo ou vazio.");
            }

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    session.Save(product);
                    session.Flush();
                }
                catch (ConstraintViolationException ex)
                {
                    throw new RepositoryException($"Produto '{product.Description}' já existe.", ex);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível adicionar o produto '{product.Description}': {ex.Message}", ex);
                }
            }
        }

        public void Delete(Product product)
        {
            if (product == null)
            {
                throw new RepositoryException($"O produto não pode estar nulo ou vazio.");
            }

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    session.Delete(product);
                    session.Flush();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível deletar o produto '{product.Description}': {ex.Message}", ex);
                }
            }
        }

        public IList<Product> GetAll()
        {
            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    return session.QueryOver<Product>().List();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível obter todos os produtos: {ex.Message}", ex);
                }
            }
        }

        public Product GetByID(long ID)
        {
            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    return (from w in session.Query<Product>() where w.ID == ID select w).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível obter dados do produto: {ex.Message}", ex);
                }
            }
        }

        public void Update(Product product)
        {
            if (product == null)
            {
                throw new RepositoryException($"O produto não pode estar nulo ou vazio.");
            }

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    session.Update(product);
                    session.Flush();
                }
                catch (ConstraintViolationException ex)
                {
                    throw new RepositoryException($"Produto '{product.Description}' já existe.", ex);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível atualizar o produto '{product.Description}': {ex.Message}", ex);
                }
            }
        }
    }
}
