using BusinessAccessLayer.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Iterators
{
    public class ProductCollection :IteratorAggregate
    {

        List<ProductDTO> _collection = new List<ProductDTO>();
        bool _direction = false;

        public void ReverseDirection()
        {
            _direction = !_direction;
        }
        public List<ProductDTO> getItems()
        {
            return _collection;
        }

        public void AddItem(ProductDTO item)
        {
            this._collection.Add(item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new AlphabeticalOrderIterator(this, _direction);
        }
    }
}
