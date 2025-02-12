DECLARE @CustomerId INT = 72;

SELECT 
    orderid As 'Orderid', 
    requireddate As 'Requireddate',  
    shippeddate As 'Shippeddate',  
    shipname As 'Shipname',  
    shipaddress As 'Shipaddress',  
    shipcity As 'Shipcity' 
FROM Sales.Orders
WHERE custid = @CustomerId;

