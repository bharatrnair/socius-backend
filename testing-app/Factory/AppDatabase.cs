using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing_app.Data;

namespace testing_app.Factory
{
     public interface IAppDatabase
    {
        testing_appContext Db { get; }
    }

    class AppDatabase : IAppDatabase
    {
        public testing_appContext Db
        {
            get
            {
                return new testing_appContext();
            }

        }
    }
}
