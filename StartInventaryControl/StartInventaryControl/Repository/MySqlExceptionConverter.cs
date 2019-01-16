using MySql.Data.MySqlClient;
using NHibernate.Exceptions;
using System;

namespace StartInventaryControl.Repository
{
    public class MySqlExceptionConverter : ISQLExceptionConverter
    {
        public Exception Convert(AdoExceptionContextInfo exInfo)
        {
            var sqlException = ADOExceptionHelper.ExtractDbException(exInfo.SqlException) as MySqlException;

            if (sqlException != null)
            {
                switch ((MySqlErrorCode)sqlException.Number)
                {
                    case MySqlErrorCode.DuplicateKeyEntry:
                        return new ConstraintViolationException(exInfo.Message, sqlException.InnerException, exInfo.Sql, null);
                }
            }

            return SQLStateConverter.HandledNonSpecificException(exInfo.SqlException, exInfo.Message, exInfo.Sql);
        }
    }
}
