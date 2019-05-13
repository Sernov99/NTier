N-tier architecture would involve dividing an application into three different tiers.  These would be the
    -logic tier,
    -the presentation tier,
    -the data tier.
	
This app is an example of NTier application on C#.
App shows creation of the shipping in some kind of monitoring system.
So there are Data Layer which connects to MySql DB, Business Logic Layer and User interface.

Unit test are present. (+Moq)

Patterns inside :
-Singleton for ServiceShippings and ServiceProducts;
-Factory for Shipping in DAL;
--------------------------------------------------------------
-Facade for BusinessLayer;
-Adapter class for JSON->ShippingService.MakeShipping(Shipping s)
--------------------------------------------------------------
-Iterator for Product_List(can access trough facade of BLL)