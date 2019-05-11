N-tier architecture would involve dividing an application into three different tiers.  These would be the
    -logic tier,
    -the presentation tier, and
    -the data tier.
	
This app is a simple example of NTier application on C#.
App shows creation of the shipping in some kind of monitoring system.
So there are Data Layer which connects to MySql DB, Business Logic Layer and User interface.
If you want to try this app don't forget to change connection string for DB.


Unit test are present. 
Three tests for functionality and one mocking test for ProductRepo;

Patterns inside :
-Singleton for ServiceShippings and ServiceProducts;
-Facade for BusinessLayer;
-Adapter class for JSON->ShippingService.MakeShipping(Shipping s)