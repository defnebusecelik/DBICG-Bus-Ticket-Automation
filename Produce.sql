CREATE OR REPLACE PROCEDURE findMostExpensiveTrip()
LANGUAGE plpgsql
AS $$
DECLARE
    maxPrice INTEGER;
    maxTripID VARCHAR(8);
    maxBusID VARCHAR(8);
    maxTSource VARCHAR(25);
    maxTDestination VARCHAR(25);
    maxTDate DATE;
    maxSTime TIME;
    maxDTime TIME;
    maxCompanyName VARCHAR(25);
BEGIN

    SELECT INTO maxPrice, maxTripID, maxBusID, maxTSource, maxTDestination, maxTDate, maxSTime, maxDTime, maxCompanyName
        MAX(price), tripID, busID, tSource, tDestination, tDate, sTime, dTime, companyName
    FROM Trip
    GROUP BY tripID, busID, tSource, tDestination, tDate, sTime, dTime, companyName
    ORDER BY MAX(price) DESC
    LIMIT 1;

    RAISE NOTICE 'En yüksek fiyatlı sefer:';
    RAISE NOTICE 'TripID: %, BusID: %, Source: %, Destination: %, Date: %, Start Time: %, Departure Time: %, Price: %, Company: %',
                 maxTripID, maxBusID, maxTSource, maxTDestination, maxTDate, maxSTime, maxDTime, maxPrice, maxCompanyName;
END;
$$;

CALL findMostExpensiveTrip();

--******************************************************************************************************************************************

CREATE OR REPLACE PROCEDURE findShortestDurationTrip()
LANGUAGE plpgsql
AS $$
DECLARE
    minDuration INTERVAL;
    shortestTripID VARCHAR(8);
    shortestBusID VARCHAR(8);
    shortestTSource VARCHAR(25);
    shortestTDestination VARCHAR(25);
    shortestTDate DATE;
    shortestSTime TIME;
    shortestDTime TIME;
    shortestCompanyName VARCHAR(25);
BEGIN
    SELECT INTO minDuration, shortestTripID, shortestBusID, shortestTSource, shortestTDestination, shortestTDate, shortestSTime, shortestDTime, shortestCompanyName
        MIN(dTime - sTime), tripID, busID, tSource, tDestination, tDate, sTime, dTime, companyName
    FROM Trip
    GROUP BY tripID, busID, tSource, tDestination, tDate, sTime, dTime, companyName
    ORDER BY MIN(dTime - sTime) ASC
    LIMIT 1;

    RAISE NOTICE 'En kısa süren sefer:';
    RAISE NOTICE 'TripID: %, BusID: %, Source: %, Destination: %, Date: %, Start Time: %, Departure Time: %, Duration: %, Company: %',
                 shortestTripID, shortestBusID, shortestTSource, shortestTDestination, shortestTDate, shortestSTime, shortestDTime, minDuration, shortestCompanyName;
END;
$$;

CALL findShortestDurationTrip();
