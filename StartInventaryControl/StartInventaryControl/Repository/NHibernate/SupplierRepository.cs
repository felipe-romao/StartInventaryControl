using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartInventaryControl.Data;
using StartInventaryControl.Factory;
using NHibernate.Exceptions;

namespace StartInventaryControl.Repository.NHibernate
{
    public class SupplierRepository : ISupplierRepository
    {
        public void Add(Supplier supplier)
        {
            if (supplier == null)
            {
                throw new RepositoryException($"O fornecedor não pode estar nulo ou vazio.");
            }

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    session.Save(supplier);
                    session.Flush();
                }
                catch (ConstraintViolationException ex)
                {
                    throw new RepositoryException($"Fornecedor '{supplier.Name}' já existe.", ex);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível adicionar o fornecedor'{supplier.Name}': {ex.Message}", ex);
                }
            }
        }

        public void Delete(Supplier supplier)
        {
            if (supplier == null)
            {
                throw new RepositoryException($"O fornecedor não pode estar nulo ou vazio.");
            }

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    session.Delete(supplier);
                    session.Flush();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível deletar o fornecedor '{supplier.Name}': {ex.Message}", ex);
                }
            }
        }

        public IList<Supplier> GetAll()
        {
            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    return session.QueryOver<Supplier>().List();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível obter todos os fornecedores: {ex.Message}", ex);
                }
            }
        }

        public void Update(Supplier supplier)
        {
            if (supplier == null)
            {
                throw new RepositoryException($"O fornecedor não pode estar nulo ou vazio.");
            }

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    session.Update(supplier);
                    session.Flush();
                }
                catch (ConstraintViolationException ex)
                {
                    throw new RepositoryException($"Fornecedor '{supplier.Name}' já existe.", ex);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível atualizar o fornecedor'{supplier.Name}': {ex.Message}", ex);
                }
            }
        }
    }
}
