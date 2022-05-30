using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_app.Factory
{
    public interface IHeading
    {
        string Value { get; }
    }

    class Heading : IHeadings
    {

        public string Value
        {
            get
            {
                return "This is a title";
             }
        }
    }
}
