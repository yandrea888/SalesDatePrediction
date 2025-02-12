
DECLARE @NewOrderId INT;


INSERT INTO Sales.Orders (
    empid, 
    shipperid, 
    shipname, 
    shipaddress, 
    shipcity, 
    orderdate, 
    requireddate, 
    shippeddate, 
    freight, 
    shipcountry
)
VALUES (
    1,                
    2,                
    'Sample Shipname',
    '123 Main St',    
    'Sample City',    
    GETDATE(),        
    DATEADD(DAY, 7, GETDATE()), 
    NULL,             
    50.00,            
    'Sample Country'  
);

SET @NewOrderId = SCOPE_IDENTITY();


INSERT INTO Sales.OrderDetails (
    orderid, 
    productid, 
    unitprice, 
    qty, 
    discount
)
VALUES 
    (@NewOrderId, 1, 20.00, 2, 0.05),  
    (@NewOrderId, 2, 15.00, 1, 0.00);  


SELECT @NewOrderId AS NewOrderId;
