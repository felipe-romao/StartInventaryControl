using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartInventaryControl.Data;
using StartInventaryControl.Factory;
using NHibernate.Exceptions;
using NHibernate.Linq;

namespace StartInventaryControl.Repository.NHibernate
{
    public class WorkOrderRepository : IWorkOrderRepository
    {
        public void Add(WorkOrder workOrder)
        {
            workOrder.Valid();

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(workOrder);
                        transaction.Commit();
                    }
                    catch (ConstraintViolationException ex)
                    {
                        transaction.Rollback();
                        throw new RepositoryException($"Ordem de serviço '{workOrder.Code}' já existe.", ex);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new RepositoryException($"Não foi possível adicionar a ordem de serviço '{workOrder.Code}': {ex.Message}", ex);
                    }
                }
            }
        }

        public void Delete(WorkOrder workOrder)
        {
            workOrder.Valid();

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    session.Delete(workOrder);
                    session.Flush();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível deletar a ordem de serviço '{workOrder.Code}': {ex.Message}", ex);
                }
            }
        }

        public IList<WorkOrder> GetAll()
        {
            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    return session.QueryOver<WorkOrder>().List();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível obter todas as ordens de serviços: {ex.Message}", ex);
                }
            }
        }

        public WorkOrder GetByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new RepositoryException("Código da ordem de serviço não pode estar vazia.");
            }

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                try
                {
                    return (from w in session.Query<WorkOrder>() where w.Code == code select w).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException($"Não foi possível obter todas as ordens de serviços: {ex.Message}", ex);
                }
            }
        }

        public void Update(WorkOrder workOrder)
        {
            workOrder.Valid();

            using (var session = NHibernateSessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(workOrder);
                        transaction.Commit();
                    }
                    catch (ConstraintViolationException ex)
                    {
                        transaction.Rollback();
                        throw new RepositoryException($"Ordem de serviço '{workOrder.Code}' já existe.", ex);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new RepositoryException($"Não foi possível adicionar a ordem de serviço '{workOrder.Code}': {ex.Message}", ex);
                    }
                }
            }
        }
    }
}
