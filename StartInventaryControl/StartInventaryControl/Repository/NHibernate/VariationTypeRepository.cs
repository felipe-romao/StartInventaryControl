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
    public class VariationTypeRepository : IVariationTypeRepository
    {

        public void Add(VariationType variationType)
        {
            if (variationType == null)
            {
                throw new RepositoryException($"Tipo de variação não pode estar nulo ou vazio.");
            }

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    session.Save(variationType);
                    session.Flush();
                }
                catch (ConstraintViolationException ex)
                {
                    throw new RepositoryException($"Tipo de variação '{variationType.Type}'/'{variationType.Value}' já existe.", ex);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível adicionar o tipo de variação '{variationType.Type}/{variationType.Value}': {ex.Message}", ex);
                }
            }
        }

        public void Delete(VariationType variationType)
        {
            if (variationType == null)
            {
                throw new RepositoryException($"Tipo de variação não pode estar nulo ou vazio.");
            }

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    session.Delete(variationType);
                    session.Flush();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível deletar o tipo de variação '{variationType.Type}/{variationType.Value}': {ex.Message}", ex);
                }
            }

        }

        public IList<VariationType> GetAll()
        {
            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    return session.QueryOver<VariationType>().List();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível obter todas as variações: {ex.Message}", ex);
                }
            }
        }
    }
}
