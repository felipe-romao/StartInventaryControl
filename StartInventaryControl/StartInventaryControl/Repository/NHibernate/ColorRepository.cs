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
    public class ColorRepository : IColorRepository
    {
        public void Add(Color color)
        {
            if(color == null)
            {
                throw new RepositoryException($"A cor não pode estar nula ou vazia.");
            }

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    session.Save(color);
                    session.Flush();
                }
                catch (ConstraintViolationException ex)
                {
                    throw new RepositoryException($"Cor '{color.Name}' já existe.", ex);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível adicionar a cor '{color.Name}': {ex.Message}", ex);
                }
            }
        }

        public void Delete(Color color)
        {
            if (color == null)
            {
                throw new RepositoryException($"A cor não pode estar nula ou vazia.");
            }

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    session.Delete(color);
                    session.Flush();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível deletar a cor '{color.Name}': {ex.Message}", ex);
                }
            }
        }

        public IList<Color> GetAll()
        {
            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    return session.QueryOver<Color>().List();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível obter todas as cores: {ex.Message}", ex);
                }
            }
        }

        public void Update(Color color)
        {
            if (color == null)
            {
                throw new RepositoryException($"A cor não pode estar nula ou vazia.");
            }

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    session.Update(color);
                    session.Flush();
                }
                catch (ConstraintViolationException ex)
                {
                    throw new RepositoryException($"Cor '{color.Name}' já existe.", ex);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível atualizar a cor '{color.Name}': {ex.Message}", ex);
                }
            }
        }
    }
}
