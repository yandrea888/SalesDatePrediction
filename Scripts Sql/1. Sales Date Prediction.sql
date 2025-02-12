WITH OrderIntervals AS (
    SELECT 
        o.custid,
        DATEDIFF(DAY, 
                 LAG(o.orderdate) OVER (PARTITION BY o.custid ORDER BY o.orderdate), 
                 o.orderdate
        ) AS IntervalDays
    FROM 
        Sales.Orders o
),
AverageIntervals AS (
    SELECT 
        oi.custid,
        AVG(oi.IntervalDays) AS AvgIntervalDays
    FROM 
        OrderIntervals oi
    WHERE 
        oi.IntervalDays IS NOT NULL
    GROUP BY 
        oi.custid
),
LastOrders AS (
    SELECT 
        o.custid,
        MAX(o.orderdate) AS LastOrderDate
    FROM 
        Sales.Orders o
    GROUP BY 
        o.custid
)
SELECT 
    c.companyname AS CustomerName,
    lo.LastOrderDate,
    DATEADD(DAY, ISNULL(ai.AvgIntervalDays, 0), lo.LastOrderDate) AS NextPredictedOrder
FROM 
    Sales.Customers c
JOIN 
    LastOrders lo ON c.custid = lo.custid
LEFT JOIN 
    AverageIntervals ai ON c.custid = ai.custid
ORDER BY 
    c.companyname;

