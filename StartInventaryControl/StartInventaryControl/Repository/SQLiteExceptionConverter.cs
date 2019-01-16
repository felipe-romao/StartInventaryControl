using NHibernate.Exceptions;
using System;
using System.Data.SQLite;

namespace StartInventaryControl.Repository
{
    public class SQLiteExceptionConverter : ISQLExceptionConverter
    {
        public Exception Convert(AdoExceptionContextInfo exInfo)
        {
            var sqlException = ADOExceptionHelper.ExtractDbException(exInfo.SqlException) as SQLiteException;

            if (sqlException != null)
            {
                switch (sqlException.ErrorCode)
                {
                    case 19:
                        return new ConstraintViolationException(exInfo.Message, sqlException.InnerException, exInfo.Sql, null);
                }
            }

            return SQLStateConverter.HandledNonSpecificException(exInfo.SqlException, exInfo.Message, exInfo.Sql);
        }
    }
}
