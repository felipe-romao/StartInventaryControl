using NUnit.Framework;
using StartInventaryControl.Data;
using StartInventaryControl.Repository.NHibernate;
using StartInventaryControl.UnitTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace StartInventaryControl.UnitTest
{
    public class Test
    {
        //[Test]
        public void Add()
        {
            var repository = new ProductEntryRepository();
            var prodRepository = new ProductRepository();

            var productEntry = ProductEntryHelperTest.CreateProductEntryValid();
            productEntry.Code = Guid.NewGuid().ToString();


            repository.Add(productEntry);


            //var transactionOptions = new TransactionOptions
            //{
            //    IsolationLevel = IsolationLevel.Serializable,
            //};


            //using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            //{
            //    repository.Add(productEntry);

 
            //    scope.Complete();
            //}
        }
    }
}
