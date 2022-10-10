using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonExercise
{
    internal interface IProductRepository
    {

        public IEnumerable<Products> GetAllProducts();

    }
}
