using System.Collections.Generic;

namespace DataAccessLayer.Enteties
{
    public abstract class ShippingDetail
    {

    }
    public class ShippingNameDetails : ShippingDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class SippingAddressDetails : ShippingDetail {
        public string Address { get; set; }
    }

    public class ShippingProductDetails : ShippingDetail
    {
        public int Product_id { get; set; }
    }

    public abstract class AbstractShipping
    {
        public AbstractShipping()
        {
            CreateDetails();
        }

        //Factory method
        public abstract void CreateDetails();

        public List<ShippingDetail> shippingDetails { get; } = new List<ShippingDetail>();

    }

    public class Shipping : AbstractShipping
    {
        ShippingNameDetails _name = new ShippingNameDetails();
        ShippingProductDetails _product = new ShippingProductDetails();
        SippingAddressDetails _address = new SippingAddressDetails();

        public string FirstName { get { return _name.FirstName; } set { _name.FirstName = value; } }
        public string LastName { get { return _name.LastName; } set { _name.LastName = value; } }
        public string Address { get { return _address.Address; } set { _address.Address = value; } }
        public int Product_id { get { return _product.Product_id; } set { _product.Product_id = value; } }

        public override void CreateDetails()
        {
            shippingDetails.Add(_name);
            shippingDetails.Add(_product);
            shippingDetails.Add(_address);
        }

    }

}
